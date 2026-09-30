-- =========================================================
-- BASE DE DATOS: Biblioteca Musical
-- =========================================================

CREATE DATABASE BibliotecaMusical;
GO

USE BibliotecaMusical;
GO


-- =========================================================
-- 1. USUARIOS
-- =========================================================

CREATE TABLE Usuarios (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100) NOT NULL,
    correo NVARCHAR(150) NOT NULL UNIQUE,
    fecha_registro DATETIME2 NOT NULL DEFAULT GETDATE()
);
GO


-- =========================================================
-- 2. ARTISTAS
-- =========================================================

CREATE TABLE Artistas (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(150) NOT NULL,
    nacionalidad NVARCHAR(100),
    fecha_inicio DATE,
    biografia NVARCHAR(MAX)
);
GO


-- =========================================================
-- 3. COMPOSITORES
-- =========================================================

CREATE TABLE Compositores (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100),
    nacionalidad NVARCHAR(100),
    fecha_nacimiento DATE
);
GO


-- =========================================================
-- 4. SELLOS DISCOGRÁFICOS
-- =========================================================

CREATE TABLE Sellos_Discograficos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(150) NOT NULL,
    pais NVARCHAR(100),
    fecha_fundacion DATE,
    sitio_web NVARCHAR(255)
);
GO


-- =========================================================
-- 5. ÁLBUMES
-- =========================================================

CREATE TABLE Albumes (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    titulo NVARCHAR(200) NOT NULL,
    fecha_lanzamiento DATE,
    portada NVARCHAR(500)
);
GO


-- =========================================================
-- 6. GÉNEROS
-- =========================================================

CREATE TABLE Generos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL UNIQUE,
    descripcion NVARCHAR(500),
    popularidad INT NOT NULL DEFAULT 0,

    CONSTRAINT CK_Generos_Popularidad
        CHECK (popularidad BETWEEN 0 AND 100)
);
GO


-- =========================================================
-- 7. IDIOMAS
-- =========================================================

CREATE TABLE Idiomas (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    codigo NVARCHAR(10) NOT NULL UNIQUE,
    descripcion NVARCHAR(500),
    activo BIT NOT NULL DEFAULT 1
);
GO


-- =========================================================
-- 8. CANCIONES
-- =========================================================

CREATE TABLE Canciones (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    titulo NVARCHAR(200) NOT NULL,
    duracion TIME(0) NOT NULL,
    numero_pista INT,
    id_album INT NULL,

    CONSTRAINT FK_Canciones_Albumes
        FOREIGN KEY (id_album)
        REFERENCES Albumes(ID),

    CONSTRAINT CK_Canciones_NumeroPista
        CHECK (numero_pista IS NULL OR numero_pista > 0)
);
GO


-- =========================================================
-- 9. SUSCRIPCIONES
-- =========================================================

CREATE TABLE Suscripciones (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    tipo_plan NVARCHAR(50) NOT NULL,
    fecha_inicio DATE NOT NULL,
    fecha_fin DATE,

    CONSTRAINT FK_Suscripciones_Usuarios
        FOREIGN KEY (id_usuario)
        REFERENCES Usuarios(ID),

    CONSTRAINT CK_Suscripciones_Fechas
        CHECK (fecha_fin IS NULL OR fecha_fin >= fecha_inicio)
);
GO


-- =========================================================
-- 10. LISTAS DE REPRODUCCIONES
-- =========================================================

CREATE TABLE Listas_Reproducciones (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    nombre NVARCHAR(150) NOT NULL,
    fecha_creacion DATETIME2 NOT NULL DEFAULT GETDATE(),
    privacidad NVARCHAR(20) NOT NULL DEFAULT 'Privada',
    id_usuario INT NOT NULL,

    CONSTRAINT FK_ListasReproducciones_Usuarios
        FOREIGN KEY (id_usuario)
        REFERENCES Usuarios(ID),

    CONSTRAINT CK_ListasReproducciones_Privacidad
        CHECK (privacidad IN ('Publica', 'Privada'))
);
GO


-- =========================================================
-- 11. FAVORITOS
-- =========================================================

CREATE TABLE Favoritos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    fecha_marcado DATETIME2 NOT NULL DEFAULT GETDATE(),
    activo BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_Favoritos_Usuarios
        FOREIGN KEY (id_usuario)
        REFERENCES Usuarios(ID)
);
GO


-- =========================================================
-- 12. REPRODUCCIONES
-- =========================================================

CREATE TABLE Reproducciones (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    id_cancion INT NOT NULL,
    fecha_hora DATETIME2 NOT NULL DEFAULT GETDATE(),
    duracion TIME(0),

    CONSTRAINT FK_Reproducciones_Usuarios
        FOREIGN KEY (id_usuario)
        REFERENCES Usuarios(ID),

    CONSTRAINT FK_Reproducciones_Canciones
        FOREIGN KEY (id_cancion)
        REFERENCES Canciones(ID)
);
GO


-- =========================================================
-- 13. LR_CANCIONES
-- Relación entre Listas_Reproducciones y Canciones
-- =========================================================

CREATE TABLE LR_Canciones (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    id_listas_reproduccion INT NOT NULL,
    id_cancion INT NOT NULL,

    CONSTRAINT FK_LRCanciones_Listas
        FOREIGN KEY (id_listas_reproduccion)
        REFERENCES Listas_Reproducciones(ID),

    CONSTRAINT FK_LRCanciones_Canciones
        FOREIGN KEY (id_cancion)
        REFERENCES Canciones(ID),

    CONSTRAINT UQ_LRCanciones
        UNIQUE (id_listas_reproduccion, id_cancion)
);
GO


-- =========================================================
-- 14. FAVORITOS - CANCIONES
-- =========================================================

CREATE TABLE Fav_Canciones (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    id_favorito INT NOT NULL,
    id_cancion INT NOT NULL,

    CONSTRAINT FK_FavCanciones_Favoritos
        FOREIGN KEY (id_favorito)
        REFERENCES Favoritos(ID),

    CONSTRAINT FK_FavCanciones_Canciones
        FOREIGN KEY (id_cancion)
        REFERENCES Canciones(ID),

    CONSTRAINT UQ_FavCanciones
        UNIQUE (id_favorito, id_cancion)
);
GO


-- =========================================================
-- 15. LISTAS_CANCIONES
-- =========================================================

CREATE TABLE Listas_Canciones (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    id_cancion INT NOT NULL,
    posicion INT NOT NULL,
    fecha_agregada DATETIME2 NOT NULL DEFAULT GETDATE(),
    favorita BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_ListasCanciones_Canciones
        FOREIGN KEY (id_cancion)
        REFERENCES Canciones(ID),

    CONSTRAINT CK_ListasCanciones_Posicion
        CHECK (posicion > 0)
);
GO


-- =========================================================
-- 16. ARTISTAS - SELLOS
-- =========================================================

CREATE TABLE Artistas_Sellos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    id_artista INT NOT NULL,
    id_sello INT NOT NULL,
    fecha_inicio DATE,
    fecha_fin DATE,
    contrato BIT NOT NULL DEFAULT 1,

    CONSTRAINT FK_ArtistasSellos_Artistas
        FOREIGN KEY (id_artista)
        REFERENCES Artistas(ID),

    CONSTRAINT FK_ArtistasSellos_Sellos
        FOREIGN KEY (id_sello)
        REFERENCES Sellos_Discograficos(ID),

    CONSTRAINT UQ_ArtistasSellos
        UNIQUE (id_artista, id_sello),

    CONSTRAINT CK_ArtistasSellos_Fechas
        CHECK (fecha_fin IS NULL OR fecha_inicio IS NULL OR fecha_fin >= fecha_inicio)
);
GO


-- =========================================================
-- 17. ÁLBUMES - ARTISTAS
-- =========================================================

CREATE TABLE Albumes_Artistas (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    id_artista INT NOT NULL,
    id_album INT NOT NULL,

    CONSTRAINT FK_AlbumesArtistas_Artistas
        FOREIGN KEY (id_artista)
        REFERENCES Artistas(ID),

    CONSTRAINT FK_AlbumesArtistas_Albumes
        FOREIGN KEY (id_album)
        REFERENCES Albumes(ID),

    CONSTRAINT UQ_AlbumesArtistas
        UNIQUE (id_artista, id_album)
);
GO


-- =========================================================
-- 18. CANCIONES - COMPOSITORES
-- =========================================================

CREATE TABLE Canciones_Compositores (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    id_cancion INT NOT NULL,
    id_compositor INT NOT NULL,
    porcentaje_autoria DECIMAL(5,2),
    fecha_registro DATETIME2 NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_CancionesCompositores_Canciones
        FOREIGN KEY (id_cancion)
        REFERENCES Canciones(ID),

    CONSTRAINT FK_CancionesCompositores_Compositores
        FOREIGN KEY (id_compositor)
        REFERENCES Compositores(ID),

    CONSTRAINT UQ_CancionesCompositores
        UNIQUE (id_cancion, id_compositor),

    CONSTRAINT CK_CancionesCompositores_Porcentaje
        CHECK (
            porcentaje_autoria IS NULL
            OR porcentaje_autoria BETWEEN 0 AND 100
        )
);
GO


-- =========================================================
-- 19. CANCIONES - GÉNEROS
-- =========================================================

CREATE TABLE Canciones_Generos (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    id_cancion INT NOT NULL,
    id_genero INT NOT NULL,
    principal BIT NOT NULL DEFAULT 0,

    CONSTRAINT FK_CancionesGeneros_Canciones
        FOREIGN KEY (id_cancion)
        REFERENCES Canciones(ID),

    CONSTRAINT FK_CancionesGeneros_Generos
        FOREIGN KEY (id_genero)
        REFERENCES Generos(ID),

    CONSTRAINT UQ_CancionesGeneros
        UNIQUE (id_cancion, id_genero)
);
GO


-- =========================================================
-- 20. CANCIONES - IDIOMAS
-- =========================================================

CREATE TABLE Canciones_Idiomas (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    id_cancion INT NOT NULL,
    id_idioma INT NOT NULL,
    idioma_principal BIT NOT NULL DEFAULT 0,
    porcentaje DECIMAL(5,2),
    fecha_registro DATETIME2 NOT NULL DEFAULT GETDATE(),

    CONSTRAINT FK_CancionesIdiomas_Canciones
        FOREIGN KEY (id_cancion)
        REFERENCES Canciones(ID),

    CONSTRAINT FK_CancionesIdiomas_Idiomas
        FOREIGN KEY (id_idioma)
        REFERENCES Idiomas(ID),

    CONSTRAINT UQ_CancionesIdiomas
        UNIQUE (id_cancion, id_idioma),

    CONSTRAINT CK_CancionesIdiomas_Porcentaje
        CHECK (
            porcentaje IS NULL
            OR porcentaje BETWEEN 0 AND 100
        )
);
GO
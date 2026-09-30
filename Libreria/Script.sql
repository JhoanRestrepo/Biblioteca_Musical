CREATE DATABASE bd_Biblioteca_Musical;
GO
USE bd_Biblioteca_Musical;
GO
-- 1. Usuarios
CREATE TABLE [Usuarios] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(100) NULL,
    [Apellido] NVARCHAR(100) NULL,
    [Correo] NVARCHAR(150) NULL,
    [Fecha_registro] SMALLDATETIME NOT NULL
);

-- 2. Artistas
CREATE TABLE [Artistas] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(150) NULL,
    [Nacionalidad] NVARCHAR(100) NULL,
    [Fecha_Inicio] SMALLDATETIME NOT NULL,
    [Biografia] NVARCHAR(MAX) NULL
);

-- 3. Compositores
CREATE TABLE [Compositores] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(100) NULL,
    [Apellido] NVARCHAR(100) NULL,
    [Nacionalidad] NVARCHAR(100) NULL,
    [Fecha_Nacimiento] SMALLDATETIME NULL
);

-- 4. Sellos discográficos
CREATE TABLE [Sellos_Discograficos] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(150) NULL,
    [Pais] NVARCHAR(100) NULL,
    [Fecha_Fundacion] SMALLDATETIME NULL,
    [Sitio_Web] NVARCHAR(255) NULL
);

-- 5. Álbumes
CREATE TABLE [Albumes] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Titulo] NVARCHAR(150) NULL,
    [Fecha_Lanzamiento] SMALLDATETIME NOT NULL,
    [Portada] NVARCHAR(255) NULL
);

-- 6. Géneros
CREATE TABLE [Generos] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(100) NULL,
    [Descripcion] NVARCHAR(500) NULL,
    [popularidad] INT NOT NULL
);

-- 7. Idiomas
CREATE TABLE [Idiomas] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(100) NULL,
    [Codigo] NVARCHAR(20) NULL,
    [Descripcion] NVARCHAR(500) NULL,
    [Activo] BIT NOT NULL
);

-- 8. Canciones
CREATE TABLE [Canciones] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Titulo] NVARCHAR(255) NULL,
    [Duracion] TIME NOT NULL,
    [Numero_Pista] INT NOT NULL,
    [Album] INT NOT NULL,
    FOREIGN KEY ([Album]) REFERENCES [Albumes]([Id])
);

-- 9. Álbumes y artistas
CREATE TABLE [Albumes_Artistas] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Artista] INT NOT NULL,
    [Album] INT NOT NULL,
    FOREIGN KEY ([Artista]) REFERENCES [Artistas]([Id]),
    FOREIGN KEY ([Album]) REFERENCES [Albumes]([Id])
);

-- 10. Artistas y sellos discográficos
CREATE TABLE [Artistas_Sellos] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Artista] INT NOT NULL,
    [Sello_Discografico] INT NOT NULL,
    [Fecha_Inicio] SMALLDATETIME NULL,
    [Fecha_Fin] SMALLDATETIME NULL,
    [Contrato] NVARCHAR(255) NULL,
    FOREIGN KEY ([Artista]) REFERENCES [Artistas]([Id]),
    FOREIGN KEY ([Sello_Discografico]) REFERENCES [Sellos_Discograficos]([Id])
);

-- 11. Canciones y compositores
CREATE TABLE [Canciones_Compositores] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Cancion] INT NOT NULL,
    [Compositor] INT NOT NULL,
    [Porcentaje_Autoria] DECIMAL(5,2) NULL,
    [Fecha_Registro] SMALLDATETIME NULL,
    FOREIGN KEY ([Cancion]) REFERENCES [Canciones]([Id]),
    FOREIGN KEY ([Compositor]) REFERENCES [Compositores]([Id])
);

-- 12. Canciones y géneros
CREATE TABLE [Canciones_Generos] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Cancion] INT NOT NULL,
    [Genero] INT NOT NULL,
    [Principal] BIT NOT NULL,
    FOREIGN KEY ([Cancion]) REFERENCES [Canciones]([Id]),
    FOREIGN KEY ([Genero]) REFERENCES [Generos]([Id])
);

-- 13. Canciones e idiomas
CREATE TABLE [Canciones_Idiomas] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Cancion] INT NOT NULL,
    [Idioma] INT NOT NULL,
    [Idioma_Principal] NVARCHAR(100) NULL,
    [Porcentaje] DECIMAL(5,2) NULL,
    [Fecha_Registro] SMALLDATETIME NULL,
    FOREIGN KEY ([Cancion]) REFERENCES [Canciones]([Id]),
    FOREIGN KEY ([Idioma]) REFERENCES [Idiomas]([Id])
);

-- 14. Suscripciones
CREATE TABLE [Suscripciones] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Usuario] INT NOT NULL,
    [tipo_plan] NVARCHAR(50) NULL,
    [fecha_inicio] SMALLDATETIME NULL,
    [fecha_fin] SMALLDATETIME NULL,
    FOREIGN KEY ([Usuario]) REFERENCES [Usuarios]([Id])
);

-- 15. Listas de reproducción
CREATE TABLE [Listas_Reproducciones] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [nombre] NVARCHAR(100) NULL,
    [fecha_creacion] SMALLDATETIME NULL,
    [privacidad] NVARCHAR(50) NULL,
    [usuario] INT NOT NULL,
    FOREIGN KEY ([usuario]) REFERENCES [Usuarios]([Id])
);

-- 16. Listas y canciones (tabla LR_Canciones del diagrama)
CREATE TABLE [LR_Canciones] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Listas_reproduccion] INT NOT NULL,
    [Cancion] INT NOT NULL,
    FOREIGN KEY ([Listas_reproduccion])
        REFERENCES [Listas_Reproducciones]([Id]),
    FOREIGN KEY ([Cancion]) REFERENCES [Canciones]([Id])
);

-- 17. Listas y canciones con posición (tabla Listas_Canciones)
CREATE TABLE [Listas_Canciones] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Lista_reproduccion] INT NOT NULL,
    [Cancion] INT NOT NULL,
    [posicion] INT NOT NULL,
    [fecha_agregada] SMALLDATETIME NOT NULL,
    [favorita] BIT NOT NULL,
    FOREIGN KEY ([Lista_reproduccion])
        REFERENCES [Listas_Reproducciones]([Id]),
    FOREIGN KEY ([Cancion]) REFERENCES [Canciones]([Id])
);

-- 18. Favoritos
CREATE TABLE [Favoritos] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Usuario] INT NOT NULL,
    [fecha_marcado] SMALLDATETIME NULL,
    [activo] BIT NOT NULL,
    FOREIGN KEY ([Usuario]) REFERENCES [Usuarios]([Id])
);

-- 19. Canciones guardadas en favoritos
CREATE TABLE [Fav_Canciones] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Favorito] INT NOT NULL,
    [Cancion] INT NOT NULL,
    FOREIGN KEY ([Favorito]) REFERENCES [Favoritos]([Id]),
    FOREIGN KEY ([Cancion]) REFERENCES [Canciones]([Id])
);

    CONSTRAINT FK_Canciones_Generos_Genero
        FOREIGN KEY (Genero)
        REFERENCES Generos(Id)
);

CREATE TABLE Canciones_Idiomas
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Cancion INT NOT NULL,
    Idioma INT NOT NULL,
    Idioma_Principal VARCHAR(255) NULL,
    Porcentaje_Idioma FLOAT NULL,
    Fecha_Registro DATETIME NULL,

    CONSTRAINT FK_Canciones_Idiomas_Cancion
        FOREIGN KEY (Cancion)
        REFERENCES Canciones(Id),

    CONSTRAINT FK_Canciones_Idiomas_Idioma
        FOREIGN KEY (Idioma)
        REFERENCES Idiomas(Id)
);

CREATE TABLE Compositores
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NULL,
    Apellido VARCHAR(100) NULL,
    Nacionalidad VARCHAR(100) NULL,
    Fecha_Nacimiento DATETIME NULL
);

CREATE TABLE Fav_Canciones
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Id_Favorito INT NOT NULL,
    Id_Cancion INT NOT NULL,

    CONSTRAINT FK_Fav_Canciones_Favorito
        FOREIGN KEY (Id_Favorito)
        REFERENCES Favoritos(Id),

    CONSTRAINT FK_Fav_Canciones_Cancion
        FOREIGN KEY (Id_Cancion)
        REFERENCES Canciones(Id)
);

-- 6. Géneros
INSERT INTO [Generos] ([Nombre], [Descripcion], [popularidad])
VALUES
('Rock', 'Género de música rock.', 80),
('Salsa', 'Género musical bailable.', 75),
('Reguetón', 'Género urbano latino.', 90);

-- 7. Idiomas
INSERT INTO [Idiomas] ([Nombre], [Codigo], [Descripcion], [Activo])
VALUES
('Español', 'es', 'Idioma español.', 1),
('Inglés', 'en', 'Idioma inglés.', 1),
('Francés', 'fr', 'Idioma francés.', 1);

-- 8. Canciones
-- Album debe tener los IDs 1, 2 y 3 en Albumes.
INSERT INTO [Canciones] ([Titulo], [Duracion], [Numero_Pista], [Album])
VALUES
('Canción uno', '00:03:30', 1, 1),
('Canción dos', '00:04:10', 1, 2),
('Canción tres', '00:02:55', 1, 3);

-- 9. Álbumes y artistas
INSERT INTO [Albumes_Artistas] ([Artista], [Album])
VALUES
(1, 1),
(2, 2),
(3, 3);

CREATE TABLE Listas_Reproducciones
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NULL,
    Fecha_Creacion DATETIME NULL,
    Privacidad VARCHAR(50) NULL,
    Id_Usuario INT NOT NULL,

    CONSTRAINT FK_Listas_Reproducciones_Usuario
        FOREIGN KEY (Id_Usuario)
        REFERENCES Usuarios(Id)
);

CREATE TABLE LR_Canciones
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Id_Listas_Reproduccion INT NOT NULL,
    Id_Cancion INT NOT NULL,

    CONSTRAINT FK_LR_Canciones_Lista_Reproduccion
        FOREIGN KEY (Id_Listas_Reproduccion)
        REFERENCES Listas_Reproducciones(Id),

    CONSTRAINT FK_LR_Canciones_Cancion
        FOREIGN KEY (Id_Cancion)
        REFERENCES Canciones(Id)
);

CREATE TABLE Reproducciones
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Id_Usuario INT NOT NULL,
    Id_Cancion INT NOT NULL,
    Fecha_Hora DATETIME NULL,
    Duracion TIME NULL,

-- 16. Listas y canciones (LR_Canciones)
INSERT INTO [LR_Canciones] ([Listas_reproduccion], [Cancion])
VALUES
(1, 1),
(2, 2),
(3, 3);

    CONSTRAINT FK_Reproducciones_Cancion
        FOREIGN KEY (Id_Cancion)
        REFERENCES Canciones(Id)
);

CREATE TABLE Sellos_Discograficos
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(150) NULL,
    Pais VARCHAR(100) NULL,
    Fecha_Fundacion DATETIME NULL,
    Sitio_Web VARCHAR(255) NULL
);

-- 19. Canciones guardadas en favoritos
INSERT INTO [Fav_Canciones] ([Favorito], [Cancion])
VALUES
(1, 1),
(2, 2),
(3, 3);

-- 20. Reproducciones
INSERT INTO [Reproducciones] ([Usuario], [cancion], [fecha_hora], [duracion])
VALUES
(1, 1, '2026-09-29 14:30', '00:03:30'),
(2, 2, '2026-09-29 15:10', '00:04:10'),
(3, 3, '2026-09-29 16:05', '00:02:55');
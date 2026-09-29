CREATE DATABASE bd_Biblioteca_Musical;
GO
USE  bd_Biblioteca_Musical;
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

-- 3. Albumnes
CREATE TABLE [Albumes] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Titulo] NVARCHAR(150) NULL,
    [Fecha_Lanzamiento] SMALLDATETIME NOT NULL,
    [Portada] NVARCHAR(255) NULL
);

-- 4. Albumnes_Artistas
CREATE TABLE [Albumes_Artistas] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Artista] INT NOT NULL,
    [Album] INT NOT NULL,
    FOREIGN KEY ([Artista]) REFERENCES [Artistas]([Id]),
    FOREIGN KEY ([Album]) REFERENCES [Albumes]([Id])
);

--CREATE TABLE Artistas_Sellos0
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Artista INT NOT NULL,
    Sello_Discografico INT NOT NULL,
    Fecha_Inicio DATETIME NULL,
    Fecha_Fin DATETIME NULL,
    Contrato VARCHAR(255) NULL,

    CONSTRAINT FK_Artistas_Sellos_Artistas
        FOREIGN KEY (Artista)
        REFERENCES Artistas(Id),

    CONSTRAINT FK_Artistas_Sellos_Sellos_Discograficos
        FOREIGN KEY (Sello_Discografico)
        REFERENCES Sellos_Discograficos(Id)
);

CREATE TABLE Canciones
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo VARCHAR(255) NULL,
    Duracion TIME NOT NULL,
    Numero_Pista INT NOT NULL,
    Album INT NOT NULL,

    CONSTRAINT FK_Canciones_Albumes
        FOREIGN KEY (Album)
        REFERENCES Albumes(Id)
);

CREATE TABLE Canciones_Compositores
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Cancion INT NOT NULL,
    Compositor INT NOT NULL,

    CONSTRAINT FK_Canciones_Compositores_Cancion
        FOREIGN KEY (Cancion)
        REFERENCES Canciones(Id),

    CONSTRAINT FK_Canciones_Compositores_Compositor
        FOREIGN KEY (Compositor)
        REFERENCES Compositores(Id)
);

CREATE TABLE Canciones_Generos
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Cancion INT NOT NULL,
    Genero INT NOT NULL,
    Principal BIT NULL,

    CONSTRAINT FK_Canciones_Generos_Cancion
        FOREIGN KEY (Cancion)
        REFERENCES Canciones(Id),

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

CREATE TABLE Favoritos
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Id_Usuario INT NOT NULL,
    Fecha_Marcado DATETIME NULL,
    Activo BIT NOT NULL,

    CONSTRAINT FK_Favoritos_Usuario
        FOREIGN KEY (Id_Usuario)
        REFERENCES Usuarios(Id)
);

CREATE TABLE Generos
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NULL,
    Descripcion VARCHAR(500) NULL,
    popularidad INT NOT NULL
);

CREATE TABLE Idiomas
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NULL,
    Codigo VARCHAR(20) NULL,
    Descripción VARCHAR(500) NULL,
    Activo BIT NULL
);

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

    CONSTRAINT FK_Reproducciones_Usuario
        FOREIGN KEY (Id_Usuario)
        REFERENCES Usuarios(Id),

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

CREATE TABLE Suscripciones
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Id_Usuario INT NOT NULL,
    Tipo_Plan VARCHAR(50) NULL,
    Fecha_Inicio DATETIME NULL,
    Fecha_Fin DATETIME NULL,

    CONSTRAINT FK_Suscripciones_Usuario
        FOREIGN KEY (Id_Usuario)
        REFERENCES Usuarios(Id)
);

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

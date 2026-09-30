CREATE DATABASE Biblioteca_Musical_db
GO
USE Biblioteca_Musical_db

CREATE TABLE Albumes (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Titulo] NVARCHAR(100) NOT NULL,
	[Fecha_Lanzamiento] DATE,
	[Portada] NVARCHAR(20),
);

CREATE TABLE Albumes_Artistas (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Artista] INT FOREIGN KEY REFERENCES Artistas([Id]),
	[Album] INT FOREIGN KEY REFERENCES Albumes([Id])
);

CREATE TABLE Artistas (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Nombre] NVARCHAR(100) NOT NULL,
	[Nacionalidad] NVARCHAR(50),
	[Fecha_Inicio] DATE,
	[Biografia] NVARCHAR(200)
);

CREATE TABLE Artistas_Sellos (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Artista] INT FOREIGN KEY REFERENCES Artistas([Id]),
	[Sello] INT FOREIGN KEY REFERENCES Sellos([Id]),
	[Fecha_Inicio] DATE,
	[Fecha_Fin] DATE,
	[Contrato] NVARCHAR(100)
);

CREATE TABLE Canciones (
	[Id] INT PRIMARY KEY IDENTITY(1,1),
	[Titulo] NVARCHAR(100) NOT NULL,
	[Duracion] TIME,
	[Album] INT FOREIGN KEY REFERENCES Albumes([Id])
);

CREATE TABLE Usuarios (
	[id_usuario] INT PRIMARY KEY IDENTITY(1,1),
	[nombre] NVARCHAR(30) NOT NULL,
	[apellido] NVARCHAR(30) NOT NULL,
	[email] NVARCHAR(20) UNIQUE NOT NULL,
	[fecha_registro] DATETIME DEFAULT GETDATE()
);

CREATE TABLE Listas_Canciones (
	[id_lista] INT PRIMARY KEY IDENTITY(1,1),
	[nombre] NVARCHAR(50) NOT NULL,
	[id_usuario] INT FOREIGN KEY REFERENCES Usuarios([id_usuario])
);


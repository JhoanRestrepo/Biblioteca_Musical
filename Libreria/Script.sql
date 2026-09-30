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

-- 20. Reproducciones
CREATE TABLE [Reproducciones] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Usuario] INT NOT NULL,
    [cancion] INT NOT NULL,
    [fecha_hora] SMALLDATETIME NULL,
    [duracion] TIME NULL,
    FOREIGN KEY ([Usuario]) REFERENCES [Usuarios]([Id]),
    FOREIGN KEY ([Cancion]) REFERENCES [Canciones]([Id])
);

-- Datos iniciales para que las pruebas tengan registros relacionados
-- 1. Usuarios
INSERT INTO [Usuarios] ([Nombre], [Apellido], [Correo], [Fecha_registro])
VALUES
('Ana', 'Gómez', 'ana@example.com', '2026-09-29'),
('Luis', 'Pérez', 'luis@example.com', '2026-09-29'),
('María', 'Rodríguez', 'maria@example.com', '2026-09-29');

-- 2. Artistas
INSERT INTO [Artistas] ([Nombre], [Nacionalidad], [Fecha_Inicio], [Biografia])
VALUES
('Michael Jackson', 'Estadounidense', '1964-01-01', 'Cantante y bailarín.'),
('Ryan Castro', 'Colombiano', '2017-01-01', 'Cantante colombiano.'),
('Shakira', 'Colombiana', '1990-01-01', 'Cantante y compositora.');

-- 3. Compositores
INSERT INTO [Compositores]
    ([Nombre], [Apellido], [Nacionalidad], [Fecha_Nacimiento])
VALUES
('Juan Luis', 'Guerra', 'Dominicana', '1957-06-07'),
('Shakira', 'Mebarak', 'Colombiana', '1977-02-02'),
('Rafael', 'Escalona', 'Colombiana', '1927-05-26');

-- 4. Sellos discográficos
INSERT INTO [Sellos_Discograficos]
    ([Nombre], [Pais], [Fecha_Fundacion], [Sitio_Web])
VALUES
('Sony Music', 'Estados Unidos', '1929-09-01', 'https://www.sonymusic.com'),
('Universal Music Group', 'Estados Unidos', '1934-09-01', 'https://www.universalmusic.com'),
('Warner Music Group', 'Estados Unidos', '1958-03-19', 'https://www.wmg.com');

-- 5. Álbumes
INSERT INTO [Albumes] ([Titulo], [Fecha_Lanzamiento], [Portada])
VALUES
('Thriller', '1982-11-30', 'thriller.jpg'),
('Bad', '1987-08-31', 'bad.jpg'),
('Dangerous', '1991-11-26', 'dangerous.jpg');

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

-- 10. Artistas y sellos discográficos
INSERT INTO [Artistas_Sellos]
    ([Artista], [Sello_Discografico], [Fecha_Inicio], [Fecha_Fin], [Contrato])
VALUES
(1, 1, '2020-01-01', NULL, 'Contrato exclusivo'),
(2, 2, '2022-06-15', NULL, 'Contrato de grabación'),
(3, 3, '2019-03-10', '2024-03-10', 'Contrato finalizado');

-- 11. Canciones y compositores
INSERT INTO [Canciones_Compositores]
    ([Cancion], [Compositor], [Porcentaje_Autoria], [Fecha_Registro])
VALUES
(1, 1, 100.00, '2026-09-29'),
(2, 2, 100.00, '2026-09-29'),
(3, 3, 100.00, '2026-09-29');

-- 12. Canciones y géneros
INSERT INTO [Canciones_Generos] ([Cancion], [Genero], [Principal])
VALUES
(1, 1, 1),
(2, 2, 1),
(3, 3, 1);

-- 13. Canciones e idiomas
INSERT INTO [Canciones_Idiomas]
    ([Cancion], [Idioma], [Idioma_Principal], [Porcentaje], [Fecha_Registro])
VALUES
(1, 1, 'Español', 100.00, '2026-09-29'),
(2, 2, 'Inglés', 100.00, '2026-09-29'),
(3, 3, 'Francés', 100.00, '2026-09-29');

-- 14. Suscripciones
INSERT INTO [Suscripciones]
    ([Usuario], [tipo_plan], [fecha_inicio], [fecha_fin])
VALUES
(1, 'Premium', '2026-09-01', '2026-10-01'),
(2, 'Gratis', '2026-09-15', NULL),
(3, 'Familiar', '2026-09-20', '2026-12-20');

-- 15. Listas de reproducción
INSERT INTO [Listas_Reproducciones]
    ([nombre], [fecha_creacion], [privacidad], [usuario])
VALUES
('Favoritas para estudiar', '2026-09-29', 'Privada', 1),
('Música para entrenar', '2026-09-29', 'Pública', 2),
('Clásicos', '2026-09-29', 'Privada', 3);

-- 16. Listas y canciones (LR_Canciones)
INSERT INTO [LR_Canciones] ([Listas_reproduccion], [Cancion])
VALUES
(1, 1),
(2, 2),
(3, 3);

-- 17. Listas y canciones con posición
INSERT INTO [Listas_Canciones]
    ([Lista_reproduccion], [Cancion], [posicion], [fecha_agregada], [favorita])
VALUES
(1, 1, 1, '2026-09-29', 1),
(2, 2, 1, '2026-09-29', 0),
(3, 3, 1, '2026-09-29', 1);

-- 18. Favoritos
INSERT INTO [Favoritos] ([Usuario], [fecha_marcado], [activo])
VALUES
(1, '2026-09-29', 1),
(2, '2026-09-29', 1),
(3, '2026-09-29', 1);

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
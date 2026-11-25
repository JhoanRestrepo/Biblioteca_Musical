/*
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
    [ContrasenaHash] NVARCHAR(150) NULL,
    [Fecha_Registro] SMALLDATETIME NOT NULL
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
    [Portada] NVARCHAR(MAX) NULL
);

-- 6. Géneros
CREATE TABLE [Generos] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(100) NULL,
    [Descripcion] NVARCHAR(500) NULL,
    [Popularidad] INT NOT NULL
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
    [Porcentaje] DECIMAL(5,2) NULL,
    [Fecha_Registro] SMALLDATETIME NULL,
    FOREIGN KEY ([Cancion]) REFERENCES [Canciones]([Id]),
    FOREIGN KEY ([Idioma]) REFERENCES [Idiomas]([Id])
);

-- 14. Suscripciones
CREATE TABLE [Suscripciones] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Usuario] INT NOT NULL,
    [Tipo_Plan] NVARCHAR(50) NULL,
    [Fecha_Inicio] SMALLDATETIME NULL,
    [Fecha_Fin] SMALLDATETIME NULL,
    FOREIGN KEY ([Usuario]) REFERENCES [Usuarios]([Id])
);

-- 15. Listas de reproducción
CREATE TABLE [Listas_Reproducciones] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(100) NULL,
    [Fecha_Creacion] SMALLDATETIME NULL,
    [Privacidad] NVARCHAR(50) NULL,
    [Usuario] INT NOT NULL,
    FOREIGN KEY ([usuario]) REFERENCES [Usuarios]([Id])
);

-- 16. Listas y canciones (tabla LR_Canciones del diagrama)
CREATE TABLE [LR_Canciones] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Lista_Reproduccion] INT NOT NULL,
    [Cancion] INT NOT NULL,
    FOREIGN KEY ([Lista_Reproduccion])
        REFERENCES [Listas_Reproducciones]([Id]),
    FOREIGN KEY ([Cancion]) REFERENCES [Canciones]([Id])
);

-- 17. Listas y canciones con posición (tabla Listas_Canciones)
CREATE TABLE [Listas_Canciones] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Cancion] INT NOT NULL,
    [Posicion] INT NOT NULL,
    [Fecha_Agregada] SMALLDATETIME NOT NULL,
    [Favorita] INT NOT NULL,
    FOREIGN KEY ([Cancion]) REFERENCES [Canciones]([Id])
);

-- 18. Favoritos
CREATE TABLE [Favoritos] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Usuario] INT NOT NULL,
    [Fecha_Marcado] SMALLDATETIME NULL,
    [Activo] BIT NOT NULL,
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
    [Cancion] INT NOT NULL,
    [Fecha_hora] DATETIME2 NULL,
    [Duracion] TIME NULL,
    FOREIGN KEY ([Usuario]) REFERENCES [Usuarios]([Id]),
    FOREIGN KEY ([Cancion]) REFERENCES [Canciones]([Id])
);

-- 21. Auditorias
CREATE TABLE [Auditorias] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Accion] NVARCHAR(255) NOT NULL,
    [Usuario] INT NULL,
    [Fecha] SMALLDATETIME NOT NULL,
    FOREIGN KEY ([Usuario]) REFERENCES [Usuarios]([Id])
);

-- 22. Roles
CREATE TABLE [Roles] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(255) NOT NULL,
    [Descripcion] NVARCHAR(255) NOT NULL
);

-- 23. Permisos
CREATE TABLE [Permisos] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Nombre] NVARCHAR(255) NOT NULL,
    [Codigo] NVARCHAR(255) NOT NULL,
    [Descripcion] NVARCHAR(255) NOT NULL
);

-- 24. Usuarios y Roles
CREATE TABLE [Usuarios_Roles] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Usuario] INT NOT NULL,
    [Rol] INT NOT NULL,
    FOREIGN KEY ([Usuario]) REFERENCES [Usuarios]([Id]),
    FOREIGN KEY ([Rol]) REFERENCES [Roles]([Id])
);

-- 25. Roles y Permisos
CREATE TABLE [Roles_Permisos] (
    [Id] INT PRIMARY KEY IDENTITY(1,1),
    [Rol] INT NOT NULL,
    [Permiso] INT NOT NULL,
    FOREIGN KEY ([Rol]) REFERENCES [Roles]([Id]),
    FOREIGN KEY ([Permiso]) REFERENCES [Permisos]([Id])
);

-- Datos iniciales para que las pruebas tengan registros relacionados
-- 1. Usuarios
INSERT INTO [Usuarios] ([Nombre], [Apellido], [Correo], [ContrasenaHash], [Fecha_Registro])
VALUES
('Sebastian', 'Restrepo', 'Sebas@admin.com', '369', '20260929'),
('Melissa', 'Pino', 'Meli@employee.com', '258', '20260929'),
('Roveiro', 'Osorio', 'Roveiro@employee.com', '147', '20260929');

-- 2. Artistas
INSERT INTO [Artistas] ([Nombre], [Nacionalidad], [Fecha_Inicio], [Biografia])
VALUES
('Michael Jackson', 'Estadounidense', '19640101', 'Cantante y bailarín.'),
('Ryan Castro', 'Colombiano', '20170101', 'Cantante colombiano.'),
('Shakira', 'Colombiana', '19900101', 'Cantante y compositora.');

-- 3. Compositores
INSERT INTO [Compositores]
    ([Nombre], [Nacionalidad], [Fecha_Nacimiento])
VALUES
('Michael Jackson', 'Estadounidense', '19580829'),
('Quincy Jones', 'Estadounidense', '19330314'),
('Bill Bottrell', 'Estadounidense', '19521027');

-- 4. Sellos discográficos
INSERT INTO [Sellos_Discograficos]
    ([Nombre], [Pais], [Fecha_Fundacion], [Sitio_Web])
VALUES
('Sony Music', 'Estados Unidos', '19290901', 'https://www.sonymusic.com'),
('Universal Music Group', 'Estados Unidos', '19340901', 'https://www.universalmusic.com'),
('Warner Music Group', 'Estados Unidos', '19580319', 'https://www.wmg.com');

-- 5. Álbumes
INSERT INTO [Albumes] ([Titulo], [Fecha_Lanzamiento], [Portada])
VALUES
('Thriller', '19821130', 'Thriller.jpg'),
('Bad', '19870831', 'Bad.jpg'),
('Dangerous', '19911126', 'Dangerous.jpg');

-- 6. Géneros
INSERT INTO [Generos] ([Nombre], [Descripcion], [Popularidad])
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
('Beat It', '00:04:19', 5, 1),
('Dirty Diana', '00:04:41', 9, 2),
('Give In to Me', '00:05:29', 10, 3);

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
(1, 1, '20200101', NULL, 'Contrato exclusivo'),
(2, 2, '20220615', NULL, 'Contrato de grabación'),
(3, 3, '20190310', '20240310', 'Contrato finalizado');

-- 11. Canciones y compositores
INSERT INTO [Canciones_Compositores]
    ([Cancion], [Compositor], [Porcentaje_Autoria], [Fecha_Registro])
VALUES
(1, 1, 100.00, '20260929'),
(2, 1, 65.00, '20260929'),
(2, 2, 35.00, '20260929'),
(3, 1, 80.00, '20260929'),
(3, 3, 20.00, '20260929');

-- 12. Canciones y géneros
INSERT INTO [Canciones_Generos] ([Cancion], [Genero], [Principal])
VALUES
(1, 1, 1),
(2, 2, 1),
(3, 3, 1);

-- 13. Canciones e idiomas
INSERT INTO [Canciones_Idiomas]
    ([Cancion], [Idioma], [Porcentaje], [Fecha_Registro])
VALUES
(1, 1, 100.00, '20260929'),
(2, 2, 75.00, '20260929'),
(3, 3, 80.00, '20260929');

-- 14. Suscripciones
INSERT INTO [Suscripciones]
    ([Usuario], [Tipo_Plan], [Fecha_Inicio], [Fecha_Fin])
VALUES
(1, 'Premium', '20260901', '20261001'),
(2, 'Gratis', '20260915', NULL),
(3, 'Familiar', '20260920', '20261220');

-- 15. Listas de reproducción
INSERT INTO [Listas_Reproducciones]
    ([Nombre], [Fecha_creacion], [Privacidad], [Usuario])
VALUES
('Favoritas para estudiar', '20260929', 'Privada', 1),
('Música para entrenar', '20260929', 'Pública', 2),
('Clásicos', '20260929', 'Privada', 3);

-- 16. Listas y canciones (LR_Canciones)
INSERT INTO [LR_Canciones] ([Lista_Reproduccion], [Cancion])
VALUES
(1, 1),
(2, 2),
(3, 3);

-- 17. Listas y canciones con posición
INSERT INTO [Listas_Canciones]
    ([Cancion], [Posicion], [Fecha_Agregada], [Favorita])
VALUES
(1, 1, '20260929', 1),
(2, 2, '20260929', 0),
(3, 3, '20260929', 1);

-- 18. Favoritos
INSERT INTO [Favoritos] ([Usuario], [Fecha_Marcado], [Activo])
VALUES
(1, '20260929', 1),
(2, '20260929', 1),
(3, '20260929', 1);

-- 19. Canciones guardadas en favoritos
INSERT INTO [Fav_Canciones] ([Favorito], [Cancion])
VALUES
(1, 1),
(2, 2),
(3, 3);

-- 20. Reproducciones
INSERT INTO [Reproducciones] ([Usuario], [Cancion], [Fecha_Hora], [Duracion])
VALUES
(1, 1, '2026-09-29T14:30:00', '00:03:30'),
(2, 2, '2026-09-29T15:10:00', '00:04:10'),
(3, 3, '2026-09-29T16:05:00', '00:02:55');

-- 22. Roles
INSERT INTO [Roles]
    ([Nombre], [Descripcion])
VALUES
('Administrador', 'Acceso completo al sistema'),
('Empleado', 'Puede gestionar los registros musicales'),
('Cliente', 'Puede consultar cierta información del sistema');

-- 23. Permisos
INSERT INTO [Permisos]
    ([Nombre], [Codigo], [Descripcion])
VALUES
('Consultar', '010', 'Puede consultar albumes, canciones, etc'),
('Editar', '020', 'Puede editar albumes, canciones, etc'),
('Eliminar', '030', 'Puede eliminar albumes, canciones, etc');

-- 24. Usuarios_Roles
INSERT INTO [Usuarios_Roles]
    ([Usuario], [Rol])
VALUES
(1, 1),
(2, 2),
(3, 2);
-- 25. Roles_Permisos
INSERT INTO [Roles_Permisos]
    ([Rol], [Permiso])
VALUES
(1, 1),
(1, 2),
(1, 3),
(2, 1),
(2, 2),
(3, 1);

*/
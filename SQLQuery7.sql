CREATE TABLE Compositores
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre VARCHAR(100) NULL,
    Apellido VARCHAR(100) NULL,
    Nacionalidad VARCHAR(100) NULL,
    Fecha_Nacimiento SMALLDATETIME NULL
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
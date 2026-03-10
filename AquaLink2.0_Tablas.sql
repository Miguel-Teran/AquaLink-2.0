CREATE DATABASE AquaLink2

USE AquaLink2
-----------------------------------------------------

CREATE TABLE Rol (
Rol_Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
Rol_Nombre VARCHAR (50) NOT NULL,
Rol_Descripcion VARCHAR (100)
)

SELECT * FROM Rol

-----------------------------------------------------

CREATE TABLE Usuario (
Usu_Id INT PRIMARY KEY NOT NULL,
Usu_Nombre VARCHAR (50) NOT NULL,
Usu_Correo VARCHAR (50) NOT NULL,
Usu_Telefono VARCHAR (20),
Usu_IdRol INT
FOREIGN KEY (Usu_IdRol) REFERENCES Rol(Rol_Id)
)

SELECT Usu_Nombre, rol_nombre FROM Usuario
inner join rol on Rol_Id = Usu_IdRol

-----------------------------------------------------

CREATE TABLE Reporte (
Rep_Id INT IDENTITY(1,1)  PRIMARY KEY,
Rep_Descripción VARCHAR(200),
Rep_Fecha DATE,
Rep_Lat DECIMAL (18,10),
Rep_Lon dECIMAL (18,10),
Rep_IdUsu INT
FOREIGN KEY (Rep_IdUsu) REFERENCES Usuario(Usu_Id)
)

SELECT * FROM Reporte

-----------------------------------------------------

CREATE TABLE Comentario (
Com_Id INT IDENTITY(1,1) PRIMARY KEY,
Com_IdUsu INT,
Com_IdRep INT,
Descripción VARCHAR (100)
FOREIGN KEY (Com_IdUsu) REFERENCES Usuario(Usu_Id),
FOREIGN KEY (Com_IdRep) REFERENCES Reporte(Rep_Id)
)

EXEC sp_rename 'Comentario.Descripción', 'Com_Descripcion', 'COLUMN';

select * from Comentario

-----------------------------------------------------

CREATE TABLE Evidencia (
Evi_IdRep INT,
Evi_Descripcion VARCHAR (200),
Evi_ImaDireccion VARCHAR(200),
FOREIGN KEY (Evi_IdRep) REFERENCES Reporte(Rep_Id)
)

SELECT * FROM Evidencia

-----------------------------------------------------
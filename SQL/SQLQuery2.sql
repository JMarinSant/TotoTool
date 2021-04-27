/*
	Equipo 05
	Integrantes:
	Jos� �ngel Mar�n Santiago 1884108
	Itzel Yaressi Moreno Tiznado 1665588

	QUERY #2
	Descripci�n:
	Creaci�n de los disparadores necesarios para un correcto funcionamiento de la base de datos "TOTOTOOLDB"
	Creaci�n de los disparadores:
		- Docente
		- DocenteDocente
		- Historial
		- Categor�a
		- Producto
		- ProductoCarrito
		- ComentarioEnProducto 
		- Revista
		- ComentarioEnPublicacion 

	Fecha de Creaci�n: 23 / 04 / 21.
*/

USE TOTOTOOLDB
GO

CREATE TRIGGER TR_CrearCarrito
ON Docente 
FOR INSERT
AS
DECLARE @DocenteId INT
DECLARE @Estado BIT
SET @DocenteId = (SELECT Id FROM inserted)
SET @Estado = 0
INSERT INTO Carrito (DocenteId, Estado)
VALUES (@DocenteId, @Estado)
GO


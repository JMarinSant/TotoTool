/*
	Equipo 05
	Integrantes:
	José Ángel Marín Santiago 1884108
	Itzel Yaressi Moreno Tiznado 1665588

	QUERY #2
	Descripción:
	Creación de los disparadores necesarios para un correcto funcionamiento de la base de datos "TOTOTOOLDB"
	Creación de los disparadores:
		- Docente
		- DocenteDocente
		- Historial
		- Categoría
		- Producto
		- ProductoCarrito
		- ComentarioEnProducto 
		- Revista
		- ComentarioEnPublicacion 

	Fecha de Creación: 23 / 04 / 21.
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


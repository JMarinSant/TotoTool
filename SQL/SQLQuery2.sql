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

CREATE TRIGGER TR_AgregarHistorial
ON ProductoCarrito
FOR DELETE
AS
DECLARE @Fecha DATE
DECLARE @NombreDelProducto VARCHAR(255)
DECLARE @NombreDelVendedor VARCHAR(255)
DECLARE @MontoExtraido DECIMAL(10,2)
DECLARE @Paypal VARCHAR(50)
DECLARE @HistorialDocenteId INT
DECLARE @idProducto int
DECLARE @idCarrito int
SET @Fecha = GETDATE()
SET @idProducto = (SELECT ProductoId FROM deleted)
SET @idCarrito = (SELECT CarritoId FROM deleted)
SET @NombreDelProducto = (SELECT nombre FROM Producto WHERE Producto.Id = @idProducto)
SET @NombreDelVendedor = (SELECT Docente.nombre FROM Docente JOIN Producto ON Producto.Id = @idProducto AND Producto.DocenteId = Docente.Id)
SET @MontoExtraido = (SELECT precio FROM Producto WHERE Producto.Id = @idProducto)
SET @Paypal = (SELECT paypal FROM Docente JOIN Carrito ON Docente.Id = Carrito.DocenteId AND @NombreDelVendedor = Docente.Nombre)
SET @HistorialDocenteId = (SELECT Docente.Id FROM Docente JOIN Producto ON Producto.Id = @idProducto AND Producto.DocenteId = Docente.Id)
INSERT INTO Historial(Fecha, NombreDelProducto, NombreDelVendedor, MontoExtraido, Paypal, HistorialDocenteId)
VALUES (@Fecha, @NombreDelProducto, @NombreDelVendedor, @MontoExtraido, @Paypal, @HistorialDocenteId)
GO
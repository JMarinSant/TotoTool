
USE TOTOTOOLDB
GO

INSERT INTO Categoria(Nombre)
VALUES ('Juguetes')
INSERT INTO Categoria(Nombre)
VALUES ('Muebles')


INSERT INTO Docente (Nombre, CorreoElectronico, Contrase�a)
VALUES ('JOSE', 'jose@jose.com', '123456789')
INSERT INTO Docente (Nombre, CorreoElectronico, Contrase�a)
VALUES ('ANGEL', 'angel@jose.com', '123456789')

SELECT * FROM Docente
SELECT * FROM carrito


INSERT INTO DocenteDocente(DocenteASeguirId, DocenteEnSesionId)
VALUES (1, 2)

INSERT INTO ComentarioEnProducto(Contenido, Fecha, Hora, Valoracion)
VALUES ('muy bueno', '10/04/21', '06:10', '5.0')

SELECT * FROM DocenteDocente
SELECT * FROM Categoria
SELECT * FROM Producto
SELECT * FROM ProductoCarrito
SELECT * FROM Historial

DELETE FROM ProductoCarrito
WHERE Id = 6

UPDATE Docente
SET Paypal = 123456
WHERE Docente.Id = 3
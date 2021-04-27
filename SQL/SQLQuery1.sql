
USE TOTOTOOLDB
GO

INSERT INTO Categoria(Nombre)
VALUES ('Juguetes')

INSERT INTO Docente (Nombre, CorreoElectronico, Contraseña)
VALUES ('JOSE', 'jose@jose.com', '123456789')

SELECT * FROM Docente
SELECT * FROM carrito


INSERT INTO DocenteDocente(IdDocenteASeguir, IdDocenteEnSesion)
VALUES (1, 2)

SELECT * FROM DocenteDocente
SELECT * FROM Categoria
SELECT * FROM Producto
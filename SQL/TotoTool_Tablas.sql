/*
	Equipo 05
	Integrantes:
	José Ángel Marín Santiago 1884108
	Itzel Yaressi Moreno Tiznado 1665588

	QUERY #1
	Descripción:
	Creación de la base de datos "TOTOTOOLDB"
	Creación de las tablas:
		- Docente
		- DocenteDocente
		- Historial
		- Categoría
		- Producto
		- ProductoCarrito
		- ComentarioEnProducto 
		- Revista
		- ComentarioEnPublicacion 

	Fecha de Creación: 12 / 03 / 21.
*/

CREATE DATABASE TOTOTOOLDB
GO

USE TOTOTOOLDB
GO

/*
	1. Tabla Docente
*/

CREATE TABLE Docente (
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(255) NOT NULL,
	CorreoElectronico VARCHAR(150) NOT NULL,
	Contraseña VARCHAR(50) NOT NULL,
	Direccion VARCHAR(255) NULL,
	Ciudad VARCHAR(100) NULL,
	EntidadFederativa VARCHAR(75) NULL,
	Pais VARCHAR(50) NULL,
	Paypal VARCHAR(50) NULL,
	Telefono BIGINT NULL,
	CONSTRAINT CHK_Telefono CHECK (Telefono >= 1000000000)
)
GO

/*
	2. Tabla resultante de la relacion entre un docente y otro.
	Sucede cuando un docente sigue a otro.
*/

CREATE TABLE DocenteDocente (
	Id INT IDENTITY PRIMARY KEY,
	IdDocenteEnSesion INT NOT NULL,
	IdDocenteASeguir INT NOT NULL,
	CONSTRAINT FK_IdDocenteEnSesion FOREIGN KEY (IdDocenteEnSesion) REFERENCES Docente(Id),
	CONSTRAINT FK_IdDocenteASeguir FOREIGN KEY (IdDocenteASeguir) REFERENCES Docente(Id)
)
GO

/*
	3. Tabla Historial. Esta se llenará de manera automática cuando el docente haga una compra.
*/

CREATE TABLE Historial (
	Id INT IDENTITY PRIMARY KEY,
	Fecha DATE NOT NULL,
	NombreDelProducto VARCHAR(255) NOT NULL,
	NombreDelVendedor VARCHAR(255) NOT NULL,
	MontoExtraido DECIMAL(10,2) NOT NULL,
	Paypal VARCHAR(50) NOT NULL
)
GO

/*
	4. Tabla Categoria.
*/

CREATE TABLE Categoria (
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL
)
GO

/*
	5. Tabla Producto.
*/

CREATE TABLE Producto (
	Id INT IDENTITY PRIMARY KEY,
	Nombre VARCHAR(100) NOT NULL,
	Descripcion VARCHAR(MAX) NOT NULL,
	Precio DECIMAL(10,2) NOT NULL,
	Imagen VARCHAR(255) NOT NULL,
	IdCategoria INT NOT NULL,
	CONSTRAINT FK_IdCategoria FOREIGN KEY (IdCategoria) REFERENCES Categoria(Id)
)
GO

/*
	6. Tabla Carrito.
*/

CREATE TABLE Carrito (
	Id INT IDENTITY PRIMARY KEY,
	IdDocente INT NOT NULL,
	Estado BIT NOT NULL,
	CONSTRAINT FK_Carrito_IdDocente FOREIGN KEY (IdDocente) REFERENCES Docente(Id)
)
GO

/*
	7. Tabla ProductoCarrito. Table producto de la relacion entre la tabla producto y carrito.
*/

CREATE TABLE ProductoCarrito (
	Id INT IDENTITY PRIMARY KEY,
	IdProducto INT NOT NULL,
	IdCarrito INT NOT NULL,
	CONSTRAINT FK_ProductoCarrito_IdProducto FOREIGN KEY (IdProducto) REFERENCES Producto(Id),
	CONSTRAINT FK_ProductoCarrito_IdCarrito FOREIGN KEY (IdCarrito) REFERENCES Carrito(Id)
)
GO

/*
	8. Tabla ComentarioEnProducto.
*/

CREATE TABLE ComentarioEnProducto (
	Id INT IDENTITY PRIMARY KEY,
	Contenido VARCHAR(255) NOT NULL,
	Fecha DATE NOT NULL,
	Hora TIME NOT NULL,
	Valoracion FLOAT NOT NULL,
	IdProducto INT NOT NULL,
	IdDocente INT NOT NULL,
	CONSTRAINT FK_ComentarioEnProducto_IdProducto FOREIGN KEY (IdProducto) REFERENCES Producto(Id),
	CONSTRAINT FK_ComentarioEnProducto_IdDocente FOREIGN KEY (IdDocente) REFERENCES Docente(Id)
)
GO

/*
	9. Tabla Revista.
*/

CREATE TABLE Revista (
	Id INT IDENTITY PRIMARY KEY,
	Contenido VARCHAR(255) NOT NULL,
	Imagen VARCHAR(100) NOT NULL,
	IdDocente INT NOT NULL,
	CONSTRAINT FK_Revista_IdDocente FOREIGN KEY (IdDocente) REFERENCES Docente(Id)
)
GO

/*
	10. Tabla ComentarioEnPublicacion.
*/

CREATE TABLE ComentarioEnPublicacion (
	Id INT IDENTITY PRIMARY KEY,
	Contenido VARCHAR(255) NOT NULL,
	Fecha DATE NOT NULL,
	IdDocente INT NOT NULL,
	IdRevista INT NOT NULL,
	CONSTRAINT FK_ComentarioEnPublicacion_IdDocente FOREIGN KEY (IdDocente) REFERENCES Docente(Id),
	CONSTRAINT FK_ComentarioEnPublicacion_IdRevista FOREIGN KEY (IdRevista) REFERENCES Revista(Id)
)	
GO

# DAEA_Semana5
CREATE PROC USP_SeleccionProducto 
@Nombre varchar(50) = '' AS BEGIN SELECT * FROM producto 
WHERE (@Nombre LIKE '%'+nombre+'%' OR @Nombre ='') 
END

USP_SeleccionProducto 'Pera'

CREATE PROC USP_InsProducto 
@IdProducto INT, 
@Nombre varchar(50), 
@Precio decimal(5,2) 
AS 
BEGIN 
INSERT INTO producto(id, nombre, precio, fechaCreacion) 
VALUES (@IdProducto, @Nombre, @Precio, GETDATE()) 
END

USP_InsProducto 2,'Pera', 1.50

select * from producto

USP_SeleccionProducto()

DROP PROCEDURE USP_SeleccionProducto
go

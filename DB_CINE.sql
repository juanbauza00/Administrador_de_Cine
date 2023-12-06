

create database TPI_Cine
go
use TPI_CINE
go
create table Formas_Pago(
id_forma_pago int not null identity,
forma_pago varchar(40)
constraint pk_formas_pagos PRIMARY KEY (id_forma_pago)
)
go
create table Tipos_Salas(
id_tipo_sala int not null identity,
tipo_sala varchar(40),
precio decimal(10,2)
constraint pk_tipos_salas PRIMARY KEY (id_tipo_sala)
)
go
create table Categorias(
id_categoria int not null identity,
categoria varchar(40)
constraint pk_categorias PRIMARY KEY (id_categoria))
go
create table Generos(
id_genero int not null identity,
genero varchar(40)
constraint pk_generos PRIMARY KEY(id_genero)
)

go
create table Formatos(
id_formato int not null identity,
formato varchar(40)
constraint pk_Formatos primary key(id_formato)
)

go
create table Tipos_Documentos(
id_tipo_documento int not null identity,
tipo_documento varchar(40)
constraint pk_tipos_documentos PRIMARY KEY(id_tipo_documento))
go
create table Promociones(
id_promocion int not null identity,
dia_promocion int,
porcentaje int,
descripcion varchar(40)
constraint pk_promociones PRIMARY KEY(id_promocion)
)
go
create table Clientes(
id_cliente int not null identity,
nom_cliente varchar(40),
ape_cliente varchar(40),
documento int,
id_tipo_documento int
constraint pk_clientes PRIMARY KEY(id_cliente)
constraint fk_clientes_tipos_documento FOREIGN KEY(id_tipo_documento) references Tipos_Documentos(id_tipo_documento)
)
go
create table Salas(
id_sala int not null identity,
id_tipo_sala int,
constraint pk_salas PRIMARY KEY(id_sala),
constraint fk_salas_tipos_salas FOREIGN KEY(id_tipo_sala) references Tipos_Salas(id_tipo_sala)
)
go
create table Butacas(
id_butaca int not null identity,
fila int,
columna int,
id_sala int
constraint pk_butacas PRIMARY KEY(id_butaca)
constraint fk_butacas_id_sala FOREIGN KEY(id_sala) references Salas(id_sala)
)
go
create table Peliculas(
id_pelicula int not null identity,
nombre varchar(40),
descripcion varchar(255),
duracion int,
id_categoria int,
id_genero int
constraint pk_peliculas PRIMARY KEY(id_pelicula)
constraint fk_peliculas_categorias FOREIGN KEY(id_categoria) references Categorias(id_categoria),
constraint fk_peliculas_generos FOREIGN KEY(id_genero) references Generos(id_genero)
)
go
create table Funciones(
id_funcion int not null identity,
id_pelicula int,
fecha_hora datetime,
id_formato int,
id_sala int
constraint pk_funciones PRIMARY KEY(id_funcion)
constraint fk_funciones_peliculas FOREIGN KEY(id_pelicula) references Peliculas(id_pelicula),
constraint fk_funciones_salas FOREIGN KEY(id_sala) references Salas(id_sala),
constraint fk_funciones_formatos foreign key(id_formato) references Formatos (id_formato)
)
go
create table Funciones_Butacas(
id_funcion_butaca int not null identity,
id_funcion int,
id_butaca int,
disponible bit
constraint pk_funciones_butacas PRIMARY KEY(id_funcion_butaca)
constraint fk_funciones_butacas_funcion FOREIGN KEY(id_funcion) references Funciones(id_funcion),
constraint fk_funciones_butacas_butaca FOREIGN KEY(id_butaca) references Butacas(id_butaca)
)


go
create table Tickets(
id_ticket int not null identity,
id_cliente int,
id_forma_pago int,
estado bit,
fecha datetime
constraint pk_tickets PRIMARY KEY(id_ticket)
constraint fk_tickets_clientes FOREIGN KEY(id_cliente) references Clientes(id_cliente),
constraint fk_tickets_formas_pagos FOREIGN KEY(id_forma_pago) references Formas_Pago(id_forma_pago)
)
go
create table Detalles_Tickets(
id_detalle int not null identity,
id_ticket int,
id_funcion_butaca int,
precio_unitario float,
id_promocion int,
descuento decimal(10,2)
constraint pk_detalles_tickets PRIMARY KEY(id_detalle)
constraint fk_detalles_tickets FOREIGN KEY(id_ticket) references Tickets(id_ticket),
constraint fk_detalles_funciones_bucatas FOREIGN KEY(id_funcion_butaca) references Funciones_Butacas(id_funcion_butaca),
constraint fk_detalles_promociones FOREIGN KEY(id_promocion) references Promociones(id_promocion)
)
go
create table Gerentes(
id_gerente int not null identity,
nom_gerente varchar(100),
ape_gerente varchar(100),
email varchar(100),
password_gerente varchar(100)
constraint pk_gerentes PRIMARY KEY(id_gerente))
go


-------------------------------------------inserts DB CINE TPI --------------------------------------------------------------------------------------

INSERT INTO Formas_Pago(forma_pago) VALUES
('Efectivo'),
('Tarjeta de crédito'),
('Transferencia bancaria'),
('PayPal'),
('Cheque');

go
INSERT INTO Tipos_Salas (tipo_sala, precio) VALUES
('Sala 2D', 3200),
('Sala 3D', 3800),
('Sala VIP', 4100),
('Sala IMAX', 3900),
('Sala 4D', 4900);

go
insert into Categorias(categoria) values
('ATP'),
('+13'),
('+16'),
('+18')

go
insert into Generos(genero) values
('Accion'),
('Terror'),
('Documental'),
('Suspenso'),
('Infantil'),
('Comedia'),
('Romance')



go
INSERT INTO Tipos_Documentos (tipo_documento) VALUES
('DNI'),
('Pasaporte'),
('Cédula de identidad'),
('Licencia de conducir'),
('Tarjeta de identificación');


go
INSERT INTO Promociones (dia_promocion, porcentaje, descripcion) VALUES
(1, 10, 'Descuento del 10% los lunes'),
(2, 20, 'Descuento del 20% los martes'),
(3, 15, 'Descuento del 15% los miércoles'),
(4, 25, 'Descuento del 25% los jueves'),
(5, 30, 'Descuento del 30% los viernes'),
(6, 10, 'Descuento del 10% los sábados'),
(7, 20, 'Descuento del 20% los domingos');

go
INSERT INTO Clientes (nom_cliente, ape_cliente, documento, id_tipo_documento) VALUES
('Juan', 'Pérez', 12345678, 1), -- DNI
('María', 'González', 98765432, 2), -- Pasaporte
('Carlos', 'López', 54321678, 3), -- Cédula de identidad
('Ana', 'Martínez', 87654321, 1), -- DNI
('Luis', 'Sánchez', 34567890, 4), -- Licencia de conducir
('Laura', 'Rodríguez', 23456789, 3), -- Cédula de identidad
('Pedro', 'Fernández', 65432187, 2), -- Pasaporte
('Sofía', 'Ramírez', 78901234, 1), -- DNI
('Elena', 'Díaz', 45678901, 4), -- Licencia de conducir
('Diego', 'Peralta', 56789012, 2); -- Pasaporte


go
INSERT INTO Salas (id_tipo_sala) VALUES
(1), -- Sala 2D
(2), -- Sala 3D
(3), -- Sala VIP
(4) -- Sala IMAX

go
INSERT INTO Butacas (fila, columna, id_sala) VALUES
(1, 1, 1),
(1, 2, 1),
(1, 3, 1),
(2, 1, 1),
(2, 2, 1),
(2, 3, 1),
(1, 1, 2),
(1, 2, 2),
(1, 3, 2),
(2, 1, 2),
(2, 2, 2),
(2, 3, 2),
(1, 1, 3),
(1, 2, 3),
(1, 3, 3),
(2, 1, 3),
(2, 2, 3),
(2, 3, 3),
(1,1,4),
(1,2,4),
(1,3,4),
(2,1,4),
(2,2,4),
(2,3,4)
go
INSERT INTO Formatos (formato) values ('Subtitulada'), ('Traducida');

go
INSERT INTO Peliculas (nombre, descripcion, duracion, id_categoria, id_genero) VALUES -- 10 reg
('El Héroe de la Aventura', 'Una emocionante película de acción', 120, 2, 1),
('Risas en la Comedia', 'Una divertida comedia para toda la familia', 90, 2, 6),
('Drama en la Ciudad', 'Una conmovedora historia de amor y pérdida', 150, 3, 4),
('La Odisea Espacial', 'Una épica de ciencia ficción en el espacio', 180, 2, 4),
('Aventuras Animadas', 'Una película animada llena de diversión', 100, 1, 5),
('Misterio en la Montaña', 'Un emocionante thriller de suspense', 110, 3, 4),
('Romance de Verano', 'Un dulce romance bajo el sol', 120, 2, 6),
('Aventura en la Selva', 'Una emocionante expedición en la jungla', 130, 2, 1),
('Ciencia en Documental', 'Un documental educativo sobre la naturaleza', 90, 1, 3),
('Risas Animadas', 'Una película animada para todas las edades', 95, 1, 5);



go


--Fecha_hora: AAAA-MM-DD hh:mm:ss

INSERT INTO Funciones (id_pelicula, id_sala,fecha_hora, id_formato) VALUES --12 reg
(1, 1,'2023/10/10 10:00', 1), --funcion 1 -h1
(2, 2,'2023/10/08 13:00', 2), --funcion 2 -h2
(3, 3,'2023/10/05 16:00', 1), --funcion 3 -h3
(4, 4,'2023/05/04 18:00', 2), --funcion 4 -h4
(5, 1,'2023/08/10 20:00', 1), --funcion 5 -h5
(6, 2,'2023/06/20 22:00', 2), --funcion 6 -h6
(7, 3,'2023/09/15 10:00', 1), --funcion 7 -h1
(8, 4,'2023/07/09 13:00', 1), --funcion 8 -h2
(9, 1,'2023/08/03 16:00', 2), --funcion 9
(10, 2,'2023/09/05 18:00', 2), --funcion 10
(1, 3,'2023/06/08 20:00', 1), --funcion 11
(2, 4,'2023/05/24 22:00', 2) --funcion 12

go
INSERT INTO Funciones_Butacas (id_funcion, id_butaca, disponible) VALUES
--funcion 1 pertenece a sala 1, butacas de sala 1 van de id 1 a 6
--funcion 2 pertenece a sala 2, butacas de sala 2 van de 6 a 12
--...
--cada sala tiene 3 funciones

(1,1,1),(1,2,1),(1,3,1),(1,4,1),(1,5,0),(1,6,0),
(2,7,1),(2,8,0),(2,9,0),(2,10,1),(2,11,0),(2,12,1),
(3,13,0),(3,14,0),(3,15,0),(3,16,1),(3,17,1),(3,18,1),
(4,19,1),(4,20,1),(4,21,0),(4,22,0),(4,23,1),(4,24,0),
(5,1,1),(5,2,0),(5,3,0),(5,4,1),(5,5,0),(5,6,0),
(6,7,0),(6,8,1),(6,9,1),(6,10,0),(6,11,0),(6,12,1),
(7,13,0),(7,14,0),(7,15,0),(7,16,0),(7,17,0),(7,18,0),
(8,19,1),(8,20,0),(8,21,0),(8,22,1),(8,23,0),(8,24,0),
(9,1,1),(9,2,1),(9,3,1),(9,4,0),(9,5,0),(9,6,0),
(10,7,0),(10,8,0),(10,9,1),(10,10,1),(10,11,1),(10,12,1),
(11,13,1),(11,14,0),(11,15,1),(11,16,0),(11,17,1),(11,18,0),
(12,19,1),(12,20,1),(12,21,0),(12,22,0),(12,23,0),(12,24,1)

go
--ticket 1 juan perez
INSERT INTO Tickets (id_cliente, id_forma_pago, fecha, estado) VALUES
(1, 1, '2023/10/15',1);
go
-- Ticket 2 (Cliente: María González, Forma de Pago: Tarjeta de crédito)
INSERT INTO Tickets (id_cliente, id_forma_pago, fecha, estado) VALUES
(2, 2, '2023/10/15',1);
go
-- Ticket 3 (Cliente: Carlos López, Forma de Pago: Efectivo)
INSERT INTO Tickets (id_cliente, id_forma_pago, fecha, estado) VALUES
(3, 1, '2023/10/16',1);
go
-- Ticket 4 (Cliente: Ana Martínez, Forma de Pago: Transferencia bancaria)
INSERT INTO Tickets (id_cliente, id_forma_pago, fecha, estado) VALUES
(4, 3, '2023/10/16',1);
go
-- Ticket 5 (Cliente: Luis Sánchez, Forma de Pago: Tarjeta de crédito)
INSERT INTO Tickets (id_cliente, id_forma_pago, fecha, estado) VALUES
(5, 2, '2023/10/17',1);
--------------------------DETALLES-TICKETS-----------------------------------

go
INSERT INTO Detalles_Tickets (id_ticket, id_funcion_butaca, precio_unitario, id_promocion) VALUES
(1, 1, 1000.50, 1),
(2, 1, 1000.50, 1),
(3, 1, 1000.50, 1),
(4, 1, 1000.50, 1),
(5, 1, 1000.50, 1)
go
-- Detalle de Ticket 2 (Ticket 2)
INSERT INTO Detalles_Tickets (id_ticket, id_funcion_butaca, precio_unitario, id_promocion) VALUES
(2, 12, 1500.00, 2),
(2, 16, 1500.00, 2),
(2, 19, 1500.00, 2),
(2, 20, 1500.00, 2),
(2, 21, 1500.00, 2)
go
-- Detalle de Ticket 3 (Ticket 3)
INSERT INTO Detalles_Tickets (id_ticket, id_funcion_butaca, precio_unitario, id_promocion) VALUES
(3, 31, 1200.00, 3),
(3, 32, 1200.00, 3),
(3, 36, 1200.00, 3),
(3, 38, 1200.00, 3),
(3, 40, 1200.00, 3)
go
-- Detalle de Ticket 4 (Ticket 4)
INSERT INTO Detalles_Tickets (id_ticket, id_funcion_butaca, precio_unitario, id_promocion) VALUES
(4, 43, 1800.50, 4),
(4, 46, 1800.50, 4),
(4, 48, 1800.50, 4),
(4, 51, 1800.50, 4),
(4, 54, 1800.50, 4)

go
-- Detalle de Ticket 5 (Ticket 5)
INSERT INTO Detalles_Tickets (id_ticket, id_funcion_butaca, precio_unitario, id_promocion) VALUES
(5, 55, 1150.50, 5),
(5, 56, 1150.50, 5),
(5, 60, 1150.50, 5),
(5, 61, 1150.50, 5),
(5, 65, 1150.50, 5),
(5, 66, 1150.50, 5),
(5, 69, 1150.50, 5),
(5, 71, 1150.50, 5)
go
insert into Gerentes(nom_gerente,ape_gerente,email,password_gerente)
VALUES('Juan','Perez','juanperez@gmail.com','admin')

go

--------------------------------------------------------PROCEDIMIENTOS----------------------------------------------------------------------------------------------------------------


CREATE PROCEDURE SP_MODIFICAR_MAESTRO_CLIENTE
	@id_cliente int,
	@nom_cliente varchar(40),
	@ape_cliente varchar(40),
	@documento int, 
	@id_tipo_documento int
AS
BEGIN
	UPDATE Clientes SET nom_cliente = @nom_cliente, ape_cliente = @ape_cliente, documento = @documento, id_tipo_documento = @id_tipo_documento
	WHERE id_cliente = @id_cliente;
END


go
CREATE PROCEDURE SP_MODIFICAR_MAESTRO_TICKET
	@id_ticket int,
	@id_cliente int,
	@fecha datetime,
	@estado bit, 
	@id_forma_pago int
AS
BEGIN
	UPDATE Tickets SET id_cliente =@id_cliente, fecha=@fecha, estado=@estado, id_forma_pago=@id_forma_pago
	WHERE id_ticket = @id_ticket;

	DELETE Detalles_Tickets
	WHERE id_ticket = @id_ticket;
END


go
CREATE PROCEDURE SP_MODIFICAR_MAESTRO_FUNCIONES
	@id_funcion int,
	@id_pelicula int,
	@fecha_hora datetime,
	@id_formato int,
	@id_sala int
AS
BEGIN
	UPDATE Funciones SET id_pelicula=@id_pelicula, fecha_hora=@fecha_hora, id_formato=@id_formato, id_sala=@id_sala
	WHERE id_funcion = @id_funcion;

	DELETE Funciones_Butacas
	WHERE id_funcion = @id_funcion;

END


go
CREATE PROCEDURE SP_CONSULTAR_TICKETS
	@fecha_desde Datetime,
	@fecha_hasta Datetime
AS
BEGIN
	SELECT * 
	FROM Tickets
	WHERE (@fecha_desde is null OR fecha >= @fecha_desde)
	AND (@fecha_hasta is null OR fecha <= @fecha_hasta)
END


go
CREATE PROCEDURE SP_CONSULTAR_CLIENTES
AS
BEGIN
	SELECT *
	FROM Clientes
END
go

CREATE PROCEDURE SP_CONSULTAR_FORMAS_PAGO
AS
BEGIN
	SELECT * FROM Formas_Pago
END


go---------------------------------------
CREATE PROCEDURE SP_CONSULTAR_DETALLES_TICKETS
	@id_ticket int
AS
BEGIN
	SELECT precio_unitario, p.descripcion, descuento
	FROM Detalles_Tickets t
	JOIN Promociones P ON t.id_promocion=p.id_promocion
	WHERE id_ticket = @id_ticket; 
END


go
CREATE PROCEDURE SP_PROXIMO_ID_TICKET
@next int OUTPUT
AS
BEGIN
	SET @next = (SELECT MAX(id_ticket)+1  FROM Tickets);
END


go
CREATE PROCEDURE SP_CONSULTAR_FUNCIONES
	@fecha_desde Datetime,
	@fecha_hasta Datetime
AS
BEGIN
	SELECT * 
	FROM Funciones
	WHERE (fecha_hora between @fecha_desde and @fecha_hasta)
END

select * from Peliculas

go
CREATE PROCEDURE SP_ELIMINAR_TICKET
	@id_ticket int
AS
BEGIN
	delete from Tickets WHERE id_ticket = @id_ticket;
END


go
CREATE PROCEDURE SP_ELIMINAR_FUNCION
	@id_funcion int
AS
BEGIN
	delete from Funciones WHERE id_funcion = @id_funcion;
END


go
CREATE PROCEDURE SP_ELIMINAR_CLIENTE
	@id_cliente int
AS
BEGIN
	delete from Clientes WHERE id_cliente = @id_cliente;
END
go



create PROCEDURE SP_INSERTAR_DETALLE_TICKET --Se elimino el campo de id_ticket porque es identity
	@id_ticket int,
	@id_funcion_butaca int, 
	@precio_unitario float,
	@id_promocion int,
	@descuento decimal(10,2)
AS
BEGIN
	INSERT INTO Detalles_Tickets(id_ticket, id_funcion_butaca, precio_unitario,id_promocion,descuento)
    VALUES (@id_ticket,@id_funcion_butaca,@precio_unitario,@id_promocion,@descuento);
END

go

CREATE PROCEDURE SP_INSERTAR_MAESTRO_TICKET
	@id_cliente varchar(255), 
	@id_forma_pago numeric(5,2),
	@estado numeric(8,2),
	@id_ticket int OUTPUT
AS
BEGIN
	INSERT INTO Tickets(id_cliente, id_forma_pago, estado, fecha)
    VALUES (@id_cliente,@id_forma_pago,@estado,GETDATE());
    --Asignamos el valor del último ID autogenerado (obtenido --  
    --mediante la función SCOPE_IDENTITY() de SQLServer)	
    SET @id_ticket = SCOPE_IDENTITY();
END


go
CREATE PROCEDURE SP_INSERTAR_CLIENTE
	@nom_cliente varchar(40), 
	@ape_cliente varchar(40),
	@documento int,
	@id_tipo_documento int,
	@id_cliente int OUTPUT
AS
BEGIN
	INSERT INTO Clientes(nom_cliente, ape_cliente, documento, id_tipo_documento)
    VALUES (@nom_cliente,@ape_cliente,@documento,@id_tipo_documento);
    --Asignamos el valor del último ID autogenerado (obtenido --  
    --mediante la función SCOPE_IDENTITY() de SQLServer)	
    SET @id_cliente = SCOPE_IDENTITY();
END

select * from Clientes



go

CREATE PROCEDURE SP_INSERTAR_FUNCION
	@id_pelicula int,
	@fecha_hora datetime,
	@id_formato int,
	@id_sala int,
	@id_funcion int OUTPUT
AS
BEGIN
	INSERT INTO Funciones(id_pelicula, fecha_hora, id_formato, id_sala)
    VALUES (@id_pelicula,@fecha_hora,@id_formato,@id_sala);
    --Asignamos el valor del último ID autogenerado (obtenido --  
    --mediante la función SCOPE_IDENTITY() de SQLServer)	
    SET @id_funcion = SCOPE_IDENTITY();
END

go
create procedure sp_get_gerentes
as
begin
select nom_gerente, ape_gerente, email from Gerentes
end

go
create procedure sp_validar_gerente
@email varchar(100),
@passwordParam varchar(100),
@validado int output
as
begin
set @validado = 0
if (select password_gerente from gerentes where email = @email) = @passwordParam
begin
set @validado = 1
end
end

go
create procedure SP_CONSULTAR_FUNCIONES_NO_PARAM
as
begin
select * from funciones
end
go
create procedure SP_CONSULTAR_PELICULA_ID
@idPelicula int
as
begin
select * from Peliculas where id_pelicula = @idPelicula
end
go
create procedure SP_CONSULTAR_SALA_ID
@idSala int
as
begin
select * from Salas s join Tipos_Salas ts on s.id_tipo_sala = ts.id_tipo_sala
end


go
create procedure SP_CONSULTAR_TIPOS_DOCUMENTOS
as
begin
select * from Tipos_Documentos
end

go
create procedure SP_CONSULTAR_PELICULAS
as
begin
select * from Peliculas
end
go
create procedure SP_CONSULTAR_SALAS
as
begin
select s.id_sala, s.id_tipo_sala, precio, tipo_sala from Salas s join Tipos_Salas ts on s.id_tipo_sala = ts.id_tipo_sala
end

go
create procedure SP_OBTENER_FORMATOS_FUNCIONES
as
begin
select * from Formatos
end


go
create procedure SP_BUTACAS_POR_FUNCION --Hecho por Juan
@id_funcion int
as
begin
--BUTACAS DESOCUPADAS
select fb.id_funcion_butaca, b.id_butaca, b.fila, b.columna, 'desocupada' Estado
from Funciones_Butacas fb
join Butacas b on b.id_butaca = fb.id_butaca
where fb.id_funcion_butaca not in (select fb1.id_funcion_butaca
								   from Funciones_Butacas fb1
								   join Detalles_Tickets dt1 on dt1.id_funcion_butaca = fb1.id_funcion_butaca
								   where fb1.id_funcion = @id_funcion)
and fb.id_funcion = @id_funcion
union					   
--BUTACAS OCUPADAS
select fb.id_funcion_butaca, b.id_butaca, b.fila, b.columna, 'ocupada'
from Funciones_Butacas fb
join Butacas b on b.id_butaca = fb.id_butaca
where fb.id_funcion_butaca in (select fb1.id_funcion_butaca
								   from Funciones_Butacas fb1
								   join Detalles_Tickets dt on dt.id_funcion_butaca = fb.id_funcion_butaca
								   where fb1.id_funcion = @id_funcion)
and fb.id_funcion = @id_funcion
end

go
create procedure SP_CONSULTAR_GENERO_ID
@idPelicula int
as
begin
select g.id_genero from Generos g
join peliculas p on p.id_genero = g.id_genero
where p.id_pelicula = @idPelicula
end


go
create procedure SP_CONSULTAR_CATEGORIAS_ID
@idPelicula int
as
begin
select c.id_categoria from Categorias c 
join peliculas p on c.id_categoria = p.id_categoria
where p.id_pelicula = @idPelicula
end


go
create procedure SP_CONSULTAR_SALAS_ID
@idSala int
as
begin
select s.id_sala, ts.tipo_sala, precio
from Salas s
join Tipos_Salas ts on ts.id_tipo_sala = s.id_tipo_sala
where s.id_sala = @idSala
end


go
create procedure SP_CONSULTAR_FORMATOS_ID
@idFormato int
as
begin
select f.id_formato from formatos f
where f.id_formato = @idFormato
end

go
create procedure sp_consultar_clientes_visitantes
@fec_desde datetime,
@fec_hasta datetime
as 
begin
select distinct ape_cliente 'Apellido Cliente', nom_cliente 'Nombre Cliente',
c.documento 'Documento Cliente', 'Visitó' Observaciones
from Tickets t join Detalles_Tickets dt on t.id_ticket = dt.id_ticket
join clientes c on t.id_cliente = c.id_cliente
where t.fecha between @fec_desde and @fec_hasta

union 
select distinct ape_cliente,nom_cliente,c.documento, 'No visitó'
from clientes c 
where c.id_cliente not in (select t1.id_cliente from tickets t1
                            where t1.fecha between @fec_desde and @fec_hasta)
order by 4
end

go
CREATE PROCEDURE SP_REPORTE_TICKETS
@fecha_desde datetime, 
@fecha_hasta datetime 

AS
BEGIN
SELECT t.id_ticket,p.nombre,format(f.fecha_hora,'HH:mm') hora,format(t.fecha,'dd-MM-yyyy') fecha,dt.precio_unitario,fo.formato,ts.tipo_sala
	FROM Tickets t
	join Detalles_Tickets dt on t.id_ticket=dt.id_ticket
	join Funciones_Butacas fb on dt.id_funcion_butaca=fb.id_funcion_butaca
	join Funciones f on fb.id_funcion=f.id_funcion
	join Peliculas p on f.id_pelicula=p.id_pelicula
	join Formatos fo on f.id_formato=fo.id_formato
	join Salas s on f.id_sala=s.id_sala
	join Tipos_Salas ts on s.id_tipo_sala=ts.id_tipo_sala
	WHERE t.fecha between @fecha_desde and @fecha_hasta
END

--Consultar Clientes entre fechas
go
create procedure SP_CONSULTAR_CLIENTES_PARAM
@fecha_desde datetime,
@fecha_hasta datetime
as
begin
select * from Clientes C join Tickets t on t.id_cliente= C.id_cliente
where t.fecha between @fecha_desde and @fecha_hasta
end
--Consultar Tipos de documentos con un id
go
create procedure SP_CONSULTAR_TIPO_DOC_ID
@id_tipo_documento int
as
begin
select * from Tipos_Documentos TD where TD.id_tipo_documento= @id_tipo_documento
end

go
create procedure SP_CONSULTAR_CLIENTES_NO_PARAM
as
begin
select * from Clientes
end

go
create procedure SP_CLIENTE_TIENE_TICKET
@idCliente int,
@tiene int output
as
begin
set @tiene = 0
if (@idCliente in (select c.id_cliente from clientes c join tickets t on c.id_cliente = t.id_cliente))
begin
set @tiene = 1
end
end
go
--create procedure SP_FUNCION_TIENE_RESERVA
--@idFuncion int,
--@tiene int output
--as
--begin
--set @tiene=0;
--if( @idFuncion  in ( select FB.id_funcion from Funciones_Butacas FB where disponible=0))
--begin
--set @tiene=1
--end
--end
--go
create procedure SP_FUNCION_TIENE_RESERVA
@idFuncion int,
@tiene int output
as
begin
set @tiene=0;
if( @idFuncion  in ( select id_funcion from detalles_tickets dt
join Funciones_Butacas fb on dt.id_funcion_butaca = fb.id_funcion_butaca
where id_funcion = @idFuncion))
begin
set @tiene=1
end
end
go


create procedure SP_CONSULTAR_PROMOCION
@dia_semana int
as
begin
select top 1 * from Promociones
where dia_promocion = @dia_semana
end
go


create procedure SP_TRAER_TICKETS_CLIENTES
as
begin
select t.id_ticket, t.fecha fecha, t.estado, t.id_forma_pago, c.id_cliente, c.nom_cliente, c.ape_cliente, c.documento, c.id_tipo_documento
from Tickets t join Clientes c on c.id_cliente = t.id_cliente
end
go

create procedure SP_TRAER_TICKETS_CLIENTES_CON_PARAM
@fecha_desde datetime,
@fecha_hasta datetime
as
begin
select t.id_ticket, t.fecha fecha, t.estado, t.id_forma_pago, c.id_cliente, c.nom_cliente, c.ape_cliente, c.documento, c.id_tipo_documento
from Tickets t join Clientes c on c.id_cliente = t.id_cliente
where t.fecha between @fecha_desde and @fecha_hasta
end
go

create procedure SP_TRAER_DETALLES_TICKETS_Y_BUTACAS
@id_ticket int
as
begin
select dt.id_detalle, dt.precio_unitario, dt.descuento, p.dia_promocion, dt.id_funcion_butaca, fb.id_butaca,b.fila,b.columna
from Detalles_Tickets dt
join Funciones_Butacas fb on dt.id_funcion_butaca = dt.id_funcion_butaca
join Butacas b on b.id_butaca = fb.id_butaca
join Promociones p on p.id_promocion = dt.id_promocion
where dt.id_ticket = @id_ticket and dt.id_funcion_butaca = fb.id_funcion_butaca
end
go



go
create trigger TR_INSERT_FUNCION
on funciones
after insert

as
begin

declare @nrosButacas int
declare @funcion int
declare @idSala int

set @idSala = 6*(select id_sala from inserted)
set @nrosButacas = @idSala
set @funcion = (select id_funcion from inserted)

while @nrosButacas > (@idSala - 6)
begin

insert into Funciones_Butacas(id_funcion,id_butaca,disponible)
values (@funcion, @nrosButacas,1)
set @nrosButacas = @nrosButacas -1

end
end


go

create procedure SP_ELIMINAR_FUNC_BUTACA
@idFuncion int
as
begin
delete from Funciones_Butacas where id_funcion = @idFuncion
end

go
create procedure SP_ELIMINAR_DETALLE_TICKET
@idTicket int
as
begin delete from Detalles_Tickets where id_ticket= @idTicket
end

go
create procedure SP_CONSULTAR_FUNCION_ID_FUNCIONBUTACA
@idFuncionButaca int
as
begin
select f.id_funcion,f.id_pelicula,f.fecha_hora,f.id_formato,f.id_sala 
from Funciones f join Funciones_Butacas FB on FB.id_funcion=f.id_funcion where FB.id_funcion_butaca=@idFuncionButaca
end




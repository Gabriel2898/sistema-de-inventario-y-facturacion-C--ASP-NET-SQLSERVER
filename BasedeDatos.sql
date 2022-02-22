create database sistemadefacturacion 
go 
use sistemadefacturacion
go
-- create TABLE dtpaises(idpais int identity(1,1) primary key, pais nchar(50))

--insert into dtpaises values('Peru')
--insert into dtpaises values('Mexico')
--insert into dtpaises values('Colombia')
--insert into dtpaises values('Bolivia')
--insert into dtpaises values('Ecuador')
--insert into dtpaises values('Argentina')
--insert into dtpaises values('chile')

--create procedure usp_listarPaises
--as
--begin


--select idpais, pais from dtpaises

--end

/**************************************************/

-- create TABLE dtmoneda(idmoneda int identity(1,1) primary key, moneda nchar(10))

--insert into dtmoneda values('S/')
--insert into dtmoneda values('$')

--create procedure usp_listarMoneda
--as
--begin


--select idmoneda, moneda from dtmoneda

--end

--/**************************************************/

-- create TABLE dttimpuestos(idtimpuestos int identity(1,1) primary key, impuestos nchar(10))

--insert into dttimpuestos values('IGV')
--insert into dttimpuestos values('IVA')

--create procedure usp_listarTImpuestos
--as
--begin


--select idtimpuestos, impuestos from dttimpuestos

--end


--/**************************************************/

-- create TABLE dtpimpuestos(idpimpuestos int identity(1,1) primary key, pimpuestos int)

--insert into dtpimpuestos values(18)
--insert into dtpimpuestos values(5)
--insert into dtpimpuestos values(23)

--create procedure usp_listarPImpuestos
--as
--begin


--select idpimpuestos, pimpuestos from dtpimpuestos

--end

/*************************************************************/


--create table dtempresas(idempresa int identity(1,1) primary key, razonsocial nchar(100), ruc nchar(20), email nchar(100), idpais int,
--idmoneda int, vendeconimpuestos int, tipoimpuesto int, idporcimpuestos int, direccion varchar(max), imagen varchar(max), proyecto nchar(30)
-- ,status int, fregistro datetime)

/*El truncate es para eliminar todo el contenido de la tabla*/
--truncate table dtempresas

--create procedure usp_validarRegistroEmpresa
--(
--@razonsocial nchar(100),
--@ruc nchar(20),
--@email nchar(100)
--)
--as
--begin

--if not exists(select * from dtempresas where razonsocial = @razonsocial)
--begin

--if not exists(select * from dtempresas where ruc = @ruc)
--begin

--if not exists(select * from dtempresas where email = @email)
--begin

--select 'ok' response

--end
--else
--begin

--select 'El email ya se encuentra registrado' response

--end
--end
--else
--begin

--select 'El ruc ya se encuentra registrado' response

--end
--end
--else
--begin

--select 'La razon social ya se encuentra registrada' response

--end


--end

-- select * from dtempresas

--truncate table dtempresas

/**************************************************************/

--create procedure usp_insertarEmpresa
--(

--@razonsocial nchar(100),
--@ruc nchar(20),
--@email nchar(100),
--@idpais int,
--@idmoneda int,
--@direccion varchar(max),
--@idimpuesto int,
--@idporcentaje int,
--@vendeimpuestos int,
--@filename varchar(max),
--@proyecto nchar(30)

--)
--as
--begin

--if	not exists(select * from dtempresas where ruc = @ruc)
--begin

--insert into dtempresas values(@razonsocial ,
--@ruc,
--@email,
--@idpais ,
--@idmoneda ,
--@vendeimpuestos ,
--@idimpuesto ,
--@idporcentaje,
--@direccion ,
--@filename,
--@proyecto,
--1,
--getdate())


--select 'ok' response

--end
--else
--begin


--select 'La empresa ya se encuentra registrada' response

--end
--end



create table dtproveedores(
idproveedor int primary key identity(1,1),
ruc nchar(13),
razonsocial nchar(200),
telefono nchar(50),
email nchar(200),
direccion varchar( max),
rucempresa nchar(20),
status int)

create procedure usp_registrarProveedor(
@ruc nchar(13),
@razonsocial nchar(200),
@telefono nchar(50),
@email nchar(200),
@direccion varchar( max),
@rucempresa nchar(20)
)
as
begin
if not exists(select * from dtproveedores where ruc=@ruc and rucempresa=@rucempresa)
begin
if not exists(select * from dtproveedores where ruc=@ruc and rucempresa=@rucempresa)
begin
if not exists(select * from dtproveedores where ruc=@ruc and rucempresa=@rucempresa)
begin
insert into dtproveedores values (@ruc, @razonsocial,@telefono,@email,@direccion,@rucempresa,1)

select 'ok' response
end
else
begin

select 'El email del proveedor ya se encuentra registrado' response
end

end
else
begin

select 'La razon social del proveedor ya se encuentra registrado' response
end

end
else
begin

select 'El ruc del proveedor ya se encuentra registrado' response
end
end


create procedure usp_listarProveedores(
@rucempresa nchar(20)
)
as 
begin
select idproveedor, LTRIM(RTRIM(ruc)) ruc, LTRIM(RTRIM(razonsocial)) razonsocial,LTRIM(RTRIM(telefono)) telefono, LTRIM(RTRIM(email)) email, LTRIM(RTRIM(direccion)) direccion, status from dtproveedores
end
/*activar proveedor*/
create procedure usp_activarProveedor
(
@idprov int,
@rucempresa nchar(20)
)
as
begin


if exists(Select * from dtproveedores  where rucempresa = @rucempresa and idproveedor = @idprov)
begin
update dtproveedores set status = 1 where rucempresa = @rucempresa and idproveedor = @idprov

select 'ok' response

end
else
begin

select 'No se pudo activar al proveedor' response

end
end

/*desactivar proveedor*/
create procedure usp_desactivarProveedor
(
@idprov int,
@rucempresa nchar(20)
)
as
begin 
if exists(Select * from dtproveedores where rucempresa=@rucempresa and idproveedor=@idprov )
begin
update dtproveedores set status=0 where rucempresa=@rucempresa and idproveedor=@idprov
select 'ok' response 
end
else
begin
select 'no se pudo desactivar al proveedor' response
end


end

/*eliminar proveedor*/

create procedure usp_eliminarProveedor
(
@idprov int,
@rucempresa nchar(20)
)
as
begin


if exists(Select * from dtproveedores  where rucempresa = @rucempresa and idproveedor = @idprov)
begin

delete dtproveedores where rucempresa = @rucempresa and idproveedor = @idprov

select 'ok' response

end
else
begin

select 'No se pudo activar al proveedor' response

end
end

/*obtener editar proveedor*/
create procedure usp_obteditarProveedor
(
@idprov int
)
as
begin


if exists(select * from dtproveedores where idproveedor = @idprov)
begin

select idproveedor,RTRIM(LTRIM(ruc))ruc, RTRIM(LTRIM(razonsocial))razonsocial,
RTRIM(LTRIM(telefono))telefono, RTRIM(LTRIM(email))email, RTRIM(LTRIM(direccion))direccion,
'ok'response
 from dtproveedores where idproveedor = @idprov



end
else
begin

select 'El proveedor no existe' response 

end



end


/*editar proveedor*/
create procedure usp_editarProveedor
(
@idprov int,
@ruc nchar(20),
@razonsocial nchar(200),
@telefono nchar(50),
@email nchar(200),
@direccion varchar(max),
@rucempresa nchar(20)
)
as
begin


if not exists(select * from dtproveedores where ruc = @ruc and rucempresa = @rucempresa and idproveedor != @idprov)
begin

if not exists(select * from dtproveedores where razonsocial = @razonsocial and rucempresa = @rucempresa and idproveedor != @idprov)
begin

if not exists(select * from dtproveedores where email = @email and rucempresa = @rucempresa and idproveedor != @idprov)
begin


update dtproveedores set ruc= @ruc, razonsocial = @razonsocial, telefono= @telefono,
email =@email,  direccion = @direccion where idproveedor = @idprov

select 'ok' response

end
else
begin

select 'El email del proveedor ya se encuentra resgistrado' response



end

end
else
begin

select 'La Razon Social del proveedor ya se encuentra resgistrado' response



end

end
else
begin

select 'El ruc del proveedor ya se encuentra resgistrado' response



end



end
/**********************************/
exec usp_calcularPventaSinImpuestos 1700.50, 5.4
alter procedure usp_calcularPventaSinImpuestos
(
@pcosto decimal(18,2),
@ganancia decimal(18,2)
)
as
begin

declare @totala decimal(18,2)
declare @totalb decimal(18,2)

select @totala = (@ganancia/100);
select @totalb = @pcosto + (@pcosto*@totala)

select @totalb as pventa

end


/******************************************/

create table dtdepartamentos(iddepartamento int identity(1,1) primary key,
  departamento nchar(250),rucempresa  nchar(20),  status int)

  insert into dtdepartamentos values('Laptops', 1)
   insert into dtdepartamentos values('Impresoras', 1)
    insert into dtdepartamentos values('Gaseosas', 1)
	 insert into dtdepartamentos values('Lacteos', 1)
	 select * from dtdepartamentos

/*******************************************************/
create procedure usp_ListarDepartamentos
as
begin

select iddepartamento, LTRIM(RTRIM(departamento)) departamento from dtdepartamentos where status = 1

end

/********************************************************/
create table dtproductos(idproducto int identity(1,1) primary key,
  tipo int, codbarra nchar(50), descripcion varchar(max), tproduct int, pcosto decimal(18,2), ganancia int,
  pventa decimal(18,2), pmayoreo decimal(18,2), apartir int, iddepart int, existencia int,
  minexisten int, fvenci date, faplica int,  status int , rucempresa nchar(20))
/*******************************************************/

create procedure usp_guardarProduct
(
@rucempresa nchar(20),
@tipo int,
@codbarra nchar(50),
@desc varchar(max),
@tproduct int,
@pcosto decimal(18,2),
@ganancia decimal(18,2),
@pventa decimal(18,2),
@pmayoreo decimal(18,2),
@apartir int,
@sldepart int,
@existen int,
@minexisten int,
@fvenci nchar(50),
@faplica int
)     
as
begin

declare @fvencimiento date

if @tipo = 1
begin


if not exists(select * from dtproductos where  codbarra = @codbarra and rucempresa = @rucempresa)
begin

if not exists(select * from dtproductos where  descripcion = @desc and rucempresa = @rucempresa)
begin


if @fvenci = ''
begin
select @fvencimiento =  getdate();

end
else
begin

select @fvencimiento =  cast(@fvenci as date);
end

insert into dtproductos values(@tipo,@codbarra,@desc,@tproduct,@pcosto,
@ganancia,@pventa,@pmayoreo,@apartir,@sldepart,@existen,@minexisten, @fvencimiento, @faplica, 1, @rucempresa)

select 'ok'response


end
else
begin

select 'La descripción ya se encuentra registrado' response

end
end
else
begin

select 'El codigo de barras ya se encuentra registrado' response


end


end

if	@tipo = 2
begin

if not exists(select * from dtproductos where  descripcion = @desc and rucempresa = @rucempresa)
begin


if @fvenci = ''
begin
select @fvencimiento =  getdate();

end
else
begin

select @fvencimiento =  cast(@fvenci as datetime);
end

insert into dtproductos values(@tipo,@codbarra,@desc,@tproduct,0,
100,@pventa,0,0,@sldepart,0,0, @fvencimiento, 1, 1, @rucempresa)

select 'ok'response


end
else
begin

select 'La descripción ya se encuentra registrado' response

end

end

end       

/*******************************************************/}
create procedure usp_listarProductos--'10461793784'
(
@rucempresa nchar(20)
)
as
begin

select top 1000 ROW_NUMBER() OVER(ORDER BY a.idproducto ASC) AS Row,  a.idproducto
,case when a.tipo = 1 then 'Bien' else 'Servicio' end tipo
,case when a.tproduct = 1 then 'Unid/Caja' else 'Kilos/Gramos' end tproduct
,a.codbarra ,a.descripcion ,b.departamento ,a.pcosto
,a.pventa , a.pmayoreo, a.existencia ,a.minexisten,
case when a.faplica = 1 then 'No Aplica' else cast(a.fvenci as nchar) end fvenci
,a.status
from dtproductos a
inner join dtdepartamentos b on a.iddepart = b.iddepartamento
where a.rucempresa = @rucempresa


end    
/***************************************************************/
create procedure usp_buscarProducto
(
@letra varchar(200),
@rucempresa nchar(20)
)
as
begin



select top 30 ROW_NUMBER() OVER(ORDER BY a.idproducto ASC) AS Row, a.idproducto
,case when a.tipo = 1 then 'Bien' else 'Servicio' end tipo
,case when a.tproduct = 1 then 'Unid/Caja' else 'Kilos/Gramos' end tproduct
,a.codbarra ,a.descripcion ,b.departamento ,a.pcosto
,a.pventa , a.pmayoreo, a.existencia ,a.minexisten,
case when a.faplica = 1 then 'No Aplica' else cast(a.fvenci as nchar) end fvenci
,a.status
from dtproductos a
inner join dtdepartamentos b on a.iddepart = b.iddepartamento
where a.descripcion LIKE '%'+@letra+'%' AND a.rucempresa = @rucempresa
union
select top 30 ROW_NUMBER() OVER(ORDER BY a.idproducto ASC) AS Row, a.idproducto
,case when a.tipo = 1 then 'Bien' else 'Servicio' end tipo
,case when a.tproduct = 1 then 'Unid/Caja' else 'Kilos/Gramos' end tproduct
,a.codbarra ,a.descripcion ,b.departamento ,a.pcosto
,a.pventa , a.pmayoreo, a.existencia ,a.minexisten,
case when a.faplica = 1 then 'No Aplica' else cast(a.fvenci as nchar) end fvenci
,a.status
from dtproductos a
inner join dtdepartamentos b on a.iddepart = b.iddepartamento
where a.codbarra LIKE '%'+@letra+'%' AND a.rucempresa = @rucempresa



end
/**************************************************************/
create procedure usp_buscarProductodepart
(
@iddepartamento int,
@rucempresa nchar(20)
)
as
begin

if @iddepartamento <> 0
begin
select top 30 ROW_NUMBER() OVER(ORDER BY a.idproducto ASC) AS Row, a.idproducto
,case when a.tipo = 1 then 'Bien' else 'Servicio' end tipo
,case when a.tproduct = 1 then 'Unid/Caja' else 'Kilos/Gramos' end tproduct
,a.codbarra ,a.descripcion ,b.departamento ,a.pcosto
,a.pventa , a.pmayoreo, a.existencia ,a.minexisten,
case when a.faplica = 1 then 'No Aplica' else cast(a.fvenci as nchar) end fvenci
,a.status
from dtproductos a
inner join dtdepartamentos b on a.iddepart = b.iddepartamento
where a.iddepart = @iddepartamento AND a.rucempresa = @rucempresa
end

if @iddepartamento = 0
begin
select top 30 ROW_NUMBER() OVER(ORDER BY a.idproducto ASC) AS Row, a.idproducto
,case when a.tipo = 1 then 'Bien' else 'Servicio' end tipo
,case when a.tproduct = 1 then 'Unid/Caja' else 'Kilos/Gramos' end tproduct
,a.codbarra ,a.descripcion ,b.departamento ,a.pcosto
,a.pventa , a.pmayoreo, a.existencia ,a.minexisten,
case when a.faplica = 1 then 'No Aplica' else cast(a.fvenci as nchar) end fvenci
,a.status
from dtproductos a
inner join dtdepartamentos b on a.iddepart = b.iddepartamento
where a.rucempresa = @rucempresa 

end

end
  
 /************************************************/

  create procedure usp_eliminarProducto
  (
  @idproducto int
  )
  as
  begin

  delete dtproductos where idproducto = @idproducto
  
  select 'ok' response 
  end

   /************************************************/

  create procedure usp_obtTipoMoneda --'10461793784' 
  (
  @rucempresa nchar(30)
  )
  as
  begin


  select RTRIM(LTRIM(b.Moneda)) Moneda from dtempresas a
  inner join dtmoneda b on a.idmoneda = b.idmoneda
  where a.ruc = @rucempresa



  end
  /******************************************************/
  create procedure usp_obtEditarProducto
  (
  @idproducto int
  )
  as
  begin

  select a.idproducto, a.tipo, RTRIM(LTRIM(a.codbarra)) codbarra, RTRIM(LTRIM(a.descripcion)) descripcion
  ,a.tproduct sevende, a.pcosto,a.ganancia,a.pventa, a.pmayoreo, a.apartir, b.iddepartamento, RTRIM(LTRIM(b.departamento))departamento,
  a.existencia, a.minexisten, RTRIM(LTRIM(cast(a.fvenci as nchar))) fvenci, a.faplica
   from dtproductos a
   inner join dtdepartamentos b on a.iddepart = b.iddepartamento   
   where idproducto = @idproducto


  end



 /********************************************************/
 create procedure usp_editarProduct
(
@idproducto int,
@rucempresa nchar(20),
@tipo int,
@codbarra nchar(50),
@desc varchar(max),
@tproduct int,
@pcosto decimal(18,2),
@ganancia decimal(18,2),
@pventa decimal(18,2),
@pmayoreo decimal(18,2),
@apartir int,
@sldepart int,
@existen int,
@minexisten int,
@fvenci nchar(50),
@faplica int
)     
as
begin

declare @fvencimiento date

if @tipo = 1
begin


if not exists(select * from dtproductos where  codbarra = @codbarra and rucempresa = @rucempresa and idproducto != @idproducto)
begin

if not exists(select * from dtproductos where  descripcion = @desc and rucempresa = @rucempresa and idproducto != @idproducto)
begin


if @fvenci = ''
begin
select @fvencimiento =  getdate();

end
else
begin

select @fvencimiento =  cast(@fvenci as date);
end

update dtproductos set tipo = @tipo, codbarra =@codbarra, descripcion =  @desc, tproduct = @tproduct, pcosto = @pcosto,
ganancia = @ganancia, pventa =@pventa, pmayoreo =  @pmayoreo, apartir = @apartir,
iddepart =  @sldepart, existencia = @existen,minexisten = @minexisten, fvenci =@fvencimiento, faplica = @faplica, status = 1,
rucempresa= @rucempresa
where idproducto = @idproducto

select 'ok'response


end
else
begin

select 'La descripción ya se encuentra registrado' response

end
end
else
begin

select 'El codigo de barras ya se encuentra registrado' response


end


end

if	@tipo = 2
begin

if not exists(select * from dtproductos where  descripcion = @desc and rucempresa = @rucempresa and idproducto != @idproducto)
begin


if @fvenci = ''
begin
select @fvencimiento =  getdate();

end
else
begin

select @fvencimiento =  cast(@fvenci as date);
end

update dtproductos set  tipo = @tipo,codbarra = @codbarra, descripcion = @desc, tproduct = @tproduct, pcosto=0,
ganancia = 100,pventa=@pventa, pmayoreo =  0, apartir = 0,
iddepart =  @sldepart, existencia = 0,minexisten = 0, fvenci =@fvencimiento, faplica = 1, status = 1,
rucempresa= @rucempresa where idproducto = @idproducto



select 'ok'response


end
else
begin

select 'La descripción ya se encuentra registrado' response

end

end

end      


/****************************************************/
create procedure usp_guardarDepartamento
(
@departamento nchar(100),
@rucempresa nchar(20)
)
as
begin


if not exists(select * from dtdepartamentos where departamento =@departamento and rucempresa = @rucempresa)
begin

insert into dtdepartamentos values(@departamento,@rucempresa, 1)

select 'ok' response

end
else
begin

select 'El departamento ya se encuentra registrado' response

end


end    



/*********************************************/

create procedure usp_listadepartamentos --'10461793784'
(
@rucempresa nchar(20)
)
as
begin


select top 1000 ROW_NUMBER() OVER(ORDER BY iddepartamento ASC) AS Row, iddepartamento
,LTRIM(RTRIM(departamento))departamento, status
from dtdepartamentos 
where rucempresa  = @rucempresa


end

/**************************************/

create procedure usp_eliminarDepartamento
(
@iddepartamento int
)
as
begin


delete dtdepartamentos where iddepartamento = @iddepartamento

select 'ok' response

end

--/*********************************************/

create procedure usp_obtEditarDepartamento 
(

@iddepartamento int
)
as
begin


select iddepartamento, RTRIM(LTRIM(departamento)) departamento from dtdepartamentos where iddepartamento =  @iddepartamento

end


/********************************************/


create procedure usp_editarDepartamento
(
@iddepartamento int,
@departamento nchar(100),
@rucempresa nchar(20)
)
as
begin


if not exists(select * from dtdepartamentos where departamento =@departamento and iddepartamento != @iddepartamento and rucempresa = @rucempresa)
begin

update dtdepartamentos set departamento =  @departamento where iddepartamento = @iddepartamento

select 'ok' response

end
else
begin

select 'El departamento ya se encuentra registrado' response

end


end    


/********************************************/
-- exec usp_obtlistaProducto 'sa', '10461793784'

create procedure usp_obtlistaProducto
(
@letra varchar(200),
@rucempresa nchar(20)
)
as
begin


select  a.idproducto, a.descripcion, RTRIM(LTRIM(c.moneda)) +' '+ cast(a.pventa as nchar) precioventa
from dtproductos a
inner join dtempresas b on b.ruc = a.rucempresa
inner join dtmoneda c on c.idmoneda = b.idmoneda
where a.descripcion LIKE '%'+@letra+'%' AND a.rucempresa = @rucempresa

union

select  a.idproducto, a.descripcion, RTRIM(LTRIM(c.moneda)) +' '+ cast(a.pventa as nchar) precioventa
from dtproductos a
inner join dtempresas b on b.ruc = a.rucempresa
inner join dtmoneda c on c.idmoneda = b.idmoneda
where a.codbarra =@letra AND a.rucempresa = @rucempresa

end

/********************************************/

create table dtpromociones(idpromo int identity(1,1) primary key,
 promocion varchar(max), idproducto  int, finicio date, ffin date, status int, rucempresa nchar(20))

create procedure usp_guardarPromocion
(
@idproducto int,
@promocion varchar(max),
@finicio date,
@ffin date,
@rucempresa nchar(20)
)
as
begin

if not exists(select * from dtpromociones where promocion = @promocion and status = 1 and rucempresa = @rucempresa)
begin

if not exists(select * from dtpromociones where idproducto = @idproducto and status = 1 and rucempresa = @rucempresa)
begin

insert into dtpromociones values(@promocion,@idproducto, @finicio,@ffin, 1, @rucempresa)

select 'ok' response

end
else
begin

select 'El producto ya tiene una promocion activa' response

end
end
else
begin

select 'El nombre de la promoción ya esta registrado' response

end

end


/*********************************************************************/

create procedure usp_listaPromociones --'10461793784'
(
@rucempresa nchar(20)
)
as
begin

declare @f date = getdate();
update dtpromociones set status = 0 where 
ffin < @f

select top 1000 ROW_NUMBER() OVER(ORDER BY a.idpromo ASC) AS Row, a.idpromo idpromocion
,LTRIM(RTRIM(a.promocion))nombrePromocion, b.descripcion descProducto, b.codbarra, b.pventa
,cast(finicio as nchar(20)) finicio, cast(ffin as nchar(20)) ffin, a.status
from dtpromociones a
inner join dtproductos b on b.idproducto = a.idproducto
where a.rucempresa  = @rucempresa

end

/******************************************************/

create procedure usp_eliminarPromociones
(
@idpromocion int
)
as
begin


delete dtpromociones where idpromo = @idpromocion

select 'ok' response


end


/********************************************/

create procedure usp_obtPromociones 
(
@rucempresa nchar(20),
@idpromo int
)
as
begin


select a.idpromo idpromocion
,LTRIM(RTRIM(a.promocion))nombrePromocion, b.descripcion descProducto,b.idproducto,  RTRIM(LTRIM(d.moneda)) +' '+ cast(b.pventa as nchar) pventa
,LTRIM(RTRIM(cast(finicio as nchar(20)))) finicio, LTRIM(RTRIM(cast(ffin as nchar(20)))) ffin, 'ok' response
from dtpromociones a
inner join dtproductos b on b.idproducto = a.idproducto
inner join dtempresas c on c.ruc = a.rucempresa
inner join dtmoneda d on d.idmoneda = c.idmoneda
where a.rucempresa  = @rucempresa and a.idpromo = @idpromo


end


/*******************************************************/

create procedure usp_editarPromocion
(
@idpromo int,
@promocion varchar(max),
@finicio date,
@ffin date,
@rucempresa nchar(20)
)
as
begin

if not exists(select * from dtpromociones where promocion = @promocion and idpromo <> @idpromo and rucempresa = @rucempresa)
begin

update  dtpromociones set  promocion = @promocion, finicio = @finicio, ffin = @ffin
where idpromo = @idpromo

select 'ok' response

end
else
begin

select 'El nombre de la promoción ya esta registrado' response

end

end


/***************************************************************************/
create table dtinventario(idinventario int identity(1,1) primary key, idproducto int, pventa decimal(18,2),
pcosto decimal(18,2), pmayore decimal(18,2), apartir int, cantagregada int,
 idempleado int, rucempresa nchar(20), fecharegistro datetime)


/************************************************************/
create procedure usp_AgregarInventario
(
@idproducto int,
@idempleado int,
@cantexisten int,
@rucempresa nchar(20)
)
as
begin

declare @pventa decimal(18,2)
declare @pcosto decimal(18,2)
declare @pmayore decimal(18,2)
declare @aparti int
declare @existenanterior int
declare @existenactual int

declare @tipo int

select @tipo = tipo, @pventa = pventa, @pcosto = pcosto, @pmayore = pmayoreo, @aparti = apartir, @existenanterior = existencia
 from dtproductos where idproducto = @idproducto

 if	@tipo = 1
 begin

insert into dtinventario values(@idproducto,@pventa,@pcosto,@pmayore,@aparti,@cantexisten,@idempleado,@rucempresa, getdate())


select @existenactual = @existenanterior + @cantexisten

update dtproductos set existencia = @existenactual where idproducto = @idproducto

select 'ok' response
end


if @tipo = 2
begin

select 'No se puede agregar al inventario un producto de servicio.' response

end

end
/*********************************************************************/


/*********************************************************************/

/*****  ESTAS TABLAS Y STORED SON DE OTRA BASE DE DATOS CREADA. LA DB SE LLAMA ACCESOS ***********/

create database ACCESOS
go 
use ACCESOS
go
--create table dtusuarios_factur(idusuario int identity(1,1) primary key, username nchar(200), dni nchar(10),
-- email nchar(100),usuario nchar(50), contrasena varchar(max), cargo nchar(50), cantaccesos int,
--  ruc nchar(20), proyecto nchar(30),status int, fregistro datetime)

--  create table dtlicencias(idlicencia int identity(1,1) primary key,  ruc nchar(20), email nchar(100),
--  fincio datetime, ffin datetime, proyecto nchar(30), cantuser int, validateemail int, status int, fregistro datetime)


create table dtcargo_factur(idcargo int identity(1,1) primary key, cargo nchar(100),status int)
insert into dtcargo_factur values ('Vendedor/Caja',1);
insert into dtcargo_factur values ('Almacenero',1);
insert into dtcargo_factur values ('Administrador',1);

/*******cargos*////

create procedure ups_listarCargosEmpleado
as 
begin
select idcargo,cargo from dtcargo_factur where status=1
end

--create procedure usp_insertarUserAdminEmpresa

--@ruc nchar(20),
--@email nchar(100),
--@username nchar(200),
--@usuario nchar(50),
--@contrasena varchar(max),
--@cargo nchar(20),
--@cantuser int,
--@proyecto nchar(30)
--as
--begin

---- select * from dtlicencias


--if	not exists(select * from dtusuarios_factur where usuario = @usuario and ruc = @ruc)
--begin

--insert into dtusuarios_factur values(@username,'00000000',@email,@usuario,@contrasena,@cargo,0,@ruc,@proyecto, 0, getdate())

--declare @ffin datetime

--select @ffin = DATEADD(DAY,16,GETDATE())

--insert into dtlicencias values(@ruc,@email,getdate(), @ffin,@proyecto, 0,0,0, getdate())

--select 'ok' response


--end
--else
--begin


--select 'Usuario ya se encuentra registrado' response

--end



--end

 select * from [sistemadefacturacion].[dbo].[dtempresas]
select * from dtusuarios_factur
 select * from dtlicencias

-- truncate table dtempresas

/************************************************************/

--alter procedure usp_activarCuenta '1723793723'
--(
--@ruc nchar(20)
--)
--as
--begin


--if exists(select *  from dtlicencias where ruc = @ruc and validateemail = 0 )
--begin

--declare @ffin datetime

--select @ffin = DATEADD(DAY,16,GETDATE())

--update dtlicencias set validateemail = 1, status = 1, fincio = getdate() , ffin = @ffin where ruc = @ruc
--update dtusuarios_factur set status = 1 where ruc = @ruc

--select 'CUENTA ACTIVADA CORRECTAMENTE' response

--end
--else
--begin


--select 'LA CUENTA YA ESTA ACTIVADA' response


--end



--end


/********************************************************/


--create table dtusertokens(idusertoken int identity(1,1) primary key,
--  usertokens nchar(50), passworktokens nchar(100), proyecto nchar(50), status int)

--create procedure usp_ValidarUserToken
--(
--@usertoken nchar(50),
--@passwordtoken nchar(100),
--@proyecto nchar(50)
--)
--as
--begin

--if	exists(select * from dtusertokens where  usertokens = @usertoken and passworktokens =  @passwordtoken and proyecto = @proyecto and status = 1)
--begin

--select 'ok' response

--end
--else
--begin

--select 'Usuario o contraseña del token no existen' response

--end


--end
/*************************************/


alter procedure usp_ValidarAccesos --'17237936810','admin','6f3ddc9ed3948b0a844d443a42c0ad387f32dacee0087caa15292cd2038d3961', 'FACTUR'
(
@ruc nchar(20),
@user nchar(50),
@password varchar(max),
@proyecto nchar(20)
)
as
begin

-- select * from dtlicencias

if exists(Select * from dtlicencias where validateemail = 1 and ruc = @ruc)
begin

update dtlicencias set status = 0 where ruc = @ruc and ffin < getdate()


if exists(Select * from dtlicencias where status = 1 and ruc = @ruc)
begin

if exists(select * from dtusuarios_factur where status = 1 and ruc = @ruc and usuario = @user and contrasena = @password)
begin

select 'ok' response, RTRIM(LTRIM(username))username, RTRIM(LTRIM(cargo))cargo, cantaccesos, RTRIM(LTRIM(ruc))ruc,
m.ventas,m.caja,m.clientes,m.compras,m.productos,m.invetarios, m.proveedores,m.dashboard, m.usuarios, m.empresa, m.configuraciones
from dtusuarios_factur u
inner join dtmoduloapp_factur m on m.idusuario = u.idusuario
where status = 1 and ruc = @ruc and usuario = @user and contrasena = @password and cargo <> 'superadmin'

 union
 select 'ok' response, RTRIM(LTRIM(username))username, RTRIM(LTRIM(cargo))cargo, cantaccesos, RTRIM(LTRIM(ruc))ruc,
  0 ventas,0 caja,0 clientes, 0 compras,0 productos,0 invetarios, 0 proveedores,0 dashboard, 0 usuarios, 0 empresa, 0 configuraciones
from dtusuarios_factur u
--inner join dtmoduloapp_factur m on m.idusuario = u.idusuario
where status = 1 and ruc = @ruc and usuario = @user and contrasena = @password and cargo = 'superadmin'


end
else
begin

select 'Usuario o contraseña incorrectos' response, ''username, ''cargo, 0 cantaccesos, '' ruc,
0 ventas,0 caja,0 clientes, 0 compras,0 productos,0 invetarios, 0 proveedores,0 dashboard, 0 usuarios, 0 empresa, 0 configuraciones


end


end
else
begin

update dtusuarios_factur set status = 0 where ruc = @ruc 

select 'Licencia vencida o la empresa no esta registrada' response, '' username, ''cargo, 0 cantaccesos, '' ruc,
0 ventas,0 caja,0 clientes, 0 compras,0 productos,0 invetarios, 0 proveedores,0 dashboard, 0 usuarios, 0 empresa, 0 configuraciones


end


end
else
begin

select 'No a validado el correo o la empresa no esta registrada' response, '' username, '' cargo, 0 cantaccesos, '' ruc,
0 ventas,0 caja,0 clientes, 0 compras,0 productos,0 invetarios, 0 proveedores,0 dashboard, 0 usuarios, 0 empresa, 0 configuraciones

end

end


/*****************************************************************/


--alter procedure usp_validarCantUsers '17237936810'
--(
--@ruc nchar(20)
--)
--as
--begin


--if exists(select *  from dtlicencias where ruc = @ruc and status = 1)
--begin

--declare @cant int
--declare @cantlogin int

--select @cant = cantuser from dtlicencias where ruc = @ruc

--select @cantlogin = count(*) from dtusuarios_factur where ruc = @ruc and status = 1 and cargo <> 'superadmin'

--if @cant > @cantlogin
--begin

--select 'ok' response


--end
--else
--begin

--select 'error' response

--end


--end
--else
--begin

--select 'el ruc no existe' response


--end



--end




/******************************************************/

--create table dtmoduloapp_factur(idmodulos int identity(1,1) primary key,
--  idusuario int, ventas int, caja int, clientes int, compras int, productos int,
--  inventarios int, proveedores int, dashboard int, usuarios int, empresa int, configuraciones int)

--alter procedure usp_registrarUsuario
--(
--@ruc nchar(20),
--@nombre nchar(200),
--@dni nchar(10),
--@email varchar(max),
--@user nchar(50),
--@password varchar(max),
--@slcargo nchar(50),

--/* Accesos */

--@ventas int,
--@caja int,
--@clientes int,
--@compras int,
--@productos int,
--@inventario int,
--@proveedor int,
--@dashboard int,
--@usuarios int,
--@empresa int,
--@configuraciones int
--)
--as
--begin 

--if not exists(select * from dtusuarios_factur where dni = @dni and ruc = @ruc and proyecto ='Factur')
--begin

--if not exists(select * from dtusuarios_factur where email = @email and ruc = @ruc and proyecto ='Factur')
--begin

--if not exists(select * from dtusuarios_factur where usuario = @user and ruc = @ruc and proyecto ='Factur')
--begin


--declare @countaccesos int

--select @countaccesos = SUM(@ventas + @caja + @clientes + @compras + @productos + @inventario + @proveedor + @dashboard +
--@usuarios + @empresa + @configuraciones )


--insert into dtusuarios_factur values(@nombre,@dni,@email,@user,@password, @slcargo, @countaccesos, @ruc, 'Factur', 1, getdate())

--declare @idusuario int

--select @idusuario = idusuario from dtusuarios_factur where dni = @dni and ruc = @ruc and proyecto ='Factur'


--insert into dtmoduloapp_factur values(@idusuario,@ventas, @caja, @clientes,@compras,@productos,
-- @inventario, @proveedor, @dashboard,@usuarios, @empresa,@configuraciones)


-- select 'ok' response

--end
--else
--begin

--select 'El usuario ya existe' response

--end
--end
--else
--begin

--select 'El email del usuario ya existe' response

--end
--end
--else
--begin

--select 'El dni del usuario ya existe' response



--end




--end


-- select * from dtmoduloapp_factur


/*****************************************************/



create procedure usp_listarEmpleados
(
@ruc nchar(20),
@cargo nchar(50)

)
as
begin

if @cargo = 'superadmin'
begin

select idusuario, username, dni, usuario, email, cargo, status  
from dtusuarios_factur where ruc = @ruc

end
else
begin

select idusuario, username, dni, usuario, email, cargo, status  
from dtusuarios_factur
where ruc = @ruc and cargo <> 'superadmin'

end


end


/*******************************************************/


create procedure usp_activarEmpleado
(
@iduser int,
@ruc nchar(20)
)
as
begin

declare @countusert int
declare @count int

select @countusert = count(*) from dtusuarios_factur where ruc = @ruc and status = 1 and cargo <> 'superadmin'
select @count = cantuser from dtlicencias where ruc= @ruc

if @countusert < @count
begin

update dtusuarios_factur set status = 1 where idusuario = @iduser
select 'ok' response


end
else
begin

select 'Ya supero la cantidad de usuarios permitidos' response

end



end

/****desactivar empleado*/
alter procedure usp_desactivarEmpleado
(
@iduser int,
@ruc nchar(20)
)
as
begin 
if exists(Select * from dtusuarios_factur where ruc=@ruc and idusuario=@iduser and cargo != 'superadmin')
begin
update dtusuarios_factur set status=0 where ruc=@ruc and idusuario=@iduser
select 'ok' response 
end
else
begin
select 'no se pudo desactivar al empleado' response
end


end

/*eliminar empleado*/
alter procedure usp_eliminarEmpleado
(
@iduser int,
@ruc nchar(20)
)
as
begin 
if exists(Select * from dtusuarios_factur where ruc=@ruc and idusuario=@iduser and cargo != 'superadmin')
begin
delete dtusuarios_factur where ruc=@ruc and idusuario=@iduser
select 'ok' response 
end
else
begin
select 'no se pudo eliminar al empleado' response
end


end

/*editar empleado*/
alter procedure usp_obteditarEmpleado
(
@iduser int,
@ruc nchar(20),
@cargosession nchar(50)
)
as
begin
if exists(Select * from dtusuarios_factur where ruc=@ruc and idusuario=@iduser and cargo != 'superadmin')
begin 
select a.idusuario,RTRIM(LTRIM(a.username))username,RTRIM(LTRIM(a.dni))dni,RTRIM(LTRIM(a.email))email,RTRIM(LTRIM(a.usuario))usuario,b.idcargo,RTRIM(LTRIM(b.cargo))cargo,c.ventas,c.caja,c.clientes,
c.compras,c.productos,c.invetarios,c.proveedores,c.dashboard,c.usuarios,c.empresa,c.configuraciones, 'ok'response
 from dtusuarios_factur a 
inner join dtcargo_factur b on b.cargo=a.cargo
inner join dtmoduloapp_factur c on c.idusuario=a.idusuario
where ruc=@ruc and a.idusuario=@iduser
end
else
begin

select 'no se encontro al usuario'response
 
end



end

/************************************/

alter procedure usp_editarUsuario
(
@iduser int,
@ruc nchar(20),
@nombre nchar(200),
@dni nchar(10),
@email varchar(max),
@user nchar(50),
@password varchar(max),
@slcargo nchar(50),

/* Accesos */

@ventas int,
@caja int,
@clientes int,
@compras int,
@productos int,
@inventario int,
@proveedor int,
@dashboard int,
@usuarios int,
@empresa int,
@configuraciones int
)
as
begin 

if not exists(select * from dtusuarios_factur where dni = @dni and ruc = @ruc and proyecto ='Factur' and idusuario <> @iduser)
begin

if not exists(select * from dtusuarios_factur where email = @email and ruc = @ruc and proyecto ='Factur'and idusuario <> @iduser)
begin

if not exists(select * from dtusuarios_factur where usuario = @user and ruc = @ruc and proyecto ='Factur'and idusuario <> @iduser)
begin


declare @countaccesos int

select @countaccesos = SUM(@ventas + @caja + @clientes + @compras + @productos + @inventario + @proveedor + @dashboard +
@usuarios + @empresa + @configuraciones )

if @password != '0'
begin
update dtusuarios_factur set ruc=@ruc,username=@nombre,dni=@dni,email=@email,usuario=@user,contrasena= @password,cargo=@slcargo,cantaccesos=@countaccesos
where idusuario=@iduser
end
else
begin
update dtusuarios_factur set ruc=@ruc,username=@nombre,dni=@dni,email=@email,usuario=@user,cargo=@slcargo,cantaccesos=@countaccesos
where idusuario=@iduser
end



update dtmoduloapp_factur set ventas=@ventas, caja=@caja, clientes= @clientes,compras= @compras,productos= @productos,
 invetarios= @inventario, proveedores= @proveedor, dashboard= @dashboard,usuarios= @usuarios, empresa= @empresa,configuraciones= @configuraciones
 where idusuario=@iduser 


 select 'ok' response

end
else
begin

select 'El usuario ya existe' response

end
end
else
begin

select 'El email del usuario ya existe' response

end
end
else
begin

select 'El dni del usuario ya existe' response



end




end

--select * from dtmoduloapp_factur
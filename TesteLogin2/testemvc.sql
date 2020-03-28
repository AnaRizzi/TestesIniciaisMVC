create database TesteMVC
Use TesteMVC

create table Clientes(
id_cliente int primary key identity,
nome varchar(50),
email varchar(50),
data_cadastro datetime
)

select * from Clientes

insert into Clientes(nome, email, data_cadastro) values ('ana', 'ana@ana.com', '03-18-2020')
insert into Clientes(nome, email, data_cadastro) values ('andre', 'andre@andre.com', '03-15-2020')
insert into Clientes(nome, email, data_cadastro) values ('alguem', 'alguem@gmail.com', '03-20-2020')

create table Usuario(
usuario varchar(15) primary key,
senha varchar(15)
)

insert into Usuario values('ana', 'ana')
insert into Usuario values('admin', '1234567')

select * from Usuario

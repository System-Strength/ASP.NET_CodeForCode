create database db_CFC;

use db_CFC;

create table tbl_conta(
	id_usu int primary key auto_increment,
	user_login varchar(14) not null,
    rg_usu varchar(12) not null,
    senha_login varchar(14) not null
);
create table tbl_compra(
	cd_compra int not null primary key auto_increment,
	cpf_usu varchar(14), 
	end_usu varchar(50) not null,
    numCasa_usu int,
    blocoApa_usu varchar(10),
    formaPag_usu varchar(20)
);
drop table tbl_compra;
select * from tbl_compra;
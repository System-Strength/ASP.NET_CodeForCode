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
create table tbl_parceiro(
	cd_parc int not null primary key auto_increment,
    nm_parc varchar(50) not null,
    empresa_parc varchar(50) not null,
    cnpj_parc varchar(17) not null,
    email_parc varchar(40) not null,
    site_parc varchar(40),
    end_parc varchar(50),
    tel_parc varchar(30) not null,
    redeSocial_parc varchar(40),
    descr_parc varchar(2000)
);
select * from tbl_compra;
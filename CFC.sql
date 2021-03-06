create database db_CFC;

use db_CFC;

create table tbl_conta(
	id_usu int primary key auto_increment,
	user_login varchar(14) not null,
    rg_usu varchar(12) not null,
    senha_login varchar(14) not null
);

select * from tbl_conta;

create table tbl_categoria(
	cd_cat int primary key auto_increment,
    nm_cat varchar(50) not null
);

insert into tbl_categoria (nm_cat) values ("Café");
insert into tbl_categoria (nm_cat) values ("Chocolate");
insert into tbl_categoria (nm_cat) values ("MilkShake");
insert into tbl_categoria (nm_cat) values ("Sanduíche");
insert into tbl_categoria (nm_cat) values ("Cookies");
insert into tbl_categoria (nm_cat) values ("Hambúrguer");

select * from tbl_categoria;

create table tbl_cardapio(
	cd_prod int primary key auto_increment,
    img_prod mediumblob not null,
    nm_prod varchar(50) not null,
    preco_prod decimal(6, 2) not null,
	qntd_prod int not null,
    cat_prod varchar(50) not null,
    data_prod date
);

insert into tbl_cardapio (nm_prod, preco_prod, cat_prod, qntd_prod, img_prod) values ( "Expresso", "5.00", "Café", "1", "/expresso.jpg");

select * from tbl_cardapio;	

create table tbl_compra(
	cd_compra int primary key auto_increment,
	cpf_usu varchar(14), 
	end_usu varchar(50),
    numCasa_usu varchar(40),
    blocoApa_usu varchar(10),
    formaPag_usu varchar(20) not null
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
create table tbl_trabalheConosco(
	cd_usu int not null primary key auto_increment,
	nm_usu varchar(50) not null,
    tel_usu varchar(20) not null,
    email_usu varchar(40) not null
);

create table tbl_gerente(
	nm_ger varchar(50) not null,
    cpf_ger varchar(14) not null,
    senha_ger varchar(12)  primary key not null
);	

create table tbl_funcionario(
	id_func int primary key auto_increment,
    nm_func varchar(50) not null,
    cg_func varchar(50) not null,
    email_func varchar(40) not null,
    cpf_func varchar(14) not null,
    end_func varchar(50) not null,
    tel_func varchar(15) not null
);

select * from tbl_funcionario;
create database db_CFC;

use db_CFC;

create table tbl_conta(
	id_usu int primary key auto_increment,
	user_login varchar(14) not null,
    rg_usu varchar(12) not null,
    senha_login varchar(14) not null
);
select * from tbl_conta;
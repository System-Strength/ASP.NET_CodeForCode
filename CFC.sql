create database db_CFC;

use db_CFC;

create table tbl_conta(
	user_login varchar(14) not null,
    rg_usu varchar(12) not null primary key,
    senha_login varchar(14) not null,
    confimaSenha varchar(14) not null
);
select * from tbl_conta;
create database trabalho2;

-- drop database trabalho2;

use trabalho2;

create table per_perfil(
	per_id int not null auto_increment,
    per_tipo varchar(50) not null,
    constraint pk_per_perfil primary key (per_id)
);

create table usu_usuario(
	usu_id int not null auto_increment,
    usu_nome varchar(50) not null,
    usu_email varchar(50) not null,
    usu_senha text(50) not null,
    per_id int not null,
    constraint pk_usu_usuario primary key (usu_id),
    constraint fk_usu_per_id foreign key (per_id) references per_perfil (per_id)
);

create table pro_produto(
	pro_id int not null auto_increment,
    pro_nome varchar(50) not null,
    pro_preco double not null,
    constraint pk_pro_id primary key (pro_id)
);

create table ped_pedido(
	ped_id int not null auto_increment,
    ped_frete double,
    ped_status varchar(50) not null,
    pro_id int not null,
    constraint pk_ped_id primary key (ped_id),
    constraint fk_ped_pro_id foreign key (pro_id) references pro_produto (pro_id)
);

create table ite_item(
	ite_id int not null auto_increment,
    ite_quantidade int not null,
    ped_id int not null,
    constraint pk_ite_id primary key (ite_id),
    constraint fk_ite_ped_id foreign key (ped_id) references ped_pedido (ped_id)
);

create table usu_ped(
	usu_id int not null,
    ped_id int not null,
    constraint pk_usu_ped primary key (usu_id, ped_id),
    constraint fk_usu_ped_usu_id foreign key (usu_id) references usu_usuario (usu_id),
    constraint fk_usu_ped_ped_id foreign key (ped_id) references ped_pedido (ped_id)
);
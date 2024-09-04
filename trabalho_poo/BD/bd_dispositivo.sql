CREATE DATABASE gestao_vendas;
USE gestao_vendas;

create table dispositivo(
	Id integer primary key auto_increment,
    aliquota float,
    descricao varchar(255),
    status_dispositivo varchar(255)
);

insert into dispositivo (aliquota, descricao, status_dispositivo) values (2.00,'maquina da cielo','ativo'); 

SELECT * FROM dispositivo ORDER BY Id;
	
create  DATABASE  projetointegrado;
use projetointegrado

CREATE  TABLE Consulta(
    Idconsulta int PRIMARY KEY AUTOINCREMENT,
    NomeCompleto varchar(200) not null,
    Marcar date not NULL,
    Tipo varchar(300)NOT NULL ,
    Turno varchar(6) not null,
    Idade int(2) NOT NULL 
 );

CREATE TABLE login(
    Id int PRIMARY KEY AUTOINCREMENT,
    Nome varchar(200) not null,
    Login varchar(200)NOT NULL,
    Senha varchar(200) NOT NULL 
 );
 

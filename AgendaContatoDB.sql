CREATE DATABASE AgendaContatoDB;
GO
USE AgendaContatoDB;



CREATE TABLE Usuarios(
   Id_Usuario int identity not null primary key,
   Login varchar(50) not null,
   Senha varchar(30) not null,
   Nome varchar(80) not null,
   Ativo Bit default 1,
   DtInclusao datetime default getdate() 
   unique(Login)
);

insert into Usuarios(Login, senha, Nome) values ('admin', '1234', 'Administrador');

Create table Contatos(
   Id_Contato int identity not null primary key,
   Id_Usuario int not null FOREIGN KEY REFERENCES Usuarios(Id_Usuario),
   Nome Varchar(80) not null,
   Ativo bit default 1,
   DtInclusao datetime default getdate() 
);

insert into Contatos(Id_Usuario, Nome) values (1, 'Fulando');

Create table Emails(
   Id_Email int identity not null primary key,
   Id_Contato int not null FOREIGN KEY REFERENCES Contatos(Id_Contato),
   EmailContato varchar(120),
   Valido bit default 1,
   DtInclusao datetime default getdate() 
);

insert into Emails (Id_Contato, EmailContato) values(1, 'email@email.com');

Create table Tipotelefone(
   Id_Tipotelefone  int identity not null primary key,
   Descricao varchar(100) not null
);

insert into Tipotelefone(Descricao) values ('Fixo');
insert into Tipotelefone(Descricao) values ('Movel');

Create table Telefones(
   Id_Telefone int identity not null primary key,
   Id_Contato int not null FOREIGN KEY REFERENCES Contatos(Id_Contato),
   Id_Tipotelefone int not null FOREIGN KEY REFERENCES Tipotelefone(Id_Tipotelefone),
   DDD varchar(2) not null,
   Fone varchar(9) not null,   
   Valido bit default 1,
   DtInclusao datetime default getdate() 
);


insert into Telefones (Id_Contato, Id_Tipotelefone, DDD, Fone) values(1, 1,'13', '33334444');

# Agenda de contato

  API RESTfull dotnet CORE 3.1.1 agenda de contatos Nome, E-mails e Telefones.
  * WEBApi API RestFull
  * Entity Framework 3.1.1 e Microsoft.EntityFrameworkCore.SqlServe 3.1.1
  * JWT
  * SQL Server
  * Automapper

Criar Data base
Script: AgendaContatoDB.sql

Criar testa conexão
  cria a connectstring com arquivo "teste Conexão.udl"
  Abra o arquivo com um editor de texto e copie a terceira linha removendo o "Provider".
     Exemplo: "Provider=SQLOLEDB.1;Password=123456;Persist Security Info=True;User ID=userAgenda;Initial Catalog=AgendaContatoDB;Data Source=localhost"
  Add from appsettings.json
  "ConnectionStrings": {
    "DbAgendaContatosLocal": "Password=123456;Persist Security Info=True;User ID=userAgenda;Initial Catalog=AgendaContatoDB;Data Source=localhost"
  },
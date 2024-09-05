## Trilha de Formação C# - CodeRDIversity

Esse repositório tem o objetivo de armazenar o código do sistema de controle de itens de uma geladeira.

-------------------------------------------------------------------------------------------------------

Comandos utilizados no SQL Server e SSMS:

```
CREATE DATABASE GeladeiraDB;

CREATE TABLE ItensGeladeira (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nome VARCHAR(100) NOT NULL,
    Andar INT NOT NULL,
    Container INT NOT NULL,
    Posicao INT NOT NULL
);
```

Comando feito no Scaffold:

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=GeladeiraDB;Uid=sa;Pwd=123;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```
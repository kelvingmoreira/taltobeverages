# TaltoBev

Uma API REST de um e-commerce de cervejas contendo as seguintes operações:

* Consultar o catálogo de cerveja de forma paginada, ordenando de forma crescente pelo nome;
* Consultar a cerveja pelo seu identificador;
* Consultar todas as vendas efetuadas de forma paginada, filtrando pelo range de datas (inicial e final) da venda e ordenando de forma decrescente pela data da venda;
* Consultar uma venda pelo seu identificador;
* Registrar uma nova venda de cerveja calculando o valor total de cashback.

> Nota - Esta API utiliza o .NET 5.0, certifique-se que a SDK está instalada antes de testar.

## Rodar o projeto

Este projeto será demonstrado melhor se as instruções abaixo forem seguidas. 

### Instruções iniciais

#### Ambiente de compilação

* [.NET Core 5.0 SDK](https://www.microsoft.com/net/core). 
* [SQL Server Express](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) (versão mais recente).
* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/) (versão mais recente).

#### Preparativos para compilação

Para explorar a API, será necessário definir a connection string do servidor SQL com o nome desejado do banco de dados em [appsettings.Development.json](src/Talto.WebApi/appsettings.Development.json).  
Exemplo:

<pre>
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information",
      "Microsoft.EntityFrameworkCore.Database.Command": "Information"
    }
  },
  "ConnectionStrings": {
    "ReleaseConnection": "Data Source=<b>GTC-D-2XFVP33\\SQLEXPRESS</b>;Database=<b>TaltoDB</b>;Integrated Security=SSPI;"
  }
}
</pre>


> Nota: O [sample.sql](sample.sql) referencia o banco de dados por nome ("USE TaltoDB"). Se outro nome for utilizado para o banco de dados na connection string, será necessário alterar em [sample.sql](sample.sql) também.

#### Construção do SCHEMA do banco de dados

O banco de dados foi montado na abordagem "Code First". O schema do banco de dados pode ser construído de duas formas:

* Compilando e executando o projeto ao menos uma vez. O método ```EnsureCreated()``` é utilizado em [Startup.cs](src/Talto.WebApi/Startup.cs) e cria o schema caso ele não exista.
* Executando ```Update-Database``` no Console do Gerenciador de Pacotes com o projeto [Talto.Repository](src/Talto.Repository/Talto.Repository.csproj) selecionado como projeto padrão.

#### Compilação

Após os preparativos de compilação, basta compilar o projeto. Caso **Talto.WebApi** não esteja definido como projeto de inicialização, defina-o e execute em modo IIS Express.



## Utilizando o sample

O arquivo [sample.sql](sample.sql) está disponível para facilitar a demonstração da API. Basta executá-lo no banco de dados.

> Nota: Certifique-se que o SCHEMA do banco de dados foi aplicado antes.
> > Execute o sample apenas uma vez.

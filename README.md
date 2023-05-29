If gera complexidade ciclomática: https://learn.microsoft.com/pt-br/visualstudio/code-quality/code-metrics-cyclomatic-complexity?view=vs-2022

Fail Fast Validation: https://www.techtarget.com/whatis/definition/fail-fast
Flunt → biblioteca balta.io -> para o projeto estamos usando o <PackageReference Include="flunt" Version="1.0.5" />
FluentValidator → biblioteca Microsoft

### Criando o projeto
Para criar o projetos:
library: dotnet new class library
API: dotnet new webapi

dotnet new sln
dotnet sln add seus_projetos
dotnet build

Domain sempre é referenciado

referenciar projetos ex:
	entrar no projeto Projeto.Domain.API
		dotnet add reference Projeto.Domain
		dotnet add reference Projeto.Domain.Infra
	entrar no projeto Projeto.Domain.Infra
		dotnet add reference Projeto.Domain

### Testes
Para moke MOQ
Para rodar os testes, 
	dir -> Todo.Domain.Tests
	command -> dotnet test

### Banco de Dados

SQLServer Docker:
	sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=@sa#123456" -e "MSSQL_TCP_PORT=1433" -e "MSSQL_COLLATION=SQL_Latin1_General_CP1_CI_AS" -e "MSSQL_LCID=1033" -e "MSSQL_LCID_COLLATION=Latin1_General_CI_AS" -e "MSSQL_MEMORY_LIMIT_MB=2048" -e "MSSQL_DATA_DIR=/var/opt/mssql/data" -e "MSSQL_LOG_DIR=/var/opt/mssql/log" -e "MSSQL_BACKUP_DIR=/var/opt/mssql/backup" -p 1433:1433 --name balta -d mcr.microsoft.com/mssql/server:latest


Instalando o banco de dados EntityFrameworkCore
	InMemory:
		dotnet add package Microsoft.EntityFrameworkCore.InMemory
	"Infra e API"
		dotnet add package Microsoft.EntityFrameworkCore.SqlServer

Pacote para instalar caso queiramos alterar o tipo da coluna:
	dotnet add package Microsoft.EntityFrameworkCore.Design
	dotnet add package Microsoft.EntityFrameworkCore.Relational
	dotnet add package Microsoft.EntityFrameworkCore.Tools

Migrations:
	dotnet tool install --global dotnet-ef
	dotnet ef migrations add InitialCreate --startup-project ../Todo.Domain.Api/
	dotnet ef database update --startup-project ../Todo.Domain.Api/


### API
Injeção de dependencia
	services.AddTransient:
		Cria sempre um novo repositório

	services.AddScoped
		Faz um "Singleton" por requisição.

	services.AddSingleton
		Prove uma instância do objeto para a aplicação toda.
		Sempre mantém um objeto na memória
		por exemplo no banco de dados: conexão sempre ativa no banco

	services.AddDbContext
		Nas versões mais novas do dotnetCore
		expecíficas para banco de dados

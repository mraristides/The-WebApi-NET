# Sample-WebApi-NET

### Caracteristicas

- Projeto padrão para desenvolvimento de REST API's RESTFul com ASP.NET Core 6 e Docker.
- Authenticação com Jwt Bearer
- Aceita JSON ou XML
- Suporte/Documentação com Swagger
- Banco de Dados Mysql
- Migrações (db) Manuais com Evolve
- Implementação de Hypermedia (HATEOS)
- Versionamento de Endpoints

### Fonte

- (REST API's RESTFul do 0 à Azure com ASP.NET Core 5 e Docker) https://www.udemy.com/course/restful-apis-do-0-a-nuvem-com-aspnet-core-e-docker/

### Configure o appsettings.json

```json
{
	"MySQLConnection":	{
		"MySQLConnectionString": "Server=db;DataBase=sample;Uid=root;Pwd=docker;SslMode=none"
	},
	"TokenConfigurations":	{
		"Audience": "TIAGO_ARISTIDES",
		"Issuer": "TIAGO_ARISTIDES",
		"Secret": "YEBhH21F/i9JGMVujhYy/F5bOel3dtIJ+EFAM5HOyMw=",
		"Minutes": 60,
		"DaysToExpiry": 7
	},
	"Logging":	{
		"LogLevel":	{
			"Default": "Information",
			"Microsoft": "Warning",
			"Microsoft.Hosting.Lifetime": "Information"
		}
	},
	"AllowedHosts": "*"
}
```
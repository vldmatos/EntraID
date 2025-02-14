# Projeto Exemplo Entra ID

Um exemplo de solução com multiplos projetos para validar a autenticação e authorização utilizando Microsoft Azure Entra ID.  


# Arquitetura

![](/images/001.jpg)


# Projetos

- Single Page application Blazor WebAssembly
- Web API Minimal API.
- Aspire Orchestration
- .NET 9.0

# Instruções.

- Criar o registro de APP Registration no tenant Azure
- Alterar as configurações **ClientID** e **Authority** no arquivo:  **EntraID\source\Blazor\wwwroot\appsettings.json**

- Executar o projeto com Aspire.Host para executar a API junto com o projeto blazor WebAssembly
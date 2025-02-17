# Projeto Exemplo Entra ID

Um exemplo de solução com multiplos projetos para validar a autenticação e autorização utilizando Microsoft Azure Entra ID.  
Consulta informações de usuário na API Microsoft Graph.  
Simula a consulta de dados de uma API com recursos autorizados.  


# Arquitetura

![](/images/001.jpg)


# Projetos

- Single Page application Blazor WebAssembly
- Web API Minimal API.
- Aspire Orchestration
- Configuration projects library
- Domain layer
- Test Project
- .NET 9.0

# Instruções.

- Criar o registro de APP Registration no tenant Azure para a aplicação client blazor
- Na configuração do APP Registration export uma API com o scope API.Access.   
- API Permission adicionar a permissão: User.Read
- Alterar as configurações **AzureAd** no arquivo:  **EntraID\source\Blazor\wwwroot\appsettings.json**

- Criar o registro de APP Registration no tenant Azure para aplicação API
- Criar client secret para o app registration API 
- API Permission adicionar as permissões: User.Read e User.Read.All
- Alterar as configurações **AzureAd** no arquivo:  **\EntraID\source\API\appsettings.json** 

- Executar o projeto com Aspire.Host para executar os projetos de client e api juntos

- Para obter os dados de profile de usuário do microsoft graph é necessário que o usuário faça parte do tenant

# Aplicação

A aplicação apresenta uma tela inicial de login  
Clicar no botão "Microsoft"
![](/images/002.jpg)

Informar a conta do tenat Azure Entra ID  
![](/images/003.jpg)

Ao ser autenticado o usuário será direcionado para uma tela de apresentação e poderá consultar os dados de profile e divice signal.  
Clicar no botão ""  
![](/images/004.jpg)

Será apresentada uma tela com as informações de usuário do tenant.  
![](/images/005.jpg)

Nesta tela também são exibidas as informações de device signal que são obtidas de um endpoint somente autorizado.  
As informações são simuladas e atualizadas a cada 5 segundos.  
![](/images/006.jpg)
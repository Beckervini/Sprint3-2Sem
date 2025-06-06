# Sprint1-2semestre API
RM94679 - Vinicius Becker Prediger

Esta é uma API para gerenciamento de empresas e KPIs, desenvolvida em .NET Core com integração ao banco de dados Oracle. A aplicação foi construída utilizando princípios de arquitetura limpa, injeção de dependências e documentação via Swagger.

## Arquitetura

A API segue uma arquitetura monolítica, onde todos os componentes do sistema estão contidos em um único projeto.
Optamos por uma arquitetura monolítica neste projeto por ser uma solução mais simples e adequada para o escopo atual. A arquitetura monolítica permite desenvolver, testar e implantar a aplicação como uma única unidade, facilitando o gerenciamento e a manutenção, especialmente em projetos de menor escala ou em fases iniciais. Além disso, ela reduz a complexidade operacional, uma vez que não requer a sobrecarga de gerenciar múltiplos serviços ou interações entre eles, o que é mais eficiente para este cenário de API simples com poucos componentes. 

Dentro da API, os principais componentes incluem:

- **Controllers**: Responsáveis por gerenciar as requisições HTTP, processar a entrada e devolver a resposta apropriada.
- **Services**: Classes de serviços, como o `ConfigManager`, que gerenciam regras de negócios e configurações específicas.
- **Data**: Acessa e gerencia a comunicação com o banco de dados através do `ApplicationDbContext`, que é uma classe derivada de `DbContext` do Entity Framework Core.
- **DesignTimeDbContextFactory**: Classe utilizada durante o tempo de design para configurar e fornecer o contexto do banco de dados para o Entity Framework Core, especialmente em cenários de migração e scaffolding.
- **Models**: Definem as entidades do sistema, como `Empresa` e `KPI`, mapeadas diretamente para as tabelas no banco de dados.

### Camadas

1. **Camada de Controle (Controllers)**: Gerencia a entrada do usuário (requisições HTTP) e aciona os serviços apropriados para processar os dados. Exemplo: `EmpresasController`.
2. **Camada de Serviços**: Contém lógica de negócio, como `ConfigManager`, que é utilizado para gerenciar valores de configuração na aplicação.
3. **Camada de Acesso a Dados (Data)**: Faz a comunicação com o banco de dados usando o `ApplicationDbContext` configurado para trabalhar com Oracle e o Entity Framework Core.
4. **DesignTimeDbContextFactory**: Garante que o `ApplicationDbContext` possa ser instanciado durante o tempo de design para o Entity Framework Core, principalmente para suportar comandos de migração como `dotnet ef migrations add`.

## Design Patterns Utilizados

1. **Singleton Pattern**:
   O `ConfigManager` é implementado como um Singleton para garantir que haja apenas uma instância compartilhada em toda a aplicação. Ele é utilizado para gerenciar configurações globais.

   ```csharp
   builder.Services.AddSingleton<ConfigManager>();



RODAR A API

1.restuarar os pacotes com o comando "dotnet restore" 

2. executar a aplicação com o comando "dotnet run"

3. Para acessar via Swagger coloque o link http://localhost:5246/swagger caso ao executar a aplicação ele mostre outra porta, apenas substitua "5246" pela porta que gerou.

4. assim podemos testar os endpoints e  a aplicação estará rodando

5. ao testar os endpoints atente-se de que o cnpj deve conter 14 caracteres e a senha no minimo 6


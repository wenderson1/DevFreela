# DevFreela
Plataforma para cadastro e contratação de serviços de freelance de desenvolvedores


O DevFreela é uma API Completa para implementar as funcionalidades necessárias para um sistema desse freelance.
Tendo as seguintes funcionalidades: Cadastro, Atualização, Cancelamento, e Consulta de Serviço de Freelance.
Cadastro de Usuário e de perfis de Freelancer e Cliente.
Adicionar comentários para um serviço de Freelance.
Definir, iniciar e finalizar projeto

## Fluxo Principal:

* O cliente pulica uma oportunidade de projeto na plataforma, com título, descrição e outras informações
* Um freelancer encontra essa oportunidade, e trodca mensagens com o cliente
* Acertadas as condições, o cliente seleciona o freelancer como profissional escolhido, e inicia o projeto
* Vão ser adicionadas mensagens ao projeto, sobre o avanço dele
* O projeto poderá ser concluído, e o freelancer vai ter seu saldo atualizado, bem como seu perfil

## Tecnologias

* .NET Core
* Entity Framework Core (SQL Server)
* Arquitetura Limpa com 
* Padrão de Projeto Repository para acesso da dados
* Padrão CQRS para para separar as responsabilidades de leitura e escrita de dados
* FluentValidations para validações dos commands
* Testes Unitários com XUnit e Moq

## Camadas de responsabilidades

* Core: Contém os serviços de domínio, classes, repositórios, interfaces. As classes usam private set para reforçar as imutabilidades.
* Infrastructure: Contém as implementações do repositório e a classe DbContext.
* Application: Contém as implementações dos Commands, Queries e Validators, além dos, View Models e Input Models.
* API: Contém os Controllers, Injeção de Dependência, Swagger, SQL-Server DbContext

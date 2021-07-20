# Back-end Challenge 🏅 2021

## Introdução

Este é um desafio para testar seus conhecimentos em Back-end;

O objetivo é avaliar a sua forma de estruturação e autonomia em decisões para construir algo escalável utilizando um framework moderno.

Você está livre para usar uma das seguintes tecnologias para desenvolver o back-end da solução deste tech challenge: **Node.js** ou **C# .NET Core** ou **PHP Laravel** ou **RubyOnRails** ou **Go Lang** ou **Python FastAPI** ou **Kotlin SpringBoot** ou **Java** ou **Rust**.

[SPOILER] As instruções de entrega e apresentação do challenge estão no final deste Readme (=

## Case

A empresa Pharma Inc, está trabalhando em um projeto em colaboração com sua base de clientes para facilitar a gestão e visualização da informação dos seus pacientes de maneira simples e objetiva em um Dashboard onde podem listar, filtrar e expandir os dados disponíveis.
O seu objetivo nesse projeto, é trabalhar no desenvolvimento da REST API da empresa Pharma Inc seguindo os requisitos propostos neste desafio.

## Recursos

Desenvolver REST API importando os dados do projeto: https://randomuser.me/documentation


## API

### Modelo de Dados:

Para a definição do modelo, consultar o arquivo [users.json](./users.json) que foi exportado do Random Users.

- `imported_t`: campo do tipo Date com a dia e hora que foi importado;
- `status`: campo do tipo Enum com os possíveis valores draft, trash e published;

### Sistema do CRON

Para prosseguir com o desafio, precisaremos criar na API um sistema de atualização que vai importar os dados para a Base de Dados com a versão mais recente do [Random User](https://randomuser.me/documentation#format) uma vez ao día. Adicionar aos arquivos de configuração o melhor horário para executar a importação.

A lista de arquivos do Random User, pode ser encontrada em: 

- https://randomuser.me/api

Escolher o formato que seja mais cômodo para importar todos os dados para a Base de Dados, o Random User tem os seguintes formatos:

- JSON (default)
- PrettyJSON or pretty
- CSV
- YAML
- XML

Ter em conta que:

- Todos os produtos deverão ter os campos personalizados `imported_t` e `status`.
- Importar os dados de maneira paginada para não sobrecargar a API do Random Users. Por exemplo, de 100 em usuários.
- Limitar a importação a somente 2000 usuarios;


### A REST API


Na REST API teremos um CRUD com os seguintes endpoints:

   - `GET /`: Retornar uma mensagem "REST Back-end Challenge 20201209 Running"
   - `PUT /users/:userId`: Será responsável por receber atualizações realizadas
   - `DELETE /users/:userId`: Remover o user da base
   - `GET /users/:userId`: Obter a informação somente de um user da base de dados
   - `GET /users`: Listar todos os usuários da base de dados

### Extras

- **Diferencial 1** Escrever Unit Test para os endpoints da REST API
- **Diferencial 2** Executar o projeto usando Docker
- **Diferencial 3** Escrever um esquema de segurança utilizando `API KEY` nos endpoints. Ref: https://learning.postman.com/docs/sending-requests/authorization/#api-key
- **Diferencial 4** Descrever a documentação da API utilizando o conceito de Open API 3.0;

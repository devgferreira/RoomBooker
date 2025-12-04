#  RoomBooker

**API REST moderna para Agendamento de Sala para reunião**.

Projetada com **arquitetura limpa (Clean Architecture)** e banco de dados **PostgreSQL**, esta solução é ideal para aplicações que precisam agendar salas de reunião.

---

##  Funcionalidades

-  Agendamento e Reagendamento de salas.
-  Persistência dos dados no banco de dados.
-  Documentação da API via **Swagger (OpenAPI)**.
-  Arquitetura baseada em **Clean Architecture** para alta manutenibilidade e testabilidade.
-  Tecnologia moderna com **.NET 9**.

---

## 🛠️ Tecnologias Utilizadas

| Tecnologia        | Descrição |
|------------------|---------|
| **.NET 9**       | Plataforma principal para desenvolvimento da API. |
| **PostgreSQL**   | Banco de dados relacional recomendado (configurável para outros). |
| **Swagger**      | Documentação interativa da API. |

---

## 📦 Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

- ✅ [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- ✅ Um IDE compatível com .NET (recomendado: **Visual Studio 2025** ou **Visual Studio Code**)
- ✅ **PostgreSQL** (ou outro banco compatível com Dapper)
- ✅ [PostgreSQL Client](https://www.pgadmin.org/) (opcional, para visualização do banco)
---

## 🚀 Como Rodar o Projeto

### 1. Clonar o repositório

git clone [https://github.com/devgferreira/RoomBooker.API.git](https://github.com/devgferreira/RoomBooker)

### 2. Configurar as variáveis de ambiente

Crie um arquivo `.env` dentro dos seguintes diretórios:

- `RoomBooker.API/.env`

Com o seguinte conteúdo:

```env
CONNECTION_STRING=Host=localhost;Database=seu_banco;Username=seu_username;Password=sua_senha
```

# Estrutura do Projeto

O projeto segue uma arquitetura **limpa e modular**, separando responsabilidades em camadas distintas:

## 📦 API
Responsável por expor endpoints e lidar com solicitações HTTP.

- **Controller**: Controladores de API, responsáveis por receber requisições e retornar respostas.

## 📦 Application
Camada de aplicação, responsável por lógica de integração, DTOs e serviços.

- **API**: Serviços para consumir APIs externas.  
- **DTO**: Objetos de Transferência de Dados usados para comunicar entre camadas.  
- **Interface**: Contratos para os serviços da aplicação.  
- **Service**: Contém lógica de negócios de alto nível e orquestra chamadas aos repositórios.  
- **Setting**: Configurações relacionadas ao projeto.

## 📦 Domain
Camada de domínio, responsável pelas regras de negócio essenciais.

- **Entity**: Entidades de domínio.
- **Exceptions**: Exceptions personalizadas.
- **Interface**: Contratos para os repositórios de domínio.

## 📦 Infra.Data
Camada de persistência, responsável pelo acesso ao banco de dados.

- **Context**: Orquestra o acesso às tabelas e gerencia a conexão com o banco de dados.  
- **Repository**: Contém a lógica de consulta às tabelas do banco.

## 📦 Infra.Ioc
Responsável por gerenciar a injeção de dependências do projeto.

---



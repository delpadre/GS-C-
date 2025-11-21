# SkillSync Platform - API RESTful

## 📋 Sobre o Projeto
O SkillSync Platform é uma solução tecnológica inovadora voltada para o tema "O Futuro do Trabalho". A plataforma conecta profissionais a oportunidades baseadas em suas habilidades atuais e futuras, utilizando tecnologia para melhorar a vida das pessoas no trabalho e criar oportunidades mais justas e inclusivas.

## 🎯 Funcionalidades
- ✅ Cadastro de Profissionais com habilidades e preferências
- ✅ Gestão completa de carreiras (CRUD)
- ✅ Análise de compatibilidade entre profissionais e oportunidades
- ✅ API Versionada para evolução controlada
- ✅ Documentação automática com Swagger

## 🏗️ Arquitetura

```text
SkillSync Platform/
├── 📁 SkillSync.API/           # Camada de Apresentação
├── 📁 SkillSync.Application/   # Camada de Aplicação
├── 📁 SkillSync.Domain/        # Camada de Domínio
├── 📁 SkillSync.Infrastructure/# Camada de Infraestrutura
└── 📁 SkillSync.Tests/         # Testes Unitários
```


## 📚 Versões da API

### Versão 1.0 (/api/v1)
**ProfissionaisController:** CRUD completo de profissionais  
**Status:** ✅ Implementada e Funcional  

**Endpoints:**

| Método | Endpoint | Descrição | Status Code |
|--------|---------|-----------|------------|
| GET    | /api/v1/profissionais | Listar todos | 200 |
| GET    | /api/v1/profissionais/{id} | Buscar por ID | 200, 404 |
| POST   | /api/v1/profissionais | Criar novo | 201, 400 |
| PUT    | /api/v1/profissionais/{id} | Atualizar | 204, 400, 404 |
| DELETE | /api/v1/profissionais/{id} | Remover | 204, 404 |

### Versão 2.0 (/api/v2) - Em Desenvolvimento
- Funcionalidades avançadas de recomendação
- Match entre profissionais e vagas
- Análise de tendências de mercado

## 🛠️ Tecnologias Utilizadas
- .NET 8 - Framework principal
- Entity Framework Core - ORM e Migrations
- SQL Server - Banco de dados relacional
- Swagger/OpenAPI - Documentação automática
- ASP.NET Core - Web API framework

## 🚀 Como Executar

### Pré-requisitos
- .NET 8 SDK
- SQL Server (LocalDB ou Express)
- Visual Studio 2022 ou VS Code

### Passos para Execução
1. Clone o repositório:
```bash
git clone [url-do-repositorio]
cd SkillSync-Platform
```
Restaurar pacotes NuGet:
- dotnet restore
Configurar banco de dados:
- cd SkillSync.API
- dotnet ef database update

Executar a aplicação:
- dotnet run

Acessar a documentação:
- https://localhost:7000/swagger
ou
- http://localhost:5122/swagger

Endpoints da API

| Método | Endpoint                   | Descrição     | Status Code   |
| ------ | -------------------------- | ------------- | ------------- |
| GET    | /api/v1/profissionais      | Listar todos  | 200           |
| GET    | /api/v1/profissionais/{id} | Buscar por ID | 200, 404      |
| POST   | /api/v1/profissionais      | Criar novo    | 201, 400      |
| PUT    | /api/v1/profissionais/{id} | Atualizar     | 204, 400, 404 |
| DELETE | /api/v1/profissionais/{id} | Remover       | 204, 404      |


Link Youtube:

<img width="494" height="826" alt="image" src="https://github.com/user-attachments/assets/292258b7-c0b9-44b1-892a-d2e52f37d9af" />



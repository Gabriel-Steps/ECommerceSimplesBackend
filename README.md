# 🛒 E-Commerce Simples — Backend

> API backend de um mini e-commerce desenvolvida em C# com ASP.NET Core, criada como projeto de aprendizado para consolidar conhecimentos em .NET e servir de base para o frontend em Angular.

---

## 📖 Sobre o Projeto

O **E-Commerce Simples** é um projeto Full Stack com o objetivo de consolidar habilidades no desenvolvimento de aplicações modernas, utilizando **Angular** no frontend e **.NET C#** no backend.

---

## 🚀 Tecnologias

| Tecnologia | Descrição |
|---|---|
| C# / .NET | Linguagem e plataforma principal |
| ASP.NET Core | Framework web |
| Entity Framework Core | ORM para acesso a dados |
| SQL Server | Banco de dados relacional |
| MediatR | Desacoplamento via CQRS |
| FluentValidation | Validação de entrada |
| JWT Authentication | Autenticação e autorização |

---

## 🏛️ Arquitetura

O projeto segue uma arquitetura em camadas com separação clara de responsabilidades:

```
ECommerceSimplesBackend
├── ECommerceSimplesBackend.API           → Controllers, Middlewares e configuração
├── ECommerceSimplesBackend.Application   → Commands, Queries, Handlers, Validators e ViewModels
├── ECommerceSimplesBackend.Infra         → Repositórios, DbContext e acesso ao banco
└── ECommerceSimplesBackend.Domain        → Entidades e regras de domínio
```

### Padrões utilizados

- **CQRS com MediatR** — operações de leitura e escrita isoladas em seus próprios Handlers
- **Repository Pattern** — abstração do acesso ao banco de dados
- **Pipeline Behavior** — validação automática via FluentValidation antes de cada Handler
- **Global Exception Handling** — middleware centralizado para tratamento de erros

---

## 📦 Entidades e Relacionamentos

```
User ──────────────── Cart (1:1)
                         │
                      CartItem (1:N)
                         │
                       Product

User ──────────────── Order (1:N)
                         │
                      OrderItem (1:N)
                         │
                       Product
```

| Entidade | Descrição |
|---|---|
| **User** | Usuário do sistema, pode autenticar, montar carrinho e realizar pedidos |
| **Product** | Produtos disponíveis para compra |
| **Cart** | Carrinho ativo do usuário, um por usuário |
| **CartItem** | Itens dentro do carrinho com quantidade selecionada |
| **Order** | Pedido gerado ao finalizar a compra |

> **Decisão de design:** o `OrderItem` armazena o preço do produto **no momento da compra** — preservando o histórico mesmo que o preço do produto seja alterado futuramente.

---

## 🔐 Autenticação e Autorização

A API utiliza **JWT Bearer Authentication** para proteger os endpoints. O token é gerado no login e deve ser enviado no header de todas as requisições autenticadas:

```
Authorization: Bearer {token}
```

Endpoints públicos (sem autenticação): `POST /api/auth/login` e `POST /api/auth/register`.

---

## ✅ Validações

Todas as entradas da API são validadas com **FluentValidation** integrado ao pipeline do MediatR. A validação ocorre automaticamente antes de qualquer Handler ser executado.

```
Request HTTP
    ↓
Controller → despacha Command/Query
    ↓
ValidationBehavior → valida automaticamente
    ↓ (se inválido)
400 Bad Request + lista de erros
    ↓ (se válido)
Handler → regras de negócio
```

---

## 🔍 Queries de Produto

O sistema oferece múltiplas formas de busca de produtos:

| Endpoint | Descrição |
|---|---|
| `GET /api/products` | Lista todos os produtos |
| `GET /api/products/{id}` | Busca produto por ID |
| `GET /api/products/name/{name}` | Busca produtos por nome |
| `GET /api/products/price?min={min}&max={max}` | Busca produtos por faixa de preço |

---

## ⚙️ Como executar

### Pré-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server) ou [MySQL](https://www.mysql.com)

### Configuração

1. Clone o repositório:
```bash
git clone https://github.com/seu-usuario/ecommerce-simples-backend.git
cd ecommerce-simples-backend
```

2. Configure a connection string no `appsettings.Development.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "sua-connection-string-aqui"
  },
  "Jwt": {
    "Key": "sua-chave-secreta",
    "Issuer": "ECommerceSimples",
    "Audience": "ECommerceSimplesUsers"
  }
}
```

3. Execute as migrations:
```bash
dotnet ef database update
```

4. Execute o projeto:
```bash
dotnet run --project ECommerceSimplesBackend.API
```

---

## 🗺️ Roadmap

### Backend
- [x] Estrutura do projeto e arquitetura em camadas
- [x] Entidades e relacionamentos
- [x] Migrations
- [x] Commands e Queries de todas as entidades
- [ ] Controllers
- [x] FluentValidation

---

## 🔗 Repositórios

- [**Backend:**](https://github.com/Gabriel-Steps/ECommerceSimplesBackend)

---

<p align="center">Desenvolvido com 💙 em C# e Angular</p>

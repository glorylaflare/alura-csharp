# 🏨 HoteisApi

Uma API REST moderna e robusta para gerenciamento de hotéis, desenvolvida em **ASP.NET Core 8.0** com **Entity Framework Core** e **PostgreSQL**.

## 📋 Sobre o Projeto

A **HoteisApi** é uma aplicação que permite realizar operações CRUD completas (Create, Read, Update, Delete) para o gerenciamento de informações de hotéis. O projeto foi desenvolvido seguindo as melhores práticas de desenvolvimento de APIs REST, incluindo validações robustas, documentação automática com Swagger e mapeamento de objetos com AutoMapper.

### ✨ Características Principais

- 🏗️ **Arquitetura RESTful** com ASP.NET Core 8.0
- 🗃️ **Banco de dados PostgreSQL** com Entity Framework Core
- 📝 **Documentação automática** com Swagger/OpenAPI
- 🔄 **Mapeamento de objetos** com AutoMapper
- ✅ **Validações robustas** com Data Annotations
- 🎯 **DTOs (Data Transfer Objects)** para separação de responsabilidades
- 📊 **Paginação** para listagem de resultados
- 🔧 **Operações PATCH** para atualizações parciais

## 🛠️ Tecnologias Utilizadas

### Backend
- **ASP.NET Core 8.0** - Framework web principal
- **Entity Framework Core 8.0** - ORM para acesso ao banco de dados
- **PostgreSQL** - Sistema de gerenciamento de banco de dados
- **AutoMapper 12.0** - Mapeamento automático entre objetos
- **Newtonsoft.Json** - Serialização JSON avançada

### Documentação e Desenvolvimento
- **Swagger/OpenAPI** - Documentação interativa da API
- **XML Documentation** - Comentários de documentação no código
- **.NET 8.0** - Plataforma de desenvolvimento

### Pacotes NuGet
```xml
- Microsoft.AspNetCore.OpenApi (8.0.18)
- Microsoft.EntityFrameworkCore (8.0.18)
- Microsoft.EntityFrameworkCore.Tools (8.0.18)
- Npgsql.EntityFrameworkCore.PostgreSQL (8.0.11)
- AutoMapper (12.0.0)
- AutoMapper.Extensions.Microsoft.DependencyInjection (12.0.0)
- Microsoft.AspNetCore.Mvc.NewtonsoftJson (8.0.18)
- Swashbuckle.AspNetCore (6.6.2)
```

## 🏗️ Estrutura do Projeto

```
HoteisApi/
├── Controllers/           # Controladores da API
│   └── HotelController.cs
├── Data/                  # Contexto do banco e DTOs
│   ├── HotelContext.cs
│   └── Dtos/
│       ├── CreateHotelDto.cs
│       ├── ReadHotelDto.cs
│       └── UpdateHotelDto.cs
├── Models/                # Modelos de domínio
│   └── Hotel.cs
├── Profiles/              # Perfis do AutoMapper
│   └── HotelProfile.cs
├── Migrations/            # Migrações do EF Core
├── Properties/            # Configurações de inicialização
└── Program.cs             # Ponto de entrada da aplicação
```

## 🏨 Modelo de Dados - Hotel

O modelo `Hotel` possui as seguintes propriedades com validações robustas:

| Campo | Tipo | Validações | Descrição |
|-------|------|------------|-----------|
| `Id` | int | Chave primária | Identificador único do hotel |
| `Nome` | string | Obrigatório, máx. 100 caracteres | Nome do hotel |
| `Logradouro` | string | Obrigatório, máx. 200 caracteres | Endereço completo |
| `Cidade` | string | Obrigatório, máx. 100 caracteres | Cidade onde está localizado |
| `Pais` | string | Obrigatório, máx. 100 caracteres | País de localização |
| `CEP` | string | Formato: XXXXX-XXX | Código postal |
| `Telefone` | string | Formato: +55 11 91234-5678 | Número de contato |
| `Estrelas` | int | Range: 1-5 | Classificação do hotel |
| `TemWifi` | bool | Obrigatório | Disponibilidade de Wi-Fi |
| `TemEstacionamento` | bool | Obrigatório | Disponibilidade de estacionamento |
| `AceitaAnimais` | bool | Obrigatório | Política de animais de estimação |
| `TemPiscina` | bool | Obrigatório | Disponibilidade de piscina |
| `TemAcademia` | bool | Obrigatório | Disponibilidade de academia |
| `TemRestaurante` | bool | Obrigatório | Disponibilidade de restaurante |
| `Descricao` | string | Obrigatório, máx. 500 caracteres | Descrição do hotel |
| `PrecoMedioDiaria` | decimal | Maior que zero | Valor médio da diária |

## 🚀 Como Executar o Projeto

### Pré-requisitos

1. **.NET 8.0 SDK** - [Download aqui](https://dotnet.microsoft.com/download/dotnet/8.0)
2. **PostgreSQL** - [Download aqui](https://www.postgresql.org/download/)
3. **Visual Studio 2022** ou **VS Code** (opcional)

### Configuração do Banco de Dados

1. **Instale e configure o PostgreSQL**
2. **Crie um banco de dados** chamado `HoteisDb`
3. **Configure a string de conexão** no arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=HoteisDb;Username=postgres;Password=admin"
  }
}
```

### Executando a Aplicação

1. **Clone o repositório**:
```bash
git clone <repository-url>
cd HoteisApi
```

2. **Restaure as dependências**:
```bash
dotnet restore
```

3. **Execute as migrações do banco**:
```bash
dotnet ef database update
```

4. **Execute a aplicação**:
```bash
dotnet run
```

5. **Acesse a documentação Swagger**:
   - URL: `https://localhost:5241/swagger` (HTTPS)
   - URL: `http://localhost:5241/swagger` (HTTP)

## 📚 Endpoints da API

### Base URL
```
https://localhost:5241/api/v1/hotel
```

### Operações Disponíveis

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| `GET` | `/api/v1/hotel` | Lista hotéis com paginação |
| `GET` | `/api/v1/hotel/{id}` | Busca hotel por ID |
| `POST` | `/api/v1/hotel` | Cria novo hotel |
| `PUT` | `/api/v1/hotel/{id}` | Atualiza hotel completo |
| `PATCH` | `/api/v1/hotel/{id}` | Atualização parcial do hotel |
| `DELETE` | `/api/v1/hotel/{id}` | Remove hotel |

### Exemplos de Uso

#### 📝 Criar um novo hotel (POST)
```json
{
  "nome": "Hotel Copacabana Palace",
  "logradouro": "Av. Atlântica, 1702 - Copacabana",
  "cidade": "Rio de Janeiro",
  "pais": "Brasil",
  "cep": "22021-001",
  "telefone": "+55 21 2548-7070",
  "estrelas": 5,
  "temWifi": true,
  "temEstacionamento": true,
  "aceitaAnimais": false,
  "temPiscina": true,
  "temAcademia": true,
  "temRestaurante": true,
  "descricao": "Hotel luxuoso na orla de Copacabana com vista para o mar.",
  "precoMedioDiaria": 850.00
}
```

#### 🔍 Listar hotéis com paginação (GET)
```
GET /api/v1/hotel?skip=0&take=10
```

#### 🔧 Atualização parcial (PATCH)
```json
[
  {
    "op": "replace",
    "path": "/precoMedioDiaria",
    "value": 900.00
  }
]
```

## 🎯 Recursos Interessantes

### 1. **Validações Avançadas**
- Regex customizado para telefone brasileiro
- Validação de CEP no formato brasileiro
- Range de estrelas de 1 a 5
- Validações de tamanho mínimo e máximo para strings

### 2. **AutoMapper Integration**
- Mapeamento automático entre DTOs e Models
- Perfis de mapeamento organizados
- Redução de código boilerplate

### 3. **Swagger Documentation**
- Documentação automática da API
- Comentários XML integrados
- Interface interativa para testes

### 4. **Entity Framework Core**
- Code First approach
- Migrações automáticas
- Contexto otimizado para PostgreSQL

### 5. **Separação de Responsabilidades**
- DTOs separados para Create, Read e Update
- Controllers focados apenas na lógica de API
- Models limpos com apenas regras de negócio

## 🔧 Comandos Úteis

### Entity Framework
```bash
# Criar nova migração
dotnet ef migrations add NomeDaMigracao

# Aplicar migrações
dotnet ef database update

# Remover última migração
dotnet ef migrations remove

# Ver migrações pendentes
dotnet ef migrations list
```

### Desenvolvimento
```bash
# Executar em modo de desenvolvimento
dotnet run --environment Development

# Executar com hot reload
dotnet watch run

# Limpar e rebuildar
dotnet clean && dotnet build
```

## 🧪 Testando a API

### Com Swagger UI
1. Execute a aplicação
2. Acesse `https://localhost:5241/swagger`
3. Use a interface para testar os endpoints

### Com curl
```bash
# Listar hotéis
curl -X GET "https://localhost:5241/api/v1/hotel" -H "accept: application/json"

# Criar hotel
curl -X POST "https://localhost:5241/api/v1/hotel" \
  -H "accept: application/json" \
  -H "Content-Type: application/json" \
  -d @hotel.json
```

## 📝 Próximas Melhorias

- [ ] **Autenticação e Autorização** com JWT
- [ ] **Cache** com Redis
- [ ] **Logs estruturados** com Serilog
- [ ] **Testes unitários** e de integração
- [ ] **Health checks** para monitoramento
- [ ] **Rate limiting** para proteção da API
- [ ] **Dockerização** da aplicação
- [ ] **CI/CD** pipeline

## 🤝 Contribuição

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

---

⭐ **Desenvolvido como projeto educacional da Alura** ⭐
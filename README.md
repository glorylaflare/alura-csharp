# #️⃣ Projetos de C# da Alura

Este repositório reúne diversos projetos desenvolvidos em C# durante estudos e cursos da Alura. Abaixo está uma breve descrição de cada projeto presente na pasta:

## 🔹HoteisApi
API para gerenciamento de hotéis, clientes, reservas, avaliações e quartos. Utiliza Entity Framework para persistência dos dados e segue arquitetura RESTful.

**Contém:**
- Controllers para cada entidade (Hotel, Cliente, Reserva, Quarto, Avaliação, Endereço)
- Models representando as entidades do domínio
- DTOs para transferência de dados
- Profiles para mapeamento entre entidades e DTOs
- Contexto de dados com Entity Framework
- Arquivos de configuração (`appsettings.json`)

## 🔹JornadaMilhas
Aplicação para gerenciamento de ofertas de viagens e validação de dados relacionados a milhas. Possui estrutura modular com separação entre modelos, validadores e gerenciadores. Inclui testes automatizados para garantir a qualidade do código.

**Contém:**
- Gerenciador de ofertas de viagem
- Modelos para representar ofertas e entidades relacionadas
- Validador para dados de viagem
- Testes automatizados em `tests/JornadaMilhas.Tests`
- Interface de console para interação do usuário

## 🔹ScreenSound
Projeto voltado para manipulação e organização de dados relacionados a músicas e sons. Permite cadastro, consulta e organização de faixas musicais, utilizando conceitos de listas, classes e métodos em C#.

**Contém:**
- Dicionário de bandas e avaliações
- Interface de console para interação
- Métodos para exibir logo, mensagens e manipular dados musicais

## 🔹UsuariosApi
API para gerenciamento de usuários, incluindo autenticação, autorização e controle de acesso por idade mínima. Utiliza Entity Framework, controllers, services e profiles para organização do código.

**Contém:**
- Controllers para acesso e usuários
- Models para representação de usuários
- Serviços para lógica de negócio
- Profiles para mapeamento
- Autorização por idade mínima
- Contexto de dados
- Arquivos de configuração (`appsettings.json`)
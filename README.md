📚 Book Review Manager

Este projeto tem como objetivo o desenvolvimento de um sistema de gerenciamento e avaliação de livros, inspirado em plataformas como o GoodReads, servindo como estudo prático e evolutivo de arquitetura, padrões de projeto e boas práticas no ecossistema .NET.

A aplicação foi construída com foco em Clean Architecture, DDD, CQRS e boas práticas de engenharia de software, passando por diferentes níveis de maturidade técnica, desde conceitos básicos até padrões avançados utilizados em sistemas reais de produção.

🚀 Funcionalidades
📖 Gerenciamento de Livros

Cadastro, atualização, remoção e listagem de livros

Consulta de detalhes do livro

Validação de dados

Impedimento de cadastro de livros com ISBN duplicado

Upload de capa do livro (imagem)

Integração com API externa para consulta de livros (PLUS)

👤 Gerenciamento de Usuários

Cadastro, atualização, remoção e listagem de usuários

Consulta de detalhes do usuário com suas avaliações

Validação de dados

⭐ Avaliações de Livros

Cadastro e listagem de avaliações por livro

Nota obrigatória de 1 a 5

Cálculo automático da nota média do livro

Regra de negócio impedindo mais de uma avaliação por usuário para o mesmo livro

Validação de período de leitura (data de início não pode ser maior que data de fim)

📊 Relatórios (PLUS)

Relatório com a quantidade de livros lidos em determinado ano

🧠 Regras de Negócio

ISBN deve ser único

Nota da avaliação deve estar entre 1 e 5

Um usuário pode avaliar um livro apenas uma vez

A nota média do livro é recalculada automaticamente a cada nova avaliação

🧱 Stack & Arquitetura
🔹 Tecnologias

ASP.NET Core

C#

Entity Framework Core

SQL Server / SQLite

FluentValidation

MediatR

Swagger

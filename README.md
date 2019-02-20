# Sheekr

![Logo](https://github.com/matheusdf6/sheekr-app/blob/master/Project/Design/Brand/logo-608-178.png)

Sheekr é um aplicativo de agendamento construido em ASP.NET Core Web API, Entity Framework Core e React. O objetivo do aplicativo é facilitar o agendamento de discursos, designações e territórios dentro de uma congregação.

## Histórico de Revisões

| Data       | Versão | Descrição                                                                   |
| ---------- | ------ | --------------------------------------------------------------------------- |
| 20/02/2019 | 1.0    | Adicionado objetivos do projeto e requisitos para o campo dos "Territórios" |

## Introdução

### Objetivo do Projeto

O projeto desenvolve a respeito do sistema “Sheekr”, um sistema de agendamento e monitoração para uma congregação, atuando em 3 principais áreas: designação de Territórios para trabalho de campo, designação para os estudantes em “Faça seu melhor no ministério” e agendamento de discursastes, tanto para a própria congregação quanto para os oradores locais

### Delimitação do Problema

Dentro de uma congregação há vários trabalhos que envolvem agendamento e controle do histórico. Por exemplo, quando se fala de territórios para serviço de campo, necessita-se que o responsável tanto mantenha um registro de quando esse território foi designado, de quando ele retorna, como também tem de conferir quais territórios estão sendo mais trabalhados e qual aquele que faz mais tempo em que não é designado. O mesmo acontece com respeito as designações para estudantes e os temas abordados nos discursos públicos.

Portanto o sistema visa facilitar essa parte, através do agendamento intuitivo e visualização interativa dos registros.

## Requisitos do Sistema

Na fase da modelagem, escolheu-se dividir os requisitos em 3 grandes áreas, descrevendo quais os atores envolvidos e as funcionalidades referente a sua área. Dividiu-se então nas seguinte forma:

- Designação de Territórios
- Agendamento de Discursos
- Designação para Estudantes em “Faça seu melhor no ministério”

### PRIMEIRA ÁREA: Territorios

![Casos de Uso](https://github.com/matheusdf6/sheekr-app/blob/master/Project/UserCases/user-case-territorios.png)

#### Descrição dos Atores

- **Usuário 1** – Responsável por fazer as designações do território. Tem permissão para manipular a agenda, as designações, e para fazer apenas consultas nos territórios.
- **DBA** – Data Base Administrator, atua sobre as entidades do sistema, podendo acrescentar, atualizar ou excluir territórios.

#### Descrição dos Casos de Uso

| Referência | Nome do Caso de Uso                                                                                                  |
| ---------- | -------------------------------------------------------------------------------------------------------------------- |
| UC001      | [Designar Territorios](https://github.com/matheusdf6/sheekr-app/blob/master/Project/UserCases/uc001.md)              |
| UC002      | [Retornar Territorios](https://github.com/matheusdf6/sheekr-app/blob/master/Project/UserCases/uc002.md)              |
| UC003      | [Gerar Relatório](https://github.com/matheusdf6/sheekr-app/blob/master/Project/UserCases/uc003.md)                   |
| UC004      | [Consultar Territórios](https://github.com/matheusdf6/sheekr-app/blob/master/Project/UserCases/uc004.md)             |
| UC005      | [Consultar Territórios Disponiveis](https://github.com/matheusdf6/sheekr-app/blob/master/Project/UserCases/uc005.md) |
| UC006      | [Consultar Territórios em Trabalho](https://github.com/matheusdf6/sheekr-app/blob/master/Project/UserCases/uc006.md) |
| UC007      | [Consultar Publicadores](https://github.com/matheusdf6/sheekr-app/blob/master/Project/UserCases/uc007.md)            |
| UC008      | [Consultar Agenda](https://github.com/matheusdf6/sheekr-app/blob/master/Project/UserCases/uc008.md)                  |
| UC009      | [Adicionar Territorios](https://github.com/matheusdf6/sheekr-app/blob/master/Project/UserCases/uc009.md)             |
| UC010      | [Excluir Territorios](https://github.com/matheusdf6/sheekr-app/blob/master/Project/UserCases/uc010.md)               |
| UC011      | [Migrar Territorios](https://github.com/matheusdf6/sheekr-app/blob/master/Project/UserCases/uc011.md)                |

## Diário de Bordo

# GitHub Activity Viewer

Este � um aplicativo de console em C# que permite visualizar as atividades recentes de um usu�rio no GitHub, utilizando a API p�blica do GitHub.

## Funcionalidades

- Busca as atividades p�blicas de um usu�rio no GitHub.
- Exibe uma descri��o amig�vel de cada evento, como:
  - Commits enviados (`PushEvent`)
  - Issues abertas (`IssuesEvent`)
  - Reposit�rios estrelados (`WatchEvent`)
  - Reposit�rios bifurcados (`ForkEvent`).
- Tratamento de erros para exibir mensagens claras em caso de falhas.

## Pr�-requisitos

- .NET 6.0 ou superior instalado na m�quina.
- Conex�o com a internet para acessar a API do GitHub.

## Como usar

### 1. Clonar o reposit�rio
Clone este reposit�rio ou copie o c�digo para um arquivo local.

### 2. Compilar o projeto
Compile o projeto utilizando o SDK do .NET:

`dotnet build`

### 3. Executar o programa

#### Passando o nome de usu�rio como argumento
Execute o programa no terminal, passando o nome de usu�rio do GitHub como argumento:

`dotnet run <username>`


#### Exemplo:

`dotnet run Victorpcheco`


#### Solicitando o nome de usu�rio no console
Se voc� preferir, pode modificar o c�digo para solicitar o nome de usu�rio diretamente no console (j� implementado em uma vers�o alternativa). Nesse caso, ao executar o programa, ele exibir� a mensagem:

`Insira o nome de usu�rio que deseja buscar:`

`Digite o nome de usu�rio e pressione Enter para continuar.`

### 4. Exemplo de sa�da
Ap�s executar o programa, voc� ver� as atividades recentes do usu�rio no GitHub. Exemplo:

`Pushed commits to octocat/Hello-World`<br>
`Opened an issue in octocat/Hello-World`<br>
`Starred octocat/Spoon-Knife`<br>
`Forked octocat/Spoon-Knife`


Ou, em caso de erro na requisi��o:

`Erro ao buscar atividades: NotFound`

## Estrutura do C�digo

- **`GitHubEvent`**: Representa um evento do GitHub, como `PushEvent`, `IssuesEvent`, etc.
- **`GitHubRepo`**: Representa o reposit�rio associado a um evento.
- **`GetDescription`**: M�todo que retorna uma descri��o amig�vel do evento com base no tipo.
- **Requisi��o HTTP**: Utiliza `HttpClient` para buscar dados da API do GitHub.

## Tratamento de Erros

- **Erros de conex�o**: O programa captura exce��es e exibe mensagens claras, como:
  - `Erro: Nome ou servi�o desconhecido` (problemas de rede).
  - `Erro ao buscar atividades: NotFound` (usu�rio n�o encontrado).
- **Valida��o de entrada**: Verifica se o nome de usu�rio foi fornecido e n�o est� vazio.

## Melhorias Futuras

- Adicionar suporte para autentica��o com token do GitHub para evitar limites de requisi��o.
- Melhorar o tratamento de erros para lidar com diferentes c�digos de status HTTP.
- Exibir mais detalhes sobre os eventos, como mensagens de commit ou t�tulos de issues.
- Implementar suporte para salvar os resultados em um arquivo local.

## Licen�a

Este projeto � de uso livre. Sinta-se � vontade para modificar e utilizar conforme necess�rio.

## Contribui��es

Contribui��es s�o bem-vindas! Sinta-se � vontade para abrir issues ou enviar pull requests.

## Refer�ncias

- [Documenta��o da API do GitHub](https://docs.github.com/en/rest)
- [Documenta��o do .NET](https://learn.microsoft.com/en-us/dotnet/)

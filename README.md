# GitHub Activity Viewer

Este é um aplicativo de console em C# que permite visualizar as atividades recentes de um usuário no GitHub, utilizando a API pública do GitHub.

## Funcionalidades

- Busca as atividades públicas de um usuário no GitHub.
- Exibe uma descrição amigável de cada evento, como:
  - Commits enviados (`PushEvent`)
  - Issues abertas (`IssuesEvent`)
  - Repositórios estrelados (`WatchEvent`)
  - Repositórios bifurcados (`ForkEvent`).
- Tratamento de erros para exibir mensagens claras em caso de falhas.

## Pré-requisitos

- .NET 6.0 ou superior instalado na máquina.
- Conexão com a internet para acessar a API do GitHub.

## Como usar

### 1. Clonar o repositório
Clone este repositório ou copie o código para um arquivo local.

### 2. Compilar o projeto
Compile o projeto utilizando o SDK do .NET:

`dotnet build`

### 3. Executar o programa

#### Passando o nome de usuário como argumento
Execute o programa no terminal, passando o nome de usuário do GitHub como argumento:

`dotnet run <username>`


#### Exemplo:

`dotnet run Victorpcheco`


#### Solicitando o nome de usuário no console
Se você preferir, pode modificar o código para solicitar o nome de usuário diretamente no console (já implementado em uma versão alternativa). Nesse caso, ao executar o programa, ele exibirá a mensagem:

`Insira o nome de usuário que deseja buscar:`

`Digite o nome de usuário e pressione Enter para continuar.`

### 4. Exemplo de saída
Após executar o programa, você verá as atividades recentes do usuário no GitHub. Exemplo:

`Pushed commits to octocat/Hello-World`<br>
`Opened an issue in octocat/Hello-World`<br>
`Starred octocat/Spoon-Knife`<br>
`Forked octocat/Spoon-Knife`


Ou, em caso de erro na requisição:

`Erro ao buscar atividades: NotFound`

## Estrutura do Código

- **`GitHubEvent`**: Representa um evento do GitHub, como `PushEvent`, `IssuesEvent`, etc.
- **`GitHubRepo`**: Representa o repositório associado a um evento.
- **`GetDescription`**: Método que retorna uma descrição amigável do evento com base no tipo.
- **Requisição HTTP**: Utiliza `HttpClient` para buscar dados da API do GitHub.

## Tratamento de Erros

- **Erros de conexão**: O programa captura exceções e exibe mensagens claras, como:
  - `Erro: Nome ou serviço desconhecido` (problemas de rede).
  - `Erro ao buscar atividades: NotFound` (usuário não encontrado).
- **Validação de entrada**: Verifica se o nome de usuário foi fornecido e não está vazio.

## Melhorias Futuras

- Adicionar suporte para autenticação com token do GitHub para evitar limites de requisição.
- Melhorar o tratamento de erros para lidar com diferentes códigos de status HTTP.
- Exibir mais detalhes sobre os eventos, como mensagens de commit ou títulos de issues.
- Implementar suporte para salvar os resultados em um arquivo local.

## Licença

Este projeto é de uso livre. Sinta-se à vontade para modificar e utilizar conforme necessário.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

## Referências

- [Documentação da API do GitHub](https://docs.github.com/en/rest)
- [Documentação do .NET](https://learn.microsoft.com/en-us/dotnet/)

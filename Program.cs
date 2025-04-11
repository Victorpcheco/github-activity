using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;


if (args.Length == 0)
{
    Console.WriteLine("Uso: github-activity <username>");
    return;
}

string username = args[0]; 
string url = $"https://api.github.com/users/{username}/events"; // URL da API do GitHub para eventos do usuário


using HttpClient client = new HttpClient();
client.DefaultRequestHeaders.UserAgent.ParseAdd("CSharpApp"); 

try
{
    HttpResponseMessage response = await client.GetAsync(url);

    if (!response.IsSuccessStatusCode)
    {
        Console.WriteLine($"Erro ao buscar atividades: {response.StatusCode}");
        return;
    }

    // Lê o conteúdo da resposta como string JSON
    string json = await response.Content.ReadAsStringAsync();

    // Configura opções para o desserializador JSON (ignorar diferenças de maiúsculas/minúsculas nos nomes das propriedades)
    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    // Desserializa o JSON em uma lista de objetos GitHubEvent
    List<GitHubEvent>? events = JsonSerializer.Deserialize<List<GitHubEvent>>(json, options);

    if (events == null || events.Count == 0)
    {
        Console.WriteLine("Nenhuma atividade encontrada.");
        return;
    }

    foreach (var ev in events)
    {
        Console.WriteLine(ev.GetDescription());
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Erro: {ex.Message}");
}

// Classe que representa um evento do GitHub
public class GitHubEvent
{
    [JsonPropertyName("type")]
    public string Type { get; set; } // Tipo do evento (ex.: PushEvent, IssuesEvent)

    [JsonPropertyName("repo")]
    public GitHubRepo Repo { get; set; }

    public string GetDescription()
    {
        return Type switch
        {
            "PushEvent" => $"Pushed commits to {Repo?.Name}",
            "IssuesEvent" => $"Opened an issue in {Repo?.Name}",
            "WatchEvent" => $"Starred {Repo?.Name}",
            "ForkEvent" => $"Forked {Repo?.Name}",
            _ => $"Did {Type} in {Repo?.Name}"
        };
    }
}

// Classe que representa um repositório do GitHub
public class GitHubRepo
{
    [JsonPropertyName("name")]
    public string Name { get; set; } // Nome do repositório
}

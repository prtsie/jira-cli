using System.Text;
using System.Text.Json;
using JiraCli;

namespace JiraCli;

public class Client
{
    private readonly HttpClient client;
    private readonly string authHeader;
    private readonly string url;
    private readonly JsonSerializerOptions serializerOptions;

    public Client(HttpClient client, string mail, string apiKey, string domain)
    {
        var encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{mail}:{apiKey}"));
        authHeader = $"Basic {encoded}";
        this.client = client;
        url = $"https://{domain}.atlassian.net/rest/api/3";
        serializerOptions = new() { PropertyNameCaseInsensitive = true };
    }

    public async Task<IReadOnlyCollection<Issue>> GetIssues()
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/search");
        BeforeSend(request);
        var response = await client.SendAsync(request);
        var stream = await response.Content.ReadAsStreamAsync();
        Console.WriteLine(await response.Content.ReadAsStringAsync());
        var issues = await JsonSerializer.DeserializeAsync<IReadOnlyCollection<Issue>>(stream, serializerOptions);
        return issues!;
    }

    private void BeforeSend(HttpRequestMessage request)
    {
        request.Headers.Add("Authorization", authHeader);
    }
}

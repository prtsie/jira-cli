using JiraCli.Helpers;
using JiraCli.Models;
using JiraCli.Models.CreateCommand;
using JiraCli.Models.FetchCommand;
using Microsoft.Extensions.Configuration;

namespace JiraCli;

public class JiraClient
{
    private readonly HttpClient client;
    private readonly string authHeader;
    private readonly string url;

    public JiraClient(HttpClient client, IConfiguration configuration)
    {
        var encoded = configuration["base64String"]!;
        var domain = configuration["domain"]!;
        authHeader = $"Basic {encoded}";
        this.client = client;
        url = $"https://{domain}.atlassian.net/rest/api/3";
    }

    public async Task<IReadOnlyCollection<Issue>> GetIssues()
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/search");
        BeforeSend(request);
        var response = await client.SendAsync(request);
        var parsed = await response.Parse<FetchResponse>();
        return parsed!.MapToIssuesCollection();
    }

    public async Task<CreatedIssue> CreateIssue(CreateIssueRequest request)
    {
        using var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{url}/issue");
        BeforeSend(requestMessage);
        var response = await client.SendAsync(requestMessage);
        var parsed = await response.Parse<CreatedIssue>();
        return parsed!;
    }

    private void BeforeSend(HttpRequestMessage request)
    {
        request.Headers.Add("Authorization", authHeader);
    }
}

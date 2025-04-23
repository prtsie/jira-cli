using System.CommandLine.Builder;
using System.CommandLine.Parsing;
using JiraCli.Commands.RootCommand;
using JiraCli.Commands.RootCommand.FetchIssues;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JiraCli;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureAppConfiguration(opts => { opts.AddJsonFile("appsettings.json"); })
            .ConfigureServices(services =>
            {
                services.AddSingleton<JiraCliRoot>();
                services.AddSingleton<FetchIssuesCommand>();
                services.AddSingleton<HttpClient>();
                services.AddSingleton<JiraClient>();
            }).Build();

        var parser = new CommandLineBuilder(host.Services.GetRequiredService<JiraCliRoot>())
            .UseDefaults()
            .Build();
        
        return await parser.InvokeAsync(args);
    }
}
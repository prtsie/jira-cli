using System.CommandLine;
using JiraCli.Commands.RootCommand.FetchIssues;
using Microsoft.Extensions.Configuration;

namespace JiraCli.Commands.RootCommand;

public class JiraCliRoot : System.CommandLine.RootCommand
{
    public JiraCliRoot(IConfiguration configuration, FetchIssuesCommand fetchIssuesCommand) : base(
        "Работа с issues в Jira.")
    {
        this.SetHandler(() =>
        {
            CheckCredentialsAndQuitIfEmpty(configuration);
            Console.WriteLine("Используйте -h или --help для помощи");
        });
        AddCommand(fetchIssuesCommand);
    }

    private static void CheckCredentialsAndQuitIfEmpty(IConfiguration config)
    {
        if (string.IsNullOrWhiteSpace(config["domain"])
            || string.IsNullOrWhiteSpace(config["base64String"]))
        {
            Console.WriteLine("Заполните домен и данные для аутентификации в конфигурации");
            Environment.Exit(1);
        }
    }
}
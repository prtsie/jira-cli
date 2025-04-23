using System.CommandLine;

namespace JiraCli.Commands.RootCommand.FetchIssues;

public class FetchIssuesCommand : Command
{
    public FetchIssuesCommand(JiraClient jiraClient) : base("fetch", "Получить список issue")
    {
        this.SetHandler(async () =>
        {
            var issues = await jiraClient.GetIssues();
            Console.WriteLine(string.Join(Environment.NewLine, issues.Select(i => i.ToString())));
        });
    }
}
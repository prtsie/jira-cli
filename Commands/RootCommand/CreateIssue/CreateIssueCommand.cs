using System.CommandLine;

namespace JiraCli.Commands.RootCommand.CreateIssue;

public class CreateIssueCommand : Command
{
    public CreateIssueCommand(JiraClient JiraClient) : base("create", "Создать issue")
    {
        
    }
}

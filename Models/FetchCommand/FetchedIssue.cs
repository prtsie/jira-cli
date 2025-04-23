namespace JiraCli.Models.FetchCommand;

public class FetchedIssue
{
    public required string Key { get; set; }

    public required IssueFields Fields { get; set; }

    public Issue MapToIssue() =>
        new()
        {
            Key = Key,
            Name = Fields.IssueType.Name
        };
}
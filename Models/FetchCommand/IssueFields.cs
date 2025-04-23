namespace JiraCli.Models.FetchCommand;

public class IssueFields
{
    public required IssueType IssueType { get; set; }

    public string? Description { get; set; }
}
namespace JiraCli.Models.FetchCommand;

public class FetchResponse
{
    public required IReadOnlyCollection<FetchedIssue> Issues { get; set; }

    public IReadOnlyCollection<Issue> MapToIssuesCollection()
    {
        return Issues.Select(i => i.MapToIssue()).ToList();
    }
}
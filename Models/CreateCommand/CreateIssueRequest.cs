namespace JiraCli.Models.CreateCommand;

public class CreateIssueRequest
{
    public required string ProjectId { get; set; }

    public required string Summary { get; set; }

    public required string IssueTypeId { get; set; }
}

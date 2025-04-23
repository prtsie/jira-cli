using System.Text;

namespace JiraCli.Models;

public class Issue
{
    public required string Key { get; set; }

    public required string Name { get; set; }

    public string? Description { get; set; }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.AppendLine($"{Key}: {Name}");
        if (Description != null)
        {
            stringBuilder.AppendLine($"{Description}");
        }

        return stringBuilder.ToString();
    }
}

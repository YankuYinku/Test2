namespace apetito.meinapetito.Portal.Contracts.Root.Infrastructure;

public class EmailDto
{
    public string Subject { get; set; }
    public string Content { get; set; }

    public bool IsSubjectOrContentEmpty => string.IsNullOrWhiteSpace(Subject) || string.IsNullOrWhiteSpace(Content);
}
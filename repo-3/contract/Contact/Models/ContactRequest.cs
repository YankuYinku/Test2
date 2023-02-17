namespace apetito.meinapetito.Portal.Contracts.Contact.Models;

public class ContactRequest
{
    public string TopicCode { get; set; }
    public string TopicDescription { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public string? LanguageCode { get; set; }
}
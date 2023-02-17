using apetito.CQS;

namespace apetito.meinapetito.Portal.Application.Contact.Commands;

public class SendContact : ICommand
{
    public string TopicCode { get; }
    public string TopicDescription { get; }
    public string Subject { get; }
    public string Message { get; }
    public string LanguageCode { get; }

    public SendContact(string topicCode, string topicDescription, string subject, string message, string languageCode, string senderFirstName,
        string senderLastName, string senderEmail)
    {
        TopicCode = topicCode;
        TopicDescription = topicDescription;
        Subject = subject;
        Message = $"{senderFirstName} {senderLastName}{NewLineSeparator}{senderEmail}{NewLineSeparator}{NewLineSeparator}" +
                  $"{topicDescription}{NewLineSeparator}{subject}{NewLineSeparator}{NewLineSeparator}{message}";
        LanguageCode = languageCode;
    }

    private const string NewLineSeparator = "<br/>";
}
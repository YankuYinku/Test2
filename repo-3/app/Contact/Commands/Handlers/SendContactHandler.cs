using apetito.CQS;
using apetito.meinapetito.Portal.Application.Root.Intrastructure.Email.Commands;
using apetito.meinapetito.Portal.Application.Root.Intrastructure.Email.Options;
using apetito.meinapetito.Portal.Contracts.Root.Infrastructure.Consts;

namespace apetito.meinapetito.Portal.Application.Contact.Commands.Handlers;

public class SendContactHandler : ICommandHandler<SendContact>
{
    private readonly ICommandHandler<RegisterEmailToSendCommand> _registerEmailToSendCommandHandler;
    private readonly ICommandHandler<CreateEmailToSendCommand> _createEmailToSendCommandHandler;
    private readonly EmailOptions _emailOptions;
    public SendContactHandler(ICommandHandler<RegisterEmailToSendCommand> registerCommandHandler, ICommandHandler<CreateEmailToSendCommand> createEmailToSendCommandHandler, EmailOptions emailOptions)
    {
        _registerEmailToSendCommandHandler = registerCommandHandler;
        _createEmailToSendCommandHandler = createEmailToSendCommandHandler;
        _emailOptions = emailOptions;
    }

    public async Task Handle(SendContact command)
    {
        var referenceId = Guid.NewGuid();
        EmailOptionsContextEnum context = EmailOptionsContextEnum.ContactFormMail;

        var emailsForTopic = GetReceiversFromOptions(command);
            
        await _createEmailToSendCommandHandler.Handle(new CreateEmailToSendCommand()
        {
            ReferenceId = referenceId,
            Subject = command.Subject,
            Context = context,
            Body = command.Message,
            ToReceivers = emailsForTopic,
            CcReceivers = new List<string>(),
            BccReceivers = new List<string>(),
            AttachmentsUris = new List<string>()
        });
        
        await _registerEmailToSendCommandHandler.Handle(new RegisterEmailToSendCommand
        {
            ReferenceId = referenceId,
            Context = context
        });
    }

    private List<string> GetReceiversFromOptions(SendContact command)
    {
        if (!_emailOptions.ContactFormReceiverAddress.TryGetValue(command.LanguageCode, out var topicWithEmails) )
        {
            topicWithEmails = _emailOptions.ContactFormReceiverAddress.Values.FirstOrDefault();
        }
        
        if (topicWithEmails is null || !topicWithEmails.TryGetValue(command.TopicCode, out var emailsForTopic))
        {
            emailsForTopic = topicWithEmails?.Values.FirstOrDefault();
        }

        return emailsForTopic ?? new List<string>();
    }
}
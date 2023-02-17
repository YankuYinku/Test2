using apetito.meinapetito.Portal.Contracts.Root.Infrastructure.Consts;

namespace apetito.meinapetito.Portal.Contracts.Root.Infrastructure;

public class EmailToSendCacheModel
{
    public Guid ReferenceId { get; set; }
    public EmailOptionsContextEnum? Context { get; set; } = EmailOptionsContextEnum.InvitationMail;
    public string Subject { get; set; }
    public string Body { get; set; }
    public List<string> ToReceivers { get; set; }
    public List<string>? CcReceivers { get; set; }
    public List<string>? BccReceivers { get; set; }
    public List<string>? AttachmentsUris { get; set; }
}
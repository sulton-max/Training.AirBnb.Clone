using AirBnB.Domain.Entities;

namespace AirBnB.Application.Common.Notifications.Models;

/// <summary>
/// Represents an email message for notifications
/// </summary>
public class EmailMessage : NotificationMessage
{
    /// <summary>
    /// Gets or sets email address of sender user
    /// </summary>
    public string SenderEmailAddress { get; set; } = default!;

    /// <summary>
    /// Gets or sets email address of receiver user
    /// </summary>
    public string ReceiverEmailAddress { get; set; } = default!;

    /// <summary>
    /// Gets or sets email template of the email message
    /// </summary>
    public EmailTemplate Template { get; set; } = default!;

    /// <summary>
    /// Gets or sets subject of the email message
    /// </summary>
    public string Subject { get; set; } = default!;

    /// <summary>
    /// Gets or sets body of the email message
    /// </summary>
    public string Body { get; set; } = default!;
}
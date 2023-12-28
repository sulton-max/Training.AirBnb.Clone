using AirBnB.Domain.Entities;

namespace AirBnB.Application.Common.Notifications.Models;

/// <summary>
/// Represents an sms message for notifications
/// </summary>
public class SmsMessage : NotificationMessage
{
    /// <summary>
    /// Gets or sets sms address of sender user
    /// </summary>
    public string SenderEmailAddress { get; set; } = default!;

    /// <summary>
    /// Gets or sets sms address of receiver user
    /// </summary>
    public string ReceiverEmailAddress { get; set; } = default!;

    /// <summary>
    /// Gets or sets sms template of the sms message
    /// </summary>
    public SmsTemplate Template { get; set; } = default!;

    /// <summary>
    /// Gets or sets message of the sms message
    /// </summary>
    public string Message { get; set; } = default!;
}

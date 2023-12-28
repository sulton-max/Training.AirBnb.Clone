namespace AirBnB.Application.Common.Notifications.Models;

/// <summary>
/// Represents an abstract base class for notification message
/// </summary>
public abstract class NotificationMessage
{
    /// <summary>
    /// Gets or sets sender user's id of the notification message
    /// </summary>
    public Guid SenderUserId { get; set; }

    /// <summary>
    /// Gets or sets receiver user's id of the notification message
    /// </summary>
    public Guid ReceiverUserId { get; set; }

    /// <summary>
    /// Gets or sets variables of the notification message
    /// </summary>
    /// <remarks>
    /// These variables is needed for rendering message
    /// </remarks>
    public Dictionary<string, string> Variables { get; set; }

    /// <summary>
    /// Gets or sets if the notification message is send successfully or not
    /// </summary>
    public bool IsSuccessful { get; set; }

    /// <summary>
    /// Gets or sets error message of the notification message
    /// </summary>
    /// <remarks>
    /// if therse is exception is thrown while sending message, errormessage determines message of exception
    /// </remarks>
    public string? ErrorMessage { get; set; }
}

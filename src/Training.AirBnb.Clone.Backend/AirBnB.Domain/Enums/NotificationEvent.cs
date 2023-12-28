namespace AirBnB.Domain.Enums;

/// <summary>
/// Represents different events related to notification in the application lifecycle
/// </summary>
public enum NotificationEvent
{
    /// <summary>
    /// Represents rendering events related to notification in the application lifecycle
    /// </summary>
    OnRendering,

    /// <summary>
    /// Represents sending events related to notification in the application lifecycle
    /// </summary>
    OnSending,

    /// <summary>
    /// Represents saving events related to notification in the application lifecycle
    /// </summary>
    OnSaving
}

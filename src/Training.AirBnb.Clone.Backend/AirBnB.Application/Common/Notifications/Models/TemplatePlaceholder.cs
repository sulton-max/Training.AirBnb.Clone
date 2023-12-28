namespace AirBnB.Application.Common.Notifications.Models;

/// <summary>
/// Represents a placeholder for notification template
/// </summary>
public class TemplatePlaceholder
{
    /// <summary>
    /// Gets or sets placeholder of the value 
    /// </summary>
    ///<remarks>
    /// placeholder is the thing which is going to be replaced with the value in rendering 
    ///</remarks>
    public string Placeholder { get; set; } = default!;

    /// <summary>
    /// Gets or sets value of placeholder
    /// </summary>
    public string PlaceholderValue { get; set; } = default!;

    /// <summary>
    /// Gets or sets value of the template
    /// </summary>
    /// <remarks>
    /// value is the information which is should be replaced with placeholders of the template in rendering 
    /// </remarks>
    public string? Value { get; set; } = default!;

    /// <summary>
    /// Gets or sets if the placeholder is valid or not
    /// </summary>
    public bool IsValid { get; set; }
}

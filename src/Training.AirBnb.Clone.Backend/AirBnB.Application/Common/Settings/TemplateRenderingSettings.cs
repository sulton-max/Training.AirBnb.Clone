namespace AirBnB.Application.Common.Settings;
/// <summary>
/// Represents a settings for rendering messages
/// </summary>
public class TemplateRenderingSettings
{
    /// <summary>
    /// Gets or sets the regular expression pattern for placeholder of notification template's content
    /// </summary>
    public string PlaceholderRegexPattern { get; set; } = default!;

    /// <summary>
    /// Gets or sets the regular expression pattern for value of placeholder 
    /// </summary>
    public string PlaceholderValueRegexPattern { get; set; } = default!;

    /// <summary>
    /// Gets or sets time out of regular expression pattern matching in seconds
    /// </summary>
    public int RegexMatchTimeoutInSeconds { get; set; }
}

namespace AirBnB.Api.Models.DTOs;

/// <summary>
/// Data Transfer Object (DTO) representing an access token.
/// </summary>
public class AccessTokenDto
{
    /// <summary>
    /// Gets or sets the access token string.
    /// </summary>
    /// <remarks>
    /// The exclamation mark indicates that the property is not expected to be null after initialization.
    /// </remarks>
    public string Token { get; set; } = default!;

    /// <summary>
    /// Gets or sets the expiration time of the access token.
    /// </summary>
    public DateTimeOffset ExpiryTime { get; set; }
}

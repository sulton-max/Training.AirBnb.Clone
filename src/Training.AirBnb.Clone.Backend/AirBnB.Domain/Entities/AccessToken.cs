using AirBnB.Domain.Common;

namespace AirBnB.Domain.Entities;

/// <summary>
/// Represents an access token entity.
/// </summary>
public class AccessToken : Entity
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public AccessToken()
    {
    }

    /// <summary>
    /// Parameterized constructor to initialize an access token.
    /// </summary>
    /// <param name="id">The unique identifier of the access token.</param>
    /// <param name="userId">The unique identifier of the associated user.</param>
    /// <param name="token">The access token string.</param>
    /// <param name="expiryTime">The expiration time of the access token.</param>
    /// <param name="isRevoked">A flag indicating whether the access token is revoked.</param>
    public AccessToken(Guid id, Guid userId, string token, DateTimeOffset expiryTime, bool isRevoked)
    {
        Id = id;
        UserId = userId;
        Token = token;
        ExpiryTime = expiryTime;
        IsRevoked = isRevoked;
    }

    /// <summary>
    /// Gets or sets the unique identifier of the associated user.
    /// </summary>
    public Guid UserId { get; set; }

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

    /// <summary>
    /// Gets or sets a flag indicating whether the access token is revoked.
    /// </summary>
    public bool IsRevoked { get; set; }
}

namespace AirBnB.Infrastructure.Common.Settings;

/// <summary>
/// Represents settings related to JSON Web Token (JWT) authentication and validation.
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// Gets or sets a value indicating whether to validate the issuer of the JWT.
    /// </summary>
    public bool ValidateIssuer { get; set; }

    /// <summary>
    /// Gets or sets the valid issuer for JWT validation.
    /// </summary>
    /// <remarks>
    /// The exclamation mark indicates that the property is not expected to be null after initialization.
    /// </remarks>
    public string ValidIssuer { get; set; } = default!;

    /// <summary>
    /// Gets or sets a value indicating whether to validate the audience of the JWT.
    /// </summary>
    public bool ValidateAudience { get; set; }

    /// <summary>
    /// Gets or sets the valid audience for JWT validation.
    /// </summary>
    /// <remarks>
    /// The exclamation mark indicates that the property is not expected to be null after initialization.
    /// </remarks>
    public string ValidAudience { get; set; } = default!;

    /// <summary>
    /// Gets or sets a value indicating whether to validate the lifetime of the JWT.
    /// </summary>
    public bool ValidateLifetime { get; set; }

    /// <summary>
    /// Gets or sets the expiration time of JWTs in minutes.
    /// </summary>
    public int ExpirationTimeInMinute { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to validate the issuer signing key of the JWT.
    /// </summary>
    public bool ValidateIssuerSigningKey { get; set; }

    /// <summary>
    /// Gets or sets the secret key used for JWT signing and validation.
    /// </summary>
    /// <remarks>
    /// The exclamation mark indicates that the property is not expected to be null after initialization.
    /// </remarks>
    public string SecretKey { get; set; } = default!;
}
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AirBnB.Application.Common.Notifications.Services;
using AirBnB.Domain.Constants;
using AirBnB.Domain.Entities;
using AirBnB.Infrastructure.Common.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AirBnB.Infrastructure.Common.Identity.Services;

/// <summary>
/// Service responsible for generating and handling access tokens based on JWT settings.
/// </summary>
public class AccessTokenGeneratorService(IOptions<JwtSettings> jwtSettings) : IAccessTokenGeneratorService
{
    /// <summary>
    /// Initializes a new instance of the AccessTokenGeneratorService class.
    /// </summary>
    /// <param name="jwtSettings">Options for configuring JWT settings injected via dependency injection.</param>
    private readonly JwtSettings _jwtSettings = jwtSettings.Value;

    /// <summary>
    /// Generates an access token for the specified user.
    /// </summary>
    /// <param name="user">The user for whom the access token is generated.</param>
    /// <returns>An AccessToken object representing the generated access token.</returns>
    public AccessToken GetToken(User user)
    {
        // Create a new AccessToken instance with a unique identifier.
        var accessToken = new AccessToken
        {
            Id = Guid.NewGuid()
        };

        // Generate a JWT token for the user and associate it with the AccessToken.
        var jwtToken = GetJwtToken(user, accessToken);

        // Write the JWT token to a string and assign it to the AccessToken's Token property.
        var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        accessToken.Token = token;

        // Return the generated AccessToken.
        return accessToken;
    }
    
    /// <summary>
    /// Retrieves the unique identifier (ID) associated with the provided JWT access token.
    /// </summary>
    /// <param name="accessToken">The JWT access token from which to extract the ID.</param>
    /// <returns>The unique identifier (ID) associated with the provided access token.</returns>
    /// <exception cref="ArgumentException">Thrown if the access token is invalid or the associated ID is missing.</exception>
    public Guid GetTokenId(string accessToken)
    {
        // Extract the token value from the authorization header.
        var tokenValue = accessToken.Split(' ')[1];

        // Create a JwtSecurityTokenHandler to read and parse the JWT token.
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(tokenValue);

        // Retrieve the unique identifier (ID) claim from the token.
        var tokenId = token.Claims.FirstOrDefault(c => c.Type == ClaimConstants.AccessTokenId)?.Value;

        // Validate and parse the retrieved ID, throwing an exception if it is invalid or missing.
        if (string.IsNullOrEmpty(tokenId))
            throw new ArgumentException("Invalid AccessToken");

        return Guid.Parse(tokenId);
    }

    /// <summary>
    /// Generates a JWT security token for the specified user and access token.
    /// </summary>
    /// <param name="user">The user for whom the token is generated.</param>
    /// <param name="accessToken">The associated access token.</param>
    /// <returns>A JwtSecurityToken representing the generated JWT token.</returns>
    private JwtSecurityToken GetJwtToken(User user, AccessToken accessToken)
    {
        // Retrieve the claims associated with the user and access token.
        var claims = GetClaims(user, accessToken);

        // Create a SymmetricSecurityKey using the specified secret key.
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

        // Create SigningCredentials using the security key and HMACSHA256 algorithm.
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        // Create and return a new JwtSecurityToken with the specified parameters.
        return new JwtSecurityToken(
            _jwtSettings.ValidIssuer,
            _jwtSettings.ValidAudience,
            claims,
            DateTime.UtcNow,
            DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationTimeInMinute),
            credentials
        );
    }

    /// <summary>
    /// Retrieves a list of claims associated with the specified user and access token.
    /// </summary>
    /// <param name="user">The user for whom claims are generated.</param>
    /// <param name="accessToken">The associated access token.</param>
    /// <returns>A list of Claim objects representing the generated claims.</returns>
    private List<Claim> GetClaims(User user, AccessToken accessToken)
    {
        // Create a list of claims with standard and custom claim types.
        return new List<Claim>
        {
            // Claim representing the user's email address.
            new(ClaimTypes.Email, user.EmailAddress),

            // Claim representing the user's role.
            new(ClaimTypes.Role, user.Role.ToString()),

            // Claim representing the user's unique identifier.
            new(ClaimConstants.UserId, user.Id.ToString()),

            // Claim representing the unique identifier of the associated access token.
            new(ClaimConstants.AccessTokenId, accessToken.Id.ToString())
        };
    }
}
using AirBnB.Domain.Entities;

namespace AirBnB.Application.Common.Notifications.Services;

/// <summary>
/// Interface for a service responsible for generating and managing access tokens.
/// </summary>
public interface IAccessTokenGeneratorService
{
    /// <summary>
    /// Generates an access token for the specified user.
    /// </summary>
    /// <param name="user">The user for whom the access token is generated.</param>
    /// <returns>An AccessToken object representing the generated access token.</returns>
    AccessToken GetToken(User user);

    /// <summary>
    /// Retrieves the unique identifier (ID) associated with the provided access token.
    /// </summary>
    /// <param name="accessToken">The access token for which the ID is to be retrieved.</param>
    /// <returns>The unique identifier (ID) associated with the provided access token.</returns>
    Guid GetTokenId(string accessToken);
}

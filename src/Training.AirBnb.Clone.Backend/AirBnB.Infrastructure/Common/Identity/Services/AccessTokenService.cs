using AirBnB.Application.Common.Notifications.Services;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.Repositories.Interfaces;

namespace AirBnB.Infrastructure.Common.Identity.Services;

/// <summary>
/// Service for managing access tokens using an access token repository.
/// </summary>
public class AccessTokenService(IAccessTokenRepository accessTokenRepository) : IAccessTokenService
{
    /// <summary>
    /// Asynchronously creates a new access token.
    /// </summary>
    /// <param name="accessToken">The access token to be created.</param>
    /// <param name="saveChanges">Indicates whether changes should be saved to the underlying data store (default is true).</param>
    /// <param name="cancellationToken">Cancellation token to stop the operation if needed (default is none).</param>
    /// <returns>A ValueTask representing the asynchronous operation, returning the created AccessToken.</returns>
    public ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return accessTokenRepository.CreateAsync(accessToken, saveChanges, cancellationToken);
    }

    /// <summary>
    /// Asynchronously retrieves an access token by its unique identifier.
    /// </summary>
    /// <param name="accessTokenId">The unique identifier of the access token to retrieve.</param>
    /// <param name="cancellationToken">Cancellation token to stop the operation if needed (default is none).</param>
    /// <returns>A ValueTask representing the asynchronous operation, returning the retrieved AccessToken, or null if not found.</returns>
    public ValueTask<AccessToken?> GetByIdAsync(Guid accessTokenId, CancellationToken cancellationToken = default)
    {
        return accessTokenRepository.GetByIdAsync(accessTokenId, cancellationToken);
    }

    /// <summary>
    /// Asynchronously revokes (invalidates) an access token by updating its IsRevoked property.
    /// </summary>
    /// <param name="accessTokenId">The unique identifier of the access token to revoke.</param>
    /// <param name="cancellationToken">Cancellation token to stop the operation if needed (default is none).</param>
    /// <exception cref="InvalidOperationException">Thrown if the specified access token is not found.</exception>
    public async ValueTask RevokeAsync(Guid accessTokenId, CancellationToken cancellationToken = default)
    {
        // Retrieve the access token by its ID.
        var accessToken = await GetByIdAsync(accessTokenId, cancellationToken);

        // Check if the access token exists; throw an exception if not found.
        if (accessToken is null)
            throw new InvalidOperationException($"Access with id {accessTokenId} not found.");

        // Set the IsRevoked property to true and update the access token in the repository.
        accessToken.IsRevoked = true;
        await accessTokenRepository.UpdateAsync(accessToken, cancellationToken);
    }
}
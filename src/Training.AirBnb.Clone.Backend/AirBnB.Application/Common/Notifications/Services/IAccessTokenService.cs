using AirBnB.Domain.Entities;

namespace AirBnB.Application.Common.Notifications.Services;

/// <summary>
/// Interface for managing access tokens.
/// </summary>
public interface IAccessTokenService
{
    /// <summary>
    /// Asynchronously creates a new access token.
    /// </summary>
    /// <param name="accessToken">The access token to create.</param>
    /// <param name="saveChanges">Indicates whether changes should be saved to the underlying data store (default is true).</param>
    /// <param name="cancellationToken">Cancellation token to stop the operation if needed (default is none).</param>
    /// <returns>A ValueTask representing the asynchronous operation, returning the created AccessToken.</returns>
    ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves an access token by its unique identifier.
    /// </summary>
    /// <param name="accessTokenId">The unique identifier of the access token to retrieve.</param>
    /// <param name="cancellationToken">Cancellation token to stop the operation if needed (default is none).</param>
    /// <returns>A ValueTask representing the asynchronous operation, returning the retrieved AccessToken, or null if not found.</returns>
    ValueTask<AccessToken?> GetByIdAsync(Guid accessTokenId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously revokes (invalidates) an access token.
    /// </summary>
    /// <param name="accessTokenId">The unique identifier of the access token to revoke.</param>
    /// <param name="cancellationToken">Cancellation token to stop the operation if needed (default is none).</param>
    /// <returns>A ValueTask representing the asynchronous operation.</returns>
    ValueTask RevokeAsync(Guid accessTokenId, CancellationToken cancellationToken = default);
}

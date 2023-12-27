using AirBnB.Domain.Entities;
using AirBnB.Persistence.Caching.Brokers;
using AirBnB.Persistence.Caching.Models;
using AirBnB.Persistence.Repositories.Interfaces;

namespace AirBnB.Persistence.Repositories;

/// <summary>
/// Repository for managing AccessToken entities using a cache-based storage mechanism.
/// Initializes a new instance of the AccessTokenRepository class.
/// </summary>
/// <param name="cacheBroker">The cache broker responsible for handling cache operations.</param>
public class AccessTokenRepository(ICacheBroker cacheBroker) : IAccessTokenRepository
{
    /// <summary>
    /// Asynchronously creates a new AccessToken entity and stores it in the cache.
    /// </summary>
    /// <param name="accessToken">The AccessToken entity to be created and stored.</param>
    /// <param name="saveChanges">Indicates whether changes should be saved to the underlying data store (default is true).</param>
    /// <param name="cancellationToken">Cancellation token to stop the operation if needed (default is none).</param>
    /// <returns>A ValueTask representing the asynchronous operation, returning the created AccessToken.</returns>
    public async ValueTask<AccessToken> CreateAsync(AccessToken accessToken, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        // Set cache entry with expiration based on AccessToken's ExpiryTime.
        var cacheEntryOptions = new CacheEntryOptions(accessToken.ExpiryTime - DateTimeOffset.UtcNow, null);
        await cacheBroker.SetAsync(accessToken.Id.ToString(), accessToken, cacheEntryOptions, cancellationToken);

        return accessToken;
    }

    /// <summary>
    /// Asynchronously retrieves an AccessToken entity by its unique identifier from the cache.
    /// </summary>
    /// <param name="accessTokenId">The unique identifier of the AccessToken entity to retrieve.</param>
    /// <param name="cancellationToken">Cancellation token to stop the operation if needed (default is none).</param>
    /// <returns>A ValueTask representing the asynchronous operation, returning the retrieved AccessToken, or null if not found.</returns>
    public ValueTask<AccessToken?> GetByIdAsync(Guid accessTokenId, CancellationToken cancellationToken = default)
    {
        return cacheBroker.GetAsync<AccessToken>(accessTokenId.ToString(), cancellationToken);
    }

    /// <summary>
    /// Asynchronously updates an existing AccessToken entity in the cache.
    /// </summary>
    /// <param name="accessToken">The AccessToken entity to be updated in the cache.</param>
    /// <param name="cancellationToken">Cancellation token to stop the operation if needed (default is none).</param>
    /// <returns>A ValueTask representing the asynchronous operation, returning the updated AccessToken.</returns>
    public async ValueTask<AccessToken> UpdateAsync(AccessToken accessToken, CancellationToken cancellationToken = default)
    {
        // Update cache entry with expiration based on AccessToken's ExpiryTime.
        var cacheEntryOptions = new CacheEntryOptions(accessToken.ExpiryTime - DateTimeOffset.UtcNow, null);
        await cacheBroker.SetAsync(accessToken.Id.ToString(), accessToken, cacheEntryOptions, cancellationToken);

        return accessToken;
    }
} 
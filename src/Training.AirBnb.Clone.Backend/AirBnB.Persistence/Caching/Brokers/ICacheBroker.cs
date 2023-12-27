using AirBnB.Persistence.Caching.Models;

namespace AirBnB.Persistence.Caching.Brokers;
/// <summary>
/// Represents an interface for a cache broker that provides methods for interacting with a caching mechanism.
/// </summary>
public interface ICacheBroker
{
    /// <summary>
    /// Asynchronously retrieves a cached item with the specified key.
    /// </summary>
    /// <param name="key"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    ValueTask<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);

    /// <summary>
    /// Attempts to asynchronously retrieve a cached item with the specified key.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    ValueTask<bool> TryGetAsync<T>(string key, out T? value, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously retrieves a cached item with the specified key, or sets the item if it does not exist.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="valueFactory"></param>
    /// <param name="cacheEntryOptions"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    ValueTask<T?> GetOrSetAsync<T>(
        string key,
        Func<Task<T>> valueFactory,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Asynchronously sets a cached item with the specified key and value.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <param name="entryOptions"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    ValueTask SetAsync<T>(string key, T value, CacheEntryOptions? entryOptions = default, CancellationToken cancellationToken = default);

    /// <summary>
    /// Asynchronously deletes a cached item with the specified key.
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    ValueTask DeleteAsync(string key, CancellationToken cancellationToken = default);
}
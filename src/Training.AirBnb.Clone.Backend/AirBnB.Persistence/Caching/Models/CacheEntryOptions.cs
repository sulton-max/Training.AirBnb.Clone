namespace AirBnB.Persistence.Caching.Models;

/// <summary>
/// Represents the options for configuring cache entry behavior.
/// </summary>
public class CacheEntryOptions
{
    /// <summary>
    /// Gets or sets the absolute expiration time relative to the current moment.
    /// </summary>
    public TimeSpan? AbsoluteExpirationRelativeToNow { get; init; }
    
    /// <summary>
    /// Gets or sets the sliding expiration time for cached items.
    /// </summary>
    public TimeSpan? SlidingExpiration { get; init; }

    /// <summary>
    /// /// Initializes a new instance of the <see cref="CacheEntryOptions"/> class.
    /// </summary>
    public CacheEntryOptions()
    {
    }

    /// <summary>
    /// /// Initializes a new instance of the <see cref="CacheEntryOptions"/> class with specified absolute and sliding expiration times.
    /// </summary>
    /// <param name="absoluteExpirationRelativeToNow"></param>
    /// <param name="slidingExpiration"></param>
    public CacheEntryOptions(TimeSpan? absoluteExpirationRelativeToNow, TimeSpan? slidingExpiration)
    {
        AbsoluteExpirationRelativeToNow = absoluteExpirationRelativeToNow;
        SlidingExpiration = slidingExpiration;
    }
}
using AirBnB.Domain.Entities;

namespace AirBnB.Application.Common.Identity.Services;

/// <summary>
/// Represents the contract for managing user accounts, providing methods for user creation,
/// retrieval by email address, and user verification.
/// </summary>
public interface IAccountService
{
    /// <summary>
    /// creates a new user with the specified information.
    /// </summary>
    /// <param name="user"></param>
    /// <param name="saveChanges"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<bool> CreateUserAsync(User user, bool saveChanges = true, CancellationToken cancellationToken = default);

    /// <summary>
    /// retrieves a user by their email address.
    /// </summary>
    /// <param name="emailAddress"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<User?> GetUserByEmailAddressAsync(string emailAddress, bool asNoTracking = false, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// verifies a user by their verification token.
    /// </summary>
    /// <param name="emailAddress"></param>
    /// <param name="asNoTracking"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<bool> VerifyUserAsync(string emailAddress, bool asNoTracking = false, CancellationToken cancellationToken = default);
}
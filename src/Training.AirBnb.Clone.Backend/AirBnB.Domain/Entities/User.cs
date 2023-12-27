using AirBnB.Domain.Common;
using AirBnB.Domain.Enums;

namespace AirBnB.Domain.Entities;

/// <summary>
/// Represents a user entity
/// </summary>
public sealed class User : SoftDeletedEntity
{
    /// <summary>
    /// Gets or sets the first name of the user
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the last name of the user 
    /// </summary>
    public string LastName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the email address of the user
    /// </summary>
    public string EmailAddress { get; set; } = default!;

    /// <summary>
    ///Gets or sets the password of the user 
    /// </summary>
    public string Password { get; set; } = default!;
    
    ///<summary>
    /// Gets or sets the Role Id of user
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// Gets or sets the User role type
    /// </summary>
    public Role Role { get; set; }
    
    /// <summary>
    /// Gets or sets user activation
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    ///Gets or sets user's phone number 
    /// </summary>
    public string PhoneNumber { get; set; } = default!;
    
    /// <summary>
    /// User settings property for includes
    /// </summary>
    public UserSettings? UserSettings { get; set; }
}
using AirBnB.Domain.Common;
using AirBnB.Domain.Enums;

namespace AirBnB.Domain.Entities;
/// <summary>
/// This class represents a Role entity in the AirBnB application. 
/// </summary>

public class Role : IEntity
{
    /// <summary>
    /// Unique identifier for the Role entity. 
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Represents the type of the role (e.g., Admin, User, etc.).
    /// </summary>
    public RoleType Type { get; set; }

    /// <summary>
    /// Indicates whether the role is disabled or not. 
    /// </summary>
    public bool IsDisable { get; set; }

    /// <summary>
    /// Timestamp indicating when this role was created. 
    /// </summary>
    public DateTime CreatedTime { get; set; }

    /// <summary>
    /// Timestamp indicating the last modification time of this role. 
    /// </summary>
    public DateTime ModifiedTime { get; set; }
}

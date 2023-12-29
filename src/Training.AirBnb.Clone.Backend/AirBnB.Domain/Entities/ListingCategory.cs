using AirBnB.Domain.Common;

namespace AirBnB.Domain.Entities;

/// <summary>
/// Represents a category for a listing
/// </summary>
public class ListingCategory : SoftDeletedEntity
{
    /// <summary>
    /// Gets or sets the category name
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Gets or sets a value indicating whether the category is a special category or regular one.
    /// </summary>
    public bool IsSpecialCategory { get; set; }

    /// <summary>
    /// Gets or sets the category image id
    /// </summary>
    public Guid StorageFileId { get; set; }

    /// <summary>
    /// Gets or sets the category image
    /// </summary>
    public virtual StorageFile ImageStorageFile { get; set; }
}
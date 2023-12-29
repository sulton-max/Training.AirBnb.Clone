namespace AirBnB.Api.Models.DTOs;

/// <summary>
/// Data Transfer Object (DTO) representing a listing category.
/// </summary>
public class ListingCategoryDto
{
    /// <summary>
    /// Gets or sets the unique identifier for the listing category.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the listing category.
    /// </summary>
    public string Name { get; set; } = default!;

    /// <summary>
    /// Gets or sets the URL of the image associated with the listing category.
    /// </summary>
    public string ImageUrl { get; set; } = default!;
}
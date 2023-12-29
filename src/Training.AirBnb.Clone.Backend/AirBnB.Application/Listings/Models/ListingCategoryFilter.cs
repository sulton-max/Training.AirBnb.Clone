using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;

namespace AirBnB.Application.Listings.Models;

/// <summary>
/// Represents a listing category filter
/// </summary>
public class ListingCategoryFilter : FilterPagination, IQueryConvertible<ListingCategory>
{
    /// <summary>
    /// Converts ListingCategoryFilter to QuerySpecification<ListingCategory>
    /// </summary>
    /// <param name="asNoTracking"></param>
    /// <returns></returns>
    public new QuerySpecification<ListingCategory> ToQuerySpecification()
    {
        var querySpecification = new QuerySpecification<ListingCategory>(int.MaxValue, 1, true);

        querySpecification.IncludingOptions.Add(category => category.ImageStorageFile);

        return querySpecification;
    }

    /// <summary>
    /// Overrides base GetHashCode method
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageSize);
        hashCode.Add(PageToken);

        return hashCode.ToHashCode();
    }

    /// <summary>
    /// Overrides base Equals method
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj) => 
        obj is ListingCategoryFilter listingCategoryFilter 
            && listingCategoryFilter.GetHashCode() == GetHashCode();
}
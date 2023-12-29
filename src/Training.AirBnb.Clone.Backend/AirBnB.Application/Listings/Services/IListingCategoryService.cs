using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;

namespace AirBnB.Application.Listings.Services;

/// <summary>
/// Defines location category foundation service functionalities.
/// </summary>
public interface IListingCategoryService
{
    /// <summary>
    /// Retrieves a list of locations categories based on the provided query specification.
    /// </summary>
    /// <param name="querySpecification"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<IList<ListingCategory>> GetAsync(
        QuerySpecification<ListingCategory> querySpecification,
        CancellationToken cancellationToken = default);
}
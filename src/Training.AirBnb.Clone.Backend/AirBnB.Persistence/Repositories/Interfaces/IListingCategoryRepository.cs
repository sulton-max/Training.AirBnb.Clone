using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;

namespace AirBnB.Persistence.Repositories.Interfaces;

/// <summary>
/// Defines listing category repository functionalities
/// </summary>
public interface IListingCategoryRepository
{
    /// <summary>
    /// Retrieves a list of listing categories based on the specified query specification asynchronously.
    /// </summary>
    /// <param name="querySpecification"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<IList<ListingCategory>> GetAsync(
        QuerySpecification<ListingCategory> querySpecification, 
        CancellationToken cancellationToken = default);
}
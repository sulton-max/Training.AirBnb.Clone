using AirBnB.Application.Listings.Services;
using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.Repositories.Interfaces;

namespace AirBnB.Infrastructure.Listings.Services;

/// <summary>
/// Foundation service for managing Listing Category related operations
/// </summary>
/// <param name="listingCategoryRepository"></param>
public class ListingCategoryService(IListingCategoryRepository listingCategoryRepository) : IListingCategoryService
{
    public ValueTask<IList<ListingCategory>> GetAsync(
        QuerySpecification<ListingCategory> querySpecification,
        CancellationToken cancellationToken = default)
    {
        return listingCategoryRepository.GetAsync(querySpecification, cancellationToken);
    }
}
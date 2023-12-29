using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.Caching.Brokers;
using AirBnB.Persistence.Caching.Models;
using AirBnB.Persistence.DataContexts;
using AirBnB.Persistence.Repositories.Interfaces;

namespace AirBnB.Persistence.Repositories;

public class ListingCategoryRepository(IdentityDbContext dbContext, ICacheBroker cacheBroker) : EntityRepositoryBase<ListingCategory, IdentityDbContext>(dbContext, cacheBroker, new CacheEntryOptions()), IListingCategoryRepository
{
    public new ValueTask<IList<ListingCategory>> GetAsync(
        QuerySpecification<ListingCategory> querySpecification, 
        CancellationToken cancellationToken = default)
    {
        return base.GetAsync(querySpecification, cancellationToken);
    }
}
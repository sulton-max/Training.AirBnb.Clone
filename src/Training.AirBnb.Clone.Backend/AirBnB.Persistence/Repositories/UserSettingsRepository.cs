using AirBnB.Domain.Common.Query;
using AirBnB.Domain.Entities;
using AirBnB.Persistence.Caching.Brokers;
using AirBnB.Persistence.DataContexts;
using AirBnB.Persistence.Repositories.Interfaces;
using System.Linq.Expressions;

namespace AirBnB.Persistence.Repositories;

public class UserSettingsRepository(IdentityDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<UserSettings, IdentityDbContext>(dbContext, cacheBroker, new()), IUserSettingsRepository
{
    public new ValueTask<UserSettings> CreateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
        => base.CreateAsync(userSettings, saveChanges, cancellationToken);

    public new ValueTask<UserSettings?> DeleteAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
        => base.DeleteAsync(userSettings, saveChanges, cancellationToken);

    public new ValueTask<UserSettings?> DeleteByIdAsync(Guid userSettingsId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => base.DeleteByIdAsync(userSettingsId, saveChanges, cancellationToken);

    public new IQueryable<UserSettings> Get(Expression<Func<UserSettings, bool>>? predicate, bool asNoTracking = false)
        => base.Get(predicate, asNoTracking);

    public new ValueTask<IList<UserSettings>> GetAsync(QuerySpecification<UserSettings> querySpecification, CancellationToken cancellationToken = default)
        => base.GetAsync(querySpecification, cancellationToken);

    public new ValueTask<IList<UserSettings>> GetAsync(QuerySpecification querySpecification, CancellationToken cancellationToken = default)
        => base.GetAsync(querySpecification, cancellationToken);

    public new ValueTask<UserSettings?> GetByIdAsync(Guid userSettingsId, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => base.GetByIdAsync(userSettingsId, asNoTracking, cancellationToken);

    public new ValueTask<IList<UserSettings>> GetByIdsAsync(IEnumerable<Guid> ids, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => base.GetByIdsAsync(ids, asNoTracking, cancellationToken);

    public new ValueTask<UserSettings> UpdateAsync(UserSettings userSettings, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundUserSettings = dbContext.UserSettings.SingleOrDefault(dbUserSettings => dbUserSettings.Id == userSettings.Id)
            ?? throw new InvalidOperationException("User settings not found with this Id!");

        foundUserSettings.PreferredTheme = userSettings.PreferredTheme;
        foundUserSettings.PreferredNotificationType = userSettings.PreferredNotificationType;

        return base.UpdateAsync(foundUserSettings, saveChanges, cancellationToken);
    }
}

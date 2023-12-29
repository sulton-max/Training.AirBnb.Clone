using Microsoft.EntityFrameworkCore;

namespace AirBnB.Persistence.Extensions;

/// <summary>
/// A static class providing extension methods for configuring entity models in Entity Framework.
/// </summary>
public static class DbContextExtensions
{
    /// <summary>
    /// // Extension method for applying entity configurations to the provided ModelBuilder instance. Assumes TDataContext is a DbContext.
    /// </summary>
    /// <typeparam name="TDataContext"></typeparam>
    /// <param name="modelBuilder"></param>
    public static void ApplyEntityConfigurations<TDataContext>(this ModelBuilder modelBuilder) where TDataContext : DbContext
    {
        var dbContextType = typeof(TDataContext);

        var entityConfigurationTypes = GetEntityConfigurations(dbContextType).ToList();

        entityConfigurationTypes.ForEach(type => modelBuilder.ApplyConfiguration((dynamic)Activator.CreateInstance(type)!));
    }

    /// <summary>
    /// Retrieves entity types from the specified DbContext type by inspecting its properties of type DbSet<>.
    /// </summary>
    /// <param name="dbContextType"></param>
    /// <returns>A list of entity types extracted from DbSet<> properties in the DbContext.</returns>
    public static IList<Type> GetEntityTypes(Type dbContextType)
    {
        var dbSetProperties = dbContextType
           .GetProperties()
           .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

        return dbSetProperties
            .Select(p => p.PropertyType.GetGenericArguments()[0])
            .ToList();
    }


    /// <summary>
    /// Retrieves entity configuration types related to the specified DbContext type.
    /// </summary>
    /// <param name="dbContextType">The type of DbContext to analyze.</param>
    /// <returns>
    /// A list of types representing entity configurations associated with the entities in the DbContext.
    /// </returns>
    public static IList<Type> GetEntityConfigurations(Type dbContextType)
    {
        var dbSetTypes = GetEntityTypes(dbContextType);

        var possibleEntityConfigurationTypes = dbSetTypes
            .Select(dbSetType => typeof(IEntityTypeConfiguration<>)
            .MakeGenericType(dbSetType))
            .ToList();

        var matchingConfigurationTypes = AppDomain.CurrentDomain
            .GetAssemblies()
            .SelectMany(assembly => assembly.GetTypes())
            .Where(type => type.IsClass && !type.IsAbstract &&
                           possibleEntityConfigurationTypes.Exists(configType => configType.IsAssignableFrom(type)))
            .ToList();

        return matchingConfigurationTypes;
    }
}
using AirBnB.Domain.Entities;
using AirBnB.Domain.Enums;
using AirBnB.Persistence.DataContexts;
using AutoMapper.Configuration.Annotations;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AirBnB.Api.Data;

/// <summary>
/// Extension methods for initializing seed data in the application.
/// </summary>
public static class SeedDataExtensions
{
    /// <summary>
    /// Initializes seed data in the IdentityDbContext by checking for existing users and seeding them if necessary.
    /// </summary>
    /// <param name="serviceProvider">The service provider to resolve dependencies.</param>
    /// <returns>An asynchronous task representing the initialization process.</returns>
    public static async ValueTask InitializeSeedAsync(this IServiceProvider serviceProvider)
    {
        var identityDbContext = serviceProvider.GetRequiredService<IdentityDbContext>();
        var webHostEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();

        if (!await identityDbContext.Users.AnyAsync())
            await identityDbContext.SeedUsersAsync();

        if (!await identityDbContext.ListingCategories.AnyAsync())
            await identityDbContext.SeedListingCategoriesAsync(webHostEnvironment);
    }

    /// <summary>
    /// Seeds user data into the IdentityDbContext using Bogus library.
    /// </summary>
    /// <param name="dbContext">The IdentityDbContext instance to seed data into.</param>
    /// <returns>An asynchronous task representing the seeding process.</returns>
    private static async ValueTask SeedUsersAsync(this IdentityDbContext dbContext)
    {
        var userRoleId = dbContext.Roles.First(role => role.Type == RoleType.User).Id;

        var userFaker = new Faker<User>()
            .RuleFor(user => user.RoleId, () => userRoleId)
            .RuleFor(user => user.FirstName, data => data.Name.FirstName())
            .RuleFor(user => user.LastName, data => data.Name.LastName())
            .RuleFor(user => user.EmailAddress, data => data.Person.Email)
            .RuleFor(user => user.Password, data => data.Internet.Password(8))
            .RuleFor(user => user.PhoneNumber, data => data.Person.Phone);

        await dbContext.AddRangeAsync(userFaker.Generate(100));
        await dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Seeds listing categories into the IdentityDbContext from a JSON file.
    /// </summary>
    /// <param name="listingsDbcontext"></param>
    /// <param name="webHostEnvironment"></param>
    /// <returns></returns>
    private static async ValueTask SeedListingCategoriesAsync(
        this IdentityDbContext listingsDbcontext,
        IHostEnvironment webHostEnvironment)
    {
        var listingCategoriesFileName = Path.Combine(webHostEnvironment.ContentRootPath, "Data", "SeedData", "ListingCategories.json");

        // Retrieve listing categories
        var listingCategories = JsonConvert.DeserializeObject<List<ListingCategory>>(await File.ReadAllTextAsync(listingCategoriesFileName))!;

        // Set category images
        listingCategories.ForEach(
            listingCategory => listingCategory.ImageStorageFile = new StorageFile
            {
                Id = listingCategory.StorageFileId,
                FileName = $"{listingCategory.StorageFileId}.jpg",
                Type = StorageFileType.ListingCategoryImage
            }
        );

        await listingsDbcontext.ListingCategories.AddRangeAsync(listingCategories);
        await listingsDbcontext.SaveChangesAsync();
    }
}
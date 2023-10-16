﻿using Backend_Project.Domain.Entities;

namespace Backend_Project.Application.Listings;

public interface IListingCategoryDetailsService
{
    ValueTask<ListingCategory> DeleteCategoryAsync(Guid categoryId, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<ICollection<ListingType>> GetListingTypesByCategoryIdAsync(Guid categoryId, CancellationToken cancellationToken = default);
    ValueTask<ListingType> DeleteListingTypeAsync(Guid typeId, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<ListingFeature> AddListingFeatureAsync(ListingFeature feature, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<ListingFeature> UpdateListingFeatureAsync(ListingFeature feature, bool saveChanges = true, CancellationToken cancellationToken = default);
    ICollection<ListingFeature> GetListingFeaturesByTypeId(Guid listingTypeId);
    ValueTask<ListingFeature> DeleteListingFeatureAsync(Guid featureId, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<ListingCategoryType> AddListingCategoryTypeAsync(ListingCategoryType relation, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<bool> AddListingCategoryTypesAsync(Guid categoryId, List<Guid> listingTypes, bool saveChanges = true, CancellationToken cancellationToken = default);
    ValueTask<bool> UpdateListingCategoryTypesAsync(Guid categoryId, List<Guid> updatedListingTypes, bool saveChanges = true, CancellationToken cancellationToken = default);
}
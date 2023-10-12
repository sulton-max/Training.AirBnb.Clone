﻿using Backend_Project.Application.Interfaces;
using Backend_Project.Domain.Entities;
using Backend_Project.Domain.Exceptions.EntityExceptions;
using Backend_Project.Persistance.DataContexts;
using System.Linq.Expressions;

namespace Backend_Project.Infrastructure.Services.ListingServices;

public class ListingTypeService : IEntityBaseService<ListingType>
{
    private readonly IDataContext _appDataContext;

    public ListingTypeService(IDataContext appDataContext)
    {
        _appDataContext = appDataContext;
    }

    public async ValueTask<ListingType> CreateAsync(ListingType option, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        ValidateOption(option);

        await _appDataContext.ListingTypes.AddAsync(option, cancellationToken);

        if (saveChanges) await _appDataContext.SaveChangesAsync();

        return option;
    }  

    public ValueTask<ICollection<ListingType>> GetAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        => new ValueTask<ICollection<ListingType>>(GetUndeletedOptions()
        .Where(option => ids.Contains(option.Id))
        .ToList());

    public ValueTask<ListingType> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        => new ValueTask<ListingType>(GetUndeletedOptions()
            .FirstOrDefault(option => option.Id == id)
            ?? throw new EntityNotFoundException<ListingType>("Listing Type was not found."));

    public IQueryable<ListingType> Get(Expression<Func<ListingType, bool>> predicate)
        => GetUndeletedOptions().Where(predicate.Compile()).AsQueryable();

    public async ValueTask<ListingType> UpdateAsync(ListingType option, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        ValidateOption(option);

        var foundOption = await GetByIdAsync(option.Id, cancellationToken);

        foundOption.Name = option.Name;
        foundOption.Description = option.Description;
        
        await _appDataContext.ListingTypes.UpdateAsync(foundOption, cancellationToken);

        if (saveChanges) await _appDataContext.SaveChangesAsync();

        return foundOption;
    }

    public async ValueTask<ListingType> DeleteAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var foundOption = await GetByIdAsync(id, cancellationToken);

        await _appDataContext.ListingTypes.RemoveAsync(foundOption, cancellationToken);

        if (saveChanges) await _appDataContext.SaveChangesAsync();

        return foundOption;
    }

    public async ValueTask<ListingType> DeleteAsync(ListingType option, bool saveChanges = true, CancellationToken cancellationToken = default)
        => await DeleteAsync(option.Id, saveChanges, cancellationToken);

    private void ValidateOption(ListingType option)
    {
        if (!IsValidOption(option))
            throw new EntityValidationException<ListingType>();

        if (!IsUniqueOption(option))
            throw new DuplicateEntityException<ListingType>();
    }

    private bool IsValidOption(ListingType option)
        => (!string.IsNullOrWhiteSpace(option.Name) && option.Name.Length > 2 && option.Name.Length <= 100)
            && (!string.IsNullOrWhiteSpace(option.Description) && option.Description.Length > 2 && option.Description.Length <= 200);

    private bool IsUniqueOption(ListingType option)
        => !GetUndeletedOptions().Any(self => self.Name == option.Name);

    private IQueryable<ListingType> GetUndeletedOptions()
        => _appDataContext.ListingTypes.Where(option => !option.IsDeleted).AsQueryable();
}
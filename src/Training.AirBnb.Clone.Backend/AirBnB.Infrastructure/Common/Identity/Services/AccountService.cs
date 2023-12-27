using AirBnB.Application.Common.Identity.Services;
using AirBnB.Domain.Entities;
using AirBnB.Domain.Enums;
using AirBnB.Infrastructure.Common.Validators;
using AirBnB.Persistence.DataContexts;
using AirBnB.Persistence.Repositories.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AirBnB.Infrastructure.Common.Identity.Services;

public class AccountService(
    IdentityDbContext dbContext,
    UserValidator validator,
    IUserRepository userRepository
    ) : IAccountService
{
    public async ValueTask<bool> CreateUserAsync(User user, bool saveChanges = true, 
        CancellationToken cancellationToken = default)
    {
        var validationResult = validator.Validate(user, options => 
                 options.IncludeRuleSets(EntityEvent.OnCreate.ToString()));

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);
        
        await userRepository.CreateAsync(user, saveChanges, cancellationToken); 

        return true;
    }

    public async ValueTask<User?> GetUserByEmailAddressAsync(string emailAddress, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(emailAddress))
            throw new ArgumentNullException(nameof(emailAddress),"Email address cannot be null or empty.");

        var query = userRepository.Get(user => user.EmailAddress == emailAddress);

        if (asNoTracking)
            query = query.AsNoTracking();

        return await query.SingleOrDefaultAsync(cancellationToken);
    }

    public async ValueTask<bool> VerifyUserAsync(string emailAddress, bool asNoTracking = false, 
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(emailAddress))
            throw new ArgumentNullException(nameof(emailAddress),"Email address cannot be null or empty.");
        
        var user = dbContext.Users.Where(user => user.EmailAddress == emailAddress);

        if (asNoTracking)
            user = user.AsNoTracking();

        return await user.AnyAsync(cancellationToken);
    }

}
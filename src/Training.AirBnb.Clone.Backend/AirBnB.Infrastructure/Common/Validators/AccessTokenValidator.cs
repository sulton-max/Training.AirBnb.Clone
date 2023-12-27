using AirBnB.Domain.Entities;
using AirBnB.Domain.Enums;
using AirBnB.Infrastructure.Common.Settings;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace AirBnB.Infrastructure.Common.Validators;

/// <summary>
/// Validator for the AccessToken entity using FluentValidation.
/// </summary>
public class AccessTokenValidator : AbstractValidator<AccessToken>
{
    /// <summary>
    /// Initializes a new instance of the AccessTokenValidator class.
    /// </summary>
    /// <param name="jwtSettings">Options for configuring JWT settings injected via dependency injection.</param>
    public AccessTokenValidator(IOptions<JwtSettings> jwtSettings)
    {
        var jwtSettingsValue = jwtSettings.Value;

        // Validation rules for the 'OnCreate' scenario.
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                // Ensure that IsRevoked is not set to true during creation.
                RuleFor(accessToken => accessToken.IsRevoked).NotEqual(true);

                // Ensure that UserId is not empty during creation.
                RuleFor(accessToken => accessToken.UserId).NotEqual(Guid.Empty);
            }
        );

        // Validation rules for the 'OnUpdate' scenario.
        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                // Ensure that the Token property is not empty during update.
                RuleFor(accesstoken => accesstoken.Token).NotEmpty();

                // Ensure that the ExpiryTime is greater than the current UTC time and within the JWT token expiration.
                RuleFor(accesstoken => accesstoken.ExpiryTime)
                    .GreaterThan(DateTimeOffset.UtcNow)
                    .Custom(
                        (accesstoken, context) =>
                        {
                            if (accesstoken > DateTimeOffset.UtcNow.AddMinutes(jwtSettingsValue.ExpirationTimeInMinute))
                                context.AddFailure(
                                    nameof(AccessToken.ExpiryTime),
                                    $"{nameof(AccessToken.ExpiryTime)} cannot be greater than the expiration time of the JWT token"
                                );
                        }
                    );

                // Ensure that UserId cannot be changed during an update.
                RuleFor(accessToken => accessToken)
                    .Custom(
                        (accessToken, context) =>
                        {
                            if (context.RootContextData.TryGetValue(nameof(AccessToken), out var userInfoObj) &&
                                userInfoObj is AccessToken foundAccessToken)
                                if (accessToken.UserId != foundAccessToken.UserId)
                                    context.AddFailure(nameof(AccessToken.UserId),
                                        $"{nameof(AccessToken.UserId)} cannot be changed.");
                        }
                    );

                // Ensure that IsRevoked is not set to true during an update.
                RuleFor(accessToken => accessToken.IsRevoked).NotEqual(true);
            }
        );
    }
}
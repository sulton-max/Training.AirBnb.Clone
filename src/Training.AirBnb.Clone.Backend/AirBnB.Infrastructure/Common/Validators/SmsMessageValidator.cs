using AirBnB.Application.Common.Notifications.Models;
using AirBnB.Domain.Enums;
using FluentValidation;

namespace AirBnB.Infrastructure.Common.Validators;

public class SmsMessageValidator : AbstractValidator<SmsMessage>
{
    public SmsMessageValidator()
    {
        RuleSet(NotificationEvent.OnRendering.ToString(),
            () =>
            {
                RuleFor(message => message.Template).NotNull();
                RuleFor(message => message.Variables).NotNull();
                RuleFor(message => message.Template.Content).NotNull().NotEmpty();
            });

        RuleSet(NotificationEvent.OnSending.ToString(),
            () =>
            {
                RuleFor(message => message.SendEmailAddress).NotNull().NotEmpty();
                RuleFor(message => message.ReceiverEmailAddress).NotNull().NotEmpty();
                RuleFor(message => message.Message).NotNull().NotEmpty();
            });
    }
}

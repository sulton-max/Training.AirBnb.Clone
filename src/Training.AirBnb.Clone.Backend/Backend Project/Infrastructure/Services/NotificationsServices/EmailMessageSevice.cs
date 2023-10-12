﻿using Backend_Project.Domain.Entities;
using Backend_Project.Application.Interfaces;

namespace Backend_Project.Infrastructure.Services.NotificationsServices;

public class EmailMessageSevice : IEmailMessageService
{
    private readonly IEntityBaseService<User> _userService;

    public EmailMessageSevice(IEntityBaseService<User> userService)
    {
        _userService = userService;
    }

    public async ValueTask<EmailMessage> ConvertToMessage(EmailTemplate emailTemplate, Dictionary<string, string> values, Guid senderUserId, Guid receiverUserId)
    {
        var senderUser = await _userService.GetByIdAsync(senderUserId);
        var receiverUser = await _userService.GetByIdAsync(receiverUserId);

        var body = emailTemplate.Body;
        var subject = emailTemplate.Subject;

        foreach (var item in values)
        {
            body = body.Replace(item.Key, item.Value);
            subject = subject.Replace(item.Key, item.Value);
        }

        var emailMessage = new EmailMessage(subject, body, senderUserId, receiverUserId, senderUser.EmailAddress, receiverUser.EmailAddress);

        return emailMessage;

    }
}
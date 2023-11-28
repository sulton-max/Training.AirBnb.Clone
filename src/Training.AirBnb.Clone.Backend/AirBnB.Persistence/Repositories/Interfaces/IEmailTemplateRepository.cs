﻿using AirBnB.Domain.Entities;
using System.Linq.Expressions;

namespace AirBnB.Persistence.Repositories.Interfaces;

public interface IEmailTemplateRepository
{
    /// <summary>
    /// Get all templates which IQuerable
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="asNoTracking"></param>
    /// <returns>IQueryable<EmailTemplate> Get </returns>
    IQueryable<EmailTemplate> Get(
        Expression<Func<EmailTemplate, bool>>? predicate = default,
        bool asNoTracking = false);

    /// <summary>
    /// Create EmailTemplate async
    /// </summary>  
    /// <param name="saveChanges"></param>
    /// <returns>ValueTask<EmailTemplate</returns>
    ValueTask<EmailTemplate> CreateAsync(
        EmailTemplate emailTemplate,
        bool saveChanges = true,
        CancellationToken cancellationToken = default);
}
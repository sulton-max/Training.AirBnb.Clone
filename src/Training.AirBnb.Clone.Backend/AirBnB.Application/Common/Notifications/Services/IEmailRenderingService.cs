using AirBnB.Application.Common.Notifications.Models;

namespace AirBnB.Application.Common.Notifications.Services;

/// <summary>
/// Represents a service which provides email rendering functionalities
/// </summary>
public interface IEmailRenderingService
{
    /// <summary>
    /// Asynchronously renders email messages
    /// </summary>
    /// <param name="emailMessage"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<string> RenderAsync(
        EmailMessage emailMessage,
        CancellationToken cancellationToken = default
    );
}

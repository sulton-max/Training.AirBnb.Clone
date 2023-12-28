using AirBnB.Application.Common.Notifications.Models;

namespace AirBnB.Application.Common.Notifications.Services;

/// <summary>
/// Represents a service which provides email rendering functionalities
/// </summary>
public interface ISmsRenderingService
{

    /// <summary>
    /// Asynchronously renders sms messages
    /// </summary>
    /// <param name="smsMessage"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    ValueTask<string> RenderAsync(
        SmsMessage smsMessage,
        CancellationToken cancellationToken = default
    );
}
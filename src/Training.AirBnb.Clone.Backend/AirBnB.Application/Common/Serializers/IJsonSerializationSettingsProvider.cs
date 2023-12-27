using Newtonsoft.Json;

namespace AirBnB.Application.Common.Serializers;

/// <summary>
/// Interface for providing JSON serialization settings.
/// </summary>
public interface IJsonSerializationSettingsProvider
{
    /// <summary>
    /// Gets JSON serialization settings.
    /// </summary>
    /// <param name="clone">Indicates whether to return a clone of the settings (default is false).</param>
    /// <returns>JsonSerializerSettings for customizing JSON serialization.</returns>
    JsonSerializerSettings Get(bool clone = false);
}

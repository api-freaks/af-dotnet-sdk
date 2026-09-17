using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record MarineWeatherResponseForecastValueMinutelyItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Local timestamp of this reading (format YYYY-MM-DDTHH:mm, not ISO 8601).
    /// </summary>
    [JsonPropertyName("timestamp")]
    public string? Timestamp { get; set; }

    /// <summary>
    /// Speed of ocean current (km/h)
    /// </summary>
    [JsonPropertyName("ocean_current_velocity")]
    public double? OceanCurrentVelocity { get; set; }

    /// <summary>
    /// Direction of ocean current (°)
    /// </summary>
    [JsonPropertyName("ocean_current_direction")]
    public int? OceanCurrentDirection { get; set; }

    /// <summary>
    /// Sea level height relative to mean sea level (m)
    /// </summary>
    [JsonPropertyName("sea_level_height_msl")]
    public double? SeaLevelHeightMsl { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Current marine data
/// </summary>
[Serializable]
public record MarineWeatherResponseCurrent : IJsonOnDeserialized
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
    /// Significant height of combined sea waves (m)
    /// </summary>
    [JsonPropertyName("wave_height")]
    public double? WaveHeight { get; set; }

    /// <summary>
    /// Direction from which the combined waves are coming (°)
    /// </summary>
    [JsonPropertyName("wave_direction")]
    public double? WaveDirection { get; set; }

    /// <summary>
    /// Average period of combined sea waves (s)
    /// </summary>
    [JsonPropertyName("wave_period")]
    public double? WavePeriod { get; set; }

    /// <summary>
    /// Height of locally generated wind waves (m)
    /// </summary>
    [JsonPropertyName("wind_wave_height")]
    public double? WindWaveHeight { get; set; }

    /// <summary>
    /// Direction from which the wind waves are coming (°)
    /// </summary>
    [JsonPropertyName("wind_wave_direction")]
    public double? WindWaveDirection { get; set; }

    /// <summary>
    /// Average period of locally generated wind waves (s)
    /// </summary>
    [JsonPropertyName("wind_wave_period")]
    public double? WindWavePeriod { get; set; }

    /// <summary>
    /// Height of swell waves (m)
    /// </summary>
    [JsonPropertyName("swell_wave_height")]
    public double? SwellWaveHeight { get; set; }

    /// <summary>
    /// Direction from which the swell waves are coming (°)
    /// </summary>
    [JsonPropertyName("swell_wave_direction")]
    public double? SwellWaveDirection { get; set; }

    /// <summary>
    /// Average period of swell waves (s)
    /// </summary>
    [JsonPropertyName("swell_wave_period")]
    public double? SwellWavePeriod { get; set; }

    /// <summary>
    /// Sea level height relative to mean sea level (m)
    /// </summary>
    [JsonPropertyName("sea_level_height_msl")]
    public double? SeaLevelHeightMsl { get; set; }

    /// <summary>
    /// Temperature of the ocean surface (°C)
    /// </summary>
    [JsonPropertyName("sea_surface_temperature")]
    public double? SeaSurfaceTemperature { get; set; }

    /// <summary>
    /// Speed of the ocean current (km/h)
    /// </summary>
    [JsonPropertyName("ocean_current_velocity")]
    public double? OceanCurrentVelocity { get; set; }

    /// <summary>
    /// Direction of the ocean current (°)
    /// </summary>
    [JsonPropertyName("ocean_current_direction")]
    public double? OceanCurrentDirection { get; set; }

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

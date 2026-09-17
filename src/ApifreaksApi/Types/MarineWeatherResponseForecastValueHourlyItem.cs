using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record MarineWeatherResponseForecastValueHourlyItem : IJsonOnDeserialized
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
    /// Significant wave height at the given time (m)
    /// </summary>
    [JsonPropertyName("wave_height")]
    public double? WaveHeight { get; set; }

    /// <summary>
    /// Wave direction (°)
    /// </summary>
    [JsonPropertyName("wave_direction")]
    public int? WaveDirection { get; set; }

    /// <summary>
    /// Wave period at the given time (s)
    /// </summary>
    [JsonPropertyName("wave_period")]
    public double? WavePeriod { get; set; }

    /// <summary>
    /// Wind-driven wave height at the given time (m)
    /// </summary>
    [JsonPropertyName("wind_wave_height")]
    public double? WindWaveHeight { get; set; }

    /// <summary>
    /// Peak period of wind-driven waves (s)
    /// </summary>
    [JsonPropertyName("wind_wave_peak_period")]
    public double? WindWavePeakPeriod { get; set; }

    /// <summary>
    /// Wind-wave direction (°)
    /// </summary>
    [JsonPropertyName("wind_wave_direction")]
    public int? WindWaveDirection { get; set; }

    /// <summary>
    /// Wind-wave period (s)
    /// </summary>
    [JsonPropertyName("wind_wave_period")]
    public double? WindWavePeriod { get; set; }

    /// <summary>
    /// Swell wave height at the given time (m)
    /// </summary>
    [JsonPropertyName("swell_wave_height")]
    public double? SwellWaveHeight { get; set; }

    /// <summary>
    /// Swell wave direction (°)
    /// </summary>
    [JsonPropertyName("swell_wave_direction")]
    public int? SwellWaveDirection { get; set; }

    /// <summary>
    /// Swell wave period (s)
    /// </summary>
    [JsonPropertyName("swell_wave_period")]
    public double? SwellWavePeriod { get; set; }

    /// <summary>
    /// Peak period of swell waves (s)
    /// </summary>
    [JsonPropertyName("swell_wave_peak_period")]
    public double? SwellWavePeakPeriod { get; set; }

    /// <summary>
    /// Sea surface temperature (°C)
    /// </summary>
    [JsonPropertyName("sea_surface_temperature")]
    public double? SeaSurfaceTemperature { get; set; }

    /// <summary>
    /// Sea level height relative to mean sea level (m)
    /// </summary>
    [JsonPropertyName("sea_level_height_msl")]
    public double? SeaLevelHeightMsl { get; set; }

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

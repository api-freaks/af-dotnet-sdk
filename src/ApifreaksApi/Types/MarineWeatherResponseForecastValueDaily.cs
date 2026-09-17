using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Daily marine forecast data
/// </summary>
[Serializable]
public record MarineWeatherResponseForecastValueDaily : IJsonOnDeserialized
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
    /// Maximum significant wave height (m)
    /// </summary>
    [JsonPropertyName("wave_height_max")]
    public double? WaveHeightMax { get; set; }

    /// <summary>
    /// Dominant direction of waves (°)
    /// </summary>
    [JsonPropertyName("wave_direction_dominant")]
    public int? WaveDirectionDominant { get; set; }

    /// <summary>
    /// Maximum wave period (s)
    /// </summary>
    [JsonPropertyName("wave_period_max")]
    public double? WavePeriodMax { get; set; }

    /// <summary>
    /// Maximum wind-driven wave height (m)
    /// </summary>
    [JsonPropertyName("wind_wave_height_max")]
    public double? WindWaveHeightMax { get; set; }

    /// <summary>
    /// Dominant wind-wave direction (°)
    /// </summary>
    [JsonPropertyName("wind_wave_direction_dominant")]
    public int? WindWaveDirectionDominant { get; set; }

    /// <summary>
    /// Maximum wind-wave period (s)
    /// </summary>
    [JsonPropertyName("wind_wave_period_max")]
    public double? WindWavePeriodMax { get; set; }

    /// <summary>
    /// Maximum peak period of wind-driven waves (s)
    /// </summary>
    [JsonPropertyName("wind_wave_peak_period_max")]
    public double? WindWavePeakPeriodMax { get; set; }

    /// <summary>
    /// Maximum swell wave height (m)
    /// </summary>
    [JsonPropertyName("swell_wave_height_max")]
    public double? SwellWaveHeightMax { get; set; }

    /// <summary>
    /// Dominant swell wave direction (°)
    /// </summary>
    [JsonPropertyName("swell_wave_direction_dominant")]
    public int? SwellWaveDirectionDominant { get; set; }

    /// <summary>
    /// Maximum swell wave period (s)
    /// </summary>
    [JsonPropertyName("swell_wave_period_max")]
    public double? SwellWavePeriodMax { get; set; }

    /// <summary>
    /// Maximum peak period of swell waves (s)
    /// </summary>
    [JsonPropertyName("swell_wave_peak_period_max")]
    public double? SwellWavePeakPeriodMax { get; set; }

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

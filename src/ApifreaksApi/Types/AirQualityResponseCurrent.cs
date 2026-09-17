using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Current air quality data
/// </summary>
[Serializable]
public record AirQualityResponseCurrent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Local timestamp of the observation (format YYYY-MM-DDTHH:mm, not ISO 8601).
    /// </summary>
    [JsonPropertyName("timestamp")]
    public required string Timestamp { get; set; }

    /// <summary>
    /// Consolidated European Air Quality Index representing the highest value among individual pollutant indices. Ranges: 0-20 (good), 20-40 (fair), 40-60 (moderate), 60-80 (poor), 80-100 (very poor), &gt;100 (extremely poor).
    /// </summary>
    [JsonPropertyName("european_aqi")]
    public required int EuropeanAqi { get; set; }

    /// <summary>
    /// Consolidated U.S. Air Quality Index representing the highest value among individual pollutant indices. Ranges: 0-50 (good), 51-100 (moderate), 101-150 (unhealthy for sensitive groups), 151-200 (unhealthy), 201-300 (very unhealthy), 301-500 (hazardous).
    /// </summary>
    [JsonPropertyName("us_aqi")]
    public required int UsAqi { get; set; }

    /// <summary>
    /// Particulate matter with diameter less than 10 micrometers (μg/m³) measured at 10 meters above ground.
    /// </summary>
    [JsonPropertyName("pm10")]
    public required float Pm10 { get; set; }

    /// <summary>
    /// Particulate matter with diameter less than 2.5 micrometers (μg/m³) measured at 10 meters above ground.
    /// </summary>
    [JsonPropertyName("pm2_5")]
    public required float Pm25 { get; set; }

    /// <summary>
    /// Atmospheric carbon monoxide gas concentration (μg/m³) at 10 meters above ground.
    /// </summary>
    [JsonPropertyName("carbon_monoxide")]
    public required float CarbonMonoxide { get; set; }

    /// <summary>
    /// Atmospheric nitrogen dioxide gas concentration (μg/m³) at 10 meters above ground.
    /// </summary>
    [JsonPropertyName("nitrogen_dioxide")]
    public required float NitrogenDioxide { get; set; }

    /// <summary>
    /// Atmospheric sulphur dioxide gas concentration (μg/m³) at 10 meters above ground.
    /// </summary>
    [JsonPropertyName("sulphur_dioxide")]
    public required float SulphurDioxide { get; set; }

    /// <summary>
    /// Atmospheric ozone gas concentration (μg/m³) at 10 meters above ground.
    /// </summary>
    [JsonPropertyName("ozone")]
    public required float Ozone { get; set; }

    /// <summary>
    /// Saharan dust particle concentration (μg/m³) at 10 meters above ground.
    /// </summary>
    [JsonPropertyName("dust")]
    public required float Dust { get; set; }

    /// <summary>
    /// Ultraviolet radiation intensity index accounting for cloud coverage.
    /// </summary>
    [JsonPropertyName("uv_index")]
    public required float UvIndex { get; set; }

    /// <summary>
    /// Aerosol optical depth at 550 nm wavelength indicating atmospheric haze levels.
    /// </summary>
    [JsonPropertyName("aerosol_optical_depth")]
    public required float AerosolOpticalDepth { get; set; }

    /// <summary>
    /// Ultraviolet radiation intensity index assuming cloud-free conditions.
    /// </summary>
    [JsonPropertyName("uv_index_clear_sky")]
    public required float UvIndexClearSky { get; set; }

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

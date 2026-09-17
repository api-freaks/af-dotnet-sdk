using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Daily forecast data
/// </summary>
[Serializable]
public record WeatherForecastResponseForecastValueDaily : IJsonOnDeserialized
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
    /// Weather condition code
    /// </summary>
    [JsonPropertyName("weather_code")]
    public int? WeatherCode { get; set; }

    /// <summary>
    /// Maximum air temperature at 2m (°C)
    /// </summary>
    [JsonPropertyName("temperature_2m_max")]
    public double? Temperature2MMax { get; set; }

    /// <summary>
    /// Minimum air temperature at 2m (°C)
    /// </summary>
    [JsonPropertyName("temperature_2m_min")]
    public double? Temperature2MMin { get; set; }

    /// <summary>
    /// Mean air temperature at 2m (°C)
    /// </summary>
    [JsonPropertyName("temperature_2m_mean")]
    public double? Temperature2MMean { get; set; }

    /// <summary>
    /// Maximum feels-like temperature (°C)
    /// </summary>
    [JsonPropertyName("apparent_temperature_max")]
    public double? ApparentTemperatureMax { get; set; }

    /// <summary>
    /// Minimum feels-like temperature (°C)
    /// </summary>
    [JsonPropertyName("apparent_temperature_min")]
    public double? ApparentTemperatureMin { get; set; }

    /// <summary>
    /// Mean feels-like temperature (°C)
    /// </summary>
    [JsonPropertyName("apparent_temperature_mean")]
    public double? ApparentTemperatureMean { get; set; }

    /// <summary>
    /// Daily maximum UV index
    /// </summary>
    [JsonPropertyName("uv_index_max")]
    public double? UvIndexMax { get; set; }

    /// <summary>
    /// UV index clear sky max
    /// </summary>
    [JsonPropertyName("uv_index_clear_sky_max")]
    public double? UvIndexClearSkyMax { get; set; }

    /// <summary>
    /// Total rain (mm)
    /// </summary>
    [JsonPropertyName("rain_sum")]
    public double? RainSum { get; set; }

    /// <summary>
    /// Total showers (mm)
    /// </summary>
    [JsonPropertyName("showers_sum")]
    public double? ShowersSum { get; set; }

    /// <summary>
    /// Total snowfall (cm)
    /// </summary>
    [JsonPropertyName("snowfall_sum")]
    public double? SnowfallSum { get; set; }

    /// <summary>
    /// Total precipitation (mm)
    /// </summary>
    [JsonPropertyName("precipitation_sum")]
    public double? PrecipitationSum { get; set; }

    /// <summary>
    /// Mean probability of precipitation (%)
    /// </summary>
    [JsonPropertyName("precipitation_probability_mean")]
    public int? PrecipitationProbabilityMean { get; set; }

    /// <summary>
    /// Max wind speed at 10m (km/h)
    /// </summary>
    [JsonPropertyName("wind_speed_10m_max")]
    public double? WindSpeed10MMax { get; set; }

    /// <summary>
    /// Min wind speed at 10m (km/h)
    /// </summary>
    [JsonPropertyName("wind_speed_10m_min")]
    public double? WindSpeed10MMin { get; set; }

    /// <summary>
    /// Mean wind speed at 10m (km/h)
    /// </summary>
    [JsonPropertyName("wind_speed_10m_mean")]
    public double? WindSpeed10MMean { get; set; }

    /// <summary>
    /// Max wind gusts at 10m (km/h)
    /// </summary>
    [JsonPropertyName("wind_gusts_10m_max")]
    public double? WindGusts10MMax { get; set; }

    /// <summary>
    /// Min wind gusts at 10m (km/h)
    /// </summary>
    [JsonPropertyName("wind_gusts_10m_min")]
    public double? WindGusts10MMin { get; set; }

    /// <summary>
    /// Mean wind gusts at 10m (km/h)
    /// </summary>
    [JsonPropertyName("wind_gusts_10m_mean")]
    public double? WindGusts10MMean { get; set; }

    /// <summary>
    /// Dominant wind direction at 10m (°)
    /// </summary>
    [JsonPropertyName("wind_direction_10m_dominant")]
    public int? WindDirection10MDominant { get; set; }

    /// <summary>
    /// Total shortwave radiation (MJ/m²)
    /// </summary>
    [JsonPropertyName("shortwave_radiation_sum")]
    public double? ShortwaveRadiationSum { get; set; }

    /// <summary>
    /// Mean surface pressure (hPa)
    /// </summary>
    [JsonPropertyName("surface_pressure_mean")]
    public double? SurfacePressureMean { get; set; }

    /// <summary>
    /// Mean sea-level pressure (hPa)
    /// </summary>
    [JsonPropertyName("pressure_msl_mean")]
    public double? PressureMslMean { get; set; }

    /// <summary>
    /// Mean visibility distance (m)
    /// </summary>
    [JsonPropertyName("visibility_mean")]
    public double? VisibilityMean { get; set; }

    /// <summary>
    /// Mean cloud cover (%)
    /// </summary>
    [JsonPropertyName("cloud_cover_mean")]
    public int? CloudCoverMean { get; set; }

    /// <summary>
    /// Max dew point at 2m (°C)
    /// </summary>
    [JsonPropertyName("dew_point_2m_max")]
    public double? DewPoint2MMax { get; set; }

    /// <summary>
    /// Min dew point at 2m (°C)
    /// </summary>
    [JsonPropertyName("dew_point_2m_min")]
    public double? DewPoint2MMin { get; set; }

    /// <summary>
    /// Mean dew point at 2m (°C)
    /// </summary>
    [JsonPropertyName("dew_point_2m_mean")]
    public double? DewPoint2MMean { get; set; }

    /// <summary>
    /// Max relative humidity (%)
    /// </summary>
    [JsonPropertyName("relative_humidity_2m_max")]
    public int? RelativeHumidity2MMax { get; set; }

    /// <summary>
    /// Min relative humidity (%)
    /// </summary>
    [JsonPropertyName("relative_humidity_2m_min")]
    public int? RelativeHumidity2MMin { get; set; }

    /// <summary>
    /// Mean relative humidity (%)
    /// </summary>
    [JsonPropertyName("relative_humidity_2m_mean")]
    public int? RelativeHumidity2MMean { get; set; }

    /// <summary>
    /// ET₀ Reference Evapotranspiration (mm)
    /// </summary>
    [JsonPropertyName("et0_fao_evapotranspiration_sum")]
    public double? Et0FaoEvapotranspirationSum { get; set; }

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

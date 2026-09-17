using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record WeatherForecastResponseForecastValueHourlyItem : IJsonOnDeserialized
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
    /// Air temperature at 2m (°C)
    /// </summary>
    [JsonPropertyName("temperature_2m")]
    public double? Temperature2M { get; set; }

    /// <summary>
    /// Relative humidity at 2m (%)
    /// </summary>
    [JsonPropertyName("relative_humidity_2m")]
    public int? RelativeHumidity2M { get; set; }

    /// <summary>
    /// Dew point at 2m (°C)
    /// </summary>
    [JsonPropertyName("dew_point_2m")]
    public double? DewPoint2M { get; set; }

    /// <summary>
    /// Feels-like temperature (°C)
    /// </summary>
    [JsonPropertyName("apparent_temperature")]
    public double? ApparentTemperature { get; set; }

    /// <summary>
    /// Total precipitation at this time (mm)
    /// </summary>
    [JsonPropertyName("precipitation")]
    public double? Precipitation { get; set; }

    /// <summary>
    /// Probability of precipitation (%)
    /// </summary>
    [JsonPropertyName("precipitation_probability")]
    public int? PrecipitationProbability { get; set; }

    /// <summary>
    /// Rainfall (mm)
    /// </summary>
    [JsonPropertyName("rain")]
    public double? Rain { get; set; }

    /// <summary>
    /// Showers (mm)
    /// </summary>
    [JsonPropertyName("showers")]
    public double? Showers { get; set; }

    /// <summary>
    /// Snowfall (cm)
    /// </summary>
    [JsonPropertyName("snowfall")]
    public double? Snowfall { get; set; }

    /// <summary>
    /// Weather condition code
    /// </summary>
    [JsonPropertyName("weather_code")]
    public int? WeatherCode { get; set; }

    /// <summary>
    /// Sea-level pressure (hPa)
    /// </summary>
    [JsonPropertyName("pressure_msl")]
    public double? PressureMsl { get; set; }

    /// <summary>
    /// Surface pressure (hPa)
    /// </summary>
    [JsonPropertyName("surface_pressure")]
    public double? SurfacePressure { get; set; }

    /// <summary>
    /// Cloud cover (%)
    /// </summary>
    [JsonPropertyName("cloud_cover")]
    public int? CloudCover { get; set; }

    /// <summary>
    /// Visibility distance (m)
    /// </summary>
    [JsonPropertyName("visibility")]
    public double? Visibility { get; set; }

    /// <summary>
    /// Evapotranspiration (mm)
    /// </summary>
    [JsonPropertyName("et0_fao_evapotranspiration")]
    public double? Et0FaoEvapotranspiration { get; set; }

    /// <summary>
    /// Wind speed at 10m (km/h)
    /// </summary>
    [JsonPropertyName("wind_speed_10m")]
    public double? WindSpeed10M { get; set; }

    /// <summary>
    /// Wind direction at 10m (°)
    /// </summary>
    [JsonPropertyName("wind_direction_10m")]
    public int? WindDirection10M { get; set; }

    /// <summary>
    /// Wind gusts at 10m (km/h)
    /// </summary>
    [JsonPropertyName("wind_gusts_10m")]
    public double? WindGusts10M { get; set; }

    /// <summary>
    /// UV index
    /// </summary>
    [JsonPropertyName("uv_index")]
    public double? UvIndex { get; set; }

    /// <summary>
    /// UV index under clear-sky conditions
    /// </summary>
    [JsonPropertyName("uv_index_clear_sky")]
    public double? UvIndexClearSky { get; set; }

    /// <summary>
    /// Shortwave radiation (W/m²)
    /// </summary>
    [JsonPropertyName("shortwave_radiation")]
    public double? ShortwaveRadiation { get; set; }

    /// <summary>
    /// Direct solar radiation (W/m²)
    /// </summary>
    [JsonPropertyName("direct_radiation")]
    public double? DirectRadiation { get; set; }

    /// <summary>
    /// Diffuse solar radiation (W/m²)
    /// </summary>
    [JsonPropertyName("diffuse_radiation")]
    public double? DiffuseRadiation { get; set; }

    /// <summary>
    /// Direct normal irradiance (W/m²)
    /// </summary>
    [JsonPropertyName("direct_normal_irradiance")]
    public double? DirectNormalIrradiance { get; set; }

    /// <summary>
    /// Global tilted irradiance (W/m²)
    /// </summary>
    [JsonPropertyName("global_tilted_irradiance")]
    public double? GlobalTiltedIrradiance { get; set; }

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

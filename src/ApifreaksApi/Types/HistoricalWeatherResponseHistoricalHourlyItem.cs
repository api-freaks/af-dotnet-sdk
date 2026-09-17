using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record HistoricalWeatherResponseHistoricalHourlyItem : IJsonOnDeserialized
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
    /// Air temperature at 2 meters (°C)
    /// </summary>
    [JsonPropertyName("temperature_2m")]
    public double? Temperature2M { get; set; }

    /// <summary>
    /// Relative humidity at 2 meters (%)
    /// </summary>
    [JsonPropertyName("relative_humidity_2m")]
    public double? RelativeHumidity2M { get; set; }

    /// <summary>
    /// Dew point temperature at 2 meters (°C)
    /// </summary>
    [JsonPropertyName("dew_point_2m")]
    public double? DewPoint2M { get; set; }

    /// <summary>
    /// Perceived temperature (°C)
    /// </summary>
    [JsonPropertyName("apparent_temperature")]
    public double? ApparentTemperature { get; set; }

    /// <summary>
    /// Total precipitation in this hour (mm)
    /// </summary>
    [JsonPropertyName("precipitation")]
    public double? Precipitation { get; set; }

    /// <summary>
    /// Rainfall in this hour (mm)
    /// </summary>
    [JsonPropertyName("rain")]
    public double? Rain { get; set; }

    /// <summary>
    /// Snowfall in this hour (cm)
    /// </summary>
    [JsonPropertyName("snowfall")]
    public double? Snowfall { get; set; }

    /// <summary>
    /// Weather condition code
    /// </summary>
    [JsonPropertyName("weather_code")]
    public int? WeatherCode { get; set; }

    /// <summary>
    /// Atmospheric pressure at mean sea level (hPa)
    /// </summary>
    [JsonPropertyName("pressure_msl")]
    public double? PressureMsl { get; set; }

    /// <summary>
    /// Atmospheric pressure at ground level (hPa)
    /// </summary>
    [JsonPropertyName("surface_pressure")]
    public double? SurfacePressure { get; set; }

    /// <summary>
    /// Cloud cover percentage (%)
    /// </summary>
    [JsonPropertyName("cloud_cover")]
    public double? CloudCover { get; set; }

    /// <summary>
    /// Hourly reference evapotranspiration (mm)
    /// </summary>
    [JsonPropertyName("et0_fao_evapotranspiration")]
    public double? Et0FaoEvapotranspiration { get; set; }

    /// <summary>
    /// Wind speed at 10 meters (km/h)
    /// </summary>
    [JsonPropertyName("wind_speed_10m")]
    public double? WindSpeed10M { get; set; }

    /// <summary>
    /// Wind direction at 10 meters (°)
    /// </summary>
    [JsonPropertyName("wind_direction_10m")]
    public int? WindDirection10M { get; set; }

    /// <summary>
    /// Wind gusts at 10 meters (km/h)
    /// </summary>
    [JsonPropertyName("wind_gusts_10m")]
    public double? WindGusts10M { get; set; }

    /// <summary>
    /// Reflectivity of the Earth's surface
    /// </summary>
    [JsonPropertyName("albedo")]
    public double? Albedo { get; set; }

    /// <summary>
    /// Incoming shortwave solar radiation (W/m²)
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
    /// Direct solar irradiance (W/m²)
    /// </summary>
    [JsonPropertyName("direct_normal_irradiance")]
    public double? DirectNormalIrradiance { get; set; }

    /// <summary>
    /// Total solar irradiance on a tilted surface (W/m²)
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

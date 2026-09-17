using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Daily historical data
/// </summary>
[Serializable]
public record HistoricalWeatherResponseHistoricalDaily : IJsonOnDeserialized
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
    /// Daily mean air temperature at 2 meters (°C)
    /// </summary>
    [JsonPropertyName("temperature_2m_mean")]
    public double? Temperature2MMean { get; set; }

    /// <summary>
    /// Daily maximum air temperature at 2 meters (°C)
    /// </summary>
    [JsonPropertyName("temperature_2m_max")]
    public double? Temperature2MMax { get; set; }

    /// <summary>
    /// Daily minimum air temperature at 2 meters (°C)
    /// </summary>
    [JsonPropertyName("temperature_2m_min")]
    public double? Temperature2MMin { get; set; }

    /// <summary>
    /// Daily mean perceived temperature (°C)
    /// </summary>
    [JsonPropertyName("apparent_temperature_mean")]
    public double? ApparentTemperatureMean { get; set; }

    /// <summary>
    /// Daily maximum perceived temperature (°C)
    /// </summary>
    [JsonPropertyName("apparent_temperature_max")]
    public double? ApparentTemperatureMax { get; set; }

    /// <summary>
    /// Daily minimum perceived temperature (°C)
    /// </summary>
    [JsonPropertyName("apparent_temperature_min")]
    public double? ApparentTemperatureMin { get; set; }

    /// <summary>
    /// Total precipitation (mm)
    /// </summary>
    [JsonPropertyName("precipitation_sum")]
    public double? PrecipitationSum { get; set; }

    /// <summary>
    /// Total rainfall (mm)
    /// </summary>
    [JsonPropertyName("rain_sum")]
    public double? RainSum { get; set; }

    /// <summary>
    /// Total snowfall (cm)
    /// </summary>
    [JsonPropertyName("snowfall_sum")]
    public double? SnowfallSum { get; set; }

    /// <summary>
    /// Maximum wind speed at 10 meters (km/h)
    /// </summary>
    [JsonPropertyName("wind_speed_10m_max")]
    public double? WindSpeed10MMax { get; set; }

    /// <summary>
    /// Maximum wind gusts at 10 meters (km/h)
    /// </summary>
    [JsonPropertyName("wind_gusts_10m_max")]
    public double? WindGusts10MMax { get; set; }

    /// <summary>
    /// Daily mean wind speed at 10 meters (km/h)
    /// </summary>
    [JsonPropertyName("wind_speed_10m_mean")]
    public double? WindSpeed10MMean { get; set; }

    /// <summary>
    /// Minimum wind speed at 10 meters (km/h)
    /// </summary>
    [JsonPropertyName("wind_speed_10m_min")]
    public double? WindSpeed10MMin { get; set; }

    /// <summary>
    /// Minimum wind gusts at 10 meters (km/h)
    /// </summary>
    [JsonPropertyName("wind_gusts_10m_min")]
    public double? WindGusts10MMin { get; set; }

    /// <summary>
    /// Daily mean wind gusts at 10 meters (km/h)
    /// </summary>
    [JsonPropertyName("wind_gusts_10m_mean")]
    public double? WindGusts10MMean { get; set; }

    /// <summary>
    /// Dominant wind direction at 10 meters (°)
    /// </summary>
    [JsonPropertyName("wind_direction_10m_dominant")]
    public int? WindDirection10MDominant { get; set; }

    /// <summary>
    /// Daily sum of shortwave solar radiation (MJ/m²)
    /// </summary>
    [JsonPropertyName("shortwave_radiation_sum")]
    public double? ShortwaveRadiationSum { get; set; }

    /// <summary>
    /// Daily sum of reference evapotranspiration (mm)
    /// </summary>
    [JsonPropertyName("et0_fao_evapotranspiration_sum")]
    public double? Et0FaoEvapotranspirationSum { get; set; }

    /// <summary>
    /// Daily mean cloud cover percentage (%)
    /// </summary>
    [JsonPropertyName("cloud_cover_mean")]
    public double? CloudCoverMean { get; set; }

    /// <summary>
    /// Daily mean dew point temperature at 2 meters (°C)
    /// </summary>
    [JsonPropertyName("dew_point_2m_mean")]
    public double? DewPoint2MMean { get; set; }

    /// <summary>
    /// Daily maximum dew point temperature at 2 meters (°C)
    /// </summary>
    [JsonPropertyName("dew_point_2m_max")]
    public double? DewPoint2MMax { get; set; }

    /// <summary>
    /// Daily minimum dew point temperature at 2 meters (°C)
    /// </summary>
    [JsonPropertyName("dew_point_2m_min")]
    public double? DewPoint2MMin { get; set; }

    /// <summary>
    /// Daily mean relative humidity at 2 meters (%)
    /// </summary>
    [JsonPropertyName("relative_humidity_2m_mean")]
    public double? RelativeHumidity2MMean { get; set; }

    /// <summary>
    /// Daily maximum relative humidity at 2 meters (%)
    /// </summary>
    [JsonPropertyName("relative_humidity_2m_max")]
    public int? RelativeHumidity2MMax { get; set; }

    /// <summary>
    /// Daily minimum relative humidity at 2 meters (%)
    /// </summary>
    [JsonPropertyName("relative_humidity_2m_min")]
    public int? RelativeHumidity2MMin { get; set; }

    /// <summary>
    /// Daily mean atmospheric pressure at mean sea level (hPa)
    /// </summary>
    [JsonPropertyName("pressure_msl_mean")]
    public double? PressureMslMean { get; set; }

    /// <summary>
    /// Daily mean surface pressure at ground level (hPa)
    /// </summary>
    [JsonPropertyName("surface_pressure_mean")]
    public double? SurfacePressureMean { get; set; }

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

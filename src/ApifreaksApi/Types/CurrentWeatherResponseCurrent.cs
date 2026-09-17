using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Current weather data
/// </summary>
[Serializable]
public record CurrentWeatherResponseCurrent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Local timestamp of the current weather observation (format YYYY-MM-DDTHH:mm, not ISO 8601).
    /// </summary>
    [JsonPropertyName("timestamp")]
    public required string Timestamp { get; set; }

    /// <summary>
    /// Current air temperature (°C) measured at 2 meters above ground.
    /// </summary>
    [JsonPropertyName("temperature_2m")]
    public required float Temperature2M { get; set; }

    /// <summary>
    /// Current relative humidity percentage at 2 meters above ground.
    /// </summary>
    [JsonPropertyName("relative_humidity_2m")]
    public required float RelativeHumidity2M { get; set; }

    /// <summary>
    /// Current apparent temperature (°C) accounting for wind chill and humidity.
    /// </summary>
    [JsonPropertyName("apparent_temperature")]
    public required float ApparentTemperature { get; set; }

    /// <summary>
    /// Current snowfall accumulation in centimeters.
    /// </summary>
    [JsonPropertyName("snowfall")]
    public required float Snowfall { get; set; }

    /// <summary>
    /// Current rainfall accumulation in millimeters.
    /// </summary>
    [JsonPropertyName("rain")]
    public required float Rain { get; set; }

    /// <summary>
    /// Current shower precipitation in millimeters.
    /// </summary>
    [JsonPropertyName("showers")]
    public required float Showers { get; set; }

    /// <summary>
    /// Total precipitation (mm) including rain, showers, and snowfall.
    /// </summary>
    [JsonPropertyName("precipitation")]
    public required float Precipitation { get; set; }

    /// <summary>
    /// WMO weather condition code representing current conditions. Supported codes: 0 clear sky; 1, 2, 3 varying cloud cover; 45, 48 fog; 51, 53, 55 drizzle; 56, 57 freezing drizzle; 61, 63, 65 rain; 66, 67 freezing rain; 71, 73, 75 snowfall; 77 snow grains; 80, 81, 82 rain showers; 85, 86 snow showers; 95 thunderstorm; 96, 99 thunderstorm with hail.
    /// </summary>
    [JsonPropertyName("weather_code")]
    public required int WeatherCode { get; set; }

    /// <summary>
    /// Current percentage of sky covered by clouds.
    /// </summary>
    [JsonPropertyName("cloud_cover")]
    public required float CloudCover { get; set; }

    /// <summary>
    /// Current atmospheric pressure (hPa) adjusted to mean sea level.
    /// </summary>
    [JsonPropertyName("pressure_msl")]
    public required float PressureMsl { get; set; }

    /// <summary>
    /// Current atmospheric pressure (hPa) at surface level.
    /// </summary>
    [JsonPropertyName("surface_pressure")]
    public required float SurfacePressure { get; set; }

    /// <summary>
    /// Current wind speed (km/h) at 10 meters above ground.
    /// </summary>
    [JsonPropertyName("wind_speed_10m")]
    public required float WindSpeed10M { get; set; }

    /// <summary>
    /// Current wind direction in degrees at 10 meters above ground.
    /// </summary>
    [JsonPropertyName("wind_direction_10m")]
    public required int WindDirection10M { get; set; }

    /// <summary>
    /// Current wind gust speed (km/h) at 10 meters above ground.
    /// </summary>
    [JsonPropertyName("wind_gusts_10m")]
    public required float WindGusts10M { get; set; }

    /// <summary>
    /// Astronomical information including sunrise, sunset, and moon phases for the current date.
    /// </summary>
    [JsonPropertyName("astronomy")]
    public required CurrentWeatherResponseCurrentAstronomy Astronomy { get; set; }

    /// <summary>
    /// Air quality metrics including pollutant concentrations and AQI values.
    /// </summary>
    [JsonPropertyName("air_quality")]
    public required CurrentWeatherResponseCurrentAirQuality AirQuality { get; set; }

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

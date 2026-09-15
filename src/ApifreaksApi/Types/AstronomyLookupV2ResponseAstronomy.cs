using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Complete astronomical data for the specified location and date.
/// </summary>
[Serializable]
public record AstronomyLookupV2ResponseAstronomy : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Appears (with the provided value) only when the user includes a time_zone in the query to specify which time to observe.
    /// </summary>
    [JsonPropertyName("time_zone")]
    public string? TimeZone { get; set; }

    /// <summary>
    /// The date astronomy data was calculated for. Defaults to today's date; reflects the date query parameter's value when that parameter is supplied.
    /// </summary>
    [JsonPropertyName("date")]
    public required string Date { get; set; }

    /// <summary>
    /// The current time
    /// </summary>
    [JsonPropertyName("current_time")]
    public required string CurrentTime { get; set; }

    /// <summary>
    /// The time of midnight (solar-based)
    /// </summary>
    [JsonPropertyName("mid_night")]
    public required string MidNight { get; set; }

    /// <summary>
    /// The time when night ends (start of astronomical twilight)
    /// </summary>
    [JsonPropertyName("night_end")]
    public required string NightEnd { get; set; }

    /// <summary>
    /// Morning astronomical data including twilight, blue hour, and golden hour times.
    /// </summary>
    [JsonPropertyName("morning")]
    public required AstronomyLookupV2ResponseAstronomyMorning Morning { get; set; }

    /// <summary>
    /// The time of sunrise
    /// </summary>
    [JsonPropertyName("sunrise")]
    public required string Sunrise { get; set; }

    /// <summary>
    /// The time of sunset
    /// </summary>
    [JsonPropertyName("sunset")]
    public required string Sunset { get; set; }

    /// <summary>
    /// Evening astronomical data including golden hour, blue hour, and twilight times.
    /// </summary>
    [JsonPropertyName("evening")]
    public required AstronomyLookupV2ResponseAstronomyEvening Evening { get; set; }

    /// <summary>
    /// The time when night begins (end of astronomical twilight)
    /// </summary>
    [JsonPropertyName("night_begin")]
    public required string NightBegin { get; set; }

    /// <summary>
    /// The current status of the sun (e.g., "rising", "setting", "-")
    /// </summary>
    [JsonPropertyName("sun_status")]
    public required string SunStatus { get; set; }

    /// <summary>
    /// The time when the sun reaches its highest point in the sky
    /// </summary>
    [JsonPropertyName("solar_noon")]
    public required string SolarNoon { get; set; }

    /// <summary>
    /// The total duration of daylight
    /// </summary>
    [JsonPropertyName("day_length")]
    public required string DayLength { get; set; }

    /// <summary>
    /// The altitude angle of the sun above the horizon in degrees
    /// </summary>
    [JsonPropertyName("sun_altitude")]
    public required float SunAltitude { get; set; }

    /// <summary>
    /// The distance from the Earth to the sun in kilometers
    /// </summary>
    [JsonPropertyName("sun_distance")]
    public required float SunDistance { get; set; }

    /// <summary>
    /// The azimuth angle of the sun in degrees from true north
    /// </summary>
    [JsonPropertyName("sun_azimuth")]
    public required float SunAzimuth { get; set; }

    /// <summary>
    /// The current phase of the moon (e.g., "WAXING_GIBBOUS")
    /// </summary>
    [JsonPropertyName("moon_phase")]
    public required string MoonPhase { get; set; }

    /// <summary>
    /// The time of moonrise
    /// </summary>
    [JsonPropertyName("moonrise")]
    public required string Moonrise { get; set; }

    /// <summary>
    /// The time of moonset
    /// </summary>
    [JsonPropertyName("moonset")]
    public required string Moonset { get; set; }

    /// <summary>
    /// The current status of the moon (e.g., "rising", "setting", "-")
    /// </summary>
    [JsonPropertyName("moon_status")]
    public required string MoonStatus { get; set; }

    /// <summary>
    /// The altitude angle of the moon above the horizon in degrees
    /// </summary>
    [JsonPropertyName("moon_altitude")]
    public required float MoonAltitude { get; set; }

    /// <summary>
    /// The distance from the Earth to the moon in kilometers
    /// </summary>
    [JsonPropertyName("moon_distance")]
    public required float MoonDistance { get; set; }

    /// <summary>
    /// The azimuth angle of the moon in degrees from true north
    /// </summary>
    [JsonPropertyName("moon_azimuth")]
    public required float MoonAzimuth { get; set; }

    /// <summary>
    /// The parallactic angle of the moon in degrees
    /// </summary>
    [JsonPropertyName("moon_parallactic_angle")]
    public required float MoonParallacticAngle { get; set; }

    /// <summary>
    /// The percentage of the moon illuminated by sunlight. A negative value indicates the moon is in a waning phase.
    /// </summary>
    [JsonPropertyName("moon_illumination_percentage")]
    public required string MoonIlluminationPercentage { get; set; }

    /// <summary>
    /// The geometric angle of the moon relative to the observer
    /// </summary>
    [JsonPropertyName("moon_angle")]
    public required float MoonAngle { get; set; }

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

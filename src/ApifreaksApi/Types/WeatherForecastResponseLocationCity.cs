using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record WeatherForecastResponseLocationCity : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Original location query string as submitted, including full address or place name.
    /// </summary>
    [JsonPropertyName("location_string")]
    public required string LocationString { get; set; }

    /// <summary>
    /// Resolved country name derived from the geocoded location query.
    /// </summary>
    [JsonPropertyName("country_name")]
    public required string CountryName { get; set; }

    /// <summary>
    /// State, province, or primary administrative division identified from the location.
    /// </summary>
    [JsonPropertyName("state_prov")]
    public required string StateProv { get; set; }

    /// <summary>
    /// City or municipal area name extracted from the geocoded location.
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; set; }

    /// <summary>
    /// Specific locality, neighborhood, suburb, or village within the geocoded area.
    /// </summary>
    [JsonPropertyName("locality")]
    public string? Locality { get; set; }

    /// <summary>
    /// Geocoded latitude coordinate in decimal degrees, ranging from -90 to +90.
    /// </summary>
    [JsonPropertyName("latitude")]
    public required string Latitude { get; set; }

    /// <summary>
    /// Geocoded longitude coordinate in decimal degrees, ranging from -180 to +180.
    /// </summary>
    [JsonPropertyName("longitude")]
    public required string Longitude { get; set; }

    /// <summary>
    /// Elevation above mean sea level in meters at the geocoded coordinates.
    /// </summary>
    [JsonPropertyName("elevation")]
    public string? Elevation { get; set; }

    /// <summary>
    /// IANA timezone database identifier for the geocoded location (e.g., America/Los_Angeles).
    /// </summary>
    [JsonPropertyName("timezone")]
    public required string Timezone { get; set; }

    /// <summary>
    /// Current timezone abbreviation for the location based on local offset (e.g., PDT, CET).
    /// </summary>
    [JsonPropertyName("timezone_abbreviation")]
    public required string TimezoneAbbreviation { get; set; }

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

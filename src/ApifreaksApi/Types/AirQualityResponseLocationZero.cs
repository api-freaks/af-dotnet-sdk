using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record AirQualityResponseLocationZero : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Geographic latitude coordinate in decimal degrees, ranging from -90 (South Pole) to +90 (North Pole).
    /// </summary>
    [JsonPropertyName("latitude")]
    public required string Latitude { get; set; }

    /// <summary>
    /// Geographic longitude coordinate in decimal degrees, ranging from -180 (West) to +180 (East).
    /// </summary>
    [JsonPropertyName("longitude")]
    public required string Longitude { get; set; }

    /// <summary>
    /// Full name of the country corresponding to the provided coordinates.
    /// </summary>
    [JsonPropertyName("country_name")]
    public required string CountryName { get; set; }

    /// <summary>
    /// State, province, or primary administrative division name for the location.
    /// </summary>
    [JsonPropertyName("state_prov")]
    public required string StateProv { get; set; }

    /// <summary>
    /// City or municipal area name associated with the coordinate location.
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; set; }

    /// <summary>
    /// Specific locality, neighborhood, district, or village name within the broader area.
    /// </summary>
    [JsonPropertyName("locality")]
    public string? Locality { get; set; }

    /// <summary>
    /// Height above mean sea level in meters for the specified coordinates.
    /// </summary>
    [JsonPropertyName("elevation")]
    public string? Elevation { get; set; }

    /// <summary>
    /// IANA timezone database identifier for the location (e.g., America/New_York, Europe/London).
    /// </summary>
    [JsonPropertyName("timezone")]
    public required string Timezone { get; set; }

    /// <summary>
    /// Abbreviated timezone representation based on current offset (e.g., EST, GMT, PST).
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

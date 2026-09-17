using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record MarineWeatherResponseLocationContinentCode : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Two-letter continent code (e.g., NA for North America, EU for Europe, AS for Asia).
    /// </summary>
    [JsonPropertyName("continent_code")]
    public required string ContinentCode { get; set; }

    /// <summary>
    /// Full name of the continent where the IP address is registered.
    /// </summary>
    [JsonPropertyName("continent_name")]
    public required string ContinentName { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-2 two-letter country code (e.g., US, GB, FR).
    /// </summary>
    [JsonPropertyName("country_code2")]
    public required string CountryCode2 { get; set; }

    /// <summary>
    /// ISO 3166-1 alpha-3 three-letter country code (e.g., USA, GBR, FRA).
    /// </summary>
    [JsonPropertyName("country_code3")]
    public required string CountryCode3 { get; set; }

    /// <summary>
    /// Common name of the country associated with the IP address.
    /// </summary>
    [JsonPropertyName("country_name")]
    public required string CountryName { get; set; }

    /// <summary>
    /// Official long-form country name as recognized internationally (e.g., United States of America).
    /// </summary>
    [JsonPropertyName("country_name_official")]
    public required string CountryNameOfficial { get; set; }

    /// <summary>
    /// Boolean flag indicating whether the country is a member state of the European Union.
    /// </summary>
    [JsonPropertyName("is_eu")]
    public bool? IsEu { get; set; }

    /// <summary>
    /// State, province, or primary administrative division associated with the IP location.
    /// </summary>
    [JsonPropertyName("state_prov")]
    public required string StateProv { get; set; }

    /// <summary>
    /// ISO 3166-2 subdivision code for the state or province (e.g., CA for California).
    /// </summary>
    [JsonPropertyName("state_code")]
    public string? StateCode { get; set; }

    /// <summary>
    /// District, county, or secondary administrative division within the region.
    /// </summary>
    [JsonPropertyName("district")]
    public string? District { get; set; }

    /// <summary>
    /// City or urban area name where the IP address is geographically registered.
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; set; }

    /// <summary>
    /// Postal code or ZIP code for the approximate location of the IP address.
    /// </summary>
    [JsonPropertyName("zipcode")]
    public string? Zipcode { get; set; }

    /// <summary>
    /// Geographic latitude in decimal degrees for the IP geolocation, ranging from -90 to +90.
    /// </summary>
    [JsonPropertyName("latitude")]
    public required string Latitude { get; set; }

    /// <summary>
    /// Geographic longitude in decimal degrees for the IP geolocation, ranging from -180 to +180.
    /// </summary>
    [JsonPropertyName("longitude")]
    public required string Longitude { get; set; }

    /// <summary>
    /// Specific locality, neighborhood, or small area designation within the city.
    /// </summary>
    [JsonPropertyName("locality")]
    public string? Locality { get; set; }

    /// <summary>
    /// Elevation above mean sea level in meters for the IP geolocation.
    /// </summary>
    [JsonPropertyName("elevation")]
    public string? Elevation { get; set; }

    /// <summary>
    /// IANA timezone database identifier for the IP location (e.g., America/Chicago, Asia/Tokyo).
    /// </summary>
    [JsonPropertyName("timezone")]
    public required string Timezone { get; set; }

    /// <summary>
    /// Current timezone abbreviation based on local offset (e.g., CST, JST, UTC).
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

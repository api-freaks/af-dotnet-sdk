using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Geographic location information for the astronomy calculation. The set of populated fields depends on which lookup mode the request used: (1) location param (geocode-by-address) returns location_string plus a basic field set (country_name, state_prov, city, locality, latitude, longitude, elevation); (2) lat + long params (geocode-by-coordinates) returns the same basic field set minus location_string, and locality may be an empty string when the coordinates don't resolve to a named sub-area; (3) ip param, or no location/lat/long/ip param at all (falls back to geo-IP lookup of the client's IP), returns the full geo-IP field set — continent_code, continent_name, country_code2, country_code3, country_name_official, is_eu, state_code, district, zipcode — in addition to the basic fields, but never location_string. elevation can be an empty string when elevation data is unavailable for the resolved location.
/// </summary>
[Serializable]
public record AstronomyLookupV2ResponseLocation : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The location query parameter echoed back as-is. Present only for geocode-by-address lookups (location param); absent for lat/long and ip-based lookups.
    /// </summary>
    [JsonPropertyName("location_string")]
    public string? LocationString { get; set; }

    /// <summary>
    /// The two-letter code of the continent (e.g., "NA"). Geo-IP field only: present for ip param or default client-IP lookups; absent for location/lat/long geocode lookups.
    /// </summary>
    [JsonPropertyName("continent_code")]
    public string? ContinentCode { get; set; }

    /// <summary>
    /// The full name of the continent (e.g., "North America"). Geo-IP field only: present for ip param or default client-IP lookups; absent for location/lat/long geocode lookups.
    /// </summary>
    [JsonPropertyName("continent_name")]
    public string? ContinentName { get; set; }

    /// <summary>
    /// The ISO 3166-1 alpha-2 two-letter country code (e.g., "US"). Geo-IP field only: present for ip param or default client-IP lookups; absent for location/lat/long geocode lookups.
    /// </summary>
    [JsonPropertyName("country_code2")]
    public string? CountryCode2 { get; set; }

    /// <summary>
    /// The ISO 3166-1 alpha-3 three-letter country code (e.g., "USA"). Geo-IP field only: present for ip param or default client-IP lookups; absent for location/lat/long geocode lookups.
    /// </summary>
    [JsonPropertyName("country_code3")]
    public string? CountryCode3 { get; set; }

    /// <summary>
    /// The common name of the country (e.g., "United States"). Present in all lookup modes.
    /// </summary>
    [JsonPropertyName("country_name")]
    public string? CountryName { get; set; }

    /// <summary>
    /// The official full name of the country (e.g., "United States of America"). Geo-IP field only: present for ip param or default client-IP lookups; absent for location/lat/long geocode lookups.
    /// </summary>
    [JsonPropertyName("country_name_official")]
    public string? CountryNameOfficial { get; set; }

    /// <summary>
    /// Whether the country belongs to the European Union. Geo-IP field only: present for ip param or default client-IP lookups; absent for location/lat/long geocode lookups.
    /// </summary>
    [JsonPropertyName("is_eu")]
    public bool? IsEu { get; set; }

    /// <summary>
    /// Name of the state/province/region. Present in all lookup modes.
    /// </summary>
    [JsonPropertyName("state_prov")]
    public string? StateProv { get; set; }

    /// <summary>
    /// Code of the state/province/region. Geo-IP field only: present for ip param or default client-IP lookups; absent for location/lat/long geocode lookups.
    /// </summary>
    [JsonPropertyName("state_code")]
    public string? StateCode { get; set; }

    /// <summary>
    /// Name of the district or county. Geo-IP field only: present for ip param or default client-IP lookups; absent for location/lat/long geocode lookups.
    /// </summary>
    [JsonPropertyName("district")]
    public string? District { get; set; }

    /// <summary>
    /// Name of the city. Present in all lookup modes.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// ZIP/Postal code of the place. Geo-IP field only: present for ip param or default client-IP lookups; absent for location/lat/long geocode lookups.
    /// </summary>
    [JsonPropertyName("zipcode")]
    public string? Zipcode { get; set; }

    /// <summary>
    /// The geographic latitude of the location. Present in all lookup modes.
    /// </summary>
    [JsonPropertyName("latitude")]
    public required string Latitude { get; set; }

    /// <summary>
    /// The geographic longitude of the location. Present in all lookup modes.
    /// </summary>
    [JsonPropertyName("longitude")]
    public required string Longitude { get; set; }

    /// <summary>
    /// Smaller area, part or region of a city. Present in all lookup modes, but may be an empty string for lat/long or geo-IP lookups when no named sub-area resolves.
    /// </summary>
    [JsonPropertyName("locality")]
    public string? Locality { get; set; }

    /// <summary>
    /// The elevation of the geographical location, in meters. Present in all lookup modes, but may be an empty string when elevation data is unavailable for the resolved location.
    /// </summary>
    [JsonPropertyName("elevation")]
    public string? Elevation { get; set; }

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

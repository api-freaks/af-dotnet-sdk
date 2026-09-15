using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Geographic location information. Only present for location (address) and ip (or client-IP fallback) lookups; absent for tz, lat/long, iata_code/icao_code, and lo_code lookups. Field set varies by mode: location returns location_string plus a basic field set (country_name, state_prov, city, locality, latitude, longitude); ip/default returns a richer geo-IP field set (continent_code, continent_name, country_code2, country_code3, country_name_official, is_eu, state_code, district, zipcode) plus the common fields, but never location_string or locality.
/// </summary>
[Serializable]
public record TimezoneLookupV2ResponseLocation : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The provided location parameter as location. Present only for location (address) lookups; absent for ip lookups.
    /// </summary>
    [JsonPropertyName("location_string")]
    public string? LocationString { get; set; }

    /// <summary>
    /// The two-letter code of the continent (e.g., NA). Geo-IP field only: present for ip param or default client-IP lookups; absent for location lookups.
    /// </summary>
    [JsonPropertyName("continent_code")]
    public string? ContinentCode { get; set; }

    /// <summary>
    /// The full name of the continent (e.g., North America). Geo-IP field only: present for ip param or default client-IP lookups; absent for location lookups.
    /// </summary>
    [JsonPropertyName("continent_name")]
    public string? ContinentName { get; set; }

    /// <summary>
    /// The ISO 3166-1 alpha-2 two-letter country code (e.g., US). Geo-IP field only: present for ip param or default client-IP lookups; absent for location lookups.
    /// </summary>
    [JsonPropertyName("country_code2")]
    public string? CountryCode2 { get; set; }

    /// <summary>
    /// The ISO 3166-1 alpha-3 three-letter country code (e.g., USA). Geo-IP field only: present for ip param or default client-IP lookups; absent for location lookups.
    /// </summary>
    [JsonPropertyName("country_code3")]
    public string? CountryCode3 { get; set; }

    /// <summary>
    /// The common name of the country (e.g., United States). Present for both location and ip lookups.
    /// </summary>
    [JsonPropertyName("country_name")]
    public string? CountryName { get; set; }

    /// <summary>
    /// The official full name of the country (e.g., United States of America). Geo-IP field only: present for ip param or default client-IP lookups; absent for location lookups.
    /// </summary>
    [JsonPropertyName("country_name_official")]
    public string? CountryNameOfficial { get; set; }

    /// <summary>
    /// Whether the country belongs to the European Union. Geo-IP field only: present for ip param or default client-IP lookups; absent for location lookups.
    /// </summary>
    [JsonPropertyName("is_eu")]
    public bool? IsEu { get; set; }

    /// <summary>
    /// Name of the state/province/region. Present for both location and ip lookups.
    /// </summary>
    [JsonPropertyName("state_prov")]
    public string? StateProv { get; set; }

    /// <summary>
    /// Code of the state/province/region. Geo-IP field only: present for ip param or default client-IP lookups; absent for location lookups.
    /// </summary>
    [JsonPropertyName("state_code")]
    public string? StateCode { get; set; }

    /// <summary>
    /// Name of the district or county. Geo-IP field only: present for ip param or default client-IP lookups; absent for location lookups.
    /// </summary>
    [JsonPropertyName("district")]
    public string? District { get; set; }

    /// <summary>
    /// Name of the city. Present for both location and ip lookups.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// Smaller area, part or region of a city. Only present for location (address) lookups (may be an empty string); absent for ip lookups.
    /// </summary>
    [JsonPropertyName("locality")]
    public string? Locality { get; set; }

    /// <summary>
    /// ZIP/Postal code of the place. Geo-IP field only: present for ip param or default client-IP lookups; absent for location lookups.
    /// </summary>
    [JsonPropertyName("zipcode")]
    public string? Zipcode { get; set; }

    /// <summary>
    /// The geographic latitude of the location. Present for both location and ip lookups.
    /// </summary>
    [JsonPropertyName("latitude")]
    public string? Latitude { get; set; }

    /// <summary>
    /// The geographic longitude of the location. Present for both location and ip lookups.
    /// </summary>
    [JsonPropertyName("longitude")]
    public string? Longitude { get; set; }

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

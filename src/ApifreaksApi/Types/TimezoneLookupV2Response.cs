using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Timezone lookup result. time_zone is always present. Exactly which other object accompanies it depends on the lookup mode: tz name and lat/long coordinates return time_zone only (no location, no ip); location address returns a basic location object; ip param or client-IP fallback returns a rich location object plus top-level ip; iata_code/icao_code returns airport_details instead of location; lo_code returns lo_code_details instead of location.
/// </summary>
[Serializable]
public record TimezoneLookupV2Response : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The IP address used for the timezone lookup. Present when queried using the ip parameter, or with no location-identifying parameter at all (client-IP fallback). Absent for every other lookup mode.
    /// </summary>
    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

    /// <summary>
    /// Timezone and date/time information for the location.
    /// </summary>
    [JsonPropertyName("time_zone")]
    public required TimezoneLookupV2ResponseTimeZone TimeZone { get; set; }

    /// <summary>
    /// Geographic location information. Only present for location (address) and ip (or client-IP fallback) lookups; absent for tz, lat/long, iata_code/icao_code, and lo_code lookups. Field set varies by mode: location returns location_string plus a basic field set (country_name, state_prov, city, locality, latitude, longitude); ip/default returns a richer geo-IP field set (continent_code, continent_name, country_code2, country_code3, country_name_official, is_eu, state_code, district, zipcode) plus the common fields, but never location_string or locality.
    /// </summary>
    [JsonPropertyName("location")]
    public TimezoneLookupV2ResponseLocation? Location { get; set; }

    /// <summary>
    /// Airport information, present when queried by IATA or ICAO code.
    /// </summary>
    [JsonPropertyName("airport_details")]
    public TimezoneLookupV2ResponseAirportDetails? AirportDetails { get; set; }

    /// <summary>
    /// UN/LOCODE location details, present when queried by LO code.
    /// </summary>
    [JsonPropertyName("lo_code_details")]
    public TimezoneLookupV2ResponseLoCodeDetails? LoCodeDetails { get; set; }

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

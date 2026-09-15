using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Airport information, present when queried by IATA or ICAO code.
/// </summary>
[Serializable]
public record TimezoneLookupV2ResponseAirportDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Classification of the airport based on size and traffic.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// The full name of the airport.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The latitude coordinate of the airport.
    /// </summary>
    [JsonPropertyName("latitude")]
    public float? Latitude { get; set; }

    /// <summary>
    /// The longitude coordinate of the airport.
    /// </summary>
    [JsonPropertyName("longitude")]
    public float? Longitude { get; set; }

    /// <summary>
    /// The elevation of the airport above sea level, measured in feet.
    /// </summary>
    [JsonPropertyName("elevation_ft")]
    public int? ElevationFt { get; set; }

    /// <summary>
    /// The two-letter code of the continent.
    /// </summary>
    [JsonPropertyName("continent_code")]
    public string? ContinentCode { get; set; }

    /// <summary>
    /// The ISO 3166-1 alpha-2 code for the country where the airport is located.
    /// </summary>
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// Code of the state/province/region where the airport is located.
    /// </summary>
    [JsonPropertyName("state_code")]
    public string? StateCode { get; set; }

    /// <summary>
    /// The city or administrative region that the airport serves.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// The three-letter IATA airport code (e.g., LHR).
    /// </summary>
    [JsonPropertyName("iata_code")]
    public string? IataCode { get; set; }

    /// <summary>
    /// The four-letter ICAO airport code (e.g., EGLL).
    /// </summary>
    [JsonPropertyName("icao_code")]
    public string? IcaoCode { get; set; }

    /// <summary>
    /// The FAA location identifier, used primarily in the United States.
    /// </summary>
    [JsonPropertyName("faa_code")]
    public string? FaaCode { get; set; }

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

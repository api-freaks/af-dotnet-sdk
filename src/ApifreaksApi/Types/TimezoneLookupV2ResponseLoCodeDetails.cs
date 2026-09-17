using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// UN/LOCODE location details, present when queried by LO code.
/// </summary>
[Serializable]
public record TimezoneLookupV2ResponseLoCodeDetails : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A unique identifier for the location, often used in logistics and shipping (e.g., USNYC).
    /// </summary>
    [JsonPropertyName("lo_code")]
    public string? LoCode { get; set; }

    /// <summary>
    /// The name of the city or location associated with the LO code.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// The code for the state, province or region.
    /// </summary>
    [JsonPropertyName("state_code")]
    public string? StateCode { get; set; }

    /// <summary>
    /// The ISO 3166-1 alpha-2 country code (e.g., US).
    /// </summary>
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    /// <summary>
    /// The name of the country in an administrative context.
    /// </summary>
    [JsonPropertyName("country_name")]
    public string? CountryName { get; set; }

    /// <summary>
    /// The type of location as comma-separated list of facilities (e.g., Port, Rail Terminal, Road Terminal, Airport).
    /// </summary>
    [JsonPropertyName("location_type")]
    public string? LocationType { get; set; }

    /// <summary>
    /// The latitude coordinate of the location.
    /// </summary>
    [JsonPropertyName("latitude")]
    public string? Latitude { get; set; }

    /// <summary>
    /// The longitude coordinate of the location.
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

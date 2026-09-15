using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Geographic location information for the IP.
/// </summary>
[Serializable]
public record GeolocationLookupV2ResponseLocation : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// 2-letter code of the continent.
    /// </summary>
    [JsonPropertyName("continent_code")]
    public required string ContinentCode { get; set; }

    /// <summary>
    /// Name of the continent.
    /// </summary>
    [JsonPropertyName("continent_name")]
    public required string ContinentName { get; set; }

    /// <summary>
    /// Country code (ISO 3166-1 alpha-2) of the country.
    /// </summary>
    [JsonPropertyName("country_code2")]
    public required string CountryCode2 { get; set; }

    /// <summary>
    /// Country code (ISO 3166-1 alpha-3) of the country.
    /// </summary>
    [JsonPropertyName("country_code3")]
    public required string CountryCode3 { get; set; }

    /// <summary>
    /// Name of the country.
    /// </summary>
    [JsonPropertyName("country_name")]
    public required string CountryName { get; set; }

    /// <summary>
    /// Official name (ISO 3166) of the country.
    /// </summary>
    [JsonPropertyName("country_name_official")]
    public required string CountryNameOfficial { get; set; }

    /// <summary>
    /// Name of the country's capital.
    /// </summary>
    [JsonPropertyName("country_capital")]
    public required string CountryCapital { get; set; }

    /// <summary>
    /// Name of the state/province/region.
    /// </summary>
    [JsonPropertyName("state_prov")]
    public string? StateProv { get; set; }

    /// <summary>
    /// Code of the state/province/region.
    /// </summary>
    [JsonPropertyName("state_code")]
    public string? StateCode { get; set; }

    /// <summary>
    /// Name of the district or county.
    /// </summary>
    [JsonPropertyName("district")]
    public string? District { get; set; }

    /// <summary>
    /// Name of the city.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// A more specific area in city or it can be same as city.
    /// </summary>
    [JsonPropertyName("locality")]
    public string? Locality { get; set; }

    /// <summary>
    /// Circular radius in Km, where the IP address location can be found.
    /// </summary>
    [JsonPropertyName("accuracy_radius")]
    public string? AccuracyRadius { get; set; }

    /// <summary>
    /// Confidence level of the location match (e.g., low, medium, high).
    /// </summary>
    [JsonPropertyName("confidence")]
    public string? Confidence { get; set; }

    /// <summary>
    /// Designated Market Area (DMA) code used in the United States for media marketing.
    /// </summary>
    [JsonPropertyName("dma_code")]
    public string? DmaCode { get; set; }

    /// <summary>
    /// ZIP/Postal code of the place.
    /// </summary>
    [JsonPropertyName("zipcode")]
    public string? Zipcode { get; set; }

    /// <summary>
    /// Latitude of the place.
    /// </summary>
    [JsonPropertyName("latitude")]
    public required string Latitude { get; set; }

    /// <summary>
    /// Longitude of the place.
    /// </summary>
    [JsonPropertyName("longitude")]
    public required string Longitude { get; set; }

    /// <summary>
    /// Is the country belong to European Union?
    /// </summary>
    [JsonPropertyName("is_eu")]
    public required bool IsEu { get; set; }

    /// <summary>
    /// URL to get the country flag.
    /// </summary>
    [JsonPropertyName("country_flag")]
    public required string CountryFlag { get; set; }

    /// <summary>
    /// Geoname ID of the place from geonames.org.
    /// </summary>
    [JsonPropertyName("geoname_id")]
    public string? GeonameId { get; set; }

    /// <summary>
    /// Emoji of the Country flag.
    /// </summary>
    [JsonPropertyName("country_emoji")]
    public string? CountryEmoji { get; set; }

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

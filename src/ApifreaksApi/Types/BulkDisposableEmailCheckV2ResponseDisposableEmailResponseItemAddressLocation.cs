using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Geolocation data derived from the IP address.
/// </summary>
[Serializable]
public record BulkDisposableEmailCheckV2ResponseDisposableEmailResponseItemAddressLocation
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Municipal or city name.
    /// </summary>
    [JsonPropertyName("city")]
    public string? City { get; set; }

    /// <summary>
    /// District or neighborhood.
    /// </summary>
    [JsonPropertyName("district")]
    public string? District { get; set; }

    /// <summary>
    /// Postal or ZIP code.
    /// </summary>
    [JsonPropertyName("zipcode")]
    public string? Zipcode { get; set; }

    /// <summary>
    /// State or province.
    /// </summary>
    [JsonPropertyName("state_prov")]
    public string? StateProv { get; set; }

    /// <summary>
    /// Common country name.
    /// </summary>
    [JsonPropertyName("country_name")]
    public string? CountryName { get; set; }

    /// <summary>
    /// Official country name.
    /// </summary>
    [JsonPropertyName("country_name_official")]
    public string? CountryNameOfficial { get; set; }

    /// <summary>
    /// Two-character ISO country code.
    /// </summary>
    [JsonPropertyName("country_code2")]
    public string? CountryCode2 { get; set; }

    /// <summary>
    /// Three-character ISO country code.
    /// </summary>
    [JsonPropertyName("country_code3")]
    public string? CountryCode3 { get; set; }

    /// <summary>
    /// Continental region name.
    /// </summary>
    [JsonPropertyName("continent_name")]
    public string? ContinentName { get; set; }

    /// <summary>
    /// Continental region identifier.
    /// </summary>
    [JsonPropertyName("continent_code")]
    public string? ContinentCode { get; set; }

    /// <summary>
    /// Geolocation precision radius. Not included for every IP.
    /// </summary>
    [JsonPropertyName("accuracy_radius")]
    public string? AccuracyRadius { get; set; }

    /// <summary>
    /// Confidence score for geolocation accuracy. Not included for every IP.
    /// </summary>
    [JsonPropertyName("confidence")]
    public string? Confidence { get; set; }

    /// <summary>
    /// European Union membership status.
    /// </summary>
    [JsonPropertyName("is_eu")]
    public bool? IsEu { get; set; }

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

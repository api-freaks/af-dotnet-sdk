using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record GeolocationLookupV2Response : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The IP address used for the lookup (IPv4 or IPv6).
    /// </summary>
    [JsonPropertyName("ip")]
    public required string Ip { get; set; }

    /// <summary>
    /// The input domain, returned only for domain-based lookups.
    /// </summary>
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    /// <summary>
    /// Reverse DNS hostname (PTR) for the input IP; returns the input IP if not resolvable.
    /// </summary>
    [JsonPropertyName("hostname")]
    public string? Hostname { get; set; }

    /// <summary>
    /// Geographic location information for the IP.
    /// </summary>
    [JsonPropertyName("location")]
    public GeolocationLookupV2ResponseLocation? Location { get; set; }

    /// <summary>
    /// Country-specific metadata.
    /// </summary>
    [JsonPropertyName("country_metadata")]
    public GeolocationLookupV2ResponseCountryMetadata? CountryMetadata { get; set; }

    /// <summary>
    /// Network information for the IP.
    /// </summary>
    [JsonPropertyName("network")]
    public GeolocationLookupV2ResponseNetwork? Network { get; set; }

    /// <summary>
    /// Autonomous System details for the IP.
    /// </summary>
    [JsonPropertyName("asn")]
    public GeolocationLookupV2ResponseAsn? Asn { get; set; }

    /// <summary>
    /// Company or ISP information mapped to the IP address.
    /// </summary>
    [JsonPropertyName("company")]
    public GeolocationLookupV2ResponseCompany? Company { get; set; }

    /// <summary>
    /// Currency information for the IP's country.
    /// </summary>
    [JsonPropertyName("currency")]
    public GeolocationLookupV2ResponseCurrency? Currency { get; set; }

    /// <summary>
    /// Threat intelligence and security information for the IP.
    /// </summary>
    [JsonPropertyName("security")]
    public GeolocationLookupV2ResponseSecurity? Security { get; set; }

    /// <summary>
    /// Abuse contact information for the IP.
    /// </summary>
    [JsonPropertyName("abuse")]
    public GeolocationLookupV2ResponseAbuse? Abuse { get; set; }

    /// <summary>
    /// Time zone information for the IP's location.
    /// </summary>
    [JsonPropertyName("time_zone")]
    public GeolocationLookupV2ResponseTimeZone? TimeZone { get; set; }

    /// <summary>
    /// Parsed User-Agent details from the request.
    /// </summary>
    [JsonPropertyName("user_agent")]
    public GeolocationLookupV2ResponseUserAgent? UserAgent { get; set; }

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

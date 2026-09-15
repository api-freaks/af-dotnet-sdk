using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Geolocation and threat intelligence result for one successfully resolved IP address.
/// </summary>
[Serializable]
public record BulkGeolocationLookupV2ResponseItemAbuse : IJsonOnDeserialized
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
    public BulkGeolocationLookupV2ResponseItemAbuseLocation? Location { get; set; }

    /// <summary>
    /// Country-specific metadata.
    /// </summary>
    [JsonPropertyName("country_metadata")]
    public BulkGeolocationLookupV2ResponseItemAbuseCountryMetadata? CountryMetadata { get; set; }

    /// <summary>
    /// Network information for the IP.
    /// </summary>
    [JsonPropertyName("network")]
    public BulkGeolocationLookupV2ResponseItemAbuseNetwork? Network { get; set; }

    /// <summary>
    /// Autonomous System details for the IP.
    /// </summary>
    [JsonPropertyName("asn")]
    public BulkGeolocationLookupV2ResponseItemAbuseAsn? Asn { get; set; }

    /// <summary>
    /// Company or ISP information mapped to the IP address.
    /// </summary>
    [JsonPropertyName("company")]
    public BulkGeolocationLookupV2ResponseItemAbuseCompany? Company { get; set; }

    /// <summary>
    /// Currency information for the IP's country.
    /// </summary>
    [JsonPropertyName("currency")]
    public BulkGeolocationLookupV2ResponseItemAbuseCurrency? Currency { get; set; }

    /// <summary>
    /// Threat intelligence and security information for the IP.
    /// </summary>
    [JsonPropertyName("security")]
    public BulkGeolocationLookupV2ResponseItemAbuseSecurity? Security { get; set; }

    /// <summary>
    /// Abuse contact information for the IP.
    /// </summary>
    [JsonPropertyName("abuse")]
    public BulkGeolocationLookupV2ResponseItemAbuseAbuse? Abuse { get; set; }

    /// <summary>
    /// Time zone information for the IP's location.
    /// </summary>
    [JsonPropertyName("time_zone")]
    public BulkGeolocationLookupV2ResponseItemAbuseTimeZone? TimeZone { get; set; }

    /// <summary>
    /// Parsed User-Agent details from the request.
    /// </summary>
    [JsonPropertyName("user_agent")]
    public BulkGeolocationLookupV2ResponseItemAbuseUserAgent? UserAgent { get; set; }

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

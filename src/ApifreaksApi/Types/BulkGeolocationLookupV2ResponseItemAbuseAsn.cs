using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Autonomous System details for the IP.
/// </summary>
[Serializable]
public record BulkGeolocationLookupV2ResponseItemAbuseAsn : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ASN identifier in AS&lt;number&gt; format associated with the IP's network.
    /// </summary>
    [JsonPropertyName("as_number")]
    public string? AsNumber { get; set; }

    /// <summary>
    /// ASN operator name.
    /// </summary>
    [JsonPropertyName("organization")]
    public string? Organization { get; set; }

    /// <summary>
    /// ASN registration country as ISO 3166-1 alpha-2.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// ASN category (ISP, HOSTING, BUSINESS, etc.).
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// ASN operator domain name.
    /// </summary>
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    /// <summary>
    /// ASN allocation date in YYYY-MM-DD format.
    /// </summary>
    [JsonPropertyName("date_allocated")]
    public string? DateAllocated { get; set; }

    /// <summary>
    /// Regional Internet Registry that allocated the ASN.
    /// </summary>
    [JsonPropertyName("rir")]
    public string? Rir { get; set; }

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

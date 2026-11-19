using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleName
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("type")]
    public required int Type { get; set; }

    [JsonPropertyName("dnsType")]
    public required BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleNameDnsType DnsType { get; set; }

    [JsonPropertyName("ttl")]
    public required int Ttl { get; set; }

    [JsonPropertyName("rawText")]
    public required string RawText { get; set; }

    [JsonPropertyName("rRsetType")]
    public required int RRsetType { get; set; }

    /// <summary>
    /// The name server (NS records), or the host name the IP address resolves to (PTR records from IP address lookups).
    /// </summary>
    [JsonPropertyName("singleName")]
    public required string SingleName { get; set; }

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

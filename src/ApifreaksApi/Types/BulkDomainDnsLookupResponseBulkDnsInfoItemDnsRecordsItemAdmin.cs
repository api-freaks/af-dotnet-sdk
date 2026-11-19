using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemAdmin : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("type")]
    public required int Type { get; set; }

    [JsonPropertyName("dnsType")]
    public required BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemAdminDnsType DnsType { get; set; }

    [JsonPropertyName("ttl")]
    public required int Ttl { get; set; }

    [JsonPropertyName("rawText")]
    public required string RawText { get; set; }

    [JsonPropertyName("rRsetType")]
    public required int RRsetType { get; set; }

    [JsonPropertyName("admin")]
    public required string Admin { get; set; }

    [JsonPropertyName("host")]
    public required string Host { get; set; }

    [JsonPropertyName("expire")]
    public required int Expire { get; set; }

    [JsonPropertyName("minimum")]
    public required int Minimum { get; set; }

    [JsonPropertyName("refresh")]
    public required int Refresh { get; set; }

    [JsonPropertyName("retry")]
    public required int Retry { get; set; }

    [JsonPropertyName("serial")]
    public required long Serial { get; set; }

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

using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace ApifreaksApi;

[Serializable]
public record BulkDomainDnsLookupResponseBulkDnsInfoItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates whether the query was processed successfully.
    /// </summary>
    [JsonPropertyName("status")]
    public required bool Status { get; set; }

    /// <summary>
    /// Timestamp when the query was executed (format YYYY-MM-DD HH:mm:ss, not ISO 8601).
    /// </summary>
    [JsonPropertyName("queryTime")]
    public required string QueryTime { get; set; }

    /// <summary>
    /// Queried domain. Absent when this result is for a queried IP address instead (see `ipAddress`).
    /// </summary>
    [JsonPropertyName("domainName")]
    public string? DomainName { get; set; }

    /// <summary>
    /// Indicates whether the domain is registered. Absent when this result is for a queried IP address instead.
    /// </summary>
    [JsonPropertyName("domainRegistered")]
    public bool? DomainRegistered { get; set; }

    /// <summary>
    /// Queried IP address, present when this result is for reverse DNS (PTR) enrichment instead of a domain name.
    /// </summary>
    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; set; }

    [JsonPropertyName("dnsTypes")]
    public required BulkDomainDnsLookupResponseBulkDnsInfoItemDnsTypes DnsTypes { get; set; }

    /// <summary>
    /// List of DNS records, each based on its type.
    /// </summary>
    [JsonPropertyName("dnsRecords")]
    public IEnumerable<
        OneOf<
            BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemAddress,
            BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemOne,
            BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemPriority,
            BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleName,
            BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemAdmin,
            BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemStrings
        >
    > DnsRecords { get; set; } =
        new List<
            OneOf<
                BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemAddress,
                BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemOne,
                BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemPriority,
                BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemSingleName,
                BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemAdmin,
                BulkDomainDnsLookupResponseBulkDnsInfoItemDnsRecordsItemStrings
            >
        >();

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

using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace ApifreaksApi;

[Serializable]
public record DomainDnsReverseResponseReverseDnsRecordsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Timestamp when the query was executed (format YYYY-MM-DD HH:mm:ss, not ISO 8601).
    /// </summary>
    [JsonPropertyName("queryTime")]
    public required string QueryTime { get; set; }

    [JsonPropertyName("domainName")]
    public required string DomainName { get; set; }

    [JsonPropertyName("domainRegistered")]
    public required bool DomainRegistered { get; set; }

    [JsonPropertyName("dnsTypes")]
    public required DomainDnsReverseResponseReverseDnsRecordsItemDnsTypes DnsTypes { get; set; }

    [JsonPropertyName("dnsRecords")]
    public IEnumerable<
        OneOf<
            DomainDnsReverseResponseReverseDnsRecordsItemDnsRecordsItemAddress,
            DomainDnsReverseResponseReverseDnsRecordsItemDnsRecordsItemOne,
            DomainDnsReverseResponseReverseDnsRecordsItemDnsRecordsItemPriority,
            DomainDnsReverseResponseReverseDnsRecordsItemDnsRecordsItemSingleName,
            DomainDnsReverseResponseReverseDnsRecordsItemDnsRecordsItemAdmin,
            DomainDnsReverseResponseReverseDnsRecordsItemDnsRecordsItemStrings
        >
    > DnsRecords { get; set; } =
        new List<
            OneOf<
                DomainDnsReverseResponseReverseDnsRecordsItemDnsRecordsItemAddress,
                DomainDnsReverseResponseReverseDnsRecordsItemDnsRecordsItemOne,
                DomainDnsReverseResponseReverseDnsRecordsItemDnsRecordsItemPriority,
                DomainDnsReverseResponseReverseDnsRecordsItemDnsRecordsItemSingleName,
                DomainDnsReverseResponseReverseDnsRecordsItemDnsRecordsItemAdmin,
                DomainDnsReverseResponseReverseDnsRecordsItemDnsRecordsItemStrings
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

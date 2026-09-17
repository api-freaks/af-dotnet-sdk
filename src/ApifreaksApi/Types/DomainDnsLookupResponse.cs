using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;
using OneOf;

namespace ApifreaksApi;

[Serializable]
public record DomainDnsLookupResponse : IJsonOnDeserialized
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
    /// Queried domain.
    /// </summary>
    [JsonPropertyName("domainName")]
    public required string DomainName { get; set; }

    /// <summary>
    /// Indicates whether the domain is registered.
    /// </summary>
    [JsonPropertyName("domainRegistered")]
    public required bool DomainRegistered { get; set; }

    [JsonPropertyName("dnsTypes")]
    public required DomainDnsLookupResponseDnsTypes DnsTypes { get; set; }

    /// <summary>
    /// List of DNS records, each based on its type.
    /// </summary>
    [JsonPropertyName("dnsRecords")]
    public IEnumerable<
        OneOf<
            DomainDnsLookupResponseDnsRecordsItemAddress,
            DomainDnsLookupResponseDnsRecordsItemOne,
            DomainDnsLookupResponseDnsRecordsItemPriority,
            DomainDnsLookupResponseDnsRecordsItemSingleName,
            DomainDnsLookupResponseDnsRecordsItemAdmin,
            DomainDnsLookupResponseDnsRecordsItemStrings
        >
    > DnsRecords { get; set; } =
        new List<
            OneOf<
                DomainDnsLookupResponseDnsRecordsItemAddress,
                DomainDnsLookupResponseDnsRecordsItemOne,
                DomainDnsLookupResponseDnsRecordsItemPriority,
                DomainDnsLookupResponseDnsRecordsItemSingleName,
                DomainDnsLookupResponseDnsRecordsItemAdmin,
                DomainDnsLookupResponseDnsRecordsItemStrings
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

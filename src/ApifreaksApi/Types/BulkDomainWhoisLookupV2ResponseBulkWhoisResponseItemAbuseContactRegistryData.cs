using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Registry-level (as opposed to registrar-level) WHOIS data, sourced directly from the TLD registry.
/// </summary>
[Serializable]
public record BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactRegistryData
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Domain name as recorded by the registry.
    /// </summary>
    [JsonPropertyName("domain_name")]
    public string? DomainName { get; set; }

    /// <summary>
    /// Timestamp when the registry-level record was queried.
    /// </summary>
    [JsonPropertyName("query_time")]
    public DateTime? QueryTime { get; set; }

    /// <summary>
    /// Registry WHOIS server that returned this data.
    /// </summary>
    [JsonPropertyName("whois_server")]
    public string? WhoisServer { get; set; }

    /// <summary>
    /// Domain registration status as recorded by the registry.
    /// </summary>
    [JsonPropertyName("domain_registered")]
    public BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactRegistryDataDomainRegistered? DomainRegistered { get; set; }

    /// <summary>
    /// Domain creation date as recorded by the registry.
    /// </summary>
    [JsonPropertyName("create_date")]
    public DateOnly? CreateDate { get; set; }

    /// <summary>
    /// Domain last-updated date as recorded by the registry.
    /// </summary>
    [JsonPropertyName("update_date")]
    public DateOnly? UpdateDate { get; set; }

    /// <summary>
    /// Domain expiry date as recorded by the registry.
    /// </summary>
    [JsonPropertyName("expiry_date")]
    public DateOnly? ExpiryDate { get; set; }

    /// <summary>
    /// Name servers as recorded by the registry.
    /// </summary>
    [JsonPropertyName("name_servers")]
    public IEnumerable<string>? NameServers { get; set; }

    /// <summary>
    /// EPP domain status codes as recorded by the registry.
    /// </summary>
    [JsonPropertyName("domain_status")]
    public IEnumerable<string>? DomainStatus { get; set; }

    /// <summary>
    /// Raw WHOIS text as returned directly by the registry server.
    /// </summary>
    [JsonPropertyName("whois_raw_registery")]
    public string? WhoisRawRegistery { get; set; }

    /// <summary>
    /// Registrar of record for a domain, as published by either the registrar or the registry.
    /// </summary>
    [JsonPropertyName("domain_registrar")]
    public BulkDomainWhoisLookupV2ResponseBulkWhoisResponseItemAbuseContactRegistryDataDomainRegistrar? DomainRegistrar { get; set; }

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

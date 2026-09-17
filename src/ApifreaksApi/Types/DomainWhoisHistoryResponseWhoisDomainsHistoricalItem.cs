using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record DomainWhoisHistoryResponseWhoisDomainsHistoricalItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Shows the number of the record in the array.
    /// </summary>
    [JsonPropertyName("num")]
    public required int Num { get; set; }

    /// <summary>
    /// Always true.
    /// </summary>
    [JsonPropertyName("status")]
    public required bool Status { get; set; }

    /// <summary>
    /// Domain name which was queried.
    /// </summary>
    [JsonPropertyName("domain_name")]
    public required string DomainName { get; set; }

    /// <summary>
    /// The timestamp when the query was made (format YYYY-MM-DD HH:mm:ss, not ISO 8601).
    /// </summary>
    [JsonPropertyName("query_time")]
    public required string QueryTime { get; set; }

    /// <summary>
    /// The WHOIS server that provided the domain information.
    /// </summary>
    [JsonPropertyName("whois_server")]
    public required string WhoisServer { get; set; }

    /// <summary>
    /// Domain registration status.
    /// </summary>
    [JsonPropertyName("domain_registered")]
    public required DomainWhoisHistoryResponseWhoisDomainsHistoricalItemDomainRegistered DomainRegistered { get; set; }

    /// <summary>
    /// Date when the domain was initially registered.
    /// </summary>
    [JsonPropertyName("create_date")]
    public DateOnly? CreateDate { get; set; }

    /// <summary>
    /// The date of the most recent update to the domain registration.
    /// </summary>
    [JsonPropertyName("update_date")]
    public DateOnly? UpdateDate { get; set; }

    /// <summary>
    /// The date when the domain registration will expire if not renewed.
    /// </summary>
    [JsonPropertyName("expiry_date")]
    public DateOnly? ExpiryDate { get; set; }

    [JsonPropertyName("domain_registrar")]
    public DomainWhoisHistoryResponseWhoisDomainsHistoricalItemDomainRegistrar? DomainRegistrar { get; set; }

    [JsonPropertyName("reseller_contact")]
    public DomainWhoisHistoryResponseWhoisDomainsHistoricalItemResellerContact? ResellerContact { get; set; }

    [JsonPropertyName("registrant_contact")]
    public DomainWhoisHistoryResponseWhoisDomainsHistoricalItemRegistrantContact? RegistrantContact { get; set; }

    [JsonPropertyName("administrative_contact")]
    public DomainWhoisHistoryResponseWhoisDomainsHistoricalItemAdministrativeContact? AdministrativeContact { get; set; }

    [JsonPropertyName("technical_contact")]
    public DomainWhoisHistoryResponseWhoisDomainsHistoricalItemTechnicalContact? TechnicalContact { get; set; }

    [JsonPropertyName("billing_contact")]
    public DomainWhoisHistoryResponseWhoisDomainsHistoricalItemBillingContact? BillingContact { get; set; }

    [JsonPropertyName("name_servers")]
    public IEnumerable<string>? NameServers { get; set; }

    [JsonPropertyName("domain_status")]
    public IEnumerable<string>? DomainStatus { get; set; }

    [JsonPropertyName("whois_raw_domain")]
    public string? WhoisRawDomain { get; set; }

    [JsonPropertyName("registry_data")]
    public DomainWhoisHistoryResponseWhoisDomainsHistoricalItemRegistryData? RegistryData { get; set; }

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

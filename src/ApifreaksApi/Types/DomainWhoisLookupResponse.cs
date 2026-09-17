using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record DomainWhoisLookupResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("status")]
    public bool? Status { get; set; }

    [JsonPropertyName("domain_name")]
    public string? DomainName { get; set; }

    /// <summary>
    /// Timestamp when the WHOIS query was executed (format YYYY-MM-DD HH:mm:ss, not ISO 8601).
    /// </summary>
    [JsonPropertyName("query_time")]
    public string? QueryTime { get; set; }

    [JsonPropertyName("whois_server")]
    public string? WhoisServer { get; set; }

    [JsonPropertyName("domain_registered")]
    public DomainWhoisLookupResponseDomainRegistered? DomainRegistered { get; set; }

    [JsonPropertyName("create_date")]
    public DateOnly? CreateDate { get; set; }

    [JsonPropertyName("update_date")]
    public DateOnly? UpdateDate { get; set; }

    [JsonPropertyName("expiry_date")]
    public DateOnly? ExpiryDate { get; set; }

    [JsonPropertyName("domain_registrar")]
    public DomainWhoisLookupResponseDomainRegistrar? DomainRegistrar { get; set; }

    [JsonPropertyName("reseller_contact")]
    public DomainWhoisLookupResponseResellerContact? ResellerContact { get; set; }

    [JsonPropertyName("registrant_contact")]
    public DomainWhoisLookupResponseRegistrantContact? RegistrantContact { get; set; }

    [JsonPropertyName("administrative_contact")]
    public DomainWhoisLookupResponseAdministrativeContact? AdministrativeContact { get; set; }

    [JsonPropertyName("technical_contact")]
    public DomainWhoisLookupResponseTechnicalContact? TechnicalContact { get; set; }

    [JsonPropertyName("billing_contact")]
    public DomainWhoisLookupResponseBillingContact? BillingContact { get; set; }

    [JsonPropertyName("name_servers")]
    public IEnumerable<string>? NameServers { get; set; }

    [JsonPropertyName("domain_status")]
    public IEnumerable<string>? DomainStatus { get; set; }

    [JsonPropertyName("whois_raw_domain")]
    public string? WhoisRawDomain { get; set; }

    [JsonPropertyName("registry_data")]
    public DomainWhoisLookupResponseRegistryData? RegistryData { get; set; }

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

using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Current WHOIS registration record for the requested domain.
/// </summary>
[Serializable]
public record DomainWhoisLookupV2Response : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// true if the request was successfully processed.
    /// </summary>
    [JsonPropertyName("status")]
    public required bool Status { get; set; }

    /// <summary>
    /// Domain name that was queried.
    /// </summary>
    [JsonPropertyName("domain_name")]
    public required string DomainName { get; set; }

    /// <summary>
    /// Timestamp when the WHOIS query was executed.
    /// </summary>
    [JsonPropertyName("query_time")]
    public required string QueryTime { get; set; }

    /// <summary>
    /// WHOIS or RDAP server that provided this record.
    /// </summary>
    [JsonPropertyName("whois_server")]
    public string? WhoisServer { get; set; }

    /// <summary>
    /// Domain registration status; 'restricted' means the registry withholds registration details.
    /// </summary>
    [JsonPropertyName("domain_registered")]
    public required DomainWhoisLookupV2ResponseDomainRegistered DomainRegistered { get; set; }

    /// <summary>
    /// Indicates if DNSSEC or secure DNS is enabled for the domain.
    /// </summary>
    [JsonPropertyName("secure_dns")]
    public bool? SecureDns { get; set; }

    /// <summary>
    /// Internal domain registry handle/ID.
    /// </summary>
    [JsonPropertyName("domain_handle")]
    public string? DomainHandle { get; set; }

    /// <summary>
    /// Date the domain was originally registered, when the domain is registered.
    /// </summary>
    [JsonPropertyName("create_date")]
    public DateOnly? CreateDate { get; set; }

    /// <summary>
    /// Date the domain registration was last updated, when the domain is registered.
    /// </summary>
    [JsonPropertyName("update_date")]
    public DateOnly? UpdateDate { get; set; }

    /// <summary>
    /// Date the domain registration is set to expire, when the domain is registered.
    /// </summary>
    [JsonPropertyName("expiry_date")]
    public DateOnly? ExpiryDate { get; set; }

    /// <summary>
    /// Registrar of record for a domain, as published by either the registrar or the registry.
    /// </summary>
    [JsonPropertyName("domain_registrar")]
    public DomainWhoisLookupV2ResponseDomainRegistrar? DomainRegistrar { get; set; }

    /// <summary>
    /// A contact record (registrant, administrative, technical, billing, or reseller) published in the domain's WHOIS record.
    /// </summary>
    [JsonPropertyName("reseller_contact")]
    public DomainWhoisLookupV2ResponseResellerContact? ResellerContact { get; set; }

    /// <summary>
    /// A contact record (registrant, administrative, technical, billing, or reseller) published in the domain's WHOIS record.
    /// </summary>
    [JsonPropertyName("registrant_contact")]
    public DomainWhoisLookupV2ResponseRegistrantContact? RegistrantContact { get; set; }

    /// <summary>
    /// A contact record (registrant, administrative, technical, billing, or reseller) published in the domain's WHOIS record.
    /// </summary>
    [JsonPropertyName("administrative_contact")]
    public DomainWhoisLookupV2ResponseAdministrativeContact? AdministrativeContact { get; set; }

    /// <summary>
    /// A contact record (registrant, administrative, technical, billing, or reseller) published in the domain's WHOIS record.
    /// </summary>
    [JsonPropertyName("technical_contact")]
    public DomainWhoisLookupV2ResponseTechnicalContact? TechnicalContact { get; set; }

    /// <summary>
    /// A contact record (registrant, administrative, technical, billing, or reseller) published in the domain's WHOIS record.
    /// </summary>
    [JsonPropertyName("billing_contact")]
    public DomainWhoisLookupV2ResponseBillingContact? BillingContact { get; set; }

    /// <summary>
    /// Registrar's abuse-reporting contact.
    /// </summary>
    [JsonPropertyName("abuse_contact")]
    public DomainWhoisLookupV2ResponseAbuseContact? AbuseContact { get; set; }

    /// <summary>
    /// Domain eligibility information (populated for TLDs with registrant eligibility requirements, e.g. .eu).
    /// </summary>
    [JsonPropertyName("eligibility_info")]
    public DomainWhoisLookupV2ResponseEligibilityInfo? EligibilityInfo { get; set; }

    /// <summary>
    /// Name servers currently recorded for the domain.
    /// </summary>
    [JsonPropertyName("name_servers")]
    public IEnumerable<string>? NameServers { get; set; }

    /// <summary>
    /// EPP domain status codes currently recorded for the domain.
    /// </summary>
    [JsonPropertyName("domain_status")]
    public IEnumerable<string>? DomainStatus { get; set; }

    /// <summary>
    /// Raw WHOIS text as returned by the registrar's WHOIS server.
    /// </summary>
    [JsonPropertyName("whois_raw_domain")]
    public string? WhoisRawDomain { get; set; }

    /// <summary>
    /// Registry-level (as opposed to registrar-level) WHOIS data, sourced directly from the TLD registry.
    /// </summary>
    [JsonPropertyName("registry_data")]
    public DomainWhoisLookupV2ResponseRegistryData? RegistryData { get; set; }

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

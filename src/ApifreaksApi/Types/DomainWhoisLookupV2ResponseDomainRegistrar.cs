using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Registrar of record for a domain, as published by either the registrar or the registry.
/// </summary>
[Serializable]
public record DomainWhoisLookupV2ResponseDomainRegistrar : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// IANA registrar ID.
    /// </summary>
    [JsonPropertyName("iana_id")]
    public string? IanaId { get; set; }

    /// <summary>
    /// Registrar identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Type of registrar ID (e.g. IANA).
    /// </summary>
    [JsonPropertyName("id_type")]
    public string? IdType { get; set; }

    /// <summary>
    /// Registrar handle.
    /// </summary>
    [JsonPropertyName("handle")]
    public string? Handle { get; set; }

    /// <summary>
    /// Registry-specific registrar ID.
    /// </summary>
    [JsonPropertyName("registry_id")]
    public string? RegistryId { get; set; }

    /// <summary>
    /// Registry authority name.
    /// </summary>
    [JsonPropertyName("authoritative_registry_name")]
    public string? AuthoritativeRegistryName { get; set; }

    /// <summary>
    /// Registrar organization number.
    /// </summary>
    [JsonPropertyName("organization_number")]
    public string? OrganizationNumber { get; set; }

    /// <summary>
    /// Indicates if the registrar is a sponsor.
    /// </summary>
    [JsonPropertyName("is_sponsor")]
    public bool? IsSponsor { get; set; }

    /// <summary>
    /// Registrar's ICANN accreditation status (e.g. accredited), when published at the registrar level.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// Registered name of the registrar.
    /// </summary>
    [JsonPropertyName("registrar_name")]
    public string? RegistrarName { get; set; }

    /// <summary>
    /// Lowercased, normalized form of the registrar name, when published at the registrar level.
    /// </summary>
    [JsonPropertyName("normalized_name")]
    public string? NormalizedName { get; set; }

    /// <summary>
    /// WHOIS server operated by the registrar.
    /// </summary>
    [JsonPropertyName("whois_server")]
    public string? WhoisServer { get; set; }

    /// <summary>
    /// RDAP server URL operated by the registrar, when published at the registrar level.
    /// </summary>
    [JsonPropertyName("rdap_server")]
    public string? RdapServer { get; set; }

    /// <summary>
    /// Registrar's website URL.
    /// </summary>
    [JsonPropertyName("website_url")]
    public string? WebsiteUrl { get; set; }

    /// <summary>
    /// Registrar abuse or contact email address.
    /// </summary>
    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    /// <summary>
    /// Registrar contact phone number.
    /// </summary>
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

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

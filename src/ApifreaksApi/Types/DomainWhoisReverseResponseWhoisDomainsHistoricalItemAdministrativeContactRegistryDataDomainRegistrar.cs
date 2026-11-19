using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record DomainWhoisReverseResponseWhoisDomainsHistoricalItemAdministrativeContactRegistryDataDomainRegistrar
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("iana_id")]
    public string? IanaId { get; set; }

    [JsonPropertyName("registrar_name")]
    public string? RegistrarName { get; set; }

    [JsonPropertyName("whois_server")]
    public string? WhoisServer { get; set; }

    [JsonPropertyName("website_url")]
    public string? WebsiteUrl { get; set; }

    [JsonPropertyName("email_address")]
    public string? EmailAddress { get; set; }

    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Normalized (lowercase, stripped) registrar name, when published.
    /// </summary>
    [JsonPropertyName("normalized_name")]
    public string? NormalizedName { get; set; }

    /// <summary>
    /// RDAP (Registration Data Access Protocol) server URL of the registrar, when published.
    /// </summary>
    [JsonPropertyName("rdap_server")]
    public string? RdapServer { get; set; }

    /// <summary>
    /// Accreditation status of the registrar (e.g., 'accredited'), when published.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

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

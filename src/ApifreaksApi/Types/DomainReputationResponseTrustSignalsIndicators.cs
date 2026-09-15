using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Individual trust / risk indicators for the domain.
/// </summary>
[Serializable]
public record DomainReputationResponseTrustSignalsIndicators : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates whether the domain was recently registered. null when WHOIS data is unavailable.
    /// </summary>
    [JsonPropertyName("is_newly_registered")]
    public bool? IsNewlyRegistered { get; set; }

    /// <summary>
    /// Indicates whether the domain uses a free TLD extension.
    /// </summary>
    [JsonPropertyName("uses_free_extension")]
    public bool? UsesFreeExtension { get; set; }

    /// <summary>
    /// Indicates whether the domain uses a free SSL certificate.
    /// </summary>
    [JsonPropertyName("uses_free_ssl")]
    public bool? UsesFreeSsl { get; set; }

    /// <summary>
    /// Indicates whether WHOIS privacy protection is enabled. null when WHOIS data is unavailable.
    /// </summary>
    [JsonPropertyName("has_privacy_whois")]
    public bool? HasPrivacyWhois { get; set; }

    /// <summary>
    /// Age of the SSL certificate in days.
    /// </summary>
    [JsonPropertyName("ssl_age_days")]
    public int? SslAgeDays { get; set; }

    /// <summary>
    /// Indicates whether a DMARC record exists.
    /// </summary>
    [JsonPropertyName("has_dmarc")]
    public bool? HasDmarc { get; set; }

    /// <summary>
    /// Indicates whether an SPF record exists.
    /// </summary>
    [JsonPropertyName("has_spf")]
    public bool? HasSpf { get; set; }

    /// <summary>
    /// Indicates whether the domain redirects to an external site.
    /// </summary>
    [JsonPropertyName("redirects_externally")]
    public bool? RedirectsExternally { get; set; }

    /// <summary>
    /// Indicates whether obfuscated JavaScript was detected.
    /// </summary>
    [JsonPropertyName("javascript_obfuscated")]
    public bool? JavascriptObfuscated { get; set; }

    /// <summary>
    /// Age of the domain in days. null when WHOIS data is unavailable.
    /// </summary>
    [JsonPropertyName("domain_age_days")]
    public int? DomainAgeDays { get; set; }

    /// <summary>
    /// Domain registrar name. null when WHOIS data is unavailable.
    /// </summary>
    [JsonPropertyName("registrar")]
    public string? Registrar { get; set; }

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

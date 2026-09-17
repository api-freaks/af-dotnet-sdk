using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record DomainSslChainLookupResponseSslCertificatesItemExtensions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("authorityKeyIdentifier")]
    public required string AuthorityKeyIdentifier { get; set; }

    [JsonPropertyName("subjectKeyIdentifier")]
    public required string SubjectKeyIdentifier { get; set; }

    [JsonPropertyName("keyUsages")]
    public IEnumerable<string> KeyUsages { get; set; } = new List<string>();

    [JsonPropertyName("extendedKeyUsages")]
    public IEnumerable<string>? ExtendedKeyUsages { get; set; }

    [JsonPropertyName("crlDistributionPoints")]
    public IEnumerable<string>? CrlDistributionPoints { get; set; }

    [JsonPropertyName("authorityInfoAccess")]
    public DomainSslChainLookupResponseSslCertificatesItemExtensionsAuthorityInfoAccess? AuthorityInfoAccess { get; set; }

    [JsonPropertyName("subjectAlternativeNames")]
    public DomainSslChainLookupResponseSslCertificatesItemExtensionsSubjectAlternativeNames? SubjectAlternativeNames { get; set; }

    [JsonPropertyName("certificatePolicies")]
    public IEnumerable<DomainSslChainLookupResponseSslCertificatesItemExtensionsCertificatePoliciesItem>? CertificatePolicies { get; set; }

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

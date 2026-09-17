using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record DomainSslLookupResponseSslCertificatesItemExtensionsCertificatePoliciesItem
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Policy identifier
    /// </summary>
    [JsonPropertyName("policyId")]
    public required string PolicyId { get; set; }

    /// <summary>
    /// Policy qualifier details
    /// </summary>
    [JsonPropertyName("policyQualifier")]
    public DomainSslLookupResponseSslCertificatesItemExtensionsCertificatePoliciesItemPolicyQualifier? PolicyQualifier { get; set; }

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

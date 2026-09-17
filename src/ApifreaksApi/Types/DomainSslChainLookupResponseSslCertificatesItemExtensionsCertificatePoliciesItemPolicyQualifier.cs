using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Policy qualifier details
/// </summary>
[Serializable]
public record DomainSslChainLookupResponseSslCertificatesItemExtensionsCertificatePoliciesItemPolicyQualifier
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Object identifier
    /// </summary>
    [JsonPropertyName("oid")]
    public string? Oid { get; set; }

    /// <summary>
    /// URI of the CPS
    /// </summary>
    [JsonPropertyName("cpsUri")]
    public string? CpsUri { get; set; }

    [JsonPropertyName("userNotice")]
    public DomainSslChainLookupResponseSslCertificatesItemExtensionsCertificatePoliciesItemPolicyQualifierUserNotice? UserNotice { get; set; }

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

using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record DomainSslLookupResponseSslCertificatesItemExtensionsCertificatePoliciesItemPolicyQualifierUserNotice
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Explicit text notice
    /// </summary>
    [JsonPropertyName("explicitText")]
    public string? ExplicitText { get; set; }

    [JsonPropertyName("noticeRef")]
    public DomainSslLookupResponseSslCertificatesItemExtensionsCertificatePoliciesItemPolicyQualifierUserNoticeNoticeRef? NoticeRef { get; set; }

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

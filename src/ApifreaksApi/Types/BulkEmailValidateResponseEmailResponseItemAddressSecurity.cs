using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkEmailValidateResponseEmailResponseItemAddressSecurity : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("threat_score")]
    public required double ThreatScore { get; set; }

    [JsonPropertyName("is_tor")]
    public required bool IsTor { get; set; }

    [JsonPropertyName("is_proxy")]
    public required bool IsProxy { get; set; }

    [JsonPropertyName("proxy_type")]
    public required string ProxyType { get; set; }

    [JsonPropertyName("proxy_provider")]
    public required string ProxyProvider { get; set; }

    [JsonPropertyName("is_anonymous")]
    public required bool IsAnonymous { get; set; }

    [JsonPropertyName("is_known_attacker")]
    public required bool IsKnownAttacker { get; set; }

    [JsonPropertyName("is_spam")]
    public required bool IsSpam { get; set; }

    [JsonPropertyName("is_bot")]
    public required bool IsBot { get; set; }

    [JsonPropertyName("is_cloud_provider")]
    public required bool IsCloudProvider { get; set; }

    [JsonPropertyName("cloud_provider")]
    public required string CloudProvider { get; set; }

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

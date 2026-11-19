using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Threat and anonymity profile for the IP address.
/// </summary>
[Serializable]
public record BulkDisposableEmailCheckV2ResponseDisposableEmailResponseItemAddressSecurity
    : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Quantitative risk assessment score. Higher values indicate elevated security risk.
    /// </summary>
    [JsonPropertyName("threat_score")]
    public required int ThreatScore { get; set; }

    /// <summary>
    /// Detection flag for IP addresses routed through the Tor anonymity network.
    /// </summary>
    [JsonPropertyName("is_tor")]
    public required bool IsTor { get; set; }

    /// <summary>
    /// Detection flag identifying IP addresses operating as proxy servers.
    /// </summary>
    [JsonPropertyName("is_proxy")]
    public required bool IsProxy { get; set; }

    /// <summary>
    /// Classification of detected proxy infrastructure type (e.g. VPN, HTTP, SOCKS). Included only when is_proxy is true.
    /// </summary>
    [JsonPropertyName("proxy_type")]
    public string? ProxyType { get; set; }

    /// <summary>
    /// Identified service provider operating the proxy infrastructure. Included only when is_proxy is true.
    /// </summary>
    [JsonPropertyName("proxy_provider")]
    public string? ProxyProvider { get; set; }

    /// <summary>
    /// Anonymization detection flag for IP addresses using identity obfuscation techniques.
    /// </summary>
    [JsonPropertyName("is_anonymous")]
    public required bool IsAnonymous { get; set; }

    /// <summary>
    /// Threat intelligence flag for IP addresses documented as confirmed malicious sources.
    /// </summary>
    [JsonPropertyName("is_known_attacker")]
    public required bool IsKnownAttacker { get; set; }

    /// <summary>
    /// Reputation flag for IP addresses associated with spam transmission.
    /// </summary>
    [JsonPropertyName("is_spam")]
    public required bool IsSpam { get; set; }

    /// <summary>
    /// Automated traffic detection flag for IP addresses from bot networks.
    /// </summary>
    [JsonPropertyName("is_bot")]
    public required bool IsBot { get; set; }

    /// <summary>
    /// Infrastructure classification flag for IP addresses from cloud computing providers.
    /// </summary>
    [JsonPropertyName("is_cloud_provider")]
    public required bool IsCloudProvider { get; set; }

    /// <summary>
    /// Identified cloud infrastructure or hosting service provider name.
    /// </summary>
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

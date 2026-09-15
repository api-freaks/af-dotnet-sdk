using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Threat intelligence and security information for the IP.
/// </summary>
[Serializable]
public record GeolocationLookupV2ResponseSecurity : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Aggregate risk score from 0 to 100.
    /// </summary>
    [JsonPropertyName("threat_score")]
    public required double ThreatScore { get; set; }

    /// <summary>
    /// true if the IP matches a Tor exit node.
    /// </summary>
    [JsonPropertyName("is_tor")]
    public required bool IsTor { get; set; }

    /// <summary>
    /// true if the IP is associated with a proxy service.
    /// </summary>
    [JsonPropertyName("is_proxy")]
    public required bool IsProxy { get; set; }

    /// <summary>
    /// Detected proxy provider names.
    /// </summary>
    [JsonPropertyName("proxy_provider_names")]
    public IEnumerable<string>? ProxyProviderNames { get; set; }

    /// <summary>
    /// Proxy detection confidence from 0 to 100.
    /// </summary>
    [JsonPropertyName("proxy_confidence_score")]
    public required double ProxyConfidenceScore { get; set; }

    /// <summary>
    /// Last observed proxy activity date in YYYY-MM-DD.
    /// </summary>
    [JsonPropertyName("proxy_last_seen")]
    public string? ProxyLastSeen { get; set; }

    /// <summary>
    /// true if the IP is linked to a residential proxy network.
    /// </summary>
    [JsonPropertyName("is_residential_proxy")]
    public required bool IsResidentialProxy { get; set; }

    /// <summary>
    /// true if the IP is associated with a VPN service.
    /// </summary>
    [JsonPropertyName("is_vpn")]
    public required bool IsVpn { get; set; }

    /// <summary>
    /// Detected VPN provider names.
    /// </summary>
    [JsonPropertyName("vpn_provider_names")]
    public IEnumerable<string>? VpnProviderNames { get; set; }

    /// <summary>
    /// VPN detection confidence from 0 to 100.
    /// </summary>
    [JsonPropertyName("vpn_confidence_score")]
    public required double VpnConfidenceScore { get; set; }

    /// <summary>
    /// Last observed VPN activity date in YYYY-MM-DD.
    /// </summary>
    [JsonPropertyName("vpn_last_seen")]
    public string? VpnLastSeen { get; set; }

    /// <summary>
    /// true if the IP is associated with a relay network.
    /// </summary>
    [JsonPropertyName("is_relay")]
    public required bool IsRelay { get; set; }

    /// <summary>
    /// Relay provider name.
    /// </summary>
    [JsonPropertyName("relay_provider_name")]
    public string? RelayProviderName { get; set; }

    /// <summary>
    /// true if any anonymity signal is present.
    /// </summary>
    [JsonPropertyName("is_anonymous")]
    public required bool IsAnonymous { get; set; }

    /// <summary>
    /// true if the IP is flagged for known attacker behavior.
    /// </summary>
    [JsonPropertyName("is_known_attacker")]
    public required bool IsKnownAttacker { get; set; }

    /// <summary>
    /// true if the IP is associated with bot activity.
    /// </summary>
    [JsonPropertyName("is_bot")]
    public required bool IsBot { get; set; }

    /// <summary>
    /// true if the IP is associated with spam activity.
    /// </summary>
    [JsonPropertyName("is_spam")]
    public required bool IsSpam { get; set; }

    /// <summary>
    /// true if the IP belongs to a cloud provider range.
    /// </summary>
    [JsonPropertyName("is_cloud_provider")]
    public required bool IsCloudProvider { get; set; }

    /// <summary>
    /// Cloud provider name.
    /// </summary>
    [JsonPropertyName("cloud_provider_name")]
    public string? CloudProviderName { get; set; }

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

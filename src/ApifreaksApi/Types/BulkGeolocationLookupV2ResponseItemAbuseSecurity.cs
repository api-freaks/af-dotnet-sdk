using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Threat intelligence and security information for the IP.
/// </summary>
[Serializable]
public record BulkGeolocationLookupV2ResponseItemAbuseSecurity : IJsonOnDeserialized
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
    /// Number of days in the last 30 days on which the IP was seen acting as a proxy. `0` when no proxy activity was observed.
    /// </summary>
    [JsonPropertyName("proxy_days_seen_30d")]
    public int? ProxyDaysSeen30D { get; set; }

    /// <summary>
    /// Number of days in the last 7 days on which the IP was seen acting as a proxy. `0` when no proxy activity was observed.
    /// </summary>
    [JsonPropertyName("proxy_days_seen_7d")]
    public int? ProxyDaysSeen7D { get; set; }

    /// <summary>
    /// Number of distinct proxy providers that offered the IP in the last 30 days. `0` when no proxy activity was observed.
    /// </summary>
    [JsonPropertyName("proxy_provider_count_30d")]
    public int? ProxyProviderCount30D { get; set; }

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

    /// <summary>
    /// Bot detection confidence from 0 to 100. 0 unless is_bot is true.
    /// </summary>
    [JsonPropertyName("bot_confidence_score")]
    public double? BotConfidenceScore { get; set; }

    /// <summary>
    /// Last observed bot activity date in YYYY-MM-DD, when available.
    /// </summary>
    [JsonPropertyName("bot_last_seen")]
    public string? BotLastSeen { get; set; }

    /// <summary>
    /// Organization running the bot, when known (mostly declared bots).
    /// </summary>
    [JsonPropertyName("bot_operator_name")]
    public string? BotOperatorName { get; set; }

    /// <summary>
    /// Kind of bot activity, when known. Declared bots (is_known_good_bot true): search_engine, ai_crawler, ai_assistant, seo_crawler, site_monitor, link_preview, feed_fetcher, archiver, ad_verification, scanner. Undeclared bots (is_known_good_bot false): scanner, scraper, exploit, credential_stuffing, brute_force, worm. New values can be added over time, so treat it as a plain string.
    /// </summary>
    [JsonPropertyName("bot_type")]
    public string? BotType { get; set; }

    /// <summary>
    /// Corporate gateway provider name, when known.
    /// </summary>
    [JsonPropertyName("corporate_gateway_provider_name")]
    public string? CorporateGatewayProviderName { get; set; }

    /// <summary>
    /// Kind of corporate gateway, when known. Known values: secure_web_gateway, browser_isolation.
    /// </summary>
    [JsonPropertyName("corporate_gateway_type")]
    public string? CorporateGatewayType { get; set; }

    /// <summary>
    /// true if the IP is an outbound address of a corporate security gateway (SWG, SSE, or SASE).
    /// </summary>
    [JsonPropertyName("is_corporate_gateway")]
    public bool? IsCorporateGateway { get; set; }

    /// <summary>
    /// true if the bot is a declared bot with a verifiable operator (e.g. a search engine crawler or uptime monitor).
    /// </summary>
    [JsonPropertyName("is_known_good_bot")]
    public bool? IsKnownGoodBot { get; set; }

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

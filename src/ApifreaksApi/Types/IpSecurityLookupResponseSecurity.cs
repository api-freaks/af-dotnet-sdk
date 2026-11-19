using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record IpSecurityLookupResponseSecurity : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("threat_score")]
    public double? ThreatScore { get; set; }

    [JsonPropertyName("is_tor")]
    public bool? IsTor { get; set; }

    [JsonPropertyName("is_proxy")]
    public bool? IsProxy { get; set; }

    [JsonPropertyName("proxy_provider_names")]
    public IEnumerable<string>? ProxyProviderNames { get; set; }

    [JsonPropertyName("proxy_confidence_score")]
    public double? ProxyConfidenceScore { get; set; }

    [JsonPropertyName("proxy_last_seen")]
    public string? ProxyLastSeen { get; set; }

    [JsonPropertyName("is_residential_proxy")]
    public bool? IsResidentialProxy { get; set; }

    [JsonPropertyName("is_vpn")]
    public bool? IsVpn { get; set; }

    [JsonPropertyName("vpn_provider_names")]
    public IEnumerable<string>? VpnProviderNames { get; set; }

    [JsonPropertyName("vpn_confidence_score")]
    public double? VpnConfidenceScore { get; set; }

    [JsonPropertyName("vpn_last_seen")]
    public string? VpnLastSeen { get; set; }

    [JsonPropertyName("is_relay")]
    public bool? IsRelay { get; set; }

    [JsonPropertyName("relay_provider_name")]
    public string? RelayProviderName { get; set; }

    [JsonPropertyName("is_anonymous")]
    public bool? IsAnonymous { get; set; }

    [JsonPropertyName("is_known_attacker")]
    public bool? IsKnownAttacker { get; set; }

    [JsonPropertyName("is_bot")]
    public bool? IsBot { get; set; }

    [JsonPropertyName("is_spam")]
    public bool? IsSpam { get; set; }

    [JsonPropertyName("is_cloud_provider")]
    public bool? IsCloudProvider { get; set; }

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

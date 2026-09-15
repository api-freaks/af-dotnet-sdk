using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Threat intelligence details for the indicator of compromise (IOC).
/// </summary>
[Serializable]
public record DomainReputationResponseIntelligence : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Type of the indicator of compromise (e.g. domain).
    /// </summary>
    [JsonPropertyName("ioc_type")]
    public required string IocType { get; set; }

    /// <summary>
    /// Value of the indicator of compromise.
    /// </summary>
    [JsonPropertyName("ioc_value")]
    public required string IocValue { get; set; }

    /// <summary>
    /// Other IOCs related to this domain.
    /// </summary>
    [JsonPropertyName("related_iocs")]
    public IEnumerable<DomainReputationResponseIntelligenceRelatedIocsItem> RelatedIocs { get; set; } =
        new List<DomainReputationResponseIntelligenceRelatedIocsItem>();

    /// <summary>
    /// Tags associated with this IOC from threat feeds.
    /// </summary>
    [JsonPropertyName("feed_tags")]
    public IEnumerable<string> FeedTags { get; set; } = new List<string>();

    /// <summary>
    /// STIX 2.1 pattern representation of the IOC, ready to wrap into an Indicator object.
    /// </summary>
    [JsonPropertyName("stix_pattern")]
    public required string StixPattern { get; set; }

    /// <summary>
    /// Recommended action based on the assessment.
    /// </summary>
    [JsonPropertyName("recommended_action")]
    public required DomainReputationResponseIntelligenceRecommendedAction RecommendedAction { get; set; }

    /// <summary>
    /// First time this IOC was observed (YYYY-MM-DDTHH:mm:ssZ). null when never observed on a feed.
    /// </summary>
    [JsonPropertyName("first_seen")]
    public string? FirstSeen { get; set; }

    /// <summary>
    /// Last time this IOC was observed (YYYY-MM-DDTHH:mm:ssZ). null when never observed on a feed.
    /// </summary>
    [JsonPropertyName("last_seen")]
    public string? LastSeen { get; set; }

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

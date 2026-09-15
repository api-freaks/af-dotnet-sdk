using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Overall risk assessment for the domain.
/// </summary>
[Serializable]
public record DomainReputationResponseRiskCategory : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Final verdict of the risk assessment.
    /// </summary>
    [JsonPropertyName("verdict")]
    public required DomainReputationResponseRiskCategoryVerdict Verdict { get; set; }

    /// <summary>
    /// Confidence score for the verdict (0-1).
    /// </summary>
    [JsonPropertyName("confidence")]
    public required float Confidence { get; set; }

    /// <summary>
    /// Main threat type identified (e.g. phishing). null when no threat was identified.
    /// </summary>
    [JsonPropertyName("primary_threat")]
    public string? PrimaryThreat { get; set; }

    /// <summary>
    /// Severity level of the risk.
    /// </summary>
    [JsonPropertyName("severity")]
    public required DomainReputationResponseRiskCategorySeverity Severity { get; set; }

    /// <summary>
    /// List of threat types associated with the domain.
    /// </summary>
    [JsonPropertyName("threat_types")]
    public IEnumerable<string> ThreatTypes { get; set; } = new List<string>();

    /// <summary>
    /// Threat intelligence sources that flagged the domain. Empty when nothing flagged it.
    /// </summary>
    [JsonPropertyName("sources")]
    public IEnumerable<DomainReputationResponseRiskCategorySourcesItem> Sources { get; set; } =
        new List<DomainReputationResponseRiskCategorySourcesItem>();

    /// <summary>
    /// Related pivots (nameserver, email, etc.) linked to known threats.
    /// </summary>
    [JsonPropertyName("pivot_matches")]
    public IEnumerable<DomainReputationResponseRiskCategoryPivotMatchesItem> PivotMatches { get; set; } =
        new List<DomainReputationResponseRiskCategoryPivotMatchesItem>();

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

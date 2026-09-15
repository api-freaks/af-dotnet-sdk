using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Full domain reputation assessment response.
/// </summary>
[Serializable]
public record DomainReputationResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Input object containing the analyzed domain.
    /// </summary>
    [JsonPropertyName("input")]
    public required DomainReputationResponseInput Input { get; set; }

    /// <summary>
    /// Timestamp when the assessment was performed (YYYY-MM-DDTHH:mm:ssZ).
    /// </summary>
    [JsonPropertyName("assessed_at")]
    public required string AssessedAt { get; set; }

    /// <summary>
    /// API / response schema version.
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; set; }

    /// <summary>
    /// Time taken to process the request, in milliseconds.
    /// </summary>
    [JsonPropertyName("processing_time_ms")]
    public required int ProcessingTimeMs { get; set; }

    /// <summary>
    /// Overall risk assessment for the domain.
    /// </summary>
    [JsonPropertyName("risk_category")]
    public required DomainReputationResponseRiskCategory RiskCategory { get; set; }

    /// <summary>
    /// Domain Generation Algorithm (DGA) detection results.
    /// </summary>
    [JsonPropertyName("dga_score")]
    public required DomainReputationResponseDgaScore DgaScore { get; set; }

    /// <summary>
    /// Trust scoring and supporting signals for the domain.
    /// </summary>
    [JsonPropertyName("trust_signals")]
    public required DomainReputationResponseTrustSignals TrustSignals { get; set; }

    /// <summary>
    /// Assessment of the domain's ability to send and receive email reliably.
    /// </summary>
    [JsonPropertyName("email_deliverability")]
    public required DomainReputationResponseEmailDeliverability EmailDeliverability { get; set; }

    /// <summary>
    /// Threat intelligence details for the indicator of compromise (IOC).
    /// </summary>
    [JsonPropertyName("intelligence")]
    public required DomainReputationResponseIntelligence Intelligence { get; set; }

    /// <summary>
    /// Summary of reasons behind the risk assessment.
    /// </summary>
    [JsonPropertyName("evidence_summary")]
    public required DomainReputationResponseEvidenceSummary EvidenceSummary { get; set; }

    /// <summary>
    /// List of errors encountered during processing, if any (e.g. "WHOIS lookup failed"). An empty array means every signal resolved.
    /// </summary>
    [JsonPropertyName("errors")]
    public IEnumerable<string> Errors { get; set; } = new List<string>();

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

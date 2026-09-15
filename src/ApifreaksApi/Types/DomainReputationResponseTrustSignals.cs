using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Trust scoring and supporting signals for the domain.
/// </summary>
[Serializable]
public record DomainReputationResponseTrustSignals : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Overall trust score (0-100).
    /// </summary>
    [JsonPropertyName("trust_score")]
    public required int TrustScore { get; set; }

    /// <summary>
    /// Trust score band / category (e.g. low, medium, high).
    /// </summary>
    [JsonPropertyName("trust_band")]
    public required string TrustBand { get; set; }

    /// <summary>
    /// Signals contributing to the trust score.
    /// </summary>
    [JsonPropertyName("signals")]
    public required DomainReputationResponseTrustSignalsSignals Signals { get; set; }

    /// <summary>
    /// Individual trust / risk indicators for the domain.
    /// </summary>
    [JsonPropertyName("indicators")]
    public required DomainReputationResponseTrustSignalsIndicators Indicators { get; set; }

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

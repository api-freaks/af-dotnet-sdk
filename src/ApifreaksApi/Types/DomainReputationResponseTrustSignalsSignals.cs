using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Signals contributing to the trust score.
/// </summary>
[Serializable]
public record DomainReputationResponseTrustSignalsSignals : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Signals that positively affect the trust score.
    /// </summary>
    [JsonPropertyName("positive")]
    public IEnumerable<DomainReputationResponseTrustSignalsSignalsPositiveItem> Positive { get; set; } =
        new List<DomainReputationResponseTrustSignalsSignalsPositiveItem>();

    /// <summary>
    /// Signals that negatively affect the trust score.
    /// </summary>
    [JsonPropertyName("negative")]
    public IEnumerable<DomainReputationResponseTrustSignalsSignalsNegativeItem> Negative { get; set; } =
        new List<DomainReputationResponseTrustSignalsSignalsNegativeItem>();

    /// <summary>
    /// Signals that are neutral to the trust score.
    /// </summary>
    [JsonPropertyName("neutral")]
    public IEnumerable<DomainReputationResponseTrustSignalsSignalsNeutralItem> Neutral { get; set; } =
        new List<DomainReputationResponseTrustSignalsSignalsNeutralItem>();

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

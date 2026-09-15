using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// A threat intelligence source that flagged the domain.
/// </summary>
[Serializable]
public record DomainReputationResponseRiskCategorySourcesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Name of the threat intelligence source (e.g. Spamhaus).
    /// </summary>
    [JsonPropertyName("source")]
    public required string Source { get; set; }

    /// <summary>
    /// Indicator matched by this source.
    /// </summary>
    [JsonPropertyName("indicator")]
    public required string Indicator { get; set; }

    /// <summary>
    /// Threat type reported by this source.
    /// </summary>
    [JsonPropertyName("threat_type")]
    public required string ThreatType { get; set; }

    /// <summary>
    /// Confidence score from this source (0-1).
    /// </summary>
    [JsonPropertyName("confidence")]
    public required float Confidence { get; set; }

    /// <summary>
    /// First time this indicator was seen by the source (YYYY-MM-DDTHH:mm:ssZ).
    /// </summary>
    [JsonPropertyName("first_seen")]
    public required string FirstSeen { get; set; }

    /// <summary>
    /// Last time this indicator was seen by the source (YYYY-MM-DDTHH:mm:ssZ).
    /// </summary>
    [JsonPropertyName("last_seen")]
    public required string LastSeen { get; set; }

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

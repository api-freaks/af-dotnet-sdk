using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Domain Generation Algorithm (DGA) detection results.
/// </summary>
[Serializable]
public record DomainReputationResponseDgaScore : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// DGA likelihood score (0-1).
    /// </summary>
    [JsonPropertyName("score")]
    public required float Score { get; set; }

    /// <summary>
    /// Indicates whether the domain is likely DGA-generated.
    /// </summary>
    [JsonPropertyName("is_dga")]
    public required bool IsDga { get; set; }

    /// <summary>
    /// Model used to compute the DGA score.
    /// </summary>
    [JsonPropertyName("model")]
    public required string Model { get; set; }

    /// <summary>
    /// Underlying lexical / statistical features used in DGA detection.
    /// </summary>
    [JsonPropertyName("features")]
    public required DomainReputationResponseDgaScoreFeatures Features { get; set; }

    /// <summary>
    /// Human-readable interpretation of the DGA score.
    /// </summary>
    [JsonPropertyName("interpretation")]
    public required string Interpretation { get; set; }

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

using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// A related pivot linked to known threats.
/// </summary>
[Serializable]
public record DomainReputationResponseRiskCategoryPivotMatchesItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Pivot value (e.g. a nameserver or email address).
    /// </summary>
    [JsonPropertyName("pivot")]
    public required string Pivot { get; set; }

    /// <summary>
    /// Type of pivot.
    /// </summary>
    [JsonPropertyName("pivot_type")]
    public required string PivotType { get; set; }

    /// <summary>
    /// Total number of threats related to this pivot.
    /// </summary>
    [JsonPropertyName("total_related_threats")]
    public required int TotalRelatedThreats { get; set; }

    /// <summary>
    /// Confidence score for the pivot match (0-1).
    /// </summary>
    [JsonPropertyName("confidence")]
    public required float Confidence { get; set; }

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

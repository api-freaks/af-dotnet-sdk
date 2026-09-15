using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// A single trust signal contributing to the trust score.
/// </summary>
[Serializable]
public record DomainReputationResponseTrustSignalsSignalsPositiveItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Signal code identifier (e.g. valid_ssl, dmarc_missing).
    /// </summary>
    [JsonPropertyName("code")]
    public required string Code { get; set; }

    /// <summary>
    /// Weight assigned to the signal.
    /// </summary>
    [JsonPropertyName("weight")]
    public required int Weight { get; set; }

    /// <summary>
    /// Polarity of the signal.
    /// </summary>
    [JsonPropertyName("polarity")]
    public required DomainReputationResponseTrustSignalsSignalsPositiveItemPolarity Polarity { get; set; }

    /// <summary>
    /// Category the signal belongs to (e.g. ssl_certificate).
    /// </summary>
    [JsonPropertyName("category")]
    public required string Category { get; set; }

    /// <summary>
    /// Evidence supporting the signal.
    /// </summary>
    [JsonPropertyName("evidence")]
    public required string Evidence { get; set; }

    /// <summary>
    /// Confidence score for the signal (0-1).
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

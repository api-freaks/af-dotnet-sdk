using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// DomainKeys Identified Mail configuration.
/// </summary>
[Serializable]
public record DomainReputationResponseEmailDeliverabilityAuthenticationDkim : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates whether a DKIM record was found for any probed selector.
    /// </summary>
    [JsonPropertyName("found")]
    public required bool Found { get; set; }

    /// <summary>
    /// List of DKIM selectors for which a record was found.
    /// </summary>
    [JsonPropertyName("selectors_found")]
    public IEnumerable<string> SelectorsFound { get; set; } = new List<string>();

    /// <summary>
    /// Email service providers inferred from the matched DKIM selectors.
    /// </summary>
    [JsonPropertyName("providers_detected")]
    public IEnumerable<string> ProvidersDetected { get; set; } = new List<string>();

    /// <summary>
    /// Clarifying note about the limitations of DKIM selector probing.
    /// </summary>
    [JsonPropertyName("note")]
    public required string Note { get; set; }

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

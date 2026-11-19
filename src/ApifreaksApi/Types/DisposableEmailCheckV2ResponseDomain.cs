using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Domain-level disposable/spam/free classification for the email address.
/// </summary>
[Serializable]
public record DisposableEmailCheckV2ResponseDomain : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Extracted domain component from the email address.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Domain validation status confirming DNS resolution capability.
    /// </summary>
    [JsonPropertyName("validDomain")]
    public required bool ValidDomain { get; set; }

    /// <summary>
    /// Classification flag identifying domains from temporary/throwaway email service providers. Omitted when validSyntax is false or the domain could not be resolved.
    /// </summary>
    [JsonPropertyName("disposable")]
    public bool? Disposable { get; set; }

    /// <summary>
    /// Classification indicating free or consumer-grade email service providers. Omitted when validSyntax is false or the domain could not be resolved.
    /// </summary>
    [JsonPropertyName("free")]
    public bool? Free { get; set; }

    /// <summary>
    /// Reputation indicator flagging domains on spam databases. Omitted when validSyntax is false or the domain could not be resolved.
    /// </summary>
    [JsonPropertyName("spam")]
    public bool? Spam { get; set; }

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

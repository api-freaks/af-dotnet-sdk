using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record CommodityIntradayRatesV2ResponseUnresolvedValue : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Detail message explaining how this symbol was handled.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// The supported symbol the request was answered with.
    /// </summary>
    [JsonPropertyName("resolvedTo")]
    public string? ResolvedTo { get; set; }

    /// <summary>
    /// Optional list of supported symbols that closely match the unresolved symbol.
    /// </summary>
    [JsonPropertyName("suggestions")]
    public IEnumerable<string>? Suggestions { get; set; }

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

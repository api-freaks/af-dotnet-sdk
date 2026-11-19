using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// A selector/value pair used by fill, select, and clickButtonByValue instructions.
/// </summary>
[Serializable]
public record WebScrapeRequestBodyBlockUrlInstructionsItemClickButtonByValue : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// CSS or XPath selector identifying the target element.
    /// </summary>
    [JsonPropertyName("place")]
    public required string Place { get; set; }

    /// <summary>
    /// Value to fill, select, or match against.
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; set; }

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

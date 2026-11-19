using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// A single static-HTML scraping step. Exactly one of these action fields is set per instruction; every other field is absent.
/// </summary>
[Serializable]
public record WebScrapeRequestBodyOneInstructionsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Form selector and field values to submit via postForm or getForm.
    /// </summary>
    [JsonPropertyName("postForm")]
    public WebScrapeRequestBodyOneInstructionsItemPostForm? PostForm { get; set; }

    /// <summary>
    /// Form selector and field values to submit via postForm or getForm.
    /// </summary>
    [JsonPropertyName("getForm")]
    public WebScrapeRequestBodyOneInstructionsItemGetForm? GetForm { get; set; }

    /// <summary>
    /// Maps arbitrary output field names to CSS or XPath selectors. Each key becomes a field in the response's extractedData object.
    /// </summary>
    [JsonPropertyName("extract")]
    public Dictionary<string, string>? Extract { get; set; }

    /// <summary>
    /// Get page action: retrieves the full page content. Optionally provide a URL or selector to target a specific page.
    /// </summary>
    [JsonPropertyName("getPage")]
    public string? GetPage { get; set; }

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

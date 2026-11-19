using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record WebScrapeRequestBodyBlockUrl : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// List of script or URL patterns to block during network requests.
    /// </summary>
    [JsonPropertyName("blockUrl")]
    public IEnumerable<string>? BlockUrl { get; set; }

    /// <summary>
    /// List of cookies to be set in the browser session.
    /// </summary>
    [JsonPropertyName("cookies")]
    public IEnumerable<WebScrapeRequestBodyBlockUrlCookiesItem>? Cookies { get; set; }

    /// <summary>
    /// An ordered list of step-by-step scraping instructions to be executed in the browser. Each item is one Instruction object, with exactly one action field set.
    /// </summary>
    [JsonPropertyName("instructions")]
    public IEnumerable<WebScrapeRequestBodyBlockUrlInstructionsItem> Instructions { get; set; } =
        new List<WebScrapeRequestBodyBlockUrlInstructionsItem>();

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

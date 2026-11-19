using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// A single browser scraping step. Exactly one of these action fields is set per instruction; every other field is absent.
/// </summary>
[Serializable]
public record WebScrapeRequestBodyBlockUrlInstructionsItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// A selector/value pair used by fill, select, and clickButtonByValue instructions.
    /// </summary>
    [JsonPropertyName("fill")]
    public WebScrapeRequestBodyBlockUrlInstructionsItemFill? Fill { get; set; }

    /// <summary>
    /// Click action: CSS selector or XPath identifying the element to click.
    /// </summary>
    [JsonPropertyName("click")]
    public string? Click { get; set; }

    /// <summary>
    /// Click if exists action: CSS selector or XPath identifying the element to click, only if it appears on the page within a short timeout.
    /// </summary>
    [JsonPropertyName("clickIfExist")]
    public string? ClickIfExist { get; set; }

    /// <summary>
    /// Enter key action: CSS selector or XPath identifying the element to send an Enter keystroke to.
    /// </summary>
    [JsonPropertyName("enter")]
    public string? Enter { get; set; }

    /// <summary>
    /// New tab action: set to true to switch focus to a newly opened browser tab.
    /// </summary>
    [JsonPropertyName("newTab")]
    public bool? NewTab { get; set; }

    /// <summary>
    /// Move to relative tab action: relative tab index to move to (e.g. 1 for the next tab, -1 for the previous tab).
    /// </summary>
    [JsonPropertyName("moveToRelativeTab")]
    public int? MoveToRelativeTab { get; set; }

    /// <summary>
    /// Wait action: pauses execution for this many milliseconds.
    /// </summary>
    [JsonPropertyName("wait")]
    public int? Wait { get; set; }

    /// <summary>
    /// Wait for element action: CSS selector or XPath identifying the element to wait for before continuing.
    /// </summary>
    [JsonPropertyName("waitFor")]
    public string? WaitFor { get; set; }

    /// <summary>
    /// A selector/value pair used by fill, select, and clickButtonByValue instructions.
    /// </summary>
    [JsonPropertyName("select")]
    public WebScrapeRequestBodyBlockUrlInstructionsItemSelect? Select { get; set; }

    /// <summary>
    /// Execute JavaScript action: JavaScript code to execute inside the page context.
    /// </summary>
    [JsonPropertyName("jsExe")]
    public string? JsExe { get; set; }

    /// <summary>
    /// Conditional check action: list of conditional steps, each supporting if-&lt;method&gt; and else-&lt;method&gt; keys with conditions, executed based on element state.
    /// </summary>
    [JsonPropertyName("conditionalCheck")]
    public IEnumerable<Dictionary<string, object?>>? ConditionalCheck { get; set; }

    /// <summary>
    /// A selector/value pair used by fill, select, and clickButtonByValue instructions.
    /// </summary>
    [JsonPropertyName("clickButtonByValue")]
    public WebScrapeRequestBodyBlockUrlInstructionsItemClickButtonByValue? ClickButtonByValue { get; set; }

    /// <summary>
    /// Image captcha solver action: instructions for solving image-based captchas using a selected model.
    /// </summary>
    [JsonPropertyName("generalImageCaptcha")]
    public IEnumerable<WebScrapeRequestBodyBlockUrlInstructionsItemGeneralImageCaptchaItem>? GeneralImageCaptcha { get; set; }

    /// <summary>
    /// Block element action: list of CSS selectors or XPaths for elements to block or hide on the page.
    /// </summary>
    [JsonPropertyName("blockElement")]
    public IEnumerable<string>? BlockElement { get; set; }

    /// <summary>
    /// Maps arbitrary output field names to CSS or XPath selectors. Each key becomes a field in the response's extractedData object.
    /// </summary>
    [JsonPropertyName("extract")]
    public Dictionary<string, string>? Extract { get; set; }

    /// <summary>
    /// Fill image captcha action: captures and fills image-based captcha values automatically.
    /// </summary>
    [JsonPropertyName("fillImageCaptcha")]
    public IEnumerable<WebScrapeRequestBodyBlockUrlInstructionsItemFillImageCaptchaItem>? FillImageCaptcha { get; set; }

    /// <summary>
    /// Switch to iframe action: switches the browser context into an iframe identified by name or ID.
    /// </summary>
    [JsonPropertyName("switchToIframe")]
    public string? SwitchToIframe { get; set; }

    /// <summary>
    /// Switch to parent frame action: returns the browser context from an iframe back to its parent frame.
    /// </summary>
    [JsonPropertyName("switchToParentFrame")]
    public bool? SwitchToParentFrame { get; set; }

    /// <summary>
    /// Selectors for locating and solving a single audio CAPTCHA challenge.
    /// </summary>
    [JsonPropertyName("resolveAudioCaptcha")]
    public WebScrapeRequestBodyBlockUrlInstructionsItemResolveAudioCaptcha? ResolveAudioCaptcha { get; set; }

    /// <summary>
    /// Screenshot action: captures a screenshot of the current page state. Can be a boolean-like value or a selector.
    /// </summary>
    [JsonPropertyName("screenshot")]
    public string? Screenshot { get; set; }

    /// <summary>
    /// Save image action: saves an image from the page by CSS selector or element ID.
    /// </summary>
    [JsonPropertyName("saveimage")]
    public string? Saveimage { get; set; }

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

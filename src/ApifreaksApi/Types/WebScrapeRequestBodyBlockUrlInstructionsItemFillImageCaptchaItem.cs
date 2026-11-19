using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Instructions for locating and solving a single image CAPTCHA challenge.
/// </summary>
[Serializable]
public record WebScrapeRequestBodyBlockUrlInstructionsItemFillImageCaptchaItem : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Selector for the CAPTCHA image element.
    /// </summary>
    [JsonPropertyName("imagePath")]
    public string? ImagePath { get; set; }

    /// <summary>
    /// Selector for the field where the CAPTCHA text is entered.
    /// </summary>
    [JsonPropertyName("textField")]
    public string? TextField { get; set; }

    /// <summary>
    /// Selector to refresh or update the CAPTCHA image.
    /// </summary>
    [JsonPropertyName("imageUpdatePath")]
    public string? ImageUpdatePath { get; set; }

    /// <summary>
    /// Selector indicating a CAPTCHA failure so the solver can retry.
    /// </summary>
    [JsonPropertyName("captchaFailedPath")]
    public string? CaptchaFailedPath { get; set; }

    /// <summary>
    /// Model used for CAPTCHA solving.
    /// </summary>
    [JsonPropertyName("model")]
    public WebScrapeRequestBodyBlockUrlInstructionsItemFillImageCaptchaItemModel? Model { get; set; }

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

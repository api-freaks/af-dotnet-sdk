using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Selectors for locating and solving a single audio CAPTCHA challenge.
/// </summary>
[Serializable]
public record WebScrapeRequestBodyBlockUrlInstructionsItemResolveAudioCaptcha : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Selector for the audio CAPTCHA element.
    /// </summary>
    [JsonPropertyName("audioPath")]
    public string? AudioPath { get; set; }

    /// <summary>
    /// Selector for the field where the resolved audio CAPTCHA text is entered.
    /// </summary>
    [JsonPropertyName("textField")]
    public string? TextField { get; set; }

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

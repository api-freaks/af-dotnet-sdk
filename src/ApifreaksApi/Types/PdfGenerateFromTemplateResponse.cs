using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// Result of a PDF generation request, containing the hosted URL of the generated PDF.
/// </summary>
[Serializable]
public record PdfGenerateFromTemplateResponse : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The template that was rendered.
    /// </summary>
    [JsonPropertyName("template_id")]
    public required string TemplateId { get; set; }

    /// <summary>
    /// Hosted URL of the generated PDF.
    /// </summary>
    [JsonPropertyName("pdf_url")]
    public required string PdfUrl { get; set; }

    /// <summary>
    /// When the PDF was generated (ISO 8601).
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// When the hosted PDF expires (ISO 8601).
    /// </summary>
    [JsonPropertyName("expiration_time")]
    public required DateTime ExpirationTime { get; set; }

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

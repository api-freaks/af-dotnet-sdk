using ApifreaksApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

/// <summary>
/// PDF output options. Applies when file_type is PDF.
/// </summary>
[Serializable]
public record BulkScreenshotCaptureRequestUrlsItemPdfOptions : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Paper size of the PDF. Applies when file_type is PDF. Without it, width and height are used if set, otherwise the page renders as one long page: A0, A1, A2, A3, A4, A5, A6, Letter, Legal, Tabloid, or Ledger.
    /// </summary>
    [JsonPropertyName("format")]
    public BulkScreenshotCaptureRequestUrlsItemPdfOptionsFormat? Format { get; set; }

    /// <summary>
    /// Renders the PDF in landscape orientation, swapping the width and height of the paper size. Applies when file_type is PDF.
    /// </summary>
    [JsonPropertyName("landscape")]
    public bool? Landscape { get; set; }

    /// <summary>
    /// Pages to keep in the PDF, as start-end, for example 1-3 or 5-5. Pages are rendered first and then trimmed. Has no effect on a single-page PDF. Applies when file_type is PDF.
    /// </summary>
    [JsonPropertyName("page_range")]
    public string? PageRange { get; set; }

    /// <summary>
    /// CSS media type used to render the PDF: print or screen.
    /// </summary>
    [JsonPropertyName("media")]
    public BulkScreenshotCaptureRequestUrlsItemPdfOptionsMedia? Media { get; set; }

    /// <summary>
    /// Includes background colors and images in the PDF. Applies when file_type is PDF.
    /// </summary>
    [JsonPropertyName("print_background")]
    public bool? PrintBackground { get; set; }

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

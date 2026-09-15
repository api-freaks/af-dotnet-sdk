using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record OcrPredictRequest
{
    /// <summary>
    /// Your API key
    /// </summary>
    [JsonIgnore]
    public required string ApiKey { get; set; }

    /// <summary>
    /// URL of the image or PDF (required if `file` not provided)
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// OCR model to use. `mini-ocr-v1` for CAPTCHA OCR, `ocr-v1` for general OCR
    /// </summary>
    [JsonPropertyName("model")]
    public required OcrPredictRequestModel Model { get; set; }

    /// <summary>
    /// Specify page range for multi-page PDFs (e.g., '1,3,5-10' or 'allpages'). **Note:** This parameter can only be used with .pdf file types.
    /// </summary>
    [JsonPropertyName("page_range")]
    public string? PageRange { get; set; }

    /// <summary>
    /// Define OCR zones using coordinates (top:left:height:width). Multiple zones can be defined using commas. Only available for model 'ocr-v1'. **Note:** This parameter cannot be used with .pdf and .zip file types as it can only be applied to single image queries.
    /// </summary>
    [JsonPropertyName("zone")]
    public string? Zone { get; set; }

    /// <summary>
    /// Set to 1 to split output text into individual lines (default: 0)
    /// </summary>
    [JsonPropertyName("new_line")]
    public int? NewLine { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

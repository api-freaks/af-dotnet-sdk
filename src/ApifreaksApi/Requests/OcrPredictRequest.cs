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
    /// OCR model to use. `mini-ocr-v1` for CAPTCHA OCR, `ocr-v1` for general OCR.
    /// </summary>
    [JsonIgnore]
    public required OcrPredictRequestModel Model { get; set; }

    /// <summary>
    /// URL of the image or PDF (required if `file` is not uploaded).
    /// </summary>
    [JsonIgnore]
    public string? Url { get; set; }

    /// <summary>
    /// Specify page range for multi-page PDFs (e.g., '1,3,5-10' or 'allpages'). **Note:** This parameter can only be used with .pdf file types.
    /// </summary>
    [JsonIgnore]
    public string? PageRange { get; set; }

    /// <summary>
    /// Define OCR zones using coordinates (top:left:height:width). Multiple zones can be defined using commas. Only available for model 'ocr-v1'. **Note:** This parameter cannot be used with .pdf and .zip file types as it can only be applied to single image queries.
    /// </summary>
    [JsonIgnore]
    public string? Zone { get; set; }

    /// <summary>
    /// Set to 1 to split output text into individual lines (default: 0). This changes the shape of `OCRText` (see the response).
    /// </summary>
    [JsonIgnore]
    public int? NewLine { get; set; }

    public FileParameter? File { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

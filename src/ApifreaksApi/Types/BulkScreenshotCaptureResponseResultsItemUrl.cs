using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkScreenshotCaptureResponseResultsItemUrl : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [JsonPropertyName("screenshot")]
    public required string Screenshot { get; set; }

    [JsonPropertyName("url")]
    public required string Url { get; set; }

    [JsonPropertyName("created_at")]
    public required string CreatedAt { get; set; }

    [JsonPropertyName("format")]
    public required string Format { get; set; }

    [JsonPropertyName("ttl")]
    public required string Ttl { get; set; }

    [JsonPropertyName("file_type")]
    public string? FileType { get; set; }

    [JsonPropertyName("extracted_html")]
    public string? ExtractedHtml { get; set; }

    [JsonPropertyName("omit_background")]
    public bool? OmitBackground { get; set; }

    [JsonPropertyName("destroy_screenshot")]
    public bool? DestroyScreenshot { get; set; }

    [JsonPropertyName("fail_on_error")]
    public bool? FailOnError { get; set; }

    [JsonPropertyName("longitude")]
    public string? Longitude { get; set; }

    [JsonPropertyName("latitude")]
    public string? Latitude { get; set; }

    [JsonPropertyName("proxy")]
    public string? Proxy { get; set; }

    [JsonPropertyName("no_cookie_banners")]
    public bool? NoCookieBanners { get; set; }

    [JsonPropertyName("block_ads")]
    public bool? BlockAds { get; set; }

    [JsonPropertyName("headers")]
    public string? Headers { get; set; }

    [JsonPropertyName("cookies")]
    public string? Cookies { get; set; }

    [JsonPropertyName("scroll_to_element")]
    public string? ScrollToElement { get; set; }

    [JsonPropertyName("selector")]
    public string? Selector { get; set; }

    [JsonPropertyName("blur_selector")]
    public string? BlurSelector { get; set; }

    [JsonPropertyName("remove_selector")]
    public string? RemoveSelector { get; set; }

    [JsonPropertyName("css")]
    public string? Css { get; set; }

    [JsonPropertyName("css_url")]
    public string? CssUrl { get; set; }

    [JsonPropertyName("js")]
    public string? Js { get; set; }

    [JsonPropertyName("js_url")]
    public string? JsUrl { get; set; }

    [JsonPropertyName("user_agent")]
    public string? UserAgent { get; set; }

    [JsonPropertyName("accept_languages")]
    public string? AcceptLanguages { get; set; }

    [JsonPropertyName("delay")]
    public double? Delay { get; set; }

    [JsonPropertyName("thumbnail_width")]
    public double? ThumbnailWidth { get; set; }

    [JsonPropertyName("output")]
    public string? Output { get; set; }

    [JsonPropertyName("fresh")]
    public bool? Fresh { get; set; }

    [JsonPropertyName("enable_caching")]
    public bool? EnableCaching { get; set; }

    [JsonPropertyName("lazy_load")]
    public bool? LazyLoad { get; set; }

    [JsonPropertyName("full_page")]
    public bool? FullPage { get; set; }

    [JsonPropertyName("retina")]
    public bool? Retina { get; set; }

    [JsonPropertyName("height")]
    public double? Height { get; set; }

    [JsonPropertyName("width")]
    public double? Width { get; set; }

    [JsonPropertyName("custom_html")]
    public string? CustomHtml { get; set; }

    [JsonPropertyName("block_chat_widgets")]
    public bool? BlockChatWidgets { get; set; }

    [JsonPropertyName("block_js")]
    public bool? BlockJs { get; set; }

    [JsonPropertyName("block_stylesheets")]
    public bool? BlockStylesheets { get; set; }

    [JsonPropertyName("block_images")]
    public bool? BlockImages { get; set; }

    [JsonPropertyName("block_media")]
    public bool? BlockMedia { get; set; }

    [JsonPropertyName("block_font")]
    public bool? BlockFont { get; set; }

    [JsonPropertyName("block_text_track")]
    public bool? BlockTextTrack { get; set; }

    [JsonPropertyName("block_xhr")]
    public bool? BlockXhr { get; set; }

    [JsonPropertyName("block_fetch")]
    public bool? BlockFetch { get; set; }

    [JsonPropertyName("block_event_source")]
    public bool? BlockEventSource { get; set; }

    [JsonPropertyName("block_web_socket")]
    public bool? BlockWebSocket { get; set; }

    [JsonPropertyName("block_manifest")]
    public bool? BlockManifest { get; set; }

    [JsonPropertyName("block_specific_requests")]
    public string? BlockSpecificRequests { get; set; }

    [JsonPropertyName("adjust_top")]
    public double? AdjustTop { get; set; }

    [JsonPropertyName("image_quality")]
    public double? ImageQuality { get; set; }

    [JsonPropertyName("extract_html")]
    public bool? ExtractHtml { get; set; }

    [JsonPropertyName("extract_text")]
    public bool? ExtractText { get; set; }

    [JsonPropertyName("dark_mode")]
    public bool? DarkMode { get; set; }

    [JsonPropertyName("block_tracking")]
    public bool? BlockTracking { get; set; }

    [JsonPropertyName("wait_for_event")]
    public string? WaitForEvent { get; set; }

    [JsonPropertyName("grayscale")]
    public double? Grayscale { get; set; }

    [JsonPropertyName("result_file_name")]
    public string? ResultFileName { get; set; }

    [JsonPropertyName("enable_incognito")]
    public bool? EnableIncognito { get; set; }

    [JsonPropertyName("timeout")]
    public double? Timeout { get; set; }

    [JsonPropertyName("scrolling_screenshot")]
    public bool? ScrollingScreenshot { get; set; }

    [JsonPropertyName("multiple_scrolling")]
    public bool? MultipleScrolling { get; set; }

    [JsonPropertyName("scroll_speed")]
    public string? ScrollSpeed { get; set; }

    [JsonPropertyName("duration")]
    public double? Duration { get; set; }

    [JsonPropertyName("scroll_back")]
    public bool? ScrollBack { get; set; }

    [JsonPropertyName("start_immediately")]
    public bool? StartImmediately { get; set; }

    [JsonPropertyName("clip")]
    public Dictionary<string, object?>? Clip { get; set; }

    [JsonPropertyName("sizes")]
    public IEnumerable<Dictionary<string, object?>>? Sizes { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

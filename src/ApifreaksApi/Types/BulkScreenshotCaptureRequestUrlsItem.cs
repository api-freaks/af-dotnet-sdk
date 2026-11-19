using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record BulkScreenshotCaptureRequestUrlsItem : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [JsonPropertyName("url")]
    public required string Url { get; set; }

    /// <summary>
    /// Sets the accepted languages for the HTTP request. This is sent as the Accept-Language header.
    /// </summary>
    [JsonPropertyName("accept_languages")]
    public string? AcceptLanguages { get; set; }

    /// <summary>
    /// Initial vertical scroll position in pixels before capture. Use to position mid-page content in viewport. Not supported for PDF.
    /// </summary>
    [JsonPropertyName("adjust_top")]
    public int? AdjustTop { get; set; }

    /// <summary>
    /// Blocks requests to known ad networks for cleaner, distraction-free screenshots.
    /// </summary>
    [JsonPropertyName("block_ads")]
    public bool? BlockAds { get; set; }

    /// <summary>
    /// Blocks live chat popups, support bubbles, and messaging interfaces.
    /// </summary>
    [JsonPropertyName("block_chat_widgets")]
    public bool? BlockChatWidgets { get; set; }

    /// <summary>
    /// Blocks EventSource (SSE) connections - prevents real-time data streams.
    /// </summary>
    [JsonPropertyName("block_event_source")]
    public bool? BlockEventSource { get; set; }

    /// <summary>
    /// Blocks all Fetch API requests - stops async data loading.
    /// </summary>
    [JsonPropertyName("block_fetch")]
    public bool? BlockFetch { get; set; }

    /// <summary>
    /// Blocks external font files - page falls back to system defaults. Supported: woff, woff2, ttf, otf, eot.
    /// </summary>
    [JsonPropertyName("block_font")]
    public bool? BlockFont { get; set; }

    /// <summary>
    /// Blocks all image resources (jpg, png, gif, webp, svg, etc.) for faster rendering.
    /// </summary>
    [JsonPropertyName("block_images")]
    public bool? BlockImages { get; set; }

    /// <summary>
    /// Disables all JavaScript execution. Renders a static version of the page. Speeds up capture but may break dynamic content.
    /// </summary>
    [JsonPropertyName("block_js")]
    public bool? BlockJs { get; set; }

    /// <summary>
    /// Blocks manifest files (.json, .webmanifest) - disables PWA-related functionality.
    /// </summary>
    [JsonPropertyName("block_manifest")]
    public bool? BlockManifest { get; set; }

    /// <summary>
    /// Blocks audio and video resources (mp3, mp4, webm, etc.) from loading.
    /// </summary>
    [JsonPropertyName("block_media")]
    public bool? BlockMedia { get; set; }

    /// <summary>
    /// Fine-grained blocking of specific URLs or patterns. Separate multiple rules by comma, space, or newline. Default: empty.
    /// </summary>
    [JsonPropertyName("block_specific_requests")]
    public string? BlockSpecificRequests { get; set; }

    /// <summary>
    /// Blocks all stylesheets - page renders as raw HTML without visual formatting.
    /// </summary>
    [JsonPropertyName("block_stylesheets")]
    public bool? BlockStylesheets { get; set; }

    /// <summary>
    /// Blocks subtitles and caption overlays from loading.
    /// </summary>
    [JsonPropertyName("block_text_track")]
    public bool? BlockTextTrack { get; set; }

    /// <summary>
    /// Blocks tracking scripts and analytics services for cleaner, privacy-oriented renders.
    /// </summary>
    [JsonPropertyName("block_tracking")]
    public bool? BlockTracking { get; set; }

    /// <summary>
    /// Blocks WebSocket connections - prevents real-time bidirectional communication.
    /// </summary>
    [JsonPropertyName("block_web_socket")]
    public bool? BlockWebSocket { get; set; }

    /// <summary>
    /// Blocks all XMLHttpRequest (AJAX) calls - prevents dynamic API-driven content.
    /// </summary>
    [JsonPropertyName("block_xhr")]
    public bool? BlockXhr { get; set; }

    /// <summary>
    /// CSS selectors to blur before capture. Masks sensitive data like emails, payments, or personal info. Multiple selectors supported. Default: empty.
    /// </summary>
    [JsonPropertyName("blur_selector")]
    public string? BlurSelector { get; set; }

    /// <summary>
    /// CSS selector of the message shown for a wrong answer. While it is visible, the solver tries again.
    /// </summary>
    [JsonPropertyName("captcha_error")]
    public string? CaptchaError { get; set; }

    /// <summary>
    /// CSS selector of the captcha picture. Required when solve_captcha is true.
    /// </summary>
    [JsonPropertyName("captcha_image")]
    public string? CaptchaImage { get; set; }

    /// <summary>
    /// CSS selector of the box the answer is typed into. Required when solve_captcha is true.
    /// </summary>
    [JsonPropertyName("captcha_input")]
    public string? CaptchaInput { get; set; }

    /// <summary>
    /// CSS selector of the control that loads a new captcha picture before the next try.
    /// </summary>
    [JsonPropertyName("captcha_refresh")]
    public string? CaptchaRefresh { get; set; }

    /// <summary>
    /// Number of guesses the solver makes, from 1 to 5.
    /// </summary>
    [JsonPropertyName("captcha_retries")]
    public int? CaptchaRetries { get; set; }

    /// <summary>
    /// CSS selector of the button to click after the answer is typed.
    /// </summary>
    [JsonPropertyName("captcha_submit")]
    public string? CaptchaSubmit { get; set; }

    /// <summary>
    /// Loads the page through a datacenter proxy. Adds 20 credits per request. Ignored when premium_proxy is true or a custom proxy is set.
    /// </summary>
    [JsonPropertyName("classic_proxy")]
    public bool? ClassicProxy { get; set; }

    /// <summary>
    /// Number of times to click the selector (when set via `selector_to_click`).
    /// </summary>
    [JsonPropertyName("click_recursion")]
    public int? ClickRecursion { get; set; }

    /// <summary>
    /// Height of the clip area in pixels. Default: null.
    /// </summary>
    [JsonPropertyName("clip[height]")]
    public int? ClipHeight { get; set; }

    /// <summary>
    /// Width of the clip area in pixels. Default: null.
    /// </summary>
    [JsonPropertyName("clip[width]")]
    public int? ClipWidth { get; set; }

    /// <summary>
    /// X coordinate (in pixels) for the top-left corner of the clip area. Default: null.
    /// </summary>
    [JsonPropertyName("clip[x]")]
    public int? ClipX { get; set; }

    /// <summary>
    /// Y coordinate (in pixels) for the top-left corner of the clip area. Default: null.
    /// </summary>
    [JsonPropertyName("clip[y]")]
    public int? ClipY { get; set; }

    /// <summary>
    /// Cookies to include in the request before rendering. Supports single or multiple cookies. Example: `cookie=value; otherCookie=otherValue;`.
    /// </summary>
    [JsonPropertyName("cookies")]
    public string? Cookies { get; set; }

    /// <summary>
    /// Two-letter country code, such as US or DE, for the exit address of classic_proxy or premium_proxy. Ignored when you send your own proxy. Any two-letter code is sent, including one that is not listed. Classic proxy countries: BG, GE, DE, HN, MD, UA, GB, US. Premium proxy countries: AF, AL, DZ, AO, AG, AR, AM, AW, AU, AT, AZ, BS, BH, BD, BB, BY, BE, BZ, BJ, BT, BO, BQ, BA, BW, BR, BN, BG, BF, BI, CV, KH, CM, CA, KY, CF, TD, CL, CN, CO, KM, CG, CR, CI, HR, CU, CW, CY, CZ, CD, DK, DJ, DM, DO, EC, EG, SV, GQ, EE, SZ, ET, FO, FJ, FI, FR, GF, PF, GA, GM, GE, DE, GH, GI, GR, GL, GD, GP, GU, GT, GG, GN, GW, GY, HT, HN, HK, HU, IS, IN, ID, IR, IQ, IE, IL, IT, JM, JP, JE, JO, KZ, KE, XK, KW, KG, LA, LV, LB, LS, LR, LY, LT, MO, MG, MW, MY, MV, ML, MT, MQ, MR, MU, YT, MX, MD, MN, ME, MA, MZ, MM, NA, NP, NL, NC, NZ, NI, NE, NG, MK, NO, OM, PK, PS, PA, PG, PY, PE, PH, PL, PT, PR, QA, RE, RO, RU, RW, KN, LC, VC, WS, SA, SN, RS, SC, SL, SG, SK, SI, SB, SO, ZA, KR, SS, ES, LK, SD, SR, SE, CH, SY, TW, TJ, TZ, TH, TL, TG, TO, TT, TN, TR, TM, UG, UA, AE, GB, US, UY, UZ, VE, VN, YE, ZM, ZW.
    /// </summary>
    [JsonPropertyName("country")]
    public string? Country { get; set; }

    /// <summary>
    /// Allows injecting custom CSS code into the page before rendering. Pass the CSS code directly as a string.
    /// </summary>
    [JsonPropertyName("css")]
    public string? Css { get; set; }

    /// <summary>
    /// Allows loading external CSS into the page. Provide a URL pointing to the CSS file.
    /// </summary>
    [JsonPropertyName("css_url")]
    public string? CssUrl { get; set; }

    /// <summary>
    /// Custom HTML to render instead of loading a URL. Overrides the url option. Use for capturing specific HTML structures or dynamic content.
    /// </summary>
    [JsonPropertyName("custom_html")]
    public string? CustomHtml { get; set; }

    /// <summary>
    /// When set to `true`, websites that support prefers-color-scheme: dark will render in dark mode.
    /// </summary>
    [JsonPropertyName("dark_mode")]
    public bool? DarkMode { get; set; }

    /// <summary>
    /// Wait period in milliseconds before capture. Allows animations, API responses, and dynamic elements to finish rendering.
    /// </summary>
    [JsonPropertyName("delay")]
    public int? Delay { get; set; }

    /// <summary>
    /// If `true`, screenshot/PDF is not stored on server and must be downloaded immediately.
    /// </summary>
    [JsonPropertyName("destroy_screenshot")]
    public bool? DestroyScreenshot { get; set; }

    /// <summary>
    /// Duration of scrolling action in seconds (0-60). Higher = longer video. Default: null (full page scroll).
    /// </summary>
    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    /// <summary>
    /// Stores the render in cache for reuse on subsequent identical requests.
    /// </summary>
    [JsonPropertyName("enable_caching")]
    public bool? EnableCaching { get; set; }

    /// <summary>
    /// Enables private/incognito browsing. Each render starts with a clean slate - no cookies, cache, or session data persisted.
    /// </summary>
    [JsonPropertyName("enable_incognito")]
    public bool? EnableIncognito { get; set; }

    /// <summary>
    /// Returns rendered HTML as a .html file (includes JS-executed DOM). Only available with output=json.
    /// </summary>
    [JsonPropertyName("extract_html")]
    public bool? ExtractHtml { get; set; }

    /// <summary>
    /// Extracts rendered page content as a structured .md (Markdown) file. Preserves headings, lists, links. Only with output=json.
    /// </summary>
    [JsonPropertyName("extract_markdown")]
    public bool? ExtractMarkdown { get; set; }

    /// <summary>
    /// Strips all HTML and returns visible text as a .txt file. Ideal for text analysis, indexing, or AI pipelines. Only with output=json.
    /// </summary>
    [JsonPropertyName("extract_text")]
    public bool? ExtractText { get; set; }

    /// <summary>
    /// If `true`, returns an error when the target page responds with 4xx or 5xx status.
    /// </summary>
    [JsonPropertyName("fail_on_error")]
    public bool? FailOnError { get; set; }

    /// <summary>
    /// Output format. PNG (lossless, transparency), JPEG (compressed, smaller size), WebP (modern, efficient), PDF (document). For scrolling captures: MP4, GIF, WebM. Scrolling capture formats: WEBM (web-optimized), MP4 (widely compatible, default), GIF (short loops).
    /// </summary>
    [JsonPropertyName("file_type")]
    public BulkScreenshotCaptureRequestUrlsItemFileType? FileType { get; set; }

    /// <summary>
    /// Response format: json (default).
    /// </summary>
    [JsonPropertyName("format")]
    public BulkScreenshotCaptureRequestUrlsItemFormat? Format { get; set; }

    /// <summary>
    /// If `true`, bypasses cache and captures a fresh render. If `false`, returns cached version when available.
    /// </summary>
    [JsonPropertyName("fresh")]
    public bool? Fresh { get; set; }

    /// <summary>
    /// Captures the entire webpage from top to bottom, including scrollable content outside the viewport. Ideal for long-form pages.
    /// </summary>
    [JsonPropertyName("full_page")]
    public bool? FullPage { get; set; }

    /// <summary>
    /// Extracts all image URLs from the rendered DOM and returns them in structured format. Only with output=json.
    /// </summary>
    [JsonPropertyName("get_image_urls")]
    public bool? GetImageUrls { get; set; }

    /// <summary>
    /// Renders the page with a GPU, including WebGL and canvas content. Adds 20 credits per request.
    /// </summary>
    [JsonPropertyName("gpu")]
    public bool? Gpu { get; set; }

    /// <summary>
    /// Applies a grayscale filter to the screenshot. Requires a value from 0 (no effect) to 100 (fully grayscale).
    /// </summary>
    [JsonPropertyName("grayscale")]
    public int? Grayscale { get; set; }

    /// <summary>
    /// Custom HTTP headers to include as key=value pairs. Use a semicolon to separate multiple headers (e.g., `key1=value1;key2=value2`).
    /// </summary>
    [JsonPropertyName("headers")]
    public string? Headers { get; set; }

    /// <summary>
    /// Viewport height in pixels. Controls how much vertical area is visible. Max: 4320.
    /// </summary>
    [JsonPropertyName("height")]
    public int? Height { get; set; }

    /// <summary>
    /// Compression level for JPEG output (0-100). Lower = smaller file, higher = better quality. Only applies to JPEG.
    /// </summary>
    [JsonPropertyName("image_quality")]
    public int? ImageQuality { get; set; }

    /// <summary>
    /// Allows injecting custom JavaScript code into the page before rendering. Pass the JavaScript code directly as a string.
    /// </summary>
    [JsonPropertyName("js")]
    public string? Js { get; set; }

    /// <summary>
    /// Allows loading external JavaScript into the page. Provide a URL pointing to the script file.
    /// </summary>
    [JsonPropertyName("js_url")]
    public string? JsUrl { get; set; }

    /// <summary>
    /// Specify latitude for the browser Geolocation API. Provide a numeric value. Default: null (not set).
    /// </summary>
    [JsonPropertyName("latitude")]
    public float? Latitude { get; set; }

    /// <summary>
    /// Automatically scrolls the page to trigger lazy-loaded images and components. Ensures complete content capture.
    /// </summary>
    [JsonPropertyName("lazy_load")]
    public bool? LazyLoad { get; set; }

    /// <summary>
    /// Specify longitude for the browser Geolocation API. Provide a numeric value. Default: null (not set).
    /// </summary>
    [JsonPropertyName("longitude")]
    public float? Longitude { get; set; }

    /// <summary>
    /// Markdown to render instead of loading a URL. Works like custom_html, so you can capture a README or notes without hosting a page.
    /// </summary>
    [JsonPropertyName("markdown")]
    public string? Markdown { get; set; }

    /// <summary>
    /// Hides or blocks cookie consent banners and popups before capture.
    /// </summary>
    [JsonPropertyName("no_cookie_banners")]
    public bool? NoCookieBanners { get; set; }

    /// <summary>
    /// Recognition model used by the captcha solver: mini-ocr-v1 (default) or ocr-v1.
    /// </summary>
    [JsonPropertyName("ocr_model")]
    public BulkScreenshotCaptureRequestUrlsItemOcrModel? OcrModel { get; set; }

    /// <summary>
    /// Replaces simple white/plain backgrounds with transparency for a cut-out effect. Only works with PNG output.
    /// </summary>
    [JsonPropertyName("omit_background")]
    public bool? OmitBackground { get; set; }

    /// <summary>
    /// Set the output format. `json` returns metadata with a hosted file URL. `image` streams the raw file bytes directly.
    /// </summary>
    [JsonPropertyName("output")]
    public BulkScreenshotCaptureRequestUrlsItemOutput? Output { get; set; }

    /// <summary>
    /// PDF output options. Applies when file_type is PDF.
    /// </summary>
    [JsonPropertyName("pdf_options")]
    public BulkScreenshotCaptureRequestUrlsItemPdfOptions? PdfOptions { get; set; }

    /// <summary>
    /// Loads the page through a residential proxy. Adds 200 credits per request. Used instead of classic_proxy.
    /// </summary>
    [JsonPropertyName("premium_proxy")]
    public bool? PremiumProxy { get; set; }

    /// <summary>
    /// Allows defining a proxy for the connection. Provide a JSON string with keys: server (include port number), username, and password.
    /// </summary>
    [JsonPropertyName("proxy")]
    public string? Proxy { get; set; }

    /// <summary>
    /// CSS selectors to remove before capture. Deletes matched elements from DOM. Ideal for cleaning ads, popups, sidebars. Multiple selectors supported. Default: empty.
    /// </summary>
    [JsonPropertyName("remove_selector")]
    public string? RemoveSelector { get; set; }

    /// <summary>
    /// Custom name for the output file. Helps with organized storage and retrieval. Note: non-unique names may overwrite existing files.
    /// </summary>
    [JsonPropertyName("result_file_name")]
    public string? ResultFileName { get; set; }

    /// <summary>
    /// Captures at 2x resolution for sharper, high-DPI output. Increases file size.
    /// </summary>
    [JsonPropertyName("retina")]
    public bool? Retina { get; set; }

    /// <summary>
    /// If `true`, scrolls to bottom then back to top, creating a seamless loop.
    /// </summary>
    [JsonPropertyName("scroll_back")]
    public bool? ScrollBack { get; set; }

    /// <summary>
    /// Delay in milliseconds between scroll steps when `lazy_load` is enabled. Use higher values for heavy pages.
    /// </summary>
    [JsonPropertyName("scroll_delay")]
    public int? ScrollDelay { get; set; }

    /// <summary>
    /// Scrolling speed: fast, normal (default), or slow. Affects render time and output pacing.
    /// </summary>
    [JsonPropertyName("scroll_speed")]
    public BulkScreenshotCaptureRequestUrlsItemScrollSpeed? ScrollSpeed { get; set; }

    /// <summary>
    /// Scrolls the page to bring the specified CSS selector into view before capture. Ideal for below-the-fold content. Default: empty.
    /// </summary>
    [JsonPropertyName("scroll_to_element")]
    public string? ScrollToElement { get; set; }

    /// <summary>
    /// Enables scrolling screenshot mode to capture a video (webm, gif, mp4) of the webpage.
    /// </summary>
    [JsonPropertyName("scrolling_screenshot")]
    public bool? ScrollingScreenshot { get; set; }

    /// <summary>
    /// CSS selector to capture a specific element. Only that element is rendered. Falls back to full page if not found. Default: empty.
    /// </summary>
    [JsonPropertyName("selector")]
    public string? Selector { get; set; }

    /// <summary>
    /// CSS selector for an element to click before capturing the screenshot. Useful for opening dropdowns, modals, or triggering content.
    /// </summary>
    [JsonPropertyName("selector_to_click")]
    public string? SelectorToClick { get; set; }

    /// <summary>
    /// Solves a captcha made of text drawn in a picture, then takes the screenshot. Requires captcha_image and captcha_input. Adds 20 credits per request.
    /// </summary>
    [JsonPropertyName("solve_captcha")]
    public bool? SolveCaptcha { get; set; }

    /// <summary>
    /// Starts recording immediately without waiting for full page load.
    /// </summary>
    [JsonPropertyName("start_immediately")]
    public bool? StartImmediately { get; set; }

    /// <summary>
    /// Makes the browser look like a regular visitor for pages that block automated traffic. No extra credits.
    /// </summary>
    [JsonPropertyName("stealth")]
    public bool? Stealth { get; set; }

    /// <summary>
    /// Specifies the width of the thumbnail in pixels. Default value is 0 (meaning no specific value is set, and the screenshot is returned at its original resolution).
    /// </summary>
    [JsonPropertyName("thumbnail_width")]
    public int? ThumbnailWidth { get; set; }

    /// <summary>
    /// Maximum wait in milliseconds for page load before aborting. Adjust for slow/heavy pages. Default: 100000 (100s).
    /// </summary>
    [JsonPropertyName("timeout")]
    public int? Timeout { get; set; }

    /// <summary>
    /// IANA timezone the browser uses while rendering, such as Asia/Karachi or Europe/London. Useful for clocks and localized dates.
    /// </summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; set; }

    /// <summary>
    /// Time in seconds the render stays cached before auto-invalidation. Use higher values for static pages, lower for dynamic content. Default: 2592000 (30 days).
    /// </summary>
    [JsonPropertyName("ttl")]
    public int? Ttl { get; set; }

    /// <summary>
    /// Custom User-Agent string sent in the request headers.
    /// </summary>
    [JsonPropertyName("user_agent")]
    public string? UserAgent { get; set; }

    /// <summary>
    /// Records visible viewport only for a specified duration. Use with `duration` parameter. Ideal for dashboards and animations.
    /// </summary>
    [JsonPropertyName("video")]
    public bool? Video { get; set; }

    /// <summary>
    /// Controls when rendering starts based on page load lifecycle. `load` (all resources), `domcontentloaded` (HTML parsed), `networkidle` (no network activity for 500ms).
    /// </summary>
    [JsonPropertyName("wait_for_event")]
    public BulkScreenshotCaptureRequestUrlsItemWaitForEvent? WaitForEvent { get; set; }

    /// <summary>
    /// Viewport width in pixels. Simulates device screen sizes. Max: 7680.
    /// </summary>
    [JsonPropertyName("width")]
    public int? Width { get; set; }

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

using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;

namespace ApifreaksApi;

[Serializable]
public record ScreenshotCaptureRequest
{
    /// <summary>
    /// Your API key
    /// </summary>
    [JsonIgnore]
    public required string ApiKey { get; set; }

    /// <summary>
    /// Output format for screenshot results. The SDKs support only `json`, which returns metadata with the captured file's URL in `screenshot`; download the file from that URL. (The API's `output=image`, which returns the raw file, is not supported by the SDK methods.)
    /// </summary>
    [JsonIgnore]
    public ScreenshotCaptureRequestOutput? Output { get; set; }

    /// <summary>
    /// File type for screenshot output
    /// </summary>
    [JsonIgnore]
    public ScreenshotCaptureRequestFileType? FileType { get; set; }

    /// <summary>
    /// URLs to capture screenshots of
    /// </summary>
    [JsonIgnore]
    public required string Url { get; set; }

    /// <summary>
    /// Browser viewport width in pixels
    /// </summary>
    [JsonIgnore]
    public int? Width { get; set; }

    /// <summary>
    /// Browser viewport height in pixels
    /// </summary>
    [JsonIgnore]
    public int? Height { get; set; }

    /// <summary>
    /// Capture a full-page screenshot
    /// </summary>
    [JsonIgnore]
    public bool? FullPage { get; set; }

    /// <summary>
    /// Bypass cache and take a fresh screenshot
    /// </summary>
    [JsonIgnore]
    public bool? Fresh { get; set; }

    /// <summary>
    /// Remove cookie banners from the screenshot
    /// </summary>
    [JsonIgnore]
    public bool? NoCookieBanners { get; set; }

    /// <summary>
    /// Enable caching for repeated requests
    /// </summary>
    [JsonIgnore]
    public bool? EnableCaching { get; set; }

    /// <summary>
    /// Block advertisements on the page
    /// </summary>
    [JsonIgnore]
    public bool? BlockAds { get; set; }

    /// <summary>
    /// Block chat widget scripts from loading
    /// </summary>
    [JsonIgnore]
    public bool? BlockChatWidgets { get; set; }

    /// <summary>
    /// Extract visible text from the page
    /// </summary>
    [JsonIgnore]
    public bool? ExtractText { get; set; }

    /// <summary>
    /// Extract HTML content of the page
    /// </summary>
    [JsonIgnore]
    public bool? ExtractHtml { get; set; }

    /// <summary>
    /// Auto-destroy screenshot after fetch
    /// </summary>
    [JsonIgnore]
    public bool? DestroyScreenshot { get; set; }

    /// <summary>
    /// Enable lazy-loading content before screenshot
    /// </summary>
    [JsonIgnore]
    public bool? LazyLoad { get; set; }

    /// <summary>
    /// Capture screenshot in high-DPI (Retina) mode
    /// </summary>
    [JsonIgnore]
    public bool? Retina { get; set; }

    /// <summary>
    /// Render page in dark mode
    /// </summary>
    [JsonIgnore]
    public bool? DarkMode { get; set; }

    /// <summary>
    /// Block common user-tracking scripts
    /// </summary>
    [JsonIgnore]
    public bool? BlockTracking { get; set; }

    /// <summary>
    /// Enable private/incognito mode for browser session
    /// </summary>
    [JsonIgnore]
    public bool? EnableIncognito { get; set; }

    /// <summary>
    /// Omit background color (transparent background)
    /// </summary>
    [JsonIgnore]
    public bool? OmitBackground { get; set; }

    /// <summary>
    /// Thumbnail width in pixels
    /// </summary>
    [JsonIgnore]
    public int? ThumbnailWidth { get; set; }

    /// <summary>
    /// Adjust top in pixels
    /// </summary>
    [JsonIgnore]
    public int? AdjustTop { get; set; }

    /// <summary>
    /// Wait for a specific load event before capturing the screenshot.
    /// </summary>
    [JsonIgnore]
    public ScreenshotCaptureRequestWaitForEvent? WaitForEvent { get; set; }

    /// <summary>
    /// Range:0 to 100 for grayscale filter
    /// </summary>
    [JsonIgnore]
    public int? Grayscale { get; set; }

    /// <summary>
    /// How many milliseconds to wait before taking the screenshot
    /// </summary>
    [JsonIgnore]
    public int? Delay { get; set; }

    /// <summary>
    /// Maximum timeout in milliseconds. Defalut is `10,000`
    /// </summary>
    [JsonIgnore]
    public int? Timeout { get; set; }

    /// <summary>
    /// Number of seconds the screenshot should be cached
    /// </summary>
    [JsonIgnore]
    public int? Ttl { get; set; }

    /// <summary>
    /// X position of the clipping rectangle in pixels
    /// </summary>
    [JsonIgnore]
    public int? ClipX { get; set; }

    /// <summary>
    /// Y position of the clipping rectangle in pixels
    /// </summary>
    [JsonIgnore]
    public int? ClipY { get; set; }

    /// <summary>
    /// Width of the clipping rectangle in pixels
    /// </summary>
    [JsonIgnore]
    public int? ClipWidth { get; set; }

    /// <summary>
    /// Height of the clipping rectangle in pixels
    /// </summary>
    [JsonIgnore]
    public int? ClipHeight { get; set; }

    /// <summary>
    /// URL to CSS file
    /// </summary>
    [JsonIgnore]
    public string? CssUrl { get; set; }

    /// <summary>
    /// Your custom CSS code
    /// </summary>
    [JsonIgnore]
    public string? Css { get; set; }

    /// <summary>
    /// URL to JS file
    /// </summary>
    [JsonIgnore]
    public string? JsUrl { get; set; }

    /// <summary>
    /// Your JS code
    /// </summary>
    [JsonIgnore]
    public string? Js { get; set; }

    /// <summary>
    /// Block Scripts
    /// </summary>
    [JsonIgnore]
    public bool? BlockJs { get; set; }

    /// <summary>
    /// Block Stylesheets
    /// </summary>
    [JsonIgnore]
    public bool? BlockStylesheets { get; set; }

    /// <summary>
    /// Block Images
    /// </summary>
    [JsonIgnore]
    public bool? BlockImages { get; set; }

    /// <summary>
    /// Block Media
    /// </summary>
    [JsonIgnore]
    public bool? BlockMedia { get; set; }

    /// <summary>
    /// Block Fonts
    /// </summary>
    [JsonIgnore]
    public bool? BlockFont { get; set; }

    /// <summary>
    /// Block Text Tracks
    /// </summary>
    [JsonIgnore]
    public bool? BlockTextTrack { get; set; }

    /// <summary>
    /// Block XHR Requests
    /// </summary>
    [JsonIgnore]
    public bool? BlockXhr { get; set; }

    /// <summary>
    /// Block Fetch Requests
    /// </summary>
    [JsonIgnore]
    public bool? BlockFetch { get; set; }

    /// <summary>
    /// Block Event Source
    /// </summary>
    [JsonIgnore]
    public bool? BlockEventSource { get; set; }

    /// <summary>
    /// Block Web Sockets
    /// </summary>
    [JsonIgnore]
    public bool? BlockWebSocket { get; set; }

    /// <summary>
    /// Block Manifest
    /// </summary>
    [JsonIgnore]
    public bool? BlockManifest { get; set; }

    /// <summary>
    /// Comma- or newline-separated list of specific requests to block. Each line and comma are treated as separate requests for processing. Example: https://example.com, https://example.js
    /// </summary>
    [JsonIgnore]
    public string? BlockSpecificRequests { get; set; }

    /// <summary>
    /// Comma-separated list of indexed CSS selectors to blur.
    /// Format: `index:&lt;selector&gt;`, e.g., `0:.banner,1:#ads`.
    /// </summary>
    [JsonIgnore]
    public string? BlurSelector { get; set; }

    /// <summary>
    /// Comma-separated list of indexed CSS selectors to blur.
    /// Format: `index:&lt;selector&gt;`, e.g., `0:.banner,1:#ads`.
    /// </summary>
    [JsonIgnore]
    public string? RemoveSelector { get; set; }

    /// <summary>
    /// Specify a meaningful &amp; unique file name to easily identify the screenshot result.
    /// Avoid using spaces or special characters; use hyphens or underscores to separate words.
    /// </summary>
    [JsonIgnore]
    public string? ResultFileName { get; set; }

    /// <summary>
    /// **`Scrolling Screenshot`**: Capture a long scrolling screenshot. When true, disable `fullPage` and `freshScreenshot`.
    /// </summary>
    [JsonIgnore]
    public bool? ScrollingScreenshot { get; set; }

    /// <summary>
    /// Speed of scrolling during the screenshot.
    /// </summary>
    [JsonIgnore]
    public ScreenshotCaptureRequestScrollSpeed? ScrollSpeed { get; set; }

    /// <summary>
    /// If true, the scroll will reverse back to the top after reaching the bottom.
    /// </summary>
    [JsonIgnore]
    public bool? ScrollBack { get; set; }

    /// <summary>
    /// If true, the scrolling capture will start immediately upon page load.
    /// </summary>
    [JsonIgnore]
    public bool? StartImmediately { get; set; }

    /// <summary>
    /// If true, multiple scrolling screenshots will be taken at different viewport sizes.
    /// </summary>
    [JsonIgnore]
    public bool? MultipleScrolling { get; set; }

    /// <summary>
    /// Comma-separated list of viewport sizes in the format index:XXw:YYh. Example: sizes=0:120w:300h,1:240w:500h
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string> Sizes { get; set; } = new List<string>();

    /// <summary>
    /// Duration in seconds for the scrolling capture. Acceptable range: 0 to 100 seconds.
    /// </summary>
    [JsonIgnore]
    public double? Duration { get; set; }

    [JsonIgnore]
    public bool? FailOnError { get; set; }

    [JsonIgnore]
    public double? Longitude { get; set; }

    [JsonIgnore]
    public double? Latitude { get; set; }

    [JsonIgnore]
    public string? Proxy { get; set; }

    [JsonIgnore]
    public string? Headers { get; set; }

    [JsonIgnore]
    public string? Cookies { get; set; }

    [JsonIgnore]
    public string? ScrollToElement { get; set; }

    [JsonIgnore]
    public string? Selector { get; set; }

    [JsonIgnore]
    public string? UserAgent { get; set; }

    [JsonIgnore]
    public string? AcceptLanguages { get; set; }

    [JsonIgnore]
    public string? CustomHtml { get; set; }

    [JsonIgnore]
    public double? ImageQuality { get; set; }

    /// <summary>
    /// CSS selector of the message shown for a wrong answer. While it is visible, the solver tries again.
    /// </summary>
    [JsonIgnore]
    public string? CaptchaError { get; set; }

    /// <summary>
    /// CSS selector of the captcha picture. Required when solve_captcha is true.
    /// </summary>
    [JsonIgnore]
    public string? CaptchaImage { get; set; }

    /// <summary>
    /// CSS selector of the box the answer is typed into. Required when solve_captcha is true.
    /// </summary>
    [JsonIgnore]
    public string? CaptchaInput { get; set; }

    /// <summary>
    /// CSS selector of the control that loads a new captcha picture before the next try.
    /// </summary>
    [JsonIgnore]
    public string? CaptchaRefresh { get; set; }

    /// <summary>
    /// Number of guesses the solver makes, from 1 to 5.
    /// </summary>
    [JsonIgnore]
    public int? CaptchaRetries { get; set; }

    /// <summary>
    /// CSS selector of the button to click after the answer is typed.
    /// </summary>
    [JsonIgnore]
    public string? CaptchaSubmit { get; set; }

    /// <summary>
    /// Loads the page through a datacenter proxy. Adds 20 credits per request. Ignored when premium_proxy is true or a custom proxy is set.
    /// </summary>
    [JsonIgnore]
    public bool? ClassicProxy { get; set; }

    /// <summary>
    /// Number of times to click the selector (when set via `selector_to_click`).
    /// </summary>
    [JsonIgnore]
    public int? ClickRecursion { get; set; }

    /// <summary>
    /// Two-letter country code, such as US or DE, for the exit address of classic_proxy or premium_proxy. Ignored when you send your own proxy. Any two-letter code is sent, including one that is not listed. Classic proxy countries: BG, GE, DE, HN, MD, UA, GB, US. Premium proxy countries: AF, AL, DZ, AO, AG, AR, AM, AW, AU, AT, AZ, BS, BH, BD, BB, BY, BE, BZ, BJ, BT, BO, BQ, BA, BW, BR, BN, BG, BF, BI, CV, KH, CM, CA, KY, CF, TD, CL, CN, CO, KM, CG, CR, CI, HR, CU, CW, CY, CZ, CD, DK, DJ, DM, DO, EC, EG, SV, GQ, EE, SZ, ET, FO, FJ, FI, FR, GF, PF, GA, GM, GE, DE, GH, GI, GR, GL, GD, GP, GU, GT, GG, GN, GW, GY, HT, HN, HK, HU, IS, IN, ID, IR, IQ, IE, IL, IT, JM, JP, JE, JO, KZ, KE, XK, KW, KG, LA, LV, LB, LS, LR, LY, LT, MO, MG, MW, MY, MV, ML, MT, MQ, MR, MU, YT, MX, MD, MN, ME, MA, MZ, MM, NA, NP, NL, NC, NZ, NI, NE, NG, MK, NO, OM, PK, PS, PA, PG, PY, PE, PH, PL, PT, PR, QA, RE, RO, RU, RW, KN, LC, VC, WS, SA, SN, RS, SC, SL, SG, SK, SI, SB, SO, ZA, KR, SS, ES, LK, SD, SR, SE, CH, SY, TW, TJ, TZ, TH, TL, TG, TO, TT, TN, TR, TM, UG, UA, AE, GB, US, UY, UZ, VE, VN, YE, ZM, ZW.
    /// </summary>
    [JsonIgnore]
    public string? Country { get; set; }

    /// <summary>
    /// Extracts rendered page content as a structured .md (Markdown) file. Preserves headings, lists, links. Only with output=json.
    /// </summary>
    [JsonIgnore]
    public bool? ExtractMarkdown { get; set; }

    /// <summary>
    /// Response format: json (default).
    /// </summary>
    [JsonIgnore]
    public ScreenshotCaptureRequestFormat? Format { get; set; }

    /// <summary>
    /// Extracts all image URLs from the rendered DOM and returns them in structured format. Only with output=json.
    /// </summary>
    [JsonIgnore]
    public bool? GetImageUrls { get; set; }

    /// <summary>
    /// Renders the page with a GPU, including WebGL and canvas content. Adds 20 credits per request.
    /// </summary>
    [JsonIgnore]
    public bool? Gpu { get; set; }

    /// <summary>
    /// Markdown to render instead of loading a URL. Works like custom_html, so you can capture a README or notes without hosting a page.
    /// </summary>
    [JsonIgnore]
    public string? Markdown { get; set; }

    /// <summary>
    /// Recognition model used by the captcha solver: mini-ocr-v1 (default) or ocr-v1.
    /// </summary>
    [JsonIgnore]
    public ScreenshotCaptureRequestOcrModel? OcrModel { get; set; }

    /// <summary>
    /// Paper size of the PDF. Applies when file_type is PDF. Without it, width and height are used if set, otherwise the page renders as one long page: A0, A1, A2, A3, A4, A5, A6, Letter, Legal, Tabloid, or Ledger.
    /// </summary>
    [JsonIgnore]
    public ScreenshotCaptureRequestPdfOptionsFormat? PdfOptionsFormat { get; set; }

    /// <summary>
    /// Renders the PDF in landscape orientation, swapping the width and height of the paper size. Applies when file_type is PDF.
    /// </summary>
    [JsonIgnore]
    public bool? PdfOptionsLandscape { get; set; }

    /// <summary>
    /// CSS media type used to render the PDF: print or screen.
    /// </summary>
    [JsonIgnore]
    public ScreenshotCaptureRequestPdfOptionsMedia? PdfOptionsMedia { get; set; }

    /// <summary>
    /// Pages to keep in the PDF, as start-end, for example 1-3 or 5-5. Pages are rendered first and then trimmed. Has no effect on a single-page PDF. Applies when file_type is PDF.
    /// </summary>
    [JsonIgnore]
    public string? PdfOptionsPageRange { get; set; }

    /// <summary>
    /// Includes background colors and images in the PDF. Applies when file_type is PDF.
    /// </summary>
    [JsonIgnore]
    public bool? PdfOptionsPrintBackground { get; set; }

    /// <summary>
    /// Loads the page through a residential proxy. Adds 200 credits per request. Used instead of classic_proxy.
    /// </summary>
    [JsonIgnore]
    public bool? PremiumProxy { get; set; }

    /// <summary>
    /// Delay in milliseconds between scroll steps when `lazy_load` is enabled. Use higher values for heavy pages.
    /// </summary>
    [JsonIgnore]
    public int? ScrollDelay { get; set; }

    /// <summary>
    /// CSS selector for an element to click before capturing the screenshot. Useful for opening dropdowns, modals, or triggering content.
    /// </summary>
    [JsonIgnore]
    public string? SelectorToClick { get; set; }

    /// <summary>
    /// Solves a captcha made of text drawn in a picture, then takes the screenshot. Requires captcha_image and captcha_input. Adds 20 credits per request.
    /// </summary>
    [JsonIgnore]
    public bool? SolveCaptcha { get; set; }

    /// <summary>
    /// Makes the browser look like a regular visitor for pages that block automated traffic. No extra credits.
    /// </summary>
    [JsonIgnore]
    public bool? Stealth { get; set; }

    /// <summary>
    /// IANA timezone the browser uses while rendering, such as Asia/Karachi or Europe/London. Useful for clocks and localized dates.
    /// </summary>
    [JsonIgnore]
    public string? Timezone { get; set; }

    /// <summary>
    /// Records visible viewport only for a specified duration. Use with `duration` parameter. Ideal for dashboards and animations.
    /// </summary>
    [JsonIgnore]
    public bool? Video { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

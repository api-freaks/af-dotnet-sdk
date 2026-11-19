using ApifreaksApi.Core;
using global::System.Text.Json.Serialization;
using OneOf;

namespace ApifreaksApi;

[Serializable]
public record WebScrapeRequest
{
    /// <summary>
    /// Your API key
    /// </summary>
    [JsonIgnore]
    public required string ApiKey { get; set; }

    /// <summary>
    /// Response format returned by the API.
    /// </summary>
    [JsonIgnore]
    public WebScrapeRequestFormat? Format { get; set; }

    /// <summary>
    /// Target URL to scrape
    /// </summary>
    [JsonIgnore]
    public required string Url { get; set; }

    /// <summary>
    /// Set to `true` to return the data in text format else `false` for data in html format with tags.
    /// </summary>
    [JsonIgnore]
    public bool? Text { get; set; }

    /// <summary>
    /// Set  `true` to handle websites with JavaScript. Set `false` to handle static html websites.
    ///
    ///
    ///  Default value is `true`.
    /// </summary>
    [JsonIgnore]
    public bool? JsEnabled { get; set; }

    /// <summary>
    /// Use a proxy for the request. Pass true/false to toggle the default proxy pool, or a proxy URL string to use a specific proxy.
    /// </summary>
    [JsonIgnore]
    public OneOf<bool, string>? Proxy { get; set; }

    /// <summary>
    /// Ignore SSL certificate errors.
    ///
    ///
    ///  Only works if **jsEnabled** is **true**.
    /// </summary>
    [JsonIgnore]
    public bool? SslIgnore { get; set; }

    /// <summary>
    /// Specify the browser window size in the format 'width,height' (e.g., "1920w,1080h"). Default value is the default resolutions provided by web/browser.
    ///
    ///
    ///  Only works if **jsEnabled** is **true**.
    /// </summary>
    [JsonIgnore]
    public string? WindowSize { get; set; }

    /// <summary>
    /// Set to `true` to apply ad-blocker to the specified URL else false or ignore to not apply.
    ///
    ///
    ///  Only works if **jsEnabled** is **true**.
    /// </summary>
    [JsonIgnore]
    public bool? AdBlock { get; set; }

    /// <summary>
    /// if true user can provide captcha instructions in the instructions to solve image captchas.
    ///
    ///
    ///   Only works if **jsEnabled** is **true**.
    /// </summary>
    [JsonIgnore]
    public bool? Captcha { get; set; }

    [JsonIgnore]
    public required OneOf<WebScrapeRequestBodyBlockUrl, WebScrapeRequestBodyOne> Body { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}

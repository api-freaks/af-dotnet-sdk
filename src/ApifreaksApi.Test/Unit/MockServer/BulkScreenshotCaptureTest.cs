using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class BulkScreenshotCaptureTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "urls": [
                {
                  "url": "url"
                },
                {
                  "url": "url"
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "status": "status",
              "meta_data": {
                "total_urls": 1,
                "successful_urls": 1,
                "failed_urls": 1
              },
              "results": [
                {
                  "status": "status",
                  "error_message": "error_message",
                  "url": {
                    "screenshot": "screenshot",
                    "url": "url",
                    "created_at": "created_at",
                    "format": "format",
                    "ttl": "ttl",
                    "file_type": "file_type",
                    "extracted_html": "extracted_html",
                    "omit_background": true,
                    "destroy_screenshot": true,
                    "fail_on_error": true,
                    "longitude": "longitude",
                    "latitude": "latitude",
                    "proxy": "proxy",
                    "no_cookie_banners": true,
                    "block_ads": true,
                    "headers": "headers",
                    "cookies": "cookies",
                    "scroll_to_element": "scroll_to_element",
                    "selector": "selector",
                    "blur_selector": "blur_selector",
                    "remove_selector": "remove_selector",
                    "css": "css",
                    "css_url": "css_url",
                    "js": "js",
                    "js_url": "js_url",
                    "user_agent": "user_agent",
                    "accept_languages": "accept_languages",
                    "delay": 1.1,
                    "thumbnail_width": 1.1,
                    "output": "output",
                    "fresh": true,
                    "enable_caching": true,
                    "lazy_load": true,
                    "full_page": true,
                    "retina": true,
                    "height": 1.1,
                    "width": 1.1,
                    "custom_html": "custom_html",
                    "block_chat_widgets": true,
                    "block_js": true,
                    "block_stylesheets": true,
                    "block_images": true,
                    "block_media": true,
                    "block_font": true,
                    "block_text_track": true,
                    "block_xhr": true,
                    "block_fetch": true,
                    "block_event_source": true,
                    "block_web_socket": true,
                    "block_manifest": true,
                    "block_specific_requests": "block_specific_requests",
                    "adjust_top": 1.1,
                    "image_quality": 1.1,
                    "extract_html": true,
                    "extract_text": true,
                    "dark_mode": true,
                    "block_tracking": true,
                    "wait_for_event": "wait_for_event",
                    "grayscale": 1.1,
                    "result_file_name": "result_file_name",
                    "enable_incognito": true,
                    "timeout": 1.1,
                    "scrolling_screenshot": true,
                    "multiple_scrolling": true,
                    "scroll_speed": "scroll_speed",
                    "duration": 1.1,
                    "scroll_back": true,
                    "start_immediately": true,
                    "clip": {
                      "clip": {
                        "key": "value"
                      }
                    },
                    "sizes": [
                      {
                        "sizes": {
                          "key": "value"
                        }
                      },
                      {
                        "sizes": {
                          "key": "value"
                        }
                      }
                    ]
                  }
                },
                {
                  "status": "status",
                  "error_message": "error_message",
                  "url": {
                    "screenshot": "screenshot",
                    "url": "url",
                    "created_at": "created_at",
                    "format": "format",
                    "ttl": "ttl",
                    "file_type": "file_type",
                    "extracted_html": "extracted_html",
                    "omit_background": true,
                    "destroy_screenshot": true,
                    "fail_on_error": true,
                    "longitude": "longitude",
                    "latitude": "latitude",
                    "proxy": "proxy",
                    "no_cookie_banners": true,
                    "block_ads": true,
                    "headers": "headers",
                    "cookies": "cookies",
                    "scroll_to_element": "scroll_to_element",
                    "selector": "selector",
                    "blur_selector": "blur_selector",
                    "remove_selector": "remove_selector",
                    "css": "css",
                    "css_url": "css_url",
                    "js": "js",
                    "js_url": "js_url",
                    "user_agent": "user_agent",
                    "accept_languages": "accept_languages",
                    "delay": 1.1,
                    "thumbnail_width": 1.1,
                    "output": "output",
                    "fresh": true,
                    "enable_caching": true,
                    "lazy_load": true,
                    "full_page": true,
                    "retina": true,
                    "height": 1.1,
                    "width": 1.1,
                    "custom_html": "custom_html",
                    "block_chat_widgets": true,
                    "block_js": true,
                    "block_stylesheets": true,
                    "block_images": true,
                    "block_media": true,
                    "block_font": true,
                    "block_text_track": true,
                    "block_xhr": true,
                    "block_fetch": true,
                    "block_event_source": true,
                    "block_web_socket": true,
                    "block_manifest": true,
                    "block_specific_requests": "block_specific_requests",
                    "adjust_top": 1.1,
                    "image_quality": 1.1,
                    "extract_html": true,
                    "extract_text": true,
                    "dark_mode": true,
                    "block_tracking": true,
                    "wait_for_event": "wait_for_event",
                    "grayscale": 1.1,
                    "result_file_name": "result_file_name",
                    "enable_incognito": true,
                    "timeout": 1.1,
                    "scrolling_screenshot": true,
                    "multiple_scrolling": true,
                    "scroll_speed": "scroll_speed",
                    "duration": 1.1,
                    "scroll_back": true,
                    "start_immediately": true,
                    "clip": {
                      "clip": {
                        "key": "value"
                      }
                    },
                    "sizes": [
                      {
                        "sizes": {
                          "key": "value"
                        }
                      },
                      {
                        "sizes": {
                          "key": "value"
                        }
                      }
                    ]
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/screenshot")
                    .WithParam("apiKey", "apiKey")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.BulkScreenshotCaptureAsync(
            new BulkScreenshotCaptureRequest
            {
                ApiKey = "apiKey",
                Urls = new List<BulkScreenshotCaptureRequestUrlsItem>()
                {
                    new BulkScreenshotCaptureRequestUrlsItem
                    {
                        Url = "url",
                        AcceptLanguages = null,
                        AdjustTop = null,
                        BlockAds = null,
                        BlockChatWidgets = null,
                        BlockEventSource = null,
                        BlockFetch = null,
                        BlockFont = null,
                        BlockImages = null,
                        BlockJs = null,
                        BlockManifest = null,
                        BlockMedia = null,
                        BlockSpecificRequests = null,
                        BlockStylesheets = null,
                        BlockTextTrack = null,
                        BlockTracking = null,
                        BlockWebSocket = null,
                        BlockXhr = null,
                        BlurSelector = null,
                        CaptchaError = null,
                        CaptchaImage = null,
                        CaptchaInput = null,
                        CaptchaRefresh = null,
                        CaptchaRetries = null,
                        CaptchaSubmit = null,
                        ClassicProxy = null,
                        ClickRecursion = null,
                        ClipHeight = null,
                        ClipWidth = null,
                        ClipX = null,
                        ClipY = null,
                        Cookies = null,
                        Country = null,
                        Css = null,
                        CssUrl = null,
                        CustomHtml = null,
                        DarkMode = null,
                        Delay = null,
                        DestroyScreenshot = null,
                        Duration = null,
                        EnableCaching = null,
                        EnableIncognito = null,
                        ExtractHtml = null,
                        ExtractMarkdown = null,
                        ExtractText = null,
                        FailOnError = null,
                        FileType = null,
                        Format = null,
                        Fresh = null,
                        FullPage = null,
                        GetImageUrls = null,
                        Gpu = null,
                        Grayscale = null,
                        Headers = null,
                        Height = null,
                        ImageQuality = null,
                        Js = null,
                        JsUrl = null,
                        Latitude = null,
                        LazyLoad = null,
                        Longitude = null,
                        Markdown = null,
                        NoCookieBanners = null,
                        OcrModel = null,
                        OmitBackground = null,
                        Output = null,
                        PdfOptions = null,
                        PremiumProxy = null,
                        Proxy = null,
                        RemoveSelector = null,
                        ResultFileName = null,
                        Retina = null,
                        ScrollBack = null,
                        ScrollDelay = null,
                        ScrollSpeed = null,
                        ScrollToElement = null,
                        ScrollingScreenshot = null,
                        Selector = null,
                        SelectorToClick = null,
                        SolveCaptcha = null,
                        StartImmediately = null,
                        Stealth = null,
                        ThumbnailWidth = null,
                        Timeout = null,
                        Timezone = null,
                        Ttl = null,
                        UserAgent = null,
                        Video = null,
                        WaitForEvent = null,
                        Width = null,
                    },
                    new BulkScreenshotCaptureRequestUrlsItem
                    {
                        Url = "url",
                        AcceptLanguages = null,
                        AdjustTop = null,
                        BlockAds = null,
                        BlockChatWidgets = null,
                        BlockEventSource = null,
                        BlockFetch = null,
                        BlockFont = null,
                        BlockImages = null,
                        BlockJs = null,
                        BlockManifest = null,
                        BlockMedia = null,
                        BlockSpecificRequests = null,
                        BlockStylesheets = null,
                        BlockTextTrack = null,
                        BlockTracking = null,
                        BlockWebSocket = null,
                        BlockXhr = null,
                        BlurSelector = null,
                        CaptchaError = null,
                        CaptchaImage = null,
                        CaptchaInput = null,
                        CaptchaRefresh = null,
                        CaptchaRetries = null,
                        CaptchaSubmit = null,
                        ClassicProxy = null,
                        ClickRecursion = null,
                        ClipHeight = null,
                        ClipWidth = null,
                        ClipX = null,
                        ClipY = null,
                        Cookies = null,
                        Country = null,
                        Css = null,
                        CssUrl = null,
                        CustomHtml = null,
                        DarkMode = null,
                        Delay = null,
                        DestroyScreenshot = null,
                        Duration = null,
                        EnableCaching = null,
                        EnableIncognito = null,
                        ExtractHtml = null,
                        ExtractMarkdown = null,
                        ExtractText = null,
                        FailOnError = null,
                        FileType = null,
                        Format = null,
                        Fresh = null,
                        FullPage = null,
                        GetImageUrls = null,
                        Gpu = null,
                        Grayscale = null,
                        Headers = null,
                        Height = null,
                        ImageQuality = null,
                        Js = null,
                        JsUrl = null,
                        Latitude = null,
                        LazyLoad = null,
                        Longitude = null,
                        Markdown = null,
                        NoCookieBanners = null,
                        OcrModel = null,
                        OmitBackground = null,
                        Output = null,
                        PdfOptions = null,
                        PremiumProxy = null,
                        Proxy = null,
                        RemoveSelector = null,
                        ResultFileName = null,
                        Retina = null,
                        ScrollBack = null,
                        ScrollDelay = null,
                        ScrollSpeed = null,
                        ScrollToElement = null,
                        ScrollingScreenshot = null,
                        Selector = null,
                        SelectorToClick = null,
                        SolveCaptcha = null,
                        StartImmediately = null,
                        Stealth = null,
                        ThumbnailWidth = null,
                        Timeout = null,
                        Timezone = null,
                        Ttl = null,
                        UserAgent = null,
                        Video = null,
                        WaitForEvent = null,
                        Width = null,
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "urls": [
                {
                  "url": "url"
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "status": "status",
              "meta_data": {
                "total_urls": 1,
                "successful_urls": 1,
                "failed_urls": 1
              },
              "results": [
                {
                  "status": "status",
                  "error_message": "error_message",
                  "url": {
                    "screenshot": "screenshot",
                    "url": "url",
                    "created_at": "created_at",
                    "ttl": "ttl"
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/screenshot")
                    .WithParam("apiKey", "apiKey")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.BulkScreenshotCaptureAsync(
            new BulkScreenshotCaptureRequest
            {
                ApiKey = "apiKey",
                Urls = new List<BulkScreenshotCaptureRequestUrlsItem>()
                {
                    new BulkScreenshotCaptureRequestUrlsItem { Url = "url" },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

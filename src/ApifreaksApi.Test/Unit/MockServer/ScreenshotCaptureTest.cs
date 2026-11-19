using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ScreenshotCaptureTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
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
              "height": "height",
              "width": "width",
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
                "height": 1,
                "width": 1,
                "x": 1,
                "y": 1
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
              ],
              "click_recursion": 1,
              "extract_markdown": true,
              "extracted_text": "extracted_text",
              "get_image_urls": true,
              "scroll_delay": 1,
              "selector_to_click": "selector_to_click",
              "video": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/screenshot")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("url", "url")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.ScreenshotCaptureAsync(
            new ScreenshotCaptureRequest { ApiKey = "apiKey", Url = "url" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
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
              "height": "height",
              "width": "width",
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
                "height": 1,
                "width": 1,
                "x": 1,
                "y": 1
              },
              "sizes": [
                {
                  "key": "value"
                }
              ],
              "click_recursion": 1,
              "extract_markdown": true,
              "extracted_text": "extracted_text",
              "get_image_urls": true,
              "scroll_delay": 1,
              "selector_to_click": "selector_to_click",
              "video": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/screenshot")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("url", "url")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.ScreenshotCaptureAsync(
            new ScreenshotCaptureRequest { ApiKey = "apiKey", Url = "url" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

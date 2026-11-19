using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CommodityLatestRatesV2Test : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "success": true,
              "timestamp": 1,
              "rates": {
                "rates": 1.1
              },
              "metadata": {
                "metadata": {
                  "unit": "unit",
                  "quote": "quote"
                }
              },
              "warning": "warning",
              "unresolved": {
                "unresolved": {
                  "message": "message",
                  "suggestions": [
                    "suggestions",
                    "suggestions"
                  ]
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/commodity/rates/latest")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommodityLatestRatesV2Async(
            new CommodityLatestRatesV2Request { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "success": true,
              "timestamp": 1,
              "rates": {
                "key": 1.1
              },
              "metadata": {
                "key": {
                  "unit": "unit",
                  "quote": "quote"
                }
              },
              "warning": "warning",
              "unresolved": {
                "key": {
                  "message": "message",
                  "suggestions": [
                    "suggestions"
                  ]
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/commodity/rates/latest")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommodityLatestRatesV2Async(
            new CommodityLatestRatesV2Request
            {
                ApiKey = "apiKey",
                Symbols = new List<string>() { "symbols" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

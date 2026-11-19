using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CommodityHistoricalRatesV2Test : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "success": true,
              "date": "date",
              "rates": {
                "rates": {
                  "date": "date",
                  "open": 1.1,
                  "high": 1.1,
                  "low": 1.1,
                  "close": 1.1
                }
              },
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
                    .WithPath("/v2.0/commodity/rates/historical")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("date", "2023-01-15")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommodityHistoricalRatesV2Async(
            new CommodityHistoricalRatesV2Request
            {
                ApiKey = "apiKey",
                Date = new DateOnly(2023, 1, 15),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "success": true,
              "date": "date",
              "rates": {
                "key": {
                  "date": "date",
                  "open": 1.1,
                  "high": 1.1,
                  "low": 1.1,
                  "close": 1.1
                }
              },
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
                    .WithPath("/v2.0/commodity/rates/historical")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("date", "2023-01-15")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommodityHistoricalRatesV2Async(
            new CommodityHistoricalRatesV2Request
            {
                ApiKey = "apiKey",
                Symbols = new List<string>() { "symbols" },
                Date = new DateOnly(2023, 1, 15),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

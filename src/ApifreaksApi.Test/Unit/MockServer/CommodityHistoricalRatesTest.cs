using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CommodityHistoricalRatesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "success": true,
              "timestamp": 1.1,
              "metadata": {
                "metadata": {
                  "unit": "unit",
                  "quote": "quote"
                }
              },
              "date": "date",
              "rates": {
                "rates": {
                  "date": "date",
                  "open": 1.1,
                  "high": 1.1,
                  "low": 1.1,
                  "close": 1.1
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/commodity/rates/historical")
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

        var response = await Client.CommodityHistoricalRatesAsync(
            new CommodityHistoricalRatesRequest
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
              "timestamp": 1.1,
              "metadata": {
                "key": {
                  "unit": "unit",
                  "quote": "quote"
                }
              },
              "date": "date",
              "rates": {
                "key": {
                  "date": "date",
                  "open": 1.1,
                  "high": 1.1,
                  "low": 1.1,
                  "close": 1.1
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/commodity/rates/historical")
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

        var response = await Client.CommodityHistoricalRatesAsync(
            new CommodityHistoricalRatesRequest
            {
                ApiKey = "apiKey",
                Date = new DateOnly(2023, 1, 15),
                Symbols = new List<string>() { "symbols" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

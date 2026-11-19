using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CommodityLatestRatesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "success": true,
              "timestamp": 1.1,
              "rates": {
                "rates": 1.1
              },
              "metadata": {
                "metadata": {
                  "unit": "unit",
                  "quote": "quote"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/commodity/rates/latest")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("updates", "10m")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommodityLatestRatesAsync(
            new CommodityLatestRatesRequest
            {
                ApiKey = "apiKey",
                Updates = CommodityLatestRatesRequestUpdates.TenM,
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
              "rates": {
                "key": 1.1
              },
              "metadata": {
                "key": {
                  "unit": "unit",
                  "quote": "quote"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/commodity/rates/latest")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("updates", "10m")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommodityLatestRatesAsync(
            new CommodityLatestRatesRequest
            {
                ApiKey = "apiKey",
                Symbols = new List<string>() { "symbols" },
                Updates = CommodityLatestRatesRequestUpdates.TenM,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

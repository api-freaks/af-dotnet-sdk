using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CommodityLatestRatesV2Test : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
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
              "warning": "warning"
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

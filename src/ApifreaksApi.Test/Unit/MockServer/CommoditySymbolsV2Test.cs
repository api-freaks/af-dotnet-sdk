using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CommoditySymbolsV2Test : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "success": true,
              "symbols": [
                {
                  "symbol": "symbol",
                  "name": "name",
                  "description": "description",
                  "category": "category",
                  "status": "active",
                  "updateInterval": "PER_SECOND",
                  "exchange": "exchange",
                  "deprecationDate": "2023-01-15",
                  "currency": {
                    "code": "code",
                    "name": "name",
                    "symbol": "symbol"
                  },
                  "unit": {
                    "symbol": "symbol",
                    "name": "name"
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/commodity/symbols")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommoditySymbolsV2Async(
            new CommoditySymbolsV2Request { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

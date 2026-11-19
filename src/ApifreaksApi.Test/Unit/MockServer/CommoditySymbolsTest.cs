using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CommoditySymbolsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "success": true,
              "symbols": [
                {
                  "symbol": "symbol",
                  "name": "name",
                  "category": "category",
                  "status": "status",
                  "updateInterval": "PER_SECOND",
                  "currency": {
                    "code": "code",
                    "name": "name",
                    "symbol": "symbol"
                  },
                  "unit": {
                    "symbol": "symbol",
                    "name": "name"
                  },
                  "description": "description",
                  "exchange": "exchange",
                  "deprecationDate": "2023-01-15",
                  "contract": "contract",
                  "deliveryMonth": "deliveryMonth",
                  "expiresAt": "2023-01-15",
                  "underlying": "underlying"
                },
                {
                  "symbol": "symbol",
                  "name": "name",
                  "category": "category",
                  "status": "status",
                  "updateInterval": "PER_SECOND",
                  "currency": {
                    "code": "code",
                    "name": "name",
                    "symbol": "symbol"
                  },
                  "unit": {
                    "symbol": "symbol",
                    "name": "name"
                  },
                  "description": "description",
                  "exchange": "exchange",
                  "deprecationDate": "2023-01-15",
                  "contract": "contract",
                  "deliveryMonth": "deliveryMonth",
                  "expiresAt": "2023-01-15",
                  "underlying": "underlying"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/commodity/symbols")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommoditySymbolsAsync(
            new CommoditySymbolsRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "success": true,
              "symbols": [
                {
                  "symbol": "symbol",
                  "name": "name",
                  "category": "category",
                  "status": "status",
                  "updateInterval": "PER_SECOND",
                  "currency": {
                    "code": "code",
                    "name": "name",
                    "symbol": "symbol"
                  },
                  "unit": {
                    "symbol": "symbol",
                    "name": "name"
                  },
                  "description": "description",
                  "exchange": "exchange",
                  "deprecationDate": "2023-01-15",
                  "contract": "contract",
                  "deliveryMonth": "deliveryMonth",
                  "expiresAt": "2023-01-15",
                  "underlying": "underlying"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/commodity/symbols")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommoditySymbolsAsync(
            new CommoditySymbolsRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

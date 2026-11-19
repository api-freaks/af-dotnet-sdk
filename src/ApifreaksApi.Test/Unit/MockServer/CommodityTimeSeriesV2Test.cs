using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CommodityTimeSeriesV2Test : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "success": true,
              "startDate": "startDate",
              "endDate": "endDate",
              "rates": {
                "rates": {
                  "rates": {
                    "open": 1.1,
                    "high": 1.1,
                    "low": 1.1,
                    "close": 1.1
                  }
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
                    .WithPath("/v2.0/commodity/time-series")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("startDate", "2023-01-15")
                    .WithParam("endDate", "2023-01-15")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommodityTimeSeriesV2Async(
            new CommodityTimeSeriesV2Request
            {
                ApiKey = "apiKey",
                StartDate = new DateOnly(2023, 1, 15),
                EndDate = new DateOnly(2023, 1, 15),
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
              "startDate": "startDate",
              "endDate": "endDate",
              "rates": {
                "key": {
                  "key": {
                    "open": 1.1,
                    "high": 1.1,
                    "low": 1.1,
                    "close": 1.1
                  }
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
                    .WithPath("/v2.0/commodity/time-series")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("startDate", "2023-01-15")
                    .WithParam("endDate", "2023-01-15")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommodityTimeSeriesV2Async(
            new CommodityTimeSeriesV2Request
            {
                ApiKey = "apiKey",
                Symbols = new List<string>() { "symbols" },
                StartDate = new DateOnly(2023, 1, 15),
                EndDate = new DateOnly(2023, 1, 15),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

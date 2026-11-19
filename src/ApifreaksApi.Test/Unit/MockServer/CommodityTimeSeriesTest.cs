using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CommodityTimeSeriesTest : BaseMockServerTest
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
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/commodity/time-series")
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

        var response = await Client.CommodityTimeSeriesAsync(
            new CommodityTimeSeriesRequest
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
              "timestamp": 1.1,
              "metadata": {
                "key": {
                  "unit": "unit",
                  "quote": "quote"
                }
              },
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
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/commodity/time-series")
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

        var response = await Client.CommodityTimeSeriesAsync(
            new CommodityTimeSeriesRequest
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

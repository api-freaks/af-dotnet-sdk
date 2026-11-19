using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CommodityIntradayRatesV2Test : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "success": true,
              "symbol": "symbol",
              "date": "date",
              "interval": "1m",
              "startTime": "startTime",
              "count": 100,
              "nextStartTime": "nextStartTime",
              "rates": {
                "rates": 1.1
              },
              "metadata": {
                "metadata": {
                  "unit": "unit",
                  "quote": "quote"
                }
              },
              "unresolved": {
                "unresolved": {
                  "message": "message",
                  "resolvedTo": "resolvedTo",
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
                    .WithPath("/v2.0/commodity/rates/intraday")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("symbols", "symbols")
                    .WithParam("interval", "1m")
                    .WithParam("date", "2023-01-15")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommodityIntradayRatesV2Async(
            new CommodityIntradayRatesV2Request
            {
                ApiKey = "apiKey",
                Symbols = "symbols",
                Interval = CommodityIntradayRatesV2RequestInterval.OneM,
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
              "symbol": "XAU",
              "date": "2026-10-14",
              "interval": "1h",
              "startTime": "18:00",
              "count": 6,
              "rates": {
                "2026-10-14T18:00:00Z": 4084.75,
                "2026-10-14T19:00:00Z": 4097.03,
                "2026-10-14T20:00:00Z": 4101.92,
                "2026-10-14T21:00:00Z": 4105.72,
                "2026-10-14T22:00:00Z": 4105.72,
                "2026-10-14T23:00:00Z": 4106.41
              },
              "metadata": {
                "XAU": {
                  "unit": "T.oz",
                  "quote": "USD"
                }
              },
              "unresolved": {
                "key": {
                  "message": "message",
                  "resolvedTo": "resolvedTo",
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
                    .WithPath("/v2.0/commodity/rates/intraday")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("symbols", "symbols")
                    .WithParam("interval", "1m")
                    .WithParam("date", "2023-01-15")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommodityIntradayRatesV2Async(
            new CommodityIntradayRatesV2Request
            {
                ApiKey = "apiKey",
                Symbols = "symbols",
                Interval = CommodityIntradayRatesV2RequestInterval.OneM,
                Date = new DateOnly(2023, 1, 15),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string mockResponse = """
            {
              "success": true,
              "symbol": "WTIOIL-FUT",
              "date": "2026-10-14",
              "interval": "1m",
              "startTime": "00:00",
              "count": 100,
              "nextStartTime": "01:40",
              "rates": {
                "2026-10-14T00:00:00Z": 94.69,
                "2026-10-14T00:01:00Z": 94.81,
                "2026-10-14T00:02:00Z": 94.82,
                "2026-10-14T00:03:00Z": 94.82,
                "2026-10-14T00:04:00Z": 94.79,
                "2026-10-14T00:05:00Z": 94.8,
                "2026-10-14T00:06:00Z": 94.8,
                "2026-10-14T00:07:00Z": 94.78,
                "2026-10-14T00:08:00Z": 94.73,
                "2026-10-14T00:09:00Z": 94.73,
                "2026-10-14T00:10:00Z": 94.74,
                "2026-10-14T00:11:00Z": 94.72,
                "2026-10-14T00:12:00Z": 94.78,
                "2026-10-14T00:13:00Z": 94.81,
                "2026-10-14T00:14:00Z": 94.81,
                "2026-10-14T00:15:00Z": 94.72,
                "2026-10-14T00:16:00Z": 94.84,
                "2026-10-14T00:17:00Z": 94.98,
                "2026-10-14T00:18:00Z": 94.89,
                "2026-10-14T00:19:00Z": 94.83,
                "2026-10-14T00:20:00Z": 94.87,
                "2026-10-14T00:21:00Z": 94.86,
                "2026-10-14T00:22:00Z": 94.88,
                "2026-10-14T00:23:00Z": 94.9,
                "2026-10-14T00:24:00Z": 94.92,
                "2026-10-14T00:25:00Z": 95.01,
                "2026-10-14T00:26:00Z": 95.04,
                "2026-10-14T00:27:00Z": 94.98,
                "2026-10-14T00:28:00Z": 94.98,
                "2026-10-14T00:29:00Z": 95,
                "2026-10-14T00:30:00Z": 94.94,
                "2026-10-14T00:31:00Z": 94.99,
                "2026-10-14T00:32:00Z": 94.98,
                "2026-10-14T00:33:00Z": 94.97,
                "2026-10-14T00:34:00Z": 94.97,
                "2026-10-14T00:35:00Z": 94.99,
                "2026-10-14T00:36:00Z": 95,
                "2026-10-14T00:37:00Z": 95.02,
                "2026-10-14T00:38:00Z": 94.99,
                "2026-10-14T00:39:00Z": 94.93,
                "2026-10-14T00:40:00Z": 94.95,
                "2026-10-14T00:41:00Z": 94.99,
                "2026-10-14T00:42:00Z": 94.96,
                "2026-10-14T00:43:00Z": 94.94,
                "2026-10-14T00:44:00Z": 94.94,
                "2026-10-14T00:45:00Z": 94.95,
                "2026-10-14T00:46:00Z": 94.94,
                "2026-10-14T00:47:00Z": 94.94,
                "2026-10-14T00:48:00Z": 94.99,
                "2026-10-14T00:49:00Z": 94.97,
                "2026-10-14T00:50:00Z": 94.98,
                "2026-10-14T00:51:00Z": 95.04,
                "2026-10-14T00:52:00Z": 95.02,
                "2026-10-14T00:53:00Z": 95.06,
                "2026-10-14T00:54:00Z": 95.05,
                "2026-10-14T00:55:00Z": 95.03,
                "2026-10-14T00:56:00Z": 95.02,
                "2026-10-14T00:57:00Z": 95.02,
                "2026-10-14T00:58:00Z": 95.01,
                "2026-10-14T00:59:00Z": 95.09,
                "2026-10-14T01:00:00Z": 95.09,
                "2026-10-14T01:01:00Z": 95.24,
                "2026-10-14T01:02:00Z": 95.27,
                "2026-10-14T01:03:00Z": 95.24,
                "2026-10-14T01:04:00Z": 95.3,
                "2026-10-14T01:05:00Z": 95.38,
                "2026-10-14T01:06:00Z": 95.38,
                "2026-10-14T01:07:00Z": 95.29,
                "2026-10-14T01:08:00Z": 95.36,
                "2026-10-14T01:09:00Z": 95.31,
                "2026-10-14T01:10:00Z": 95.29,
                "2026-10-14T01:11:00Z": 95.4,
                "2026-10-14T01:12:00Z": 95.36,
                "2026-10-14T01:13:00Z": 95.27,
                "2026-10-14T01:14:00Z": 95.31,
                "2026-10-14T01:15:00Z": 95.35,
                "2026-10-14T01:16:00Z": 95.4,
                "2026-10-14T01:17:00Z": 95.37,
                "2026-10-14T01:18:00Z": 95.4,
                "2026-10-14T01:19:00Z": 95.4,
                "2026-10-14T01:20:00Z": 95.37,
                "2026-10-14T01:21:00Z": 95.35,
                "2026-10-14T01:22:00Z": 95.35,
                "2026-10-14T01:23:00Z": 95.33,
                "2026-10-14T01:24:00Z": 95.3,
                "2026-10-14T01:25:00Z": 95.28,
                "2026-10-14T01:26:00Z": 95.29,
                "2026-10-14T01:27:00Z": 95.27,
                "2026-10-14T01:28:00Z": 95.29,
                "2026-10-14T01:29:00Z": 95.3,
                "2026-10-14T01:30:00Z": 95.35,
                "2026-10-14T01:31:00Z": 95.17,
                "2026-10-14T01:32:00Z": 95.18,
                "2026-10-14T01:33:00Z": 95.18,
                "2026-10-14T01:34:00Z": 95.2,
                "2026-10-14T01:35:00Z": 95.23,
                "2026-10-14T01:36:00Z": 95.21,
                "2026-10-14T01:37:00Z": 95.25,
                "2026-10-14T01:38:00Z": 95.25,
                "2026-10-14T01:39:00Z": 95.29
              },
              "metadata": {
                "WTIOIL-FUT": {
                  "unit": "Bbl",
                  "quote": "USD"
                }
              },
              "unresolved": {
                "key": {
                  "message": "message",
                  "resolvedTo": "resolvedTo",
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
                    .WithPath("/v2.0/commodity/rates/intraday")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("symbols", "symbols")
                    .WithParam("interval", "1m")
                    .WithParam("date", "2023-01-15")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommodityIntradayRatesV2Async(
            new CommodityIntradayRatesV2Request
            {
                ApiKey = "apiKey",
                Symbols = "symbols",
                Interval = CommodityIntradayRatesV2RequestInterval.OneM,
                Date = new DateOnly(2023, 1, 15),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string mockResponse = """
            {
              "success": true,
              "symbol": "XAU",
              "date": "2026-10-14",
              "interval": "4h",
              "startTime": "12:00",
              "count": 3,
              "rates": {
                "2026-10-14T12:00:00Z": 4139.81,
                "2026-10-14T16:00:00Z": 4080.88,
                "2026-10-14T20:00:00Z": 4101.92
              },
              "metadata": {
                "key": {
                  "unit": "unit",
                  "quote": "quote"
                }
              },
              "unresolved": {
                "key": {
                  "message": "message",
                  "resolvedTo": "resolvedTo",
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
                    .WithPath("/v2.0/commodity/rates/intraday")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("symbols", "symbols")
                    .WithParam("interval", "1m")
                    .WithParam("date", "2023-01-15")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommodityIntradayRatesV2Async(
            new CommodityIntradayRatesV2Request
            {
                ApiKey = "apiKey",
                Symbols = "symbols",
                Interval = CommodityIntradayRatesV2RequestInterval.OneM,
                Date = new DateOnly(2023, 1, 15),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_5()
    {
        const string mockResponse = """
            {
              "success": true,
              "symbol": "XAU",
              "date": "2026-10-14",
              "interval": "4h",
              "startTime": "12:00",
              "count": 3,
              "rates": {
                "2026-10-14T12:00:00Z": 4139.81,
                "2026-10-14T16:00:00Z": 4080.88,
                "2026-10-14T20:00:00Z": 4101.92
              },
              "metadata": {
                "XAU": {
                  "unit": "T.oz",
                  "quote": "USD"
                }
              },
              "unresolved": {
                "GOLD": {
                  "message": "GOLD is not a symbol code used by this API. Gold is available as \"XAU\", so its rate was returned under that symbol.",
                  "resolvedTo": "XAU",
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
                    .WithPath("/v2.0/commodity/rates/intraday")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("symbols", "symbols")
                    .WithParam("interval", "1m")
                    .WithParam("date", "2023-01-15")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CommodityIntradayRatesV2Async(
            new CommodityIntradayRatesV2Request
            {
                ApiKey = "apiKey",
                Symbols = "symbols",
                Interval = CommodityIntradayRatesV2RequestInterval.OneM,
                Date = new DateOnly(2023, 1, 15),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

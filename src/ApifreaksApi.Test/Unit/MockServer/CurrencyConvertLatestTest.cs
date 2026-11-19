using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CurrencyConvertLatestTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "date": "date",
              "from": "from",
              "to": "to",
              "rate": "rate",
              "givenAmount": "givenAmount",
              "convertedAmount": "convertedAmount"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/currency/converter/latest/prices")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("from", "from")
                    .WithParam("to", "to")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CurrencyConvertLatestAsync(
            new CurrencyConvertLatestRequest
            {
                ApiKey = "apiKey",
                From = "from",
                To = "to",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "date": "date",
              "from": "from",
              "to": "to",
              "rate": "rate",
              "givenAmount": "givenAmount",
              "convertedAmount": "convertedAmount"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/currency/converter/latest/prices")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("from", "from")
                    .WithParam("to", "to")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CurrencyConvertLatestAsync(
            new CurrencyConvertLatestRequest
            {
                ApiKey = "apiKey",
                From = "from",
                To = "to",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

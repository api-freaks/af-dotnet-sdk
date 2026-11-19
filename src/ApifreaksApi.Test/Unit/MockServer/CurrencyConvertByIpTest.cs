using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CurrencyConvertByIpTest : BaseMockServerTest
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
              "ipAddress": "ipAddress",
              "givenAmount": "givenAmount",
              "convertedAmount": "convertedAmount"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/currency/converter/ip-to-currency")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("from", "from")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CurrencyConvertByIpAsync(
            new CurrencyConvertByIpRequest { ApiKey = "apiKey", From = "from" }
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
              "ipAddress": "ipAddress",
              "givenAmount": "givenAmount",
              "convertedAmount": "convertedAmount"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/currency/converter/ip-to-currency")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("from", "from")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CurrencyConvertByIpAsync(
            new CurrencyConvertByIpRequest { ApiKey = "apiKey", From = "from" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

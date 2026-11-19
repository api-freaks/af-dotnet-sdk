using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CurrencySupportedTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "supportedCurrenciesMap": {
                "supportedCurrenciesMap": {
                  "currencyCode": "currencyCode",
                  "currencyName": "currencyName",
                  "countryCode": "countryCode",
                  "countryName": "countryName",
                  "status": "AVAILABLE",
                  "availableFrom": "availableFrom",
                  "availableUntil": "availableUntil",
                  "icon": "icon"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/currency/supported")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CurrencySupportedAsync(
            new CurrencySupportedRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "supportedCurrenciesMap": {
                "key": {
                  "currencyCode": "currencyCode",
                  "currencyName": "currencyName",
                  "countryCode": "countryCode",
                  "countryName": "countryName",
                  "status": "AVAILABLE",
                  "availableFrom": "availableFrom",
                  "availableUntil": "availableUntil",
                  "icon": "icon"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/currency/supported")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CurrencySupportedAsync(
            new CurrencySupportedRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class VatRateByIpTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            [
              {
                "country": "country",
                "type": "type",
                "currency": "currency",
                "standard_rate": 1.1,
                "reduced_rate": [
                  1.1,
                  1.1
                ],
                "super_reduced_rate": [
                  1.1,
                  1.1
                ],
                "parking_rate": 1.1,
                "categories": {
                  "categories": 1.1
                },
                "state": "state"
              },
              {
                "country": "country",
                "type": "type",
                "currency": "currency",
                "standard_rate": 1.1,
                "reduced_rate": [
                  1.1,
                  1.1
                ],
                "super_reduced_rate": [
                  1.1,
                  1.1
                ],
                "parking_rate": 1.1,
                "categories": {
                  "categories": 1.1
                },
                "state": "state"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/vat/rates/ip-address")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.VatRateByIpAsync(new VatRateByIpRequest { ApiKey = "apiKey" });
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            [
              {
                "country": "DE",
                "type": "vat",
                "currency": "EUR",
                "standard_rate": 0.19,
                "reduced_rate": [
                  0.07,
                  0
                ],
                "super_reduced_rate": [
                  0.021
                ],
                "parking_rate": 0.19,
                "categories": {
                  "broadcasting": 0.19,
                  "books": 0.07,
                  "newspapers": 0.07,
                  "periodicals": 0.07
                },
                "state": "state"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/vat/rates/ip-address")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.VatRateByIpAsync(new VatRateByIpRequest { ApiKey = "apiKey" });
        JsonAssert.AreEqual(response, mockResponse);
    }
}

using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class VatSupportedCountriesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "VAT_Supported_Countries_And_States": [
                {
                  "VAT_Supported_Countries_And_States": {
                    "code": "code",
                    "states": {
                      "states": "states"
                    }
                  }
                },
                {
                  "VAT_Supported_Countries_And_States": {
                    "code": "code",
                    "states": {
                      "states": "states"
                    }
                  }
                }
              ],
              "IBAN_Supported_Countries": [
                {
                  "countryCode": "countryCode",
                  "name": "name"
                },
                {
                  "countryCode": "countryCode",
                  "name": "name"
                }
              ],
              "SWIFT_Supported_Countries": [
                {
                  "name": "name",
                  "countryCode": "countryCode"
                },
                {
                  "name": "name",
                  "countryCode": "countryCode"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/vat/supported-countries")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.VatSupportedCountriesAsync(
            new VatSupportedCountriesRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "VAT_Supported_Countries_And_States": [
                {
                  "afghanistan": {
                    "code": "af"
                  }
                },
                {
                  "albania": {
                    "code": "al"
                  }
                },
                {
                  "algeria": {
                    "code": "dz"
                  }
                }
              ],
              "IBAN_Supported_Countries": [
                {
                  "countryCode": "AL",
                  "name": "Albania"
                },
                {
                  "countryCode": "AD",
                  "name": "Andorra"
                },
                {
                  "countryCode": "AT",
                  "name": "Austria"
                },
                {
                  "countryCode": "AZ",
                  "name": "Azerbaijan"
                }
              ],
              "SWIFT_Supported_Countries": [
                {
                  "name": "Albania",
                  "countryCode": "AL"
                },
                {
                  "name": "Andorra",
                  "countryCode": "AD"
                },
                {
                  "name": "Argentina",
                  "countryCode": "AR"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/vat/supported-countries")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.VatSupportedCountriesAsync(
            new VatSupportedCountriesRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

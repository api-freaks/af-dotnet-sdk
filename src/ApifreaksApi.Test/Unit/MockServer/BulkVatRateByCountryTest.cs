using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class BulkVatRateByCountryTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "countries": [
                {
                  "country": "country"
                },
                {
                  "country": "country"
                }
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "country": "country",
                "state": "state",
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
                }
              },
              {
                "country": "country",
                "state": "state",
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
                }
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/vat/rates/country")
                    .WithParam("apiKey", "apiKey")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.BulkVatRateByCountryAsync(
            new BulkVatRateByCountryRequest
            {
                ApiKey = "apiKey",
                Countries = new List<BulkVatRateByCountryRequestCountriesItem>()
                {
                    new BulkVatRateByCountryRequestCountriesItem
                    {
                        Country = "country",
                        State = null,
                    },
                    new BulkVatRateByCountryRequestCountriesItem
                    {
                        Country = "country",
                        State = null,
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "countries": [
                {
                  "country": "PAK"
                },
                {
                  "country": "United_States",
                  "state": "New_York"
                }
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "country": "DE",
                "state": "New_York",
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
                  "books": 0.07,
                  "newspapers": 0.07,
                  "periodicals": 0.07,
                  "broadcasting": 0.19
                }
              },
              {
                "country": "USA",
                "state": "CA",
                "type": "vat",
                "currency": "",
                "standard_rate": 0.0825,
                "reduced_rate": [
                  0.055,
                  0
                ],
                "super_reduced_rate": [
                  0.021
                ],
                "parking_rate": 0.19,
                "categories": {
                  "books": 0.055,
                  "newspapers": 0.021,
                  "periodicals": 0.021,
                  "broadcasting": 0.1
                }
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/vat/rates/country")
                    .WithParam("apiKey", "apiKey")
                    .WithHeader("Content-Type", "application/json")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.BulkVatRateByCountryAsync(
            new BulkVatRateByCountryRequest
            {
                ApiKey = "apiKey",
                Countries = new List<BulkVatRateByCountryRequestCountriesItem>()
                {
                    new BulkVatRateByCountryRequestCountriesItem { Country = "PAK" },
                    new BulkVatRateByCountryRequestCountriesItem
                    {
                        Country = "United_States",
                        State = "New_York",
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

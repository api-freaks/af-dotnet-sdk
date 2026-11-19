using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetCountriesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "countries": [
                {
                  "name": "name",
                  "iso_alpha_2": "iso_alpha_2",
                  "iso_alpha_3": "iso_alpha_3",
                  "iso_numeric": 1,
                  "capital": "capital",
                  "region": "region",
                  "subregion": "subregion"
                },
                {
                  "name": "name",
                  "iso_alpha_2": "iso_alpha_2",
                  "iso_alpha_3": "iso_alpha_3",
                  "iso_numeric": 1,
                  "capital": "capital",
                  "region": "region",
                  "subregion": "subregion"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geo/countries")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.GetCountriesAsync(
            new GetCountriesRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "countries": [
                {
                  "name": "name",
                  "iso_alpha_2": "iso_alpha_2",
                  "iso_alpha_3": "iso_alpha_3",
                  "iso_numeric": 1,
                  "capital": "capital",
                  "region": "region",
                  "subregion": "subregion"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geo/countries")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.GetCountriesAsync(
            new GetCountriesRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

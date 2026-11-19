using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetCitiesTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "cities": [
                {
                  "name": "name",
                  "latitude": 1.1,
                  "longitude": 1.1,
                  "admin_unit": {
                    "name": "name",
                    "admin_code": "admin_code",
                    "admin_level": "admin_level"
                  },
                  "iso_alpha_2": "iso_alpha_2"
                },
                {
                  "name": "name",
                  "latitude": 1.1,
                  "longitude": 1.1,
                  "admin_unit": {
                    "name": "name",
                    "admin_code": "admin_code",
                    "admin_level": "admin_level"
                  },
                  "iso_alpha_2": "iso_alpha_2"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geo/cities")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("country", "country")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.GetCitiesAsync(
            new GetCitiesRequest { ApiKey = "apiKey", Country = "country" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "cities": [
                {
                  "name": "name",
                  "latitude": 1.1,
                  "longitude": 1.1,
                  "admin_unit": {
                    "name": "name",
                    "admin_code": "admin_code",
                    "admin_level": "admin_level"
                  },
                  "iso_alpha_2": "iso_alpha_2"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geo/cities")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("country", "country")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.GetCitiesAsync(
            new GetCitiesRequest { ApiKey = "apiKey", Country = "country" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

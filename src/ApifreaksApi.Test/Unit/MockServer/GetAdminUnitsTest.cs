using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetAdminUnitsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "admin_units": [
                {
                  "name": "name",
                  "admin_code": "admin_code",
                  "admin_level": "admin_level"
                },
                {
                  "name": "name",
                  "admin_code": "admin_code",
                  "admin_level": "admin_level"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geo/admin-units")
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

        var response = await Client.GetAdminUnitsAsync(
            new GetAdminUnitsRequest { ApiKey = "apiKey", Country = "country" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "admin_units": [
                {
                  "name": "name",
                  "admin_code": "admin_code",
                  "admin_level": "admin_level"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geo/admin-units")
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

        var response = await Client.GetAdminUnitsAsync(
            new GetAdminUnitsRequest { ApiKey = "apiKey", Country = "country" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

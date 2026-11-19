using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetAdminLevelsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "admin_levels": [
                "admin_levels",
                "admin_levels"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geo/admin-levels")
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

        var response = await Client.GetAdminLevelsAsync(
            new GetAdminLevelsRequest { ApiKey = "apiKey", Country = "country" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "admin_levels": [
                "admin_levels"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geo/admin-levels")
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

        var response = await Client.GetAdminLevelsAsync(
            new GetAdminLevelsRequest { ApiKey = "apiKey", Country = "country" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

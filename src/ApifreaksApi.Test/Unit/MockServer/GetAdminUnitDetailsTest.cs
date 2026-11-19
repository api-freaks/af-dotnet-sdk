using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetAdminUnitDetailsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "name": "name",
              "admin_code": "admin_code",
              "admin_iso3166_2": "admin_iso3166_2",
              "admin_level": "admin_level",
              "country_iso3166_2": "country_iso3166_2",
              "country_name": "country_name"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geo/admin-unit/details")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("country", "country")
                    .WithParam("admin_unit", "admin_unit")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.GetAdminUnitDetailsAsync(
            new GetAdminUnitDetailsRequest
            {
                ApiKey = "apiKey",
                Country = "country",
                AdminUnit = "admin_unit",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "name": "Bavaria",
              "admin_code": "BY",
              "admin_iso3166_2": "DE-BY",
              "admin_level": "land",
              "country_iso3166_2": "DE",
              "country_name": "Germany"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geo/admin-unit/details")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("country", "country")
                    .WithParam("admin_unit", "admin_unit")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.GetAdminUnitDetailsAsync(
            new GetAdminUnitDetailsRequest
            {
                ApiKey = "apiKey",
                Country = "country",
                AdminUnit = "admin_unit",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

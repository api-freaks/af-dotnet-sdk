using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetCountryDetailsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "name": "name",
              "iso_alpha_2": "iso_alpha_2",
              "iso_alpha_3": "iso_alpha_3",
              "iso_numeric": 1,
              "phone_code": 1,
              "capital": "capital",
              "top_level_domain": "top_level_domain",
              "native_name": "native_name",
              "region": "region",
              "subregion": "subregion",
              "nationality": "nationality",
              "flag_emoji": "flag_emoji",
              "currency_code": "currency_code",
              "currency_name": "currency_name",
              "currency_symbol": "currency_symbol"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geo/country/details")
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

        var response = await Client.GetCountryDetailsAsync(
            new GetCountryDetailsRequest { ApiKey = "apiKey", Country = "country" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "name": "name",
              "iso_alpha_2": "iso_alpha_2",
              "iso_alpha_3": "iso_alpha_3",
              "iso_numeric": 1,
              "phone_code": 1,
              "capital": "capital",
              "top_level_domain": "top_level_domain",
              "native_name": "native_name",
              "region": "region",
              "subregion": "subregion",
              "nationality": "nationality",
              "flag_emoji": "flag_emoji",
              "currency_code": "currency_code",
              "currency_name": "currency_name",
              "currency_symbol": "currency_symbol"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geo/country/details")
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

        var response = await Client.GetCountryDetailsAsync(
            new GetCountryDetailsRequest { ApiKey = "apiKey", Country = "country" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

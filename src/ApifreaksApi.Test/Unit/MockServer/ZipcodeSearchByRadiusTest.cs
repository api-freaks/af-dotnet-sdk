using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ZipcodeSearchByRadiusTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "total_results": 1,
              "total_pages": 1,
              "current_page": 1,
              "current_page_size": 1,
              "results": [
                {
                  "code": "code",
                  "region": "region",
                  "region_code": "region_code",
                  "city": "city",
                  "district": "district",
                  "distance": 1.1
                },
                {
                  "code": "code",
                  "region": "region",
                  "region_code": "region_code",
                  "city": "city",
                  "district": "district",
                  "distance": 1.1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/zipcode/search/radius")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("radius", "1.1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.ZipcodeSearchByRadiusAsync(
            new ZipcodeSearchByRadiusRequest { ApiKey = "apiKey", Radius = 1.1f }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "total_results": 2303,
              "total_pages": 5,
              "current_page": 1,
              "current_page_size": 500,
              "results": [
                {
                  "code": "49608",
                  "region": "Punjab",
                  "region_code": "PB",
                  "city": "Tahlian Wala",
                  "district": "",
                  "distance": 14.835
                },
                {
                  "code": "49610",
                  "region": "Punjab",
                  "region_code": "PB",
                  "city": "Alliance Textile Mills",
                  "district": "",
                  "distance": 14.835
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/zipcode/search/radius")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("radius", "1.1")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.ZipcodeSearchByRadiusAsync(
            new ZipcodeSearchByRadiusRequest { ApiKey = "apiKey", Radius = 1.1f }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

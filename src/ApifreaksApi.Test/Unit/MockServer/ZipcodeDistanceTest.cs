using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ZipcodeDistanceTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "compare": [
                "compare",
                "compare"
              ],
              "country": "country"
            }
            """;

        const string mockResponse = """
            {
              "result_count": 1,
              "results": [
                {
                  "code": "code",
                  "distance": 1.1
                },
                {
                  "code": "code",
                  "distance": 1.1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/zipcode/distance")
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

        var response = await Client.ZipcodeDistanceAsync(
            new ZipcodeDistanceRequest
            {
                ApiKey = "apiKey",
                Compare = new List<string>() { "compare", "compare" },
                Code = null,
                Lat = null,
                Long = null,
                Country = "country",
                Unit = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "compare": [
                "compare"
              ],
              "country": "country"
            }
            """;

        const string mockResponse = """
            {
              "result_count": 2,
              "results": [
                {
                  "code": "49610",
                  "distance": 14.835
                },
                {
                  "code": "49608",
                  "distance": 14.835
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/zipcode/distance")
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

        var response = await Client.ZipcodeDistanceAsync(
            new ZipcodeDistanceRequest
            {
                ApiKey = "apiKey",
                Compare = new List<string>() { "compare" },
                Country = "country",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

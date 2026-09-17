using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ZipcodeDistanceMatchTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "codes": [
                "codes"
              ],
              "country": "country"
            }
            """;

        const string mockResponse = """
            {
              "result_count": 1,
              "results": [
                {
                  "code_1": "49610",
                  "code_2": "55270",
                  "distance": 14.835
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/zipcode/distance/match")
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

        var response = await Client.ZipcodeDistanceMatchAsync(
            new ZipcodeDistanceMatchRequest
            {
                ApiKey = "apiKey",
                Codes = new List<string>() { "codes" },
                Country = "country",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

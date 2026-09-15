using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UserAgentLookupTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "user_agent_string": "user_agent_string",
              "name": "name",
              "type": "type",
              "version": "version",
              "version_major": "version_major",
              "device": {
                "name": "name",
                "type": "type",
                "brand": "brand",
                "cpu": "cpu"
              },
              "engine": {
                "name": "name",
                "type": "type",
                "version": "version",
                "version_major": "version_major"
              },
              "operating_system": {
                "name": "name",
                "type": "type",
                "version": "version",
                "version_major": "version_major",
                "build": "build"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/user-agent/lookup")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.UserAgentLookupAsync(
            new UserAgentLookupRequest { ApiKey = "apiKey", UserAgent = "userAgent" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

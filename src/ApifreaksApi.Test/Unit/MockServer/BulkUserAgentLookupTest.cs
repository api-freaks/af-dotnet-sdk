using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class BulkUserAgentLookupTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "uaStrings": [
                "uaStrings",
                "uaStrings"
              ]
            }
            """;

        const string mockResponse = """
            [
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
                },
                "message": "message"
              },
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
                },
                "message": "message"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/user-agent/lookup")
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

        var response = await Client.BulkUserAgentLookupAsync(
            new BulkUserAgentLookupRequest
            {
                ApiKey = "apiKey",
                UaStrings = new List<string>() { "uaStrings", "uaStrings" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "uaStrings": [
                "uaStrings"
              ]
            }
            """;

        const string mockResponse = """
            [
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
                },
                "message": "message"
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/user-agent/lookup")
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

        var response = await Client.BulkUserAgentLookupAsync(
            new BulkUserAgentLookupRequest
            {
                ApiKey = "apiKey",
                UaStrings = new List<string>() { "uaStrings" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

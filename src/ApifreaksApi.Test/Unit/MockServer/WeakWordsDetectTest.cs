using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class WeakWordsDetectTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "text": "text"
            }
            """;

        const string mockResponse = """
            {
              "weak_words": [
                {
                  "word": "word",
                  "offset": 1
                },
                {
                  "word": "word",
                  "offset": 1
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/readability/weak-words")
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

        var response = await Client.WeakWordsDetectAsync(
            new WeakWordsDetectRequest { ApiKey = "apiKey", Text = "text" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "text": "Many people cannot get the support they need to handle their conditions well."
            }
            """;

        const string mockResponse = """
            {
              "weak_words": [
                {
                  "word": "cannot",
                  "offset": 80
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/readability/weak-words")
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

        var response = await Client.WeakWordsDetectAsync(
            new WeakWordsDetectRequest
            {
                ApiKey = "apiKey",
                Text =
                    "Many people cannot get the support they need to handle their conditions well.",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

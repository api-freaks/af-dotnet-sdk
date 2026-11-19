using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ReadabilityScoreTest : BaseMockServerTest
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
              "readability_scores": {
                "flesch_reading_ease": {
                  "score": 1.1,
                  "level": "level"
                },
                "flesch_kincaid_grade": {
                  "score": 1.1,
                  "level": "level"
                },
                "gunning_fog": {
                  "score": 1.1,
                  "level": "level"
                },
                "smog_index": {
                  "score": 1.1,
                  "level": "level"
                },
                "coleman_liau_index": {
                  "score": 1.1,
                  "level": "level"
                },
                "automated_readability_index": {
                  "score": 1.1,
                  "level": "level"
                }
              },
              "sentence_readability": [
                {
                  "sentence": "sentence",
                  "readability_grade": 1.1,
                  "readability_level": "Very Easy"
                },
                {
                  "sentence": "sentence",
                  "readability_grade": 1.1,
                  "readability_level": "Very Easy"
                }
              ],
              "readability_grade": 1.1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/readability/score")
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

        var response = await Client.ReadabilityScoreAsync(
            new ReadabilityScoreRequest { ApiKey = "apiKey", Text = "text" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "text": "The global mental is health crisis is now a serious and compelex problem. It needs quick and ongoing action from policymakers, healthcare workers, and the whole society."
            }
            """;

        const string mockResponse = """
            {
              "readability_scores": {
                "flesch_reading_ease": {
                  "score": 51.9903,
                  "level": "Fairly Difficult"
                },
                "flesch_kincaid_grade": {
                  "score": 9.7755,
                  "level": "Grade 10"
                },
                "gunning_fog": {
                  "score": 10.4623,
                  "level": "Standard"
                },
                "smog_index": {
                  "score": 10.8642,
                  "level": "Grade 11"
                },
                "coleman_liau_index": {
                  "score": 13.033,
                  "level": "Grade 13"
                },
                "automated_readability_index": {
                  "score": 12.0325,
                  "level": "Grade 12"
                }
              },
              "sentence_readability": [
                {
                  "sentence": "The global mental is health crisis is now a serious and compelex problem.",
                  "readability_grade": 8.9496,
                  "readability_level": "Easy"
                }
              ],
              "readability_grade": 11.8783
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/readability/score")
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

        var response = await Client.ReadabilityScoreAsync(
            new ReadabilityScoreRequest
            {
                ApiKey = "apiKey",
                Text =
                    "The global mental is health crisis is now a serious and compelex problem. It needs quick and ongoing action from policymakers, healthcare workers, and the whole society.",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

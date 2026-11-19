using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class SubdomainsLookupTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "domain": "domain",
              "status": true,
              "query_time": "query_time",
              "current_page": 1,
              "total_pages": 1,
              "total_records": 1,
              "subdomains": [
                {
                  "subdomain": "subdomain",
                  "first_seen": "first_seen",
                  "last_seen": "last_seen",
                  "inactive_from": "inactive_from"
                },
                {
                  "subdomain": "subdomain",
                  "first_seen": "first_seen",
                  "last_seen": "last_seen",
                  "inactive_from": "inactive_from"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/subdomains/lookup")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("domain", "domain")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.SubdomainsLookupAsync(
            new SubdomainsLookupRequest { ApiKey = "apiKey", Domain = "domain" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "domain": "domain",
              "status": true,
              "query_time": "query_time",
              "current_page": 1,
              "total_pages": 1,
              "total_records": 1,
              "subdomains": [
                {
                  "subdomain": "subdomain",
                  "first_seen": "first_seen",
                  "last_seen": "last_seen",
                  "inactive_from": "inactive_from"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/subdomains/lookup")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("domain", "domain")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.SubdomainsLookupAsync(
            new SubdomainsLookupRequest { ApiKey = "apiKey", Domain = "domain" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

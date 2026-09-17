using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class BulkDomainWhoisLookupTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "domainNames": [
                "domainNames"
              ]
            }
            """;

        const string mockResponse = """
            {
              "bulk_whois_response": [
                {
                  "status": true,
                  "domain_name": "domain_name",
                  "query_time": "query_time",
                  "whois_server": "whois_server",
                  "domain_registered": "yes",
                  "create_date": "2023-01-15",
                  "update_date": "2023-01-15",
                  "expiry_date": "2023-01-15",
                  "name_servers": [
                    "name_servers"
                  ],
                  "domain_status": [
                    "domain_status"
                  ],
                  "whois_raw_domain": "whois_raw_domain"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/domain/whois/live")
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

        var response = await Client.BulkDomainWhoisLookupAsync(
            new BulkDomainWhoisLookupRequest
            {
                ApiKey = "apiKey",
                DomainNames = new List<string>() { "domainNames" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DomainWhoisHistoryTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "status": true,
              "whois": "historical",
              "total_records": "total_records",
              "whois_domains_historical": [
                {
                  "num": 1,
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
                    .WithPath("/v1.0/domain/whois/history")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("domainName", "domainName")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DomainWhoisHistoryAsync(
            new DomainWhoisHistoryRequest { ApiKey = "apiKey", DomainName = "domainName" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

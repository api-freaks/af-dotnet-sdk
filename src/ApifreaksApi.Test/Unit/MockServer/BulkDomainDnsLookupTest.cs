using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class BulkDomainDnsLookupTest : BaseMockServerTest
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
              "bulk_dns_info": [
                {
                  "status": true,
                  "queryTime": "queryTime",
                  "domainName": "domainName",
                  "domainRegistered": true,
                  "ipAddress": "ipAddress",
                  "dnsTypes": {},
                  "dnsRecords": [
                    {
                      "name": "name",
                      "type": 1,
                      "dnsType": "A",
                      "ttl": 1,
                      "rawText": "rawText",
                      "rRsetType": 1,
                      "address": "address"
                    }
                  ]
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/domain/dns/live")
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

        var response = await Client.BulkDomainDnsLookupAsync(
            new BulkDomainDnsLookupRequest
            {
                ApiKey = "apiKey",
                Type = new List<string>() { "type" },
                DomainNames = new List<string>() { "domainNames" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DomainDnsLookupTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "status": true,
              "queryTime": "queryTime",
              "domainName": "domainName",
              "domainRegistered": true,
              "dnsTypes": {
                "A": 1.1,
                "AAAA": 1.1,
                "CNAME": 1.1,
                "MX": 1.1,
                "NS": 1.1,
                "SOA": 1.1,
                "TXT": 1.1,
                "SPF": 1.1
              },
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/domain/dns/live")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DomainDnsLookupAsync(
            new DomainDnsLookupRequest
            {
                ApiKey = "apiKey",
                Type = new List<string>() { "type" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

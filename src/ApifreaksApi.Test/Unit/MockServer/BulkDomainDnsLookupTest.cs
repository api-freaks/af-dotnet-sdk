using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class BulkDomainDnsLookupTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "domainNames": [
                "domainNames",
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
                  "dnsTypes": {
                    "A": 1.1,
                    "AAAA": 1.1,
                    "CNAME": 1.1,
                    "MX": 1.1,
                    "NS": 1.1,
                    "SOA": 1.1,
                    "TXT": 1.1,
                    "SPF": 1.1,
                    "PTR": 1.1
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
                    },
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
                },
                {
                  "status": true,
                  "queryTime": "queryTime",
                  "domainName": "domainName",
                  "domainRegistered": true,
                  "ipAddress": "ipAddress",
                  "dnsTypes": {
                    "A": 1.1,
                    "AAAA": 1.1,
                    "CNAME": 1.1,
                    "MX": 1.1,
                    "NS": 1.1,
                    "SOA": 1.1,
                    "TXT": 1.1,
                    "SPF": 1.1,
                    "PTR": 1.1
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
                    },
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
                DomainNames = new List<string>() { "domainNames", "domainNames" },
                IpAddresses = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
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

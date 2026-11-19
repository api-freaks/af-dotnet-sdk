using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DomainDnsReverseTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "totalRecords": 1,
              "totalPages": 1,
              "currentPage": 1,
              "reverseDnsRecords": [
                {
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
                    .WithPath("/v1.0/domain/dns/reverse")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("type", "A")
                    .WithParam("value", "value")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DomainDnsReverseAsync(
            new DomainDnsReverseRequest
            {
                ApiKey = "apiKey",
                Type = DomainDnsReverseRequestType.A,
                Value = "value",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "totalRecords": 1,
              "totalPages": 1,
              "currentPage": 1,
              "reverseDnsRecords": [
                {
                  "queryTime": "queryTime",
                  "domainName": "domainName",
                  "domainRegistered": true,
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
                    .WithPath("/v1.0/domain/dns/reverse")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("type", "A")
                    .WithParam("value", "value")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.DomainDnsReverseAsync(
            new DomainDnsReverseRequest
            {
                ApiKey = "apiKey",
                Type = DomainDnsReverseRequestType.A,
                Value = "value",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class BulkDomainAvailabilityCheckTest : BaseMockServerTest
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
              "bulk_domain_available_response": [
                {
                  "domain": "domain",
                  "domainAvailability": true,
                  "status": true
                },
                {
                  "domain": "domain",
                  "domainAvailability": true,
                  "status": true
                }
              ],
              "bulk_domain_availability_response": [
                {
                  "domain": "domain",
                  "domainAvailability": true,
                  "status": true
                },
                {
                  "domain": "domain",
                  "domainAvailability": true,
                  "status": true
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/domain/availability")
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

        var response = await Client.BulkDomainAvailabilityCheckAsync(
            new BulkDomainAvailabilityCheckRequest
            {
                ApiKey = "apiKey",
                DomainNames = new List<string>() { "domainNames", "domainNames" },
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
              "bulk_domain_availability_response": [
                {
                  "domain": "domain",
                  "domainAvailability": true,
                  "status": true
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/domain/availability")
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

        var response = await Client.BulkDomainAvailabilityCheckAsync(
            new BulkDomainAvailabilityCheckRequest
            {
                ApiKey = "apiKey",
                DomainNames = new List<string>() { "domainNames" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DomainAvailabilityCheckTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "domain": "domain",
              "domainAvailability": true,
              "message": "message"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/domain/availability")
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

        var response = await Client.DomainAvailabilityCheckAsync(
            new DomainAvailabilityCheckRequest { ApiKey = "apiKey", Domain = "domain" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "domain": "domain",
              "domainAvailability": true,
              "message": "message"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/domain/availability")
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

        var response = await Client.DomainAvailabilityCheckAsync(
            new DomainAvailabilityCheckRequest { ApiKey = "apiKey", Domain = "domain" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

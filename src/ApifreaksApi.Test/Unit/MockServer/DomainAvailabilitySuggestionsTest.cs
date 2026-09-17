using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DomainAvailabilitySuggestionsTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "domain": "domain",
              "domainAvailability": true
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/domain/availability/suggestions")
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

        var response = await Client.DomainAvailabilitySuggestionsAsync(
            new DomainAvailabilitySuggestionsRequest { ApiKey = "apiKey", Domain = "domain" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

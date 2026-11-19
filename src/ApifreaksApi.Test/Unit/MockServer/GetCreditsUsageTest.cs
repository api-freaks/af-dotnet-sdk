using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetCreditsUsageTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "apiKey": "apiKey",
              "userStatus": "active",
              "subActive": true,
              "subStatus": "active",
              "subAllowedCredits": 1,
              "subUsedCredits": 1,
              "subSurchargeStatus": "none",
              "subSurchargeAllowedCredits": 1,
              "subSurchargeUsedCredits": 1,
              "subSurchargeAllowed": true,
              "oneOffCreditsActive": true,
              "oneOffAllowedCredits": 1,
              "oneOffUsedCredits": 1
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/credits/usage/info")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.GetCreditsUsageAsync(
            new GetCreditsUsageRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "apiKey": "demo",
              "userStatus": "active",
              "subActive": true,
              "subStatus": "active",
              "subAllowedCredits": 10000,
              "subUsedCredits": 2500,
              "subSurchargeStatus": "none",
              "subSurchargeAllowedCredits": 0,
              "subSurchargeUsedCredits": 0,
              "subSurchargeAllowed": false,
              "oneOffCreditsActive": true,
              "oneOffAllowedCredits": 5000,
              "oneOffUsedCredits": 1000
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/credits/usage/info")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.GetCreditsUsageAsync(
            new GetCreditsUsageRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class BulkEmailValidateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "emailData": [
                {
                  "email": "email"
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "emailResponse": [
                {
                  "success": true,
                  "email": "email",
                  "name": "name",
                  "reason": "reason",
                  "validEmail": "valid",
                  "validSyntax": true,
                  "domain": {
                    "name": "name",
                    "disposable": true,
                    "spam": true,
                    "free": true,
                    "catchAll": true,
                    "validDomain": true
                  },
                  "account": {
                    "role": true
                  },
                  "dns": {
                    "mxRecord": [
                      "mxRecord"
                    ]
                  },
                  "ip": "ip"
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/email-validation/bulk")
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

        var response = await Client.BulkEmailValidateAsync(
            new BulkEmailValidateRequest
            {
                ApiKey = "apiKey",
                EmailData = new List<BulkEmailValidateRequestEmailDataItem>()
                {
                    new BulkEmailValidateRequestEmailDataItem { Email = "email" },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

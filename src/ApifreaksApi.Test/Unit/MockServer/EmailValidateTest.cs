using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class EmailValidateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string requestJson = """
            {
              "email": "email"
            }
            """;

        const string mockResponse = """
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
                "role": true,
                "fullMailBox": true
              },
              "dns": {
                "mxRecord": [
                  "mxRecord"
                ],
                "aRecord": [
                  "aRecord"
                ]
              },
              "ip": "ip",
              "address": {
                "security": {
                  "threat_score": 1.1,
                  "is_tor": true,
                  "is_proxy": true,
                  "proxy_type": "proxy_type",
                  "proxy_provider": "proxy_provider",
                  "is_anonymous": true,
                  "is_known_attacker": true,
                  "is_spam": true,
                  "is_bot": true,
                  "is_cloud_provider": true,
                  "cloud_provider": "cloud_provider"
                },
                "location": {
                  "city": "city",
                  "district": "district",
                  "confidence": "confidence",
                  "zipcode": "zipcode",
                  "state_prov": "state_prov",
                  "country_name": "country_name",
                  "continent_name": "continent_name",
                  "continent_code": "continent_code",
                  "country_code2": "country_code2",
                  "country_code3": "country_code3",
                  "country_name_official": "country_name_official",
                  "accuracy_radius": "accuracy_radius",
                  "is_eu": true
                },
                "validIpAddress": true
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/email-validation/single")
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

        var response = await Client.EmailValidateAsync(
            new EmailValidateRequest { ApiKey = "apiKey", Email = "email" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

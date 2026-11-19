using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class BulkDisposableEmailCheckV2Test : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "emailData": [
                {
                  "email": "email"
                },
                {
                  "email": "email"
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "disposableEmailResponse": [
                {
                  "email": "email",
                  "validSyntax": true,
                  "domain": {
                    "name": "name",
                    "validDomain": true,
                    "disposable": true,
                    "free": true,
                    "spam": true
                  },
                  "account": {
                    "role": true
                  },
                  "dns": {
                    "mxRecord": [
                      "mxRecord",
                      "mxRecord"
                    ],
                    "aRecord": [
                      "aRecord",
                      "aRecord"
                    ]
                  },
                  "ip": "ip",
                  "address": {
                    "validIpAddress": true,
                    "location": {
                      "city": "city",
                      "district": "district",
                      "zipcode": "zipcode",
                      "state_prov": "state_prov",
                      "country_name": "country_name",
                      "country_name_official": "country_name_official",
                      "country_code2": "country_code2",
                      "country_code3": "country_code3",
                      "continent_name": "continent_name",
                      "continent_code": "continent_code",
                      "accuracy_radius": "accuracy_radius",
                      "confidence": "confidence",
                      "is_eu": true
                    },
                    "security": {
                      "threat_score": 1,
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
                    }
                  }
                },
                {
                  "email": "email",
                  "validSyntax": true,
                  "domain": {
                    "name": "name",
                    "validDomain": true,
                    "disposable": true,
                    "free": true,
                    "spam": true
                  },
                  "account": {
                    "role": true
                  },
                  "dns": {
                    "mxRecord": [
                      "mxRecord",
                      "mxRecord"
                    ],
                    "aRecord": [
                      "aRecord",
                      "aRecord"
                    ]
                  },
                  "ip": "ip",
                  "address": {
                    "validIpAddress": true,
                    "location": {
                      "city": "city",
                      "district": "district",
                      "zipcode": "zipcode",
                      "state_prov": "state_prov",
                      "country_name": "country_name",
                      "country_name_official": "country_name_official",
                      "country_code2": "country_code2",
                      "country_code3": "country_code3",
                      "continent_name": "continent_name",
                      "continent_code": "continent_code",
                      "accuracy_radius": "accuracy_radius",
                      "confidence": "confidence",
                      "is_eu": true
                    },
                    "security": {
                      "threat_score": 1,
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
                    }
                  }
                }
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/email/disposable-check/bulk")
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

        var response = await Client.BulkDisposableEmailCheckV2Async(
            new BulkDisposableEmailCheckV2Request
            {
                ApiKey = "apiKey",
                EmailData = new List<BulkDisposableEmailCheckV2RequestEmailDataItem>()
                {
                    new BulkDisposableEmailCheckV2RequestEmailDataItem
                    {
                        Email = "email",
                        Ip = null,
                    },
                    new BulkDisposableEmailCheckV2RequestEmailDataItem
                    {
                        Email = "email",
                        Ip = null,
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "emailData": [
                {
                  "email": "abc"
                },
                {
                  "email": "john@microsoft.com",
                  "ip": "8.8.8.8"
                },
                {
                  "email": "test@mailinator.com"
                }
              ]
            }
            """;

        const string mockResponse = """
            {
              "disposableEmailResponse": [
                {
                  "email": "abc",
                  "validSyntax": false,
                  "domain": {
                    "name": "abc",
                    "validDomain": false
                  },
                  "account": {
                    "role": true
                  },
                  "ip": "ip"
                },
                {
                  "email": "john@microsoft.com",
                  "validSyntax": true,
                  "domain": {
                    "name": "microsoft.com",
                    "validDomain": true,
                    "disposable": false,
                    "free": false,
                    "spam": false
                  },
                  "account": {
                    "role": false
                  },
                  "dns": {
                    "mxRecord": [
                      "microsoft-com.mail.protection.outlook.com."
                    ]
                  },
                  "ip": "8.8.8.8",
                  "address": {
                    "validIpAddress": true,
                    "location": {
                      "city": "Mountain View",
                      "district": "Santa Clara",
                      "zipcode": "94043-1351",
                      "state_prov": "California",
                      "country_name": "United States",
                      "country_name_official": "United States of America",
                      "country_code2": "US",
                      "country_code3": "USA",
                      "continent_name": "North America",
                      "continent_code": "NA",
                      "is_eu": false
                    },
                    "security": {
                      "threat_score": 5,
                      "is_tor": false,
                      "is_proxy": false,
                      "is_anonymous": false,
                      "is_known_attacker": false,
                      "is_spam": false,
                      "is_bot": false,
                      "is_cloud_provider": true,
                      "cloud_provider": "Google LLC"
                    }
                  }
                },
                {
                  "email": "test@mailinator.com",
                  "validSyntax": true,
                  "domain": {
                    "name": "mailinator.com",
                    "validDomain": true,
                    "disposable": true,
                    "free": false,
                    "spam": false
                  },
                  "account": {
                    "role": false
                  },
                  "dns": {
                    "mxRecord": [
                      "mail.mailinator.com.",
                      "mail2.mailinator.com."
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
                    .WithPath("/v2.0/email/disposable-check/bulk")
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

        var response = await Client.BulkDisposableEmailCheckV2Async(
            new BulkDisposableEmailCheckV2Request
            {
                ApiKey = "apiKey",
                EmailData = new List<BulkDisposableEmailCheckV2RequestEmailDataItem>()
                {
                    new BulkDisposableEmailCheckV2RequestEmailDataItem { Email = "abc" },
                    new BulkDisposableEmailCheckV2RequestEmailDataItem
                    {
                        Email = "john@microsoft.com",
                        Ip = "8.8.8.8",
                    },
                    new BulkDisposableEmailCheckV2RequestEmailDataItem
                    {
                        Email = "test@mailinator.com",
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class DisposableEmailCheckV2Test : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "email": "email"
            }
            """;

        const string mockResponse = """
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/email/disposable-check")
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

        var response = await Client.DisposableEmailCheckV2Async(
            new DisposableEmailCheckV2Request
            {
                ApiKey = "apiKey",
                Email = "email",
                Ip = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "email": "test@sogetthis.com"
            }
            """;

        const string mockResponse = """
            {
              "email": "test@sogetthis.com",
              "validSyntax": true,
              "domain": {
                "name": "sogetthis.com",
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
                  "mail.mailinator.com."
                ],
                "aRecord": [
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/email/disposable-check")
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

        var response = await Client.DisposableEmailCheckV2Async(
            new DisposableEmailCheckV2Request { ApiKey = "apiKey", Email = "test@sogetthis.com" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_3()
    {
        const string requestJson = """
            {
              "email": "someone@gmail.com",
              "ip": "8.8.8.8"
            }
            """;

        const string mockResponse = """
            {
              "email": "test@sogetthis.com",
              "validSyntax": true,
              "domain": {
                "name": "sogetthis.com",
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
                  "mail.mailinator.com."
                ],
                "aRecord": [
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/email/disposable-check")
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

        var response = await Client.DisposableEmailCheckV2Async(
            new DisposableEmailCheckV2Request
            {
                ApiKey = "apiKey",
                Email = "someone@gmail.com",
                Ip = "8.8.8.8",
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_4()
    {
        const string requestJson = """
            {
              "email": "test@sogetthis.com"
            }
            """;

        const string mockResponse = """
            {
              "email": "test@sogetthis.com",
              "validSyntax": true,
              "domain": {
                "name": "sogetthis.com",
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
                  "mail.mailinator.com."
                ],
                "aRecord": [
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/email/disposable-check")
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

        var response = await Client.DisposableEmailCheckV2Async(
            new DisposableEmailCheckV2Request { ApiKey = "apiKey", Email = "test@sogetthis.com" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_5()
    {
        const string requestJson = """
            {
              "email": "test@sogetthis.com"
            }
            """;

        const string mockResponse = """
            {
              "email": "someone@gmail.com",
              "validSyntax": true,
              "domain": {
                "name": "gmail.com",
                "validDomain": true,
                "disposable": false,
                "free": true,
                "spam": false
              },
              "account": {
                "role": false
              },
              "dns": {
                "mxRecord": [
                  "gmail-smtp-in.l.google.com.",
                  "alt1.gmail-smtp-in.l.google.com.",
                  "alt2.gmail-smtp-in.l.google.com.",
                  "alt3.gmail-smtp-in.l.google.com.",
                  "alt4.gmail-smtp-in.l.google.com."
                ],
                "aRecord": [
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/email/disposable-check")
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

        var response = await Client.DisposableEmailCheckV2Async(
            new DisposableEmailCheckV2Request { ApiKey = "apiKey", Email = "test@sogetthis.com" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_6()
    {
        const string requestJson = """
            {
              "email": "test@sogetthis.com"
            }
            """;

        const string mockResponse = """
            {
              "email": "support@microsoft.com",
              "validSyntax": true,
              "domain": {
                "name": "microsoft.com",
                "validDomain": true,
                "disposable": false,
                "free": false,
                "spam": false
              },
              "account": {
                "role": true
              },
              "dns": {
                "mxRecord": [
                  "microsoft-com.mail.protection.outlook.com."
                ],
                "aRecord": [
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/email/disposable-check")
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

        var response = await Client.DisposableEmailCheckV2Async(
            new DisposableEmailCheckV2Request { ApiKey = "apiKey", Email = "test@sogetthis.com" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_7()
    {
        const string requestJson = """
            {
              "email": "test@sogetthis.com"
            }
            """;

        const string mockResponse = """
            {
              "email": "test@rotodirect.com",
              "validSyntax": true,
              "domain": {
                "name": "rotodirect.com",
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
                  "mxRecord"
                ],
                "aRecord": [
                  "166.78.44.241"
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/email/disposable-check")
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

        var response = await Client.DisposableEmailCheckV2Async(
            new DisposableEmailCheckV2Request { ApiKey = "apiKey", Email = "test@sogetthis.com" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_8()
    {
        const string requestJson = """
            {
              "email": "test@sogetthis.com"
            }
            """;

        const string mockResponse = """
            {
              "email": "test@mailblacklist.com",
              "validSyntax": true,
              "domain": {
                "name": "mailblacklist.com",
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
                  "."
                ],
                "aRecord": [
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/email/disposable-check")
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

        var response = await Client.DisposableEmailCheckV2Async(
            new DisposableEmailCheckV2Request { ApiKey = "apiKey", Email = "test@sogetthis.com" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_9()
    {
        const string requestJson = """
            {
              "email": "test@sogetthis.com"
            }
            """;

        const string mockResponse = """
            {
              "email": "abc",
              "validSyntax": false,
              "domain": {
                "name": "abc",
                "validDomain": false,
                "disposable": true,
                "free": true,
                "spam": true
              },
              "account": {
                "role": true
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/email/disposable-check")
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

        var response = await Client.DisposableEmailCheckV2Async(
            new DisposableEmailCheckV2Request { ApiKey = "apiKey", Email = "test@sogetthis.com" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_10()
    {
        const string requestJson = """
            {
              "email": "test@sogetthis.com"
            }
            """;

        const string mockResponse = """
            {
              "email": "test@xxxxxyyyyy123spam.com",
              "validSyntax": true,
              "domain": {
                "name": "xxxxxyyyyy123spam.com",
                "validDomain": false,
                "disposable": false,
                "free": false,
                "spam": false
              },
              "account": {
                "role": false
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/email/disposable-check")
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

        var response = await Client.DisposableEmailCheckV2Async(
            new DisposableEmailCheckV2Request { ApiKey = "apiKey", Email = "test@sogetthis.com" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_11()
    {
        const string requestJson = """
            {
              "email": "test@sogetthis.com"
            }
            """;

        const string mockResponse = """
            {
              "email": "someone@gmail.com",
              "validSyntax": true,
              "domain": {
                "name": "gmail.com",
                "validDomain": true,
                "disposable": false,
                "free": true,
                "spam": false
              },
              "account": {
                "role": false
              },
              "dns": {
                "mxRecord": [
                  "gmail-smtp-in.l.google.com.",
                  "alt1.gmail-smtp-in.l.google.com.",
                  "alt2.gmail-smtp-in.l.google.com.",
                  "alt3.gmail-smtp-in.l.google.com.",
                  "alt4.gmail-smtp-in.l.google.com."
                ],
                "aRecord": [
                  "aRecord"
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
                  "accuracy_radius": "accuracy_radius",
                  "confidence": "confidence",
                  "is_eu": false
                },
                "security": {
                  "threat_score": 5,
                  "is_tor": false,
                  "is_proxy": false,
                  "proxy_type": "proxy_type",
                  "proxy_provider": "proxy_provider",
                  "is_anonymous": false,
                  "is_known_attacker": false,
                  "is_spam": false,
                  "is_bot": false,
                  "is_cloud_provider": true,
                  "cloud_provider": "Google LLC"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/email/disposable-check")
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

        var response = await Client.DisposableEmailCheckV2Async(
            new DisposableEmailCheckV2Request { ApiKey = "apiKey", Email = "test@sogetthis.com" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_12()
    {
        const string requestJson = """
            {
              "email": "test@sogetthis.com"
            }
            """;

        const string mockResponse = """
            {
              "email": "someone@gmail.com",
              "validSyntax": true,
              "domain": {
                "name": "gmail.com",
                "validDomain": true,
                "disposable": false,
                "free": true,
                "spam": false
              },
              "account": {
                "role": false
              },
              "dns": {
                "mxRecord": [
                  "gmail-smtp-in.l.google.com.",
                  "alt1.gmail-smtp-in.l.google.com.",
                  "alt2.gmail-smtp-in.l.google.com.",
                  "alt3.gmail-smtp-in.l.google.com.",
                  "alt4.gmail-smtp-in.l.google.com."
                ],
                "aRecord": [
                  "aRecord"
                ]
              },
              "ip": "10.0.0.1",
              "address": {
                "validIpAddress": false,
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
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/email/disposable-check")
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

        var response = await Client.DisposableEmailCheckV2Async(
            new DisposableEmailCheckV2Request { ApiKey = "apiKey", Email = "test@sogetthis.com" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

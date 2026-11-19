using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class BulkIpSecurityLookupTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {
              "ips": [
                "ips",
                "ips"
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "ip": "ip",
                "security": {
                  "threat_score": 1.1,
                  "is_tor": true,
                  "is_proxy": true,
                  "proxy_provider_names": [
                    "proxy_provider_names",
                    "proxy_provider_names"
                  ],
                  "proxy_confidence_score": 1.1,
                  "proxy_last_seen": "proxy_last_seen",
                  "is_residential_proxy": true,
                  "is_vpn": true,
                  "vpn_provider_names": [
                    "vpn_provider_names",
                    "vpn_provider_names"
                  ],
                  "vpn_confidence_score": 1.1,
                  "vpn_last_seen": "vpn_last_seen",
                  "is_relay": true,
                  "relay_provider_name": "relay_provider_name",
                  "is_anonymous": true,
                  "is_known_attacker": true,
                  "is_bot": true,
                  "is_spam": true,
                  "is_cloud_provider": true,
                  "cloud_provider_name": "cloud_provider_name",
                  "bot_confidence_score": 1.1,
                  "bot_last_seen": "bot_last_seen",
                  "bot_operator_name": "bot_operator_name",
                  "bot_type": "bot_type",
                  "corporate_gateway_provider_name": "corporate_gateway_provider_name",
                  "corporate_gateway_type": "corporate_gateway_type",
                  "is_corporate_gateway": true,
                  "is_known_good_bot": true,
                  "proxy_days_seen_30d": 1,
                  "proxy_days_seen_7d": 1,
                  "proxy_provider_count_30d": 1
                }
              },
              {
                "ip": "ip",
                "security": {
                  "threat_score": 1.1,
                  "is_tor": true,
                  "is_proxy": true,
                  "proxy_provider_names": [
                    "proxy_provider_names",
                    "proxy_provider_names"
                  ],
                  "proxy_confidence_score": 1.1,
                  "proxy_last_seen": "proxy_last_seen",
                  "is_residential_proxy": true,
                  "is_vpn": true,
                  "vpn_provider_names": [
                    "vpn_provider_names",
                    "vpn_provider_names"
                  ],
                  "vpn_confidence_score": 1.1,
                  "vpn_last_seen": "vpn_last_seen",
                  "is_relay": true,
                  "relay_provider_name": "relay_provider_name",
                  "is_anonymous": true,
                  "is_known_attacker": true,
                  "is_bot": true,
                  "is_spam": true,
                  "is_cloud_provider": true,
                  "cloud_provider_name": "cloud_provider_name",
                  "bot_confidence_score": 1.1,
                  "bot_last_seen": "bot_last_seen",
                  "bot_operator_name": "bot_operator_name",
                  "bot_type": "bot_type",
                  "corporate_gateway_provider_name": "corporate_gateway_provider_name",
                  "corporate_gateway_type": "corporate_gateway_type",
                  "is_corporate_gateway": true,
                  "is_known_good_bot": true,
                  "proxy_days_seen_30d": 1,
                  "proxy_days_seen_7d": 1,
                  "proxy_provider_count_30d": 1
                }
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/ip/security")
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

        var response = await Client.BulkIpSecurityLookupAsync(
            new BulkIpSecurityLookupRequest
            {
                ApiKey = "apiKey",
                Ips = new List<string>() { "ips", "ips" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "ips": [
                "ips"
              ]
            }
            """;

        const string mockResponse = """
            [
              {
                "ip": "ip",
                "security": {
                  "threat_score": 1.1,
                  "is_tor": true,
                  "is_proxy": true,
                  "proxy_provider_names": [
                    "proxy_provider_names"
                  ],
                  "proxy_confidence_score": 1.1,
                  "proxy_last_seen": "proxy_last_seen",
                  "is_residential_proxy": true,
                  "is_vpn": true,
                  "vpn_provider_names": [
                    "vpn_provider_names"
                  ],
                  "vpn_confidence_score": 1.1,
                  "vpn_last_seen": "vpn_last_seen",
                  "is_relay": true,
                  "relay_provider_name": "relay_provider_name",
                  "is_anonymous": true,
                  "is_known_attacker": true,
                  "is_bot": true,
                  "is_spam": true,
                  "is_cloud_provider": true,
                  "cloud_provider_name": "cloud_provider_name",
                  "bot_confidence_score": 1.1,
                  "bot_last_seen": "bot_last_seen",
                  "bot_operator_name": "bot_operator_name",
                  "bot_type": "bot_type",
                  "corporate_gateway_provider_name": "corporate_gateway_provider_name",
                  "corporate_gateway_type": "corporate_gateway_type",
                  "is_corporate_gateway": true,
                  "is_known_good_bot": true,
                  "proxy_days_seen_30d": 1,
                  "proxy_days_seen_7d": 1,
                  "proxy_provider_count_30d": 1
                }
              }
            ]
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/ip/security")
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

        var response = await Client.BulkIpSecurityLookupAsync(
            new BulkIpSecurityLookupRequest
            {
                ApiKey = "apiKey",
                Ips = new List<string>() { "ips" },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

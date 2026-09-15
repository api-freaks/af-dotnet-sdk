using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GeolocationLookupV2Test : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "ip": "ip",
              "domain": "domain",
              "hostname": "hostname",
              "location": {
                "continent_code": "continent_code",
                "continent_name": "continent_name",
                "country_code2": "country_code2",
                "country_code3": "country_code3",
                "country_name": "country_name",
                "country_name_official": "country_name_official",
                "country_capital": "country_capital",
                "state_prov": "state_prov",
                "state_code": "state_code",
                "district": "district",
                "city": "city",
                "locality": "locality",
                "accuracy_radius": "accuracy_radius",
                "confidence": "confidence",
                "dma_code": "dma_code",
                "zipcode": "zipcode",
                "latitude": "latitude",
                "longitude": "longitude",
                "is_eu": true,
                "country_flag": "country_flag",
                "geoname_id": "geoname_id",
                "country_emoji": "country_emoji"
              },
              "country_metadata": {
                "calling_code": "calling_code",
                "tld": "tld",
                "languages": [
                  "languages"
                ]
              },
              "network": {
                "connection_type": "connection_type",
                "route": "route",
                "is_anycast": true
              },
              "asn": {
                "as_number": "as_number",
                "organization": "organization",
                "country": "country",
                "type": "type",
                "domain": "domain",
                "date_allocated": "date_allocated",
                "rir": "rir"
              },
              "company": {
                "name": "name",
                "type": "type",
                "domain": "domain"
              },
              "currency": {
                "code": "code",
                "name": "name",
                "symbol": "symbol"
              },
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
                "cloud_provider_name": "cloud_provider_name"
              },
              "abuse": {
                "route": "route",
                "country": "country",
                "name": "name",
                "organization": "organization",
                "kind": "kind",
                "address": "address",
                "emails": [
                  "emails"
                ],
                "phone_numbers": [
                  "phone_numbers"
                ]
              },
              "time_zone": {
                "name": "name",
                "offset": 1.1,
                "offset_with_dst": 1.1,
                "current_time": "current_time",
                "current_time_unix": 1.1,
                "current_tz_abbreviation": "current_tz_abbreviation",
                "current_tz_full_name": "current_tz_full_name",
                "standard_tz_abbreviation": "standard_tz_abbreviation",
                "standard_tz_full_name": "standard_tz_full_name",
                "is_dst": true,
                "dst_savings": 1.1,
                "dst_exists": true,
                "dst_tz_abbreviation": "dst_tz_abbreviation",
                "dst_tz_full_name": "dst_tz_full_name",
                "dst_start": {
                  "utc_time": "utc_time",
                  "duration": "duration",
                  "gap": true,
                  "date_time_after": "date_time_after",
                  "date_time_before": "date_time_before",
                  "overlap": true
                },
                "dst_end": {
                  "utc_time": "utc_time",
                  "duration": "duration",
                  "gap": true,
                  "date_time_after": "date_time_after",
                  "date_time_before": "date_time_before",
                  "overlap": true
                }
              },
              "user_agent": {
                "user_agent_string": "user_agent_string",
                "name": "name",
                "type": "type",
                "version": "version",
                "version_major": "version_major",
                "device": {
                  "name": "name",
                  "type": "type",
                  "brand": "brand",
                  "cpu": "cpu"
                },
                "engine": {
                  "name": "name",
                  "type": "type",
                  "version": "version",
                  "version_major": "version_major"
                },
                "operating_system": {
                  "name": "name",
                  "type": "type",
                  "version": "version",
                  "version_major": "version_major",
                  "build": "build"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/geolocation/lookup")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.GeolocationLookupV2Async(
            new GeolocationLookupV2Request { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GeolocationLookupTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "ip": "ip",
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
                  "languages",
                  "languages"
                ]
              },
              "network": {
                "asn": {
                  "as_number": "as_number",
                  "organization": "organization",
                  "country": "country",
                  "asn_name": "asn_name",
                  "type": "type",
                  "domain": "domain",
                  "date_allocated": "date_allocated",
                  "allocation_status": "allocation_status",
                  "num_of_ipv4_routes": "num_of_ipv4_routes",
                  "num_of_ipv6_routes": "num_of_ipv6_routes",
                  "rir": "rir"
                },
                "connection_type": "connection_type",
                "company": {
                  "name": "name",
                  "type": "type",
                  "domain": "domain"
                }
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
                "proxy_type": "proxy_type",
                "proxy_provider": "proxy_provider",
                "is_anonymous": true,
                "is_known_attacker": true,
                "is_spam": true,
                "is_bot": true,
                "is_cloud_provider": true,
                "cloud_provider": "cloud_provider"
              },
              "abuse": [
                {
                  "route": "route",
                  "country": "country",
                  "handle": "handle",
                  "name": "name",
                  "organization": "organization",
                  "role": "role",
                  "kind": "kind",
                  "address": "address",
                  "emails": [
                    "emails",
                    "emails"
                  ],
                  "phone_numbers": [
                    "phone_numbers",
                    "phone_numbers"
                  ]
                },
                {
                  "route": "route",
                  "country": "country",
                  "handle": "handle",
                  "name": "name",
                  "organization": "organization",
                  "role": "role",
                  "kind": "kind",
                  "address": "address",
                  "emails": [
                    "emails",
                    "emails"
                  ],
                  "phone_numbers": [
                    "phone_numbers",
                    "phone_numbers"
                  ]
                }
              ],
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
                    .WithPath("/v1.0/geolocation/lookup")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.GeolocationLookupAsync(
            new GeolocationLookupRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "ip": "ip",
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
                "asn": {
                  "as_number": "as_number",
                  "organization": "organization",
                  "country": "country",
                  "asn_name": "asn_name",
                  "type": "type",
                  "domain": "domain",
                  "date_allocated": "date_allocated",
                  "allocation_status": "allocation_status",
                  "num_of_ipv4_routes": "num_of_ipv4_routes",
                  "num_of_ipv6_routes": "num_of_ipv6_routes",
                  "rir": "rir"
                },
                "connection_type": "connection_type",
                "company": {
                  "name": "name",
                  "type": "type",
                  "domain": "domain"
                }
              },
              "currency": {
                "code": "PKR",
                "name": "Pakistan Rupee",
                "symbol": "₨"
              },
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
              "abuse": [
                {
                  "route": "route",
                  "country": "country",
                  "handle": "handle",
                  "name": "name",
                  "organization": "organization",
                  "role": "role",
                  "kind": "kind",
                  "address": "address",
                  "emails": [
                    "emails"
                  ],
                  "phone_numbers": [
                    "phone_numbers"
                  ]
                }
              ],
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
                "user_agent_string": "Mozilla/5.0 (X11; Ubuntu; Linux x86_64; rv:142.0) Gecko/20100101 Firefox/142.0",
                "name": "Firefox",
                "type": "Browser",
                "version": "142.0",
                "version_major": "142",
                "device": {
                  "name": "Linux Desktop",
                  "type": "Desktop",
                  "brand": "Unknown",
                  "cpu": "Intel x86_64"
                },
                "engine": {
                  "name": "Gecko",
                  "type": "Browser",
                  "version": "142.0",
                  "version_major": "142"
                },
                "operating_system": {
                  "name": "Ubuntu",
                  "type": "Desktop",
                  "version": "??",
                  "version_major": "??",
                  "build": "??"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geolocation/lookup")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.GeolocationLookupAsync(
            new GeolocationLookupRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

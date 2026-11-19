using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class TimezoneLookupTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "ip": "ip",
              "location": {
                "location_string": "location_string",
                "country_name": "country_name",
                "state_prov": "state_prov",
                "city": "city",
                "locality": "locality",
                "latitude": "latitude",
                "longitude": "longitude",
                "continent_code": "continent_code",
                "continent_name": "continent_name",
                "country_code2": "country_code2",
                "country_code3": "country_code3",
                "country_name_official": "country_name_official",
                "is_eu": true,
                "state_code": "state_code",
                "district": "district",
                "zipcode": "zipcode"
              },
              "time_zone": {
                "name": "name",
                "offset": 1.1,
                "offset_with_dst": 1.1,
                "date": "date",
                "date_time": "date_time",
                "date_time_txt": "date_time_txt",
                "date_time_wti": "date_time_wti",
                "date_time_ymd": "date_time_ymd",
                "date_time_unix": 1.1,
                "time_24": "time_24",
                "time_12": "time_12",
                "week": 1.1,
                "month": 1.1,
                "year": 1.1,
                "year_abbr": "year_abbr",
                "current_tz_abbreviation": "current_tz_abbreviation",
                "current_tz_full_name": "current_tz_full_name",
                "standard_tz_abbreviation": "standard_tz_abbreviation",
                "standard_tz_full_name": "standard_tz_full_name",
                "is_dst": true,
                "dst_savings": 1.1,
                "dst_exists": true,
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
                },
                "dst_tz_abbreviation": "dst_tz_abbreviation",
                "dst_tz_full_name": "dst_tz_full_name"
              },
              "airport_details": {
                "type": "type",
                "name": "name",
                "longitude": "longitude",
                "latitude": "latitude",
                "elevation_ft": 1.1,
                "continent_code": "continent_code",
                "country_code": "country_code",
                "state_code": "state_code",
                "city": "city",
                "iata_code": "iata_code",
                "icao_code": "icao_code",
                "faa_code": "faa_code"
              },
              "lo_code_details": {
                "lo_code": "lo_code",
                "city": "city",
                "longitude": "longitude",
                "latitude": "latitude",
                "state_code": "state_code",
                "country_code": "country_code",
                "country_name": "country_name",
                "location_type": "location_type"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geolocation/timezone")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.TimezoneLookupAsync(
            new TimezoneLookupRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "ip": "ip",
              "location": {
                "location_string": "location_string",
                "country_name": "country_name",
                "state_prov": "state_prov",
                "city": "city",
                "locality": "locality",
                "latitude": "latitude",
                "longitude": "longitude",
                "continent_code": "continent_code",
                "continent_name": "continent_name",
                "country_code2": "country_code2",
                "country_code3": "country_code3",
                "country_name_official": "country_name_official",
                "is_eu": true,
                "state_code": "state_code",
                "district": "district",
                "zipcode": "zipcode"
              },
              "time_zone": {
                "name": "name",
                "offset": 1.1,
                "offset_with_dst": 1.1,
                "date": "date",
                "date_time": "date_time",
                "date_time_txt": "date_time_txt",
                "date_time_wti": "date_time_wti",
                "date_time_ymd": "date_time_ymd",
                "date_time_unix": 1.1,
                "time_24": "time_24",
                "time_12": "time_12",
                "week": 1.1,
                "month": 1.1,
                "year": 1.1,
                "year_abbr": "year_abbr",
                "current_tz_abbreviation": "current_tz_abbreviation",
                "current_tz_full_name": "current_tz_full_name",
                "standard_tz_abbreviation": "standard_tz_abbreviation",
                "standard_tz_full_name": "standard_tz_full_name",
                "is_dst": true,
                "dst_savings": 1.1,
                "dst_exists": true,
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
                },
                "dst_tz_abbreviation": "dst_tz_abbreviation",
                "dst_tz_full_name": "dst_tz_full_name"
              },
              "airport_details": {
                "type": "type",
                "name": "name",
                "longitude": "longitude",
                "latitude": "latitude",
                "elevation_ft": 1.1,
                "continent_code": "continent_code",
                "country_code": "country_code",
                "state_code": "state_code",
                "city": "city",
                "iata_code": "iata_code",
                "icao_code": "icao_code",
                "faa_code": "faa_code"
              },
              "lo_code_details": {
                "lo_code": "lo_code",
                "city": "city",
                "longitude": "longitude",
                "latitude": "latitude",
                "state_code": "state_code",
                "country_code": "country_code",
                "country_name": "country_name",
                "location_type": "location_type"
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/geolocation/timezone")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.TimezoneLookupAsync(
            new TimezoneLookupRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

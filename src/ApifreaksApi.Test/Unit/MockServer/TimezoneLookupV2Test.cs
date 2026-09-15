using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class TimezoneLookupV2Test : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "ip": "ip",
              "time_zone": {
                "name": "name",
                "offset": 1.1,
                "offset_with_dst": 1.1,
                "current_time": "current_time",
                "current_time_unix": 1.1,
                "date": "date",
                "date_time": "date_time",
                "date_time_txt": "date_time_txt",
                "date_time_wti": "date_time_wti",
                "date_time_ymd": "date_time_ymd",
                "time_24": "time_24",
                "time_12": "time_12",
                "week": 1,
                "month": 1,
                "year": 1,
                "year_abbr": "year_abbr",
                "current_tz_abbreviation": "current_tz_abbreviation",
                "current_tz_full_name": "current_tz_full_name",
                "standard_tz_abbreviation": "standard_tz_abbreviation",
                "standard_tz_full_name": "standard_tz_full_name",
                "is_dst": true,
                "dst_tz_abbreviation": "dst_tz_abbreviation",
                "dst_tz_full_name": "dst_tz_full_name",
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
                }
              },
              "location": {
                "location_string": "location_string",
                "continent_code": "continent_code",
                "continent_name": "continent_name",
                "country_code2": "country_code2",
                "country_code3": "country_code3",
                "country_name": "country_name",
                "country_name_official": "country_name_official",
                "is_eu": true,
                "state_prov": "state_prov",
                "state_code": "state_code",
                "district": "district",
                "city": "city",
                "locality": "locality",
                "zipcode": "zipcode",
                "latitude": "latitude",
                "longitude": "longitude"
              },
              "airport_details": {
                "type": "type",
                "name": "name",
                "latitude": 1.1,
                "longitude": 1.1,
                "elevation_ft": 1,
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
                "state_code": "state_code",
                "country_code": "country_code",
                "country_name": "country_name",
                "location_type": "location_type",
                "latitude": 1.1,
                "longitude": 1.1
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v2.0/geolocation/timezone")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.TimezoneLookupV2Async(
            new TimezoneLookupV2Request { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CurrentWeatherTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest()
    {
        const string mockResponse = """
            {
              "location": {
                "continent_code": "NA",
                "continent_name": "North America",
                "country_code2": "US",
                "country_code3": "USA",
                "country_name": "United States",
                "country_name_official": "United States of America",
                "is_eu": false,
                "state_prov": "California",
                "state_code": "US-CA",
                "district": "Santa Clara",
                "city": "Mountain View",
                "zipcode": "94043-1351",
                "latitude": "37.42240",
                "longitude": "-122.08421",
                "locality": "Charleston Terrace",
                "elevation": "3",
                "timezone": "America/Los_Angeles",
                "timezone_abbreviation": "GMT-7"
              },
              "current": {
                "timestamp": "2025-09-29T17:45",
                "temperature_2m": 32.5,
                "relative_humidity_2m": 61,
                "apparent_temperature": 37.9,
                "snowfall": 0,
                "rain": 0,
                "showers": 0,
                "precipitation": 0,
                "weather_code": 2,
                "cloud_cover": 49,
                "pressure_msl": 1001.9,
                "surface_pressure": 977.6,
                "wind_speed_10m": 4,
                "wind_direction_10m": 280,
                "wind_gusts_10m": 8.6,
                "astronomy": {
                  "date": "2025-09-29",
                  "mid_night": "23:52",
                  "night_end": "04:34",
                  "sunrise": "05:53",
                  "solar_noon": "11:52",
                  "sunset": "17:51",
                  "night_begin": "19:10",
                  "day_length": "11:58",
                  "sun_status": "-",
                  "moon_phase": "FIRST_QUARTER",
                  "moonrise": "12:41",
                  "moonset": "22:28",
                  "moon_status": "-"
                },
                "air_quality": {
                  "timestamp": "2025-09-29T17:45",
                  "european_aqi": 84,
                  "us_aqi": 148,
                  "pm10": 66.2,
                  "pm2_5": 52.7,
                  "carbon_monoxide": 977,
                  "nitrogen_dioxide": 44.5,
                  "sulphur_dioxide": 20.4,
                  "ozone": 159,
                  "dust": 27,
                  "uv_index": 0,
                  "aerosol_optical_depth": 0.48,
                  "uv_index_clear_sky": 0
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/weather/current")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.CurrentWeatherAsync(
            new CurrentWeatherRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class WeatherForecastTest : BaseMockServerTest
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
              "forecast": {
                "2025-09-29": {
                  "daily": {
                    "timestamp": "2025-09-29",
                    "weather_code": 2,
                    "temperature_2m_max": 34.9,
                    "temperature_2m_min": 27.3,
                    "temperature_2m_mean": 30.7,
                    "apparent_temperature_max": 41.6,
                    "apparent_temperature_min": 33.4,
                    "apparent_temperature_mean": 36.5,
                    "uv_index_max": 6.65,
                    "uv_index_clear_sky_max": 6.65,
                    "rain_sum": 0,
                    "showers_sum": 0,
                    "snowfall_sum": 0,
                    "precipitation_sum": 0,
                    "precipitation_probability_mean": 4,
                    "wind_speed_10m_max": 5.5,
                    "wind_speed_10m_min": 2,
                    "wind_speed_10m_mean": 3.4,
                    "wind_gusts_10m_max": 14.4,
                    "wind_gusts_10m_min": 4.3,
                    "wind_gusts_10m_mean": 8.7,
                    "wind_direction_10m_dominant": 225,
                    "shortwave_radiation_sum": 18.16,
                    "surface_pressure_mean": 979.9,
                    "pressure_msl_mean": 1004.4,
                    "visibility_mean": 24140,
                    "cloud_cover_mean": 36,
                    "dew_point_2m_max": 25.2,
                    "dew_point_2m_min": 22.8,
                    "dew_point_2m_mean": 24.1,
                    "relative_humidity_2m_max": 86,
                    "relative_humidity_2m_min": 51,
                    "relative_humidity_2m_mean": 69,
                    "et0_fao_evapotranspiration_sum": 4.04
                  },
                  "hourly": [
                    {}
                  ],
                  "minutely": [
                    {}
                  ],
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
                  }
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/weather/forecast")
                    .WithParam("apiKey", "apiKey")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.WeatherForecastAsync(
            new WeatherForecastRequest { ApiKey = "apiKey" }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

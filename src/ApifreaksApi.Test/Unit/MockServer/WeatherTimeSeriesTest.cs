using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class WeatherTimeSeriesTest : BaseMockServerTest
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
              "historical": {
                "2025-08-01": {
                  "daily": {
                    "timestamp": "2025-08-01",
                    "weather_code": 63,
                    "temperature_2m_mean": 27.3,
                    "temperature_2m_max": 29.8,
                    "temperature_2m_min": 26,
                    "apparent_temperature_mean": 33.6,
                    "apparent_temperature_max": 36,
                    "apparent_temperature_min": 31.9,
                    "precipitation_sum": 17.8,
                    "rain_sum": 17.8,
                    "snowfall_sum": 0,
                    "wind_speed_10m_max": 12.2,
                    "wind_gusts_10m_max": 26.3,
                    "wind_speed_10m_mean": 7.4,
                    "wind_speed_10m_min": 2.2,
                    "wind_gusts_10m_min": 5,
                    "wind_gusts_10m_mean": 16.7,
                    "wind_direction_10m_dominant": 76,
                    "shortwave_radiation_sum": 7.89,
                    "et0_fao_evapotranspiration_sum": 1.75,
                    "cloud_cover_mean": 99,
                    "dew_point_2m_mean": 25.9,
                    "dew_point_2m_max": 26.5,
                    "dew_point_2m_min": 25.1,
                    "relative_humidity_2m_mean": 92,
                    "relative_humidity_2m_max": 97,
                    "relative_humidity_2m_min": 81,
                    "pressure_msl_mean": 999.2,
                    "surface_pressure_mean": 974.6
                  },
                  "hourly": [
                    {}
                  ],
                  "astronomy": {
                    "date": "2025-08-01",
                    "mid_night": "00:09",
                    "night_end": "03:47",
                    "sunrise": "05:17",
                    "solar_noon": "12:08",
                    "sunset": "19:00",
                    "night_begin": "20:30",
                    "day_length": "13:43",
                    "sun_status": "-",
                    "moon_phase": "FIRST_QUARTER",
                    "moonrise": "12:17",
                    "moonset": "23:04",
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
                    .WithPath("/v1.0/weather/time-series")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("startDate", "2023-01-15")
                    .WithParam("endDate", "2023-01-15")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.WeatherTimeSeriesAsync(
            new WeatherTimeSeriesRequest
            {
                ApiKey = "apiKey",
                StartDate = new DateOnly(2023, 1, 15),
                EndDate = new DateOnly(2023, 1, 15),
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

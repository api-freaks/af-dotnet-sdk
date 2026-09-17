using ApifreaksApi;
using ApifreaksApi.Test.Utils;
using NUnit.Framework;

namespace ApifreaksApi.Test.Unit.MockServer;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class HistoricalWeatherTest : BaseMockServerTest
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
                "daily": {
                  "timestamp": "1940-10-10",
                  "weather_code": 0,
                  "temperature_2m_mean": 28.1,
                  "temperature_2m_max": 37.8,
                  "temperature_2m_min": 20.2,
                  "apparent_temperature_mean": 25,
                  "apparent_temperature_max": 36.5,
                  "apparent_temperature_min": 16.7,
                  "precipitation_sum": 0,
                  "rain_sum": 0,
                  "snowfall_sum": 0,
                  "wind_speed_10m_max": 12.8,
                  "wind_gusts_10m_max": 25.6,
                  "wind_speed_10m_mean": 8.7,
                  "wind_speed_10m_min": 3.9,
                  "wind_gusts_10m_min": 9,
                  "wind_gusts_10m_mean": 16.4,
                  "wind_direction_10m_dominant": 80,
                  "shortwave_radiation_sum": 20.09,
                  "et0_fao_evapotranspiration_sum": 6.31,
                  "cloud_cover_mean": 0,
                  "dew_point_2m_mean": 0.1,
                  "dew_point_2m_max": 5.5,
                  "dew_point_2m_min": -3.1,
                  "relative_humidity_2m_mean": 18,
                  "relative_humidity_2m_max": 26,
                  "relative_humidity_2m_min": 8,
                  "pressure_msl_mean": 1010.2,
                  "surface_pressure_mean": 985.4
                },
                "hourly": [
                  {}
                ],
                "astronomy": {
                  "date": "1940-10-10",
                  "mid_night": "00:19",
                  "night_end": "05:11",
                  "sunrise": "06:30",
                  "solar_noon": "12:19",
                  "sunset": "18:08",
                  "night_begin": "19:27",
                  "day_length": "11:38",
                  "sun_status": "-",
                  "moon_phase": "WAXING_GIBBOUS",
                  "moonrise": "14:39",
                  "moonset": "01:07",
                  "moon_status": "-"
                }
              }
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/v1.0/weather/historical")
                    .WithParam("apiKey", "apiKey")
                    .WithParam("date", "2023-01-15")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.HistoricalWeatherAsync(
            new HistoricalWeatherRequest { ApiKey = "apiKey", Date = new DateOnly(2023, 1, 15) }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}

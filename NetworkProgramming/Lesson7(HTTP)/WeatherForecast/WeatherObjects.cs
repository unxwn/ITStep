using Newtonsoft.Json;
using System.Collections.Generic;

public class WeatherResponse
{
    [JsonProperty("hourly")]
    public List<HourlyWeather> Hourly { get; set; }
}

public class HourlyWeather
{
    [JsonProperty("dt")]
    public long Dt { get; set; }

    [JsonProperty("temp")]
    public double Temp { get; set; }
}

public class GoogleGeocodeResponse
{
    [JsonProperty("results")]
    public List<AddressResult> Results { get; set; }
}

public class AddressResult
{
    [JsonProperty("formatted_address")]
    public string FormattedAddress { get; set; }
}
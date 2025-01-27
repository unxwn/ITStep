using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WeatherForecast
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGetForecast_Click(object sender, EventArgs e)
        {
            try
            {
                double latitude = double.Parse(textBoxLatitude.Text);
                double longitude = double.Parse(textBoxLongitude.Text);

                string weatherApiKey = "95881408f0f6a0fdbfb6edc5cae691e8";
                string weatherUrl = $"https://api.openweathermap.org/data/3.0/onecall?lat={latitude}&lon={longitude}&exclude=minutely,daily,current,alerts&units=metric&appid={weatherApiKey}";

                string googleApiKey = "AIzaSyB24J5XkL5JEEZgZonCnrgqG-X0lq0DYfw";
                string googleUrl = $"https://maps.googleapis.com/maps/api/geocode/json?latlng={latitude.ToString(CultureInfo.InvariantCulture)},{longitude.ToString(CultureInfo.InvariantCulture)}&key={googleApiKey}";

                var forecastData = await GetWeatherDataAsync(weatherUrl);
                DisplayForecastOnChart(forecastData);

                string address = await GetAddressAsync(googleUrl);
                textBoxAddress.Text = address;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.StackTrace} {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<List<HourlyWeather>> GetWeatherDataAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseData = await response.Content.ReadAsStringAsync();

                var weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseData);
                return weatherResponse.Hourly;

            }
        }

        private async Task<string> GetAddressAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseData = await response.Content.ReadAsStringAsync();

                var googleResponse = JsonConvert.DeserializeObject<GoogleGeocodeResponse>(responseData);
                return googleResponse.Results.Count > 0 ? googleResponse.Results[0].FormattedAddress : "Address not found";
            }
        }

        private void DisplayForecastOnChart(List<HourlyWeather> forecastData)
        {
            var temperatures = new ChartValues<double>();
            var hours = new string[forecastData.Count];

            for (int i = 0; i < forecastData.Count && i < 48; i++)
            {
                temperatures.Add(forecastData[i].Temp);
                DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds(forecastData[i].Dt).DateTime;
                hours[i] = dateTime.ToString("HH:mm");
            }

            weatherChart.Series.Clear();
            weatherChart.Series.Add(new LineSeries
            {
                Title = "Temperature (°C)",
                Values = temperatures
            });

            weatherChart.AxisX.Clear();
            weatherChart.AxisX.Add(new Axis
            {
                Title = "Time",
                Labels = hours
            });

            weatherChart.AxisY.Clear();
            weatherChart.AxisY.Add(new Axis
            {
                Title = "Temperature (°C)",
                LabelFormatter = value => value.ToString("N")
            });
        }
    }
}

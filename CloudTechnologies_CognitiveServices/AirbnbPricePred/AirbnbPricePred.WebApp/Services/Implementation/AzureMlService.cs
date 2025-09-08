using AirbnbPricePred.WebApp.Models;
using AirbnbPricePred.WebApp.Services.Abstraction;
using System.Text;
using System.Text.Json;

namespace AirbnbPricePred.WebApp.Services.Implementation
{
    public class AzureMlService : IAzureMlService
    {
        private readonly HttpClient _http;
        private readonly string _endpoint;
        private readonly string _authType;
        private readonly string _apiKey;
        private readonly string _apiKeyHeaderName;

        public AzureMlService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _endpoint = config["AzureMl:EndpointUrl"]
                ?? throw new InvalidOperationException("You should provide a Endpoint in the app configuration (AzureMl:EndpointUrl)");
            _authType = config["AzureMl:AuthType"] ?? "Bearer";
            _apiKey = config["AzureMl:ApiKey"]
                ?? throw new InvalidOperationException("You should provide a API Key in the app configuration (AzureMl:ApiKey)");
            _apiKeyHeaderName = _authType == "ApiKey" ? "x-api-key" : "Authorization";
        }

        public async Task<RentalResponse> PredictAsync(RentalRequest input)
        {
            var columns = new[]
            {
                "neighbourhood_group", "neighbourhood", "room_type", "minimum_nights",
                "number_of_reviews", "reviews_per_month", "last_review", "reviews_per_month"
            };

            var row = new object[]
            {
                input.NeighbourhoodGroup,
                input.Neighbourhood,
                input.RoomType,
                input.MinimumNights,
                input.NumberOfReviews,
                input.LastReviewDate ?? null,
                input.ReviewsPerMonth
            };

            var payload = new
            {
                input_data = new[] {
                    new {
                        columns = columns,
                        data = new[] { row }
                    }
                }
            };

            var json = JsonSerializer.Serialize(payload);
            using var req = new HttpRequestMessage(HttpMethod.Post, _endpoint)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            if (!string.IsNullOrWhiteSpace(_apiKey))
            {
                if (_authType.Equals("Bearer", StringComparison.OrdinalIgnoreCase))
                {
                    req.Headers.Add("Authorization", $"Bearer {_apiKey}");
                }
                else // ApiKey
                {
                    req.Headers.Add(_apiKeyHeaderName, _apiKey);
                }
            }

            try
            {
                var resp = await _http.SendAsync(req);
                var text = await resp.Content.ReadAsStringAsync();

                if (!resp.IsSuccessStatusCode)
                {
                    return new RentalResponse { Success = false, RawResponse = $"Status {(int)resp.StatusCode}: {text}" };
                }

                try
                {
                    using var doc = JsonDocument.Parse(text);
                    if (TryFindPrediction(doc.RootElement, out double val))
                    {
                        return new RentalResponse { Success = true, PredictedPrice = val, RawResponse = text };
                    }

                    return new RentalResponse { Success = false, RawResponse = text };
                }
                catch (Exception ex)
                {
                    return new RentalResponse { Success = false, RawResponse = $"Parse error: {ex.Message}. Raw: {text}" };
                }
            }
            catch (Exception ex)
            {
                return new RentalResponse { Success = false, RawResponse = ex.Message };
            }
        }

        private bool TryFindPrediction(JsonElement element, out double value)
        {
            value = 0;

            if (element.ValueKind == JsonValueKind.Object)
            {
                if (element.TryGetProperty("predictions", out var preds))
                {
                    if (preds.ValueKind == JsonValueKind.Array && preds.GetArrayLength() > 0)
                    {
                        var first = preds[0];
                        if (first.ValueKind == JsonValueKind.Array && first.GetArrayLength() > 0)
                        {
                            var num = first[0];
                            if (num.ValueKind == JsonValueKind.Number && num.TryGetDouble(out value)) return true;
                        }
                    }
                }

                // рекурсивно обійти властивості
                foreach (var prop in element.EnumerateObject())
                {
                    if (TryFindPrediction(prop.Value, out value)) return true;
                }
            }
            else if (element.ValueKind == JsonValueKind.Array)
            {
                foreach (var item in element.EnumerateArray())
                {
                    if (TryFindPrediction(item, out value)) return true;
                }
            }
            else if (element.ValueKind == JsonValueKind.Number)
            {
                if (element.TryGetDouble(out value)) return true;
            }

            return false;
        }
    }
}

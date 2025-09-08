namespace AirbnbPricePred.WebApp.Models
{
    public class RentalResponse
    {
        public bool Success { get; set; }
        public double PredictedPrice { get; set; }
        public string RawResponse { get; set; } = string.Empty;
    }
}

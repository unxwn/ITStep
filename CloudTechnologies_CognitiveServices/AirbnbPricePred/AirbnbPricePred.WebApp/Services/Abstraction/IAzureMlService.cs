using AirbnbPricePred.WebApp.Models;

namespace AirbnbPricePred.WebApp.Services.Abstraction
{
    public interface IAzureMlService
    {
        Task<RentalResponse> PredictAsync(RentalRequest input);
    }
}

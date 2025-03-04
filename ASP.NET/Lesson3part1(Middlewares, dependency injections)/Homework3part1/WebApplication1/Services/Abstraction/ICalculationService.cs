namespace WebApplication1.Services.Abstraction
{
    public interface ICalculationService
    {
        Task<long> CalculateAsync(int index);
    }
}

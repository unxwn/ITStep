namespace ASP_Meeting_7.Services.Abstract
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Create(T entity);
    }
}

namespace ASP_Meeting_7.Services.Abstract
{
    public interface IRepository<T> where T : class
    {
        T? Get(int id);
        IEnumerable<T> GetAll();

        T Create(T entity);

        T Edit(T entity);

        T? Delete(int id);
    }
}

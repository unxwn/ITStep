namespace FilmLibrary.Services.Abstraction
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Add(T entity);
    }
}

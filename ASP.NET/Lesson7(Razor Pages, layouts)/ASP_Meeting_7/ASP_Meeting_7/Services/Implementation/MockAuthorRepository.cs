using ASP_Meeting_7.Models;
using ASP_Meeting_7.Services.Abstract;

namespace ASP_Meeting_7.Services.Implementation
{
    public class MockAuthorRepository : IAuthorRepository
    {
        private ICollection<Author> _authors;
        
        public MockAuthorRepository() {
            _authors = new List<Author>();
        }
        public Author Create(Author entity)
        { 
            int newId = 0;
            if (_authors.Count>0)
            newId = _authors.Max(t => t.Id);
            entity.Id = ++newId;
            _authors.Add(entity);
            return entity;
        }

        public IEnumerable<Author> GetAll()
        {
            return _authors.ToList();
        }
    }
}

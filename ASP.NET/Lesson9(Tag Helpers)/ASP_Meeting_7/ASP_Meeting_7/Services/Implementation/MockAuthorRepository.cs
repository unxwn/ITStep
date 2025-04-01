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

        public Author? Delete(int id)
        {
            Author? author = _authors.FirstOrDefault(t => t.Id == id);
            if (author != null)
                _authors.Remove(author);
            return author;
        }

        public Author Edit(Author entity)
        {
            Author? editedAuthor = _authors
                .FirstOrDefault(t => t.Id == entity.Id);
            if (editedAuthor != null)
            {
                editedAuthor.Firstname = entity.Firstname;
                editedAuthor.Surname = entity.Surname;
                editedAuthor.YearOfBirth = entity.YearOfBirth;
                return editedAuthor;
            }
            else
                return entity;
        }

        public Author? Get(int id)
        {
            Author? author = _authors
                .FirstOrDefault(t => t.Id == id);
            return author;
        }

        public IEnumerable<Author> GetAll()
        {
            return _authors.ToList();
        }
    }
}

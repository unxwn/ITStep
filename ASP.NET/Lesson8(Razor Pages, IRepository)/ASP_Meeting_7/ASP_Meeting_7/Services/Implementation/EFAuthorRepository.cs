using ASP_Meeting_7.Data;
using ASP_Meeting_7.Models;
using ASP_Meeting_7.Services.Abstract;

namespace ASP_Meeting_7.Services.Implementation
{
    public class EFAuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext context;

        public EFAuthorRepository(LibraryContext context)
        {
            this.context = context;
        }
        public Author Create(Author entity)
        {
            context.Authors.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public Author? Delete(int id)
        {
            Author? author = context.Authors.Find(id);
            if (author is not null)
            {
                context.Authors.Remove(author);
                context.SaveChanges();
            }
            return author;
        }

        public Author Edit(Author entity)
        {
            Author? editedAuthor = context.Authors.Find(entity.Id);
            if (editedAuthor is not null)
            {
                editedAuthor.Firstname = entity.Firstname;
                editedAuthor.Surname = entity.Surname;
                editedAuthor.YearOfBirth = entity.YearOfBirth;
                context.SaveChanges();
                return editedAuthor;
            }
            return entity;
        }

        public Author? Get(int id)
        {
            Author? author = context.Authors.Find(id);
            return author;
        }

        public IEnumerable<Author> GetAll()
        {
            return context.Authors.ToList();
        }
    }
}

using LibraryManagementDemo.Entities;
using LibraryManagementDemo.GraphQLTypes;
using LibraryManagementDemo.Repositories.Interfaces;
using System.Linq;

namespace LibraryManagementDemo.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryManagementDemoContext _dbContext;

        public AuthorRepository(LibraryManagementDemoContext context)
        {
            _dbContext = context;
        }

        public Author AddAuthor(AuthorInputType authorInputType)
        {
            var author = new Author()
            {
                Name = authorInputType.Name,
                Surname = authorInputType.SurName
            };

            _dbContext.Author.Add(author);
            _dbContext.SaveChanges();

            return author;
        }

        public void DeleteAuthor(AuthorInputType authorInputType)
        {
            var author = _dbContext.Author.Where(x => x.Id == authorInputType.Id).FirstOrDefault();
            _dbContext.Author.Remove(author);
            _dbContext.SaveChanges();
        }

        public IQueryable<Author> GetAuthors() => _dbContext.Author.AsQueryable();

        public Author UpdateAuthor(AuthorInputType authorInputType)
        {
            var author = _dbContext.Author.Where(x => x.Id == authorInputType.Id).FirstOrDefault();

            author.Name = authorInputType.Name;
            author.Surname = authorInputType.SurName;

            _dbContext.Author.Update(author);
            _dbContext.SaveChanges();

            return author;
        }
    }
}
using LibraryManagementDemo.Entities;
using LibraryManagementDemo.GraphQLTypes;
using System.Linq;

namespace LibraryManagementDemo.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        IQueryable<Author> GetAuthors();

        Author AddAuthor(AuthorInputType authorInputType);

        Author UpdateAuthor(AuthorInputType authorInputType);

        void DeleteAuthor(AuthorInputType authorInputType);
    }
}
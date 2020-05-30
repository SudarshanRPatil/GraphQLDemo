using LibraryManagementDemo.Entities;
using LibraryManagementDemo.GraphQLTypes;
using System.Linq;

namespace LibraryManagementDemo.Repositories.Interfaces
{
    public interface IBookRepository
    {
        IQueryable<Book> GetBooks();

        Book AddBook(BookInputType bookInputType);

        Book UpdateBook(BookInputType bookInputType);

        void DeleteBook(BookInputType bookInputType);
    }
}
using LibraryManagementDemo.Entities;
using LibraryManagementDemo.GraphQLTypes;
using LibraryManagementDemo.Repositories.Interfaces;
using System.Linq;

namespace LibraryManagementDemo.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryManagementDemoContext _dbContext;

        public BookRepository(LibraryManagementDemoContext context)
        {
            _dbContext = context;
        }

        public Book AddBook(BookInputType bookInputType)
        {
            var book = new Book()
            {
                Title = bookInputType.Title,
                AuthorId = bookInputType.AuthorId,
                Price = bookInputType.Price
            };

            _dbContext.Book.Add(book);
            _dbContext.SaveChanges();

            return book;
        }

        public void DeleteBook(BookInputType bookInputType)
        {
            var book = _dbContext.Book.Where(x => x.Id == bookInputType.Id).FirstOrDefault();
            _dbContext.Book.Remove(book);
            _dbContext.SaveChanges();
        }

        public IQueryable<Book> GetBooks() => _dbContext.Book.AsQueryable();

        public Book UpdateBook(BookInputType bookInputType)
        {
            var book = _dbContext.Book.Where(x => x.Id == bookInputType.Id).FirstOrDefault();

            book.Title = bookInputType.Title;
            book.AuthorId = bookInputType.AuthorId;
            book.Price = bookInputType.Price;

            _dbContext.Book.Update(book);
            _dbContext.SaveChanges();

            return book;
        }
    }
}
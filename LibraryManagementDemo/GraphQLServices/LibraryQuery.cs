using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using LibraryManagementDemo.Entities;
using LibraryManagementDemo.GraphQLTypes;
using LibraryManagementDemo.Repositories.Interfaces;
using System.Linq;

namespace LibraryManagementDemo.GraphQLServices
{
    public class LibraryQuery
    {
        [UsePaging(SchemaType = typeof(BookType))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> Books([Service] IBookRepository bookRepository) => bookRepository.GetBooks();

        [UsePaging(SchemaType = typeof(AuthorType))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Author> Authors([Service] IAuthorRepository authorRepository) => authorRepository.GetAuthors();
    }
}
using HotChocolate.Resolvers;
using LibraryManagementDemo.Entities;
using LibraryManagementDemo.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementDemo.GraphQLServices
{
    public class BookResolver
    {
        private readonly IBookRepository _bookRepository;

        public BookResolver(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetBooks(Author author, IResolverContext resolverContext)
        {
            return _bookRepository.GetBooks().Where(x => x.AuthorId == author.Id).ToList();
        }
    }
}
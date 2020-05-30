using HotChocolate.Resolvers;
using LibraryManagementDemo.Entities;
using LibraryManagementDemo.Repositories.Interfaces;
using System.Linq;

namespace LibraryManagementDemo.GraphQLServices
{
    public class AuthorResolver
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorResolver(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Author GetAuthor(Book book, IResolverContext resolverContext)
        {
            return _authorRepository.GetAuthors().Where(x => x.Id == book.AuthorId).FirstOrDefault();
        }
    }
}
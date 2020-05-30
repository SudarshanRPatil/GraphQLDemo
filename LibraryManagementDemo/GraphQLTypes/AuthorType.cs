using HotChocolate.Types;
using LibraryManagementDemo.Entities;
using LibraryManagementDemo.GraphQLServices;

namespace LibraryManagementDemo.GraphQLTypes
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            base.Configure(descriptor);
            descriptor.Name("Authors");

            descriptor.Field(x => x.Id).Type<IdType>();
            descriptor.Field(x => x.Name).Type<StringType>();
            descriptor.Field(x => x.Surname).Type<StringType>();
            descriptor.Field<BookResolver>(x => x.GetBooks(default, default));
        }
    }
}
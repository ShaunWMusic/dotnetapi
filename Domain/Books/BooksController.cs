using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LibraryApi.Controllers;
using LibraryApi.Models;
using Microsoft.Extensions.Logging;

namespace LibraryApi.Domain.Books
{
    public class BooksController : BelongsToUserController<Book>
    {
        public BooksController(
            IJsonApiContext jsonApiContext, 
            IResourceService<Book> resourceService, 
            ILoggerFactory loggerFactory
            ) : base(jsonApiContext, resourceService, loggerFactory)
        { }
    }
}
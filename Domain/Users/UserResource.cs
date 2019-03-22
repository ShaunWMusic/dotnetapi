using System.Collections.Generic;
using JsonApiDotNetCore.Models;
using LibraryApi.Models;

namespace LibraryApi.Domain.Users
{
    public class UserResource : ResourceDefinition<User>
    {
        // This prevents the password from coming back on the api.
        protected override List<AttrAttribute> OutputAttrs() => Remove(u => new { u.Password, u.PasswordConfirmation });
    }
}
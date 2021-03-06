using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonApiDotNetCore.Internal;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LibraryApi.Domain.Session
{
    public class SessionController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly SigningCredentials _creds;

        public SessionController(AppDbContext db, SigningCredentials creds)
        {
            _db = db;
            _creds = creds;
        }

        [HttpPost("/session")]
        public async Task<IActionResult> PostAsync([FromBody] SessionForm input) 
        {
            var header = new JwtHeader(_creds);
            try 
            {
                var user = _db.Users.Where(u => u.Email.Equals(input.Email)).First();

                if (!BCrypt.Net.BCrypt.Verify(input.Password, user.PasswordHash)) 
                {
                    throw new JsonApiException(401, "Unauthorized", detail: "Error logging in with that email and password");
                }

                var data = new {
                    email = user.Email,
                    username = user.Username,
                    id = user.Id
                };
                var payload = new JwtPayload() {
                    { "data", data },
                    { "exp", EpochTime.GetIntDate(DateTime.Now.AddHours(2)) },
                    { "sub", user.Id }
                };

                var token = new JwtSecurityToken(header, payload);
                var signedToken = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new {
                    token = signedToken
                });
            }
            catch (InvalidOperationException) 
            {
                throw new JsonApiException(401, "Unauthorized", detail: "Error logging in with that email and password");
            }
        }
    }

    public class SessionForm
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
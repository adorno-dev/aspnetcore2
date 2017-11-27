using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using AspnetCore2.Jwt.Api.Entries;
using AspnetCore2.Jwt.Api.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace AspnetCore2.Jwt.Api.Controllers
{
    [Route("[controller]")]
    public class AuthorizeController : Controller
    {
        [HttpPost]
        [AllowAnonymous]
        [Route("/authorize")]
        public async Task<IActionResult> Post([FromServices] TokenOptions tokenOptions, [FromBody] Login login)
        {
            if (login == null || string.IsNullOrEmpty(login.Username) || string.IsNullOrEmpty(login.Password))
                return Unauthorized();

            if (login.Username.Equals("usr") && login.Password.Equals("pwd"))
            {
                var gi = new GenericIdentity(login.Username);
                var ci = new ClaimsIdentity(gi, new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, tokenOptions.GenerateJti()),
                    new Claim(JwtRegisteredClaimNames.UniqueName, login.Username),
                    new Claim("Jwt", "User"),
                    new Claim("Jwt", "Admin")
                });

                var tokenCreation = DateTime.Now;
                var tokenExpiration = tokenCreation.Add(TimeSpan.FromMinutes(60));

                var handler = new JwtSecurityTokenHandler();
                var security = new SecurityTokenDescriptor
                {
                    Issuer = tokenOptions.Issuer,
                    Audience = tokenOptions.Audience,
                    SigningCredentials = tokenOptions.Credentials,
                    Subject = ci,
                    NotBefore = tokenCreation,
                    Expires = tokenExpiration
                };

                var securityToken = handler.CreateToken(security);
                var answer = JsonConvert.SerializeObject(
                    new
                    {
                        access_token = handler.WriteToken(securityToken),
                        expires = tokenExpiration,
                        creation = tokenCreation,
                        data = new { username = login.Username }
                    }
                );

                return await Task.FromResult(Json(answer));
            }

            return Unauthorized();
        }
    }
}
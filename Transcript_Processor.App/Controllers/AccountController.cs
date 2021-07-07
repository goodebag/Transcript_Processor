using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Transcript_Processsor.Models.Models;
using Transcript_Processor_Data.Interfaces;
using Transcript_Processor_Data.Repo_s;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static Transcript_Processsor.Models.Entities.EnumsClass;
using System.IdentityModel.Tokens.Jwt;

namespace Transcript_Processor.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private IConfiguration _config;
        private readonly IUnitofWork<ProcessorContext> _Uow;

        public AccountController(IConfiguration config, IUnitofWork<ProcessorContext> unitofWork)
        {
            _config = config;
            this._Uow = unitofWork;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserRequest login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUserAsync(login);

            if (user != null)
            {
                var ResponseValue = GenerateJSONWebToken(user);
                response = Ok(new { Response = ResponseValue });
            }
            else
            {
                return BadRequest("Invalid Username or Password");
            }
            return response;
        }

        private UserResponse GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userRole = (Role)userInfo.RoleId;
            var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                    new Claim("Name", userInfo.Fullname),
                    new Claim("Role", userRole.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credentials);


            var ResponseToken = new JwtSecurityTokenHandler().WriteToken(token);
            return new UserResponse(userInfo, ResponseToken, userRole.ToString());
        }

        private UserModel AuthenticateUserAsync(UserRequest login)
        {
            UserModel user = null;

            if (login != null)
            {
                var LogedInUser = _Uow.GetRepository<Transcript_Processsor.Models.Entities.User>().JustSingle(p => p.UserName == login.Username && p.Password == login.Password);
                if (LogedInUser != null)
                {
                    user = new UserModel { Username = LogedInUser.UserName, RoleId = (int)LogedInUser.Role, Fullname = LogedInUser.FullName };
                    return user;
                }
                else
                {
                    return user;
                }

            }
            else
            {
                return user;
            }

        }
    }
}

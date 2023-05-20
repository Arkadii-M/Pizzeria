using API.Models;
using API.Services;
using BLL.Implementation;
using BLL.Interface;
using DAL;
using DAL.Implementation;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IRegisterService registerService;
        private readonly ITokenService tokenService;
        private readonly IUserService userService;

        public AccountController(
            IAuthenticationService authenticationService,
            IRegisterService registerService,
            ITokenService tokenService,
            IUserService userService) 
        {
            this.authenticationService = authenticationService;
            this.registerService = registerService;
            this.tokenService = tokenService;
            this.userService = userService;
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserModel>> Login(LoginModel model)
        {
            if(await authenticationService.LoginUser(model.Username,model.Password))
            {
                var user = await userService.GetByUserName(model.Username);
                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.RoleName)
                };

                return Ok(new UserModel
                {
                    Id = user.UserId,
                    Email = user.Email,
                    Username = user.UserName,
                    Role = new RoleModel { RoleId = user.Role.RoleId, RoleName = user.Role.RoleName },
                    Token = tokenService.GenerateToken(claims)
                });
            }
            return Unauthorized();
        }

        [Authorize]
        [HttpGet("getme")]
        public async Task<ActionResult<string>> GetCurrentUser()
        {
            var username = HttpContext.User.FindFirstValue(ClaimTypes.Name);
            var user = await userService.GetByUserName(username);

            return Ok(new UserModel
            {
                Username = user.UserName,
                Email = user.Email,
                Id = user.UserId,
                Role = new RoleModel { RoleId = user.Role.RoleId, RoleName = user.Role.RoleName }
            });
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserModel>> Register(RegisterModel model)
        {
            await registerService.RegisterUser(model.Username, model.Email, model.Password);
            var user = await userService.GetByUserName(model.Username);

            var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.RoleName)
                };

            return Ok(new UserModel
            {
                Username = user.UserName,
                Email = user.Email,
                Id = user.UserId,
                Role = new RoleModel { RoleId = user.Role.RoleId, RoleName = user.Role.RoleName },
                Token = tokenService.GenerateToken(claims)
            });
        }




    }
}

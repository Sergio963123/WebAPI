//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Microsoft.IdentityModel.Tokens;
//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using WebAPI.Models;

//namespace WebAPI.Controllers
//{
//    [Produces("application/json")]
//    [Route("api/Account")]
//    [ApiController]
//    public class AccountController : ControllerBase
//    {
   
//        private readonly IConfiguration _configuration;

//        //public AccountController(
//        //    UserManager<ApplicationUser> userManager,
//        //    SignInManager<ApplicationUser> signInManager,
//        //    IConfiguration configuration)
//        //{
//        //    _userManager = userManager;
//        //    _signInManager = signInManager;
//        //    this._configuration = configuration;
//        //}

//        [Route("Create")]
//        [HttpPost]
//        public async Task<IActionResult> CreateUser([FromBody] UsuarioInfo model)
//        {
//            if (ModelState.IsValid)
//            {
//                var user = new  { UserName = model.usuario, Email = model.clave };
//                var result = true;  // await _userManager.CreateAsync(user, model.clave);
//                if (result == true)
//                {
//                    return BuildToken(model);
//                }
//                else
//                {
//                    return BadRequest("Username or password invalid");
//                }
//            }
//            else
//            {
//                return BadRequest(ModelState);
//            }

//        }

//        [HttpPost]
//        [Route("Login")]
//        public async Task<IActionResult> Login([FromBody] UsuarioInfo userInfo)
//        {
//            if (ModelState.IsValid)
//            {
//                var result = true;//await _signInManager.PasswordSignInAsync(userInfo.usuario, userInfo.clave, isPersistent: false, lockoutOnFailure: false);
//                if (result == true)
//                {
//                    return BuildToken(userInfo);
//                }
//                else
//                {
//                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
//                    return BadRequest(ModelState);
//                }
//            }
//            else
//            {
//                return BadRequest(ModelState);
//            }
//        }

//        private IActionResult BuildToken(UsuarioInfo userInfo)
//        {
//            var claims = new[]
//            {
//                new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.usuario),
//                new Claim("miValor", "Lo que yo quiera"),
//                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
//            };

//            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("#asdasdasdasdasdaqwewqdfsfdsfsdf123123"));
//            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//            var expiration = DateTime.UtcNow.AddHours(1);
            
//            JwtSecurityToken token = new JwtSecurityToken(
//               issuer: "sergiomc5c@gmail.com",
//               audience: "sergiomc5c@gmail.com",
//               claims: claims,
//               expires: expiration,
//               signingCredentials: creds);

//            return Ok(new
//            {
//                token = new JwtSecurityTokenHandler().WriteToken(token),
//                expiration = expiration
//            });

//        }


//    }
//}
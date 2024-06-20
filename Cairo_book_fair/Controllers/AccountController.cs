using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AccountController(UserManager<User> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserResgisterDTO NewUser)
        {
            if (ModelState.IsValid)
            {
                //create acc
                User user = new User()
                {
                    Email = NewUser.Email,
                    UserName = NewUser.UserName,
                    PasswordHash = NewUser.Password
                };

                IdentityResult result = await _userManager.CreateAsync(user, NewUser.Password);
                if (result.Succeeded)
                {
                    return Ok("Account Created Successfully");
                }
                return BadRequest(result.Errors);

            }
            return BadRequest(ModelState);
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginDTO LoginUser)
        {
            if (ModelState.IsValid)
            {
                User? userDb = await _userManager.FindByEmailAsync(LoginUser.Email);
                if (userDb != null)
                {
                    //check pass
                    bool IsPassCorrect = await _userManager.CheckPasswordAsync(userDb, LoginUser.Password);
                    if (IsPassCorrect)
                    {
                        //create token
                        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
                        JwtHeader JWTHeader = new(credentials);
                        List<Claim> MyClaims = new();
                        MyClaims.Add(new Claim(ClaimTypes.Name, userDb.UserName));
                        MyClaims.Add(new Claim(ClaimTypes.NameIdentifier, userDb.Id));
                        MyClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, DateTime.Now.ToString()));
                        JwtPayload pyload = new(
                            issuer: _configuration["JWT:ValidIssuer"],
                            audience: _configuration["JWT:ValidAudience"],
                            claims: MyClaims,
                            expires: DateTime.Now.AddDays(30),
                            notBefore: null
                            );
                        JwtSecurityToken token = new(JWTHeader, pyload);
                        return Ok(
                            new
                            {
                                token = new JwtSecurityTokenHandler().WriteToken(token),
                            }
                        );
                    }
                }
                return BadRequest("Invalid User Name");
            }
            return BadRequest(ModelState);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> EditProfile(EditProfileDTO profileDTO)
        {
            string UserName = User.Identity.Name;
            User UserDB = await _userManager.FindByNameAsync(UserName);
            UserDB.Name = profileDTO.Name;
            UserDB.Location = profileDTO.Location;
            UserDB.ProfileImage = profileDTO.ProfileImage;
            UserDB.Bio = profileDTO.Bio;
            await _userManager.UpdateAsync(UserDB);
            return Ok();

        }

        [HttpGet("userId")]
        public async Task<ActionResult> GetUserId([FromQuery] string email)
        {
            User user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                string UserId = user.Id;
                return Ok(new
                {
                    status = 200,
                    userId = UserId
                });
            }
            else
            {
                return NotFound(new
                {
                    status = 404,
                    message = "Invalid Email"
                });
            }
        }
    }
}

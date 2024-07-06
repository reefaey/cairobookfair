using Cairo_book_fair.DTOs;
using Cairo_book_fair.Models;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Google.Apis.Auth;
using Cairo_book_fair.Repositories;
using Cairo_book_fair.Services;

namespace Cairo_book_fair.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly ICartService _cartService;
        //private readonly ILogger<AccountController> _logger;
        public AccountController(UserManager<User> userManager, IConfiguration configuration, ICartService cartService)
        {
            _userManager = userManager;
            _configuration = configuration;
            _cartService = cartService;
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
                    UserName = NewUser.Username,
                    PasswordHash = NewUser.Password,
                    Name = NewUser.Fullname,
                    Location = NewUser.Location,
                    ProfileImage = NewUser.ProfileImage,
                    Bio = NewUser.Bio,
                };

                IdentityResult result = await _userManager.CreateAsync(user, NewUser.Password);

                if (result.Succeeded)
                {
                    _cartService.Insert(user.Id);
                    _cartService.Save();
                    //_cartService.UpdateID(user.CartId, user.Id);

                    IdentityResult res = await _userManager.AddToRoleAsync(user, "User");
                    if (res.Succeeded)
                    {
                        return Ok(new { message = "User registered successfully" });
                    }
                }
                return BadRequest(result.Errors);

            }
            return BadRequest("Passwords do not match or model is invalid.");
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
                        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["JWT:SigninKey"]));
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
                            expires: DateTime.Now.AddMinutes(5),
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
                return Unauthorized("Invalid username or password");
            }
            return BadRequest(ModelState);
        }

        //[Authorize]
        [HttpPut("EditAccount")]
        public async Task<ActionResult> EditProfile(EditProfileDTO profileDTO)
        {
            string UserName = User.Identity.Name;
            User UserDB = await _userManager.FindByNameAsync(UserName);

            if (UserDB != null)
            {
                UserDB.Name = profileDTO.Name;
                UserDB.Location = profileDTO.Location;
                UserDB.ProfileImage = profileDTO.ProfileImage;
                UserDB.Bio = profileDTO.Bio;

                IdentityResult result = await _userManager.UpdateAsync(UserDB);
                if (result.Succeeded)
                {
                    return Ok(new
                    {
                        message = "Profile updated successfully",
                        user = new
                        {
                            UserDB.Name,
                            UserDB.Location,
                            UserDB.ProfileImage,
                            UserDB.Bio
                        }
                    });
                }
                return BadRequest(result.Errors);
            }
            return NotFound(new { message = "User not found" });
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

        //[HttpGet("GoogleLogin")]
        //public IActionResult GoogleLogin()
        //{
        //    AuthenticationProperties properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
        //    return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        //}

        //[HttpGet("GoogleResponse")]
        //public async Task<IActionResult> GoogleResponse()
        //{
        //    var result = await HttpContext.AuthenticateAsync(IdentityConstants.ExternalScheme);
        //    if (!result.Succeeded)
        //        return BadRequest(); // Handle error scenario

        //    var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
        //    {
        //        claim.Type,
        //        claim.Value
        //    });

        //    // Here you would typically create or update the user in your database
        //    // and generate a JWT token for them

        //    return Ok(claims);
        //}
        [HttpPost("google-login")]
        public async Task<ActionResult> GoogleLogin([FromBody] GoogleLoginDTO googleLoginDto)
        {
            string idtoken = googleLoginDto.IdToken;

            var googleClientId = _configuration["GoogleOAuth:ClientId"];
            var googleClientSecret = _configuration["GoogleOAuth:ClientSecret"];

            if (string.IsNullOrEmpty(googleClientId))
            {
                throw new ArgumentException("The 'ClientId' option must be provided.", nameof(googleClientId));
            }

            var setting = new GoogleJsonWebSignature.ValidationSettings
            {
                Audience = new string[] { googleClientId }
            };
            var result = await GoogleJsonWebSignature.ValidateAsync(idtoken,setting);
            if(result != null)
            {
                //create token
                SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["JWT:SigninKey"]));
                SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
                JwtHeader JWTHeader = new(credentials);
                List<Claim> MyClaims = new();
                MyClaims.Add(new Claim(ClaimTypes.Email, result.Email));
                MyClaims.Add(new Claim(ClaimTypes.NameIdentifier, result.JwtId));
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
            return BadRequest("Login Failure");
            
        }   

    }
}

using Microsoft.AspNetCore.Mvc;
using seChat.Server.Data;
using seChat.Server.Dtos;
using seChat.Server.Helpers;
using seChat.Server.Models;

namespace seChat.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository repository;
        private readonly JwtService jwtService;

        public AuthController(IUserRepository repository, JwtService jwtService)
        {
            this.repository = repository;
            this.jwtService = jwtService;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            var created = repository.Create(user);
            if (created is null) return BadRequest(new { message = "User already exists" });
            else return Created("success", created);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = repository.GetByName(dto.Name);

            if (user is null) return BadRequest(new { message = "Invalid credentials" });

            if(!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password)) return BadRequest(new { message = "Invalid credentials" });

            var jwt = jwtService.Generate(user.Id);


            Response.Cookies.Append("jwt", jwt, new CookieOptions
            {
                HttpOnly = true
            });
            return Ok(new
            {
                message = "success"
            });
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];
                var token = jwtService.Verify(jwt);

                var userId = int.Parse(token.Issuer);

                var user = repository.GetById(userId);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            if (Request.Cookies["jwt"] == null) return BadRequest(new { message = "User not logged in"});
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "success"
            });
        }
    }
}

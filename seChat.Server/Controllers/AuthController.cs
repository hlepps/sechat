using Microsoft.AspNetCore.Mvc;
using seChat.Server.Data;
using seChat.Server.Dtos;
using seChat.Server.Models;

namespace seChat.Server.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUserRepository repository;

        public AuthController(IUserRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            
            return Created("success", repository.Create(user));
        }

        
    }
}

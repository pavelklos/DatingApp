using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    // api/auth
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpPost("register")]
        // public async Task<IActionResult> Register(string username, string password)
        public async Task<IActionResult> Register(UserForRegisterDto dto)
        {
            // If [ApiController] we don't need to validate ModelState.IsValid
            // if (!ModelState.IsValid)
            //     return BadRequest(ModelState);

            dto.Username = dto.Username.ToLower();

            if (await _repo.UserExists(dto.Username))
                return BadRequest("Username already exists"); // 400 status

            var userToCreate = new User
            {
                Username = dto.Username
            };

            var createdUser = await _repo.Register(userToCreate, dto.Password);

            // return CreatedAtRoute()
            return StatusCode(201); // 201 status
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto dto)
        {
            var userFromRepo = await _repo.Login(dto.Username.ToLower(), dto.Password);

            if (userFromRepo == null)
                return Unauthorized(); // 401 status

            // Claims : Id, Username
            var Claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userFromRepo.Id.ToString()),
                new Claim(ClaimTypes.Name, userFromRepo.Username)
            };

            // Key
            // [appsettings.json] get value from "AppSettings:Token"
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            // Credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            // Token Descriptor
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(Claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            // JWT Security Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // JWT - Json Web Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}
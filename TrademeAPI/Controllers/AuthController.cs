using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TrademeAPI.Contracts;
using TrademeAPI.Model;

namespace TrademeAPI.Controllers
{
       
    public class AuthController : Controller
    {
        //public static User user = new User();
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;

        public AuthController(
            IRepository<User> userRepository,
            IConfiguration config
        )
        {
            _userRepository = userRepository;
            _configuration = config;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto req)
        {
            if (string.IsNullOrWhiteSpace(req.Username))
            {
                throw new ArgumentException("User Name is required");
            }
            if (string.IsNullOrWhiteSpace(req.Password))
            {
                throw new ArgumentException("password is required");
            }

            var existingUser = await _userRepository.Any(x => x.UserName == req.Username);
            if (existingUser)
            {
                throw new ArgumentException("the User Name already exist");
            }

            
            CreatePasswordHash(req.Password, out byte[] passwordHash, out byte[] passwordSalt);
            var user1 = new User();
            var Uid = Guid.NewGuid();
            user1.Guid = Uid;
            user1.UserName = req.Username;
            user1.PasswordHash = passwordHash;
            user1.PasswordSalt = passwordSalt;

            _userRepository.Add(user1);
            return Ok(user1);
        }

        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(UserDto req)
        {
            var userF = await _userRepository.Single(x => req.Username == x.UserName);
            if (null == userF)
            {
                throw new ArgumentException("user is not found");
            }

            if (!VerifyPasswordHash(req.Password,userF.PasswordHash, userF.PasswordSalt))
            {
                return BadRequest("Wrong pass word");
            }
            string token = CreateToken(userF);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName)
            };
            //_configuration.GetSection("AppSettings:Token").Value
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials:creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }


        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }

        private bool VerifyPasswordHash(string password,  byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                
                var result = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return result.SequenceEqual(passwordHash);
            }
        }
       
    }     
    }

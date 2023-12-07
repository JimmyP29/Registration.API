using Microsoft.IdentityModel.Tokens;
using Registration.API.Models.Data;
using Registration.API.Models.DTO;
using Registration.API.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Registration.API.Services
{
    internal class RegistrationService : IRegistrationService
    {
        private IRegistrationRepository _repository;
        private readonly IConfiguration _configuration;
        
        public async Task<List<UserDTO>> GetUsers()
        {
            var result = new List<UserDTO>();
            var persistedUsers = await _repository.GetUsers();

            foreach (User user in persistedUsers)
            {
                result.Add(new UserDTO(user.Username, user.Email, user.Password));
            }

            return result;
        }

        public async Task<string?> LoginUser(string username, string password)
        {
            var user = _repository.GetUsers().Result.Find(user => user.Username == username && user.Password == password);

            if (user == null) return null;

            var token = CreateToken(username);

            return token;
        }

        public async Task<UserDTO> RegisterUser(UserDTO user)
        {
            var userToRegister = new User(user.Username, user.Email, user.Password);
            var registeredUser = await _repository.RegisterUser(userToRegister);

            return new UserDTO(registeredUser.Username, registeredUser.Email, registeredUser.Password); 
        }

        private string CreateToken(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims, 
                expires: DateTime.Now.AddDays(1), 
                signingCredentials: credentials
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public RegistrationService(IConfiguration configuration)
        {
            _repository = new RegistrationRepository();
            _configuration = configuration;
        }
    }
}

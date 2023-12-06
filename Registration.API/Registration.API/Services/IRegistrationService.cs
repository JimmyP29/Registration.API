using Registration.API.Models;

namespace Registration.API.Services
{
    public interface IRegistrationService
    {
        public Task<List<UserDTO>> GetUsers();
        public Task<IResult> RegisterUser(UserDTO user);
        public Task<IResult> LoginUser(string username, string password);
    }
}

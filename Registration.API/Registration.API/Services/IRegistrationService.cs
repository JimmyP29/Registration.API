using Registration.API.Models.DTO;

namespace Registration.API.Services
{
    internal interface IRegistrationService
    {
        public Task<List<UserDTO>> GetUsers();
        public Task<IResult> RegisterUser(UserDTO user);
        public Task<IResult> LoginUser(string username, string password);
    }
}

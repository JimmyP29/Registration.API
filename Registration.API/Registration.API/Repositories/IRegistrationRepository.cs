using Registration.API.Models.Data;
using Registration.API.Models.DTO;

namespace Registration.API.Repositories
{
    internal interface IRegistrationRepository
    {
        public Task<List<User>> GetUsers();
        public Task<IResult> RegisterUser(UserDTO user);
        public Task<IResult> LoginUser(string username, string password);
    }
}

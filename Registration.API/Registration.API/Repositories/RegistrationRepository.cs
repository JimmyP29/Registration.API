using Registration.API.Models;

namespace Registration.API.Repositories
{
    internal class RegistrationRepository : IRegistrationRepository
    {
        public Task<List<UserDTO>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<IResult> LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> RegisterUser(UserDTO user)
        {
            throw new NotImplementedException();
        }
    }
}

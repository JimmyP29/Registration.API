using Registration.API.Data;
using Registration.API.Models.Data;
using Registration.API.Models.DTO;

namespace Registration.API.Repositories
{
    internal class RegistrationRepository : IRegistrationRepository
    {
        private readonly RegistrationDBContext _dbContext;
        public async Task<List<User>> GetUsers()
        {
            return _dbContext.Users.ToList();
        }

        public Task<IResult> LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> RegisterUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public RegistrationRepository()
        {
            _dbContext = new RegistrationDBContext(); 
        }
    }
}

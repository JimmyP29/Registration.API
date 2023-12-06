using Registration.API.Models;
using Registration.API.Repositories;

namespace Registration.API.Services
{
    public class RegistrationService : IRegistrationService
    {
        private IRegistrationRepository _repository;
        
        public async Task<List<UserDTO>> GetUsers()
        {
            return await _repository.GetUsers();
        }

        public async Task<IResult> LoginUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> RegisterUser(UserDTO user)
        {
            throw new NotImplementedException();
        }

        public RegistrationService()
        {
            _repository = new RegistrationRepository();
        }
    }
}

using Registration.API.Models.Data;
using Registration.API.Models.DTO;
using Registration.API.Repositories;

namespace Registration.API.Services
{
    internal class RegistrationService : IRegistrationService
    {
        private IRegistrationRepository _repository;
        
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

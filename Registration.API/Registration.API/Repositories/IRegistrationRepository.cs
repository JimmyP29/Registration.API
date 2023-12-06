using Registration.API.Models.Data;

namespace Registration.API.Repositories
{
    internal interface IRegistrationRepository
    {
        public Task<List<User>> GetUsers();
        public Task<User> RegisterUser(User user);
        public Task<IResult> LoginUser(string username, string password);
    }
}

using Registration.API.Data;
using Registration.API.Models.Data;

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

        public async Task<User> RegisterUser(User user)
        {
           _dbContext.Users.Add(user);
           _dbContext.SaveChanges();

           return user;
        }

        public RegistrationRepository()
        {
            _dbContext = new RegistrationDBContext(); 
        }
    }
}

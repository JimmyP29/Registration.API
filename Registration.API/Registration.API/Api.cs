using Registration.API.Models.DTO;
using Registration.API.Services;

namespace Registration.API
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/users", GetUsers);

            app.MapPost("/register", RegisterUser);

            app.MapPost("/login", LoginUser);
        }

        private static async Task<IResult> GetUsers(IRegistrationService registrationService)
        {
            try
            {
                var users = await registrationService.GetUsers();

                if (users == null) return Results.BadRequest();

                if (users.Count == 0) return Results.Ok("No Users in the system");

                return Results.Ok(users);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> RegisterUser(UserDTO user, IRegistrationService registrationService)
        {
            try
            {
                var registeredUser = await registrationService.RegisterUser(user);

                if (registeredUser == null) return Results.BadRequest();

                return Results.Ok(registeredUser);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> LoginUser(string username, string password, IRegistrationService registrationService)
        {
            try
            {
                var user = await registrationService.LoginUser(username, password);

                if (user == null) return Results.BadRequest();

                return Results.Ok(user);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}

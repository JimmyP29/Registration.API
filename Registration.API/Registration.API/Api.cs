using Registration.API.Models;
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
                var results = await registrationService.GetUsers();

                if (results == null) return Results.BadRequest();

                if (results.Count == 0) return Results.Ok("No Users in the system");

                return Results.Ok(results);
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
                var result = await registrationService.RegisterUser(user);

                if (result == null) return Results.BadRequest();

                return Results.Ok(result);
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
                var result = await registrationService.LoginUser(username, password);

                if (result == null) return Results.BadRequest();

                return Results.Ok(result);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
    }
}

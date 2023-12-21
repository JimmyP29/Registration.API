using System.Security.Claims;

namespace Registration.API
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/users", GetUsers).RequireAuthorization();

            /*app.MapPost("/register", RegisterUser);

            app.MapPost("/login", LoginUser);*/
        }

        private static async Task<IResult> GetUsers(ClaimsPrincipal user)
        {
            return Results.Ok($"User {user.Identity!.Name}");
        }

/*        private static async Task<IResult> GetUsers(IRegistrationService registrationService)
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

                return Results.Created("Registered Successfully", registeredUser);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> LoginUser(LoginDTO login, IRegistrationService registrationService)
        {
            try
            {
                var token = await registrationService.LoginUser(login.Username, login.Password);

                if (token == null) return Results.BadRequest("Credentials were incorrect");

                return Results.Ok(token);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }*/
    }
}

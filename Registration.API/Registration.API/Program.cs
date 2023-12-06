using Registration.API;
using Registration.API.Models;
using Registration.API.Repositories;
using Registration.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRegistrationService, RegistrationService>();
builder.Services.AddSingleton<IRegistrationRepository, RegistrationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var users = new List<UserDTO>();


/*app.MapPost("/register", (UserDTO user) => {
    users.Add(user);
});

app.MapPost("/login", (string username, string password) => {
   
});

app.MapGet("/users", () => {
    return users;
});*/
app.ConfigureApi();


app.Run();




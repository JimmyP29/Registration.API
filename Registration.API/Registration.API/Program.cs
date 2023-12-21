using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Registration.API;
using Registration.API.Data;
using Registration.API.Repositories;
using Registration.API.Services;

var myAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IRegistrationService, RegistrationService>();
builder.Services.AddSingleton<IRegistrationRepository, RegistrationRepository>();
builder.Services.AddDbContext<RegistrationDBContext>(options => options.UseInMemoryDatabase("Registration"));

builder.Services.AddIdentityCore<IdentityUser>()
    .AddEntityFrameworkStores<RegistrationDBContext>()
    .AddApiEndpoints();

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddCors(options =>
{
    options.AddPolicy(myAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("http://localhost:3000",
                                                  "http://localhost:3000")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<IdentityUser>();

app.UseCors(myAllowSpecificOrigins);

app.ConfigureApi();

app.Run();

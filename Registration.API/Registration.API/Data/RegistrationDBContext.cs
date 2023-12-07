using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Registration.API.Models.Data;

namespace Registration.API.Data
{
    public class RegistrationDBContext : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Registration");
        }

        public DbSet<User> Users { get; set; }  
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Registration.API.Models.Data;

namespace Registration.API.Data
{
    public class RegistrationDBContext : IdentityDbContext<IdentityUser>
    {
        public RegistrationDBContext(DbContextOptions<RegistrationDBContext> options): base(options) { }
        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseInMemoryDatabase(databaseName: "Registration");
         }*/

         public DbSet<User> Users { get; set; }  
    }
}

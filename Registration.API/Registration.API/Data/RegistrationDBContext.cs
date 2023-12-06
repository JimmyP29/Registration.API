using Microsoft.EntityFrameworkCore;
using Registration.API.Models.Data;

namespace Registration.API.Data
{
    public class RegistrationDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase(databaseName: "Registration");
        }

        public DbSet<User> Users { get; set; }  
    }
}

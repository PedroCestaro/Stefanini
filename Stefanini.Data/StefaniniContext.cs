using Microsoft.EntityFrameworkCore;
using Stefanini.Data.Mappings;
using Stefanini.Domain.Aggregates;

namespace Stefanini.Data
{
    public class StefaniniContext : DbContext
    {
        
        public DbSet<Person> Persons { get; set; }
        public DbSet<City> Cities { get; set; }

        public StefaniniContext(DbContextOptions options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonMapping());   
            modelBuilder.ApplyConfiguration(new CityMapping());   
        }

    }
}

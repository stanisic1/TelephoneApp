using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TelephoneApp.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Telephone> Telephones { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producer>().HasData(
                new Producer() { Id = 1, Name = "Xiaomi", CountryOrigin = "China" },
                new Producer() { Id = 2, Name = "Apple", CountryOrigin = "USA" },
                new Producer() { Id = 3, Name = "Huawei", CountryOrigin = "China" }
                );
            modelBuilder.Entity<Telephone>().HasData(
                new Telephone() { Id = 1, Model = "A94", OperatingSystem = "Android", AvailableAmount = 12, Price = 31125.42m, ProducerId = 3 },
                new Telephone() { Id = 2, Model = "13T Pro", OperatingSystem = "Android", AvailableAmount = 7, Price = 104999.99m, ProducerId = 1 },
                new Telephone() { Id = 3, Model = "11", OperatingSystem = "iOS", AvailableAmount = 17, Price = 71290.35m, ProducerId = 2 },
                new Telephone() { Id = 4, Model = "Reno10 Pro", OperatingSystem = "Android", AvailableAmount = 4, Price = 68264.74m, ProducerId = 3 },
                new Telephone() { Id = 5, Model = "12 Lite", OperatingSystem = "Android", AvailableAmount = 5, Price = 44999.56m, ProducerId = 1 }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}

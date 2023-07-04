using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace EFMigrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddDbContext<MyDbContext>(options =>
                    options.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_password"))
                .BuildServiceProvider();

            using (var context = serviceProvider.GetService<MyDbContext>())
            {
                // Use context here
            }
        }
    }

    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define your model here
            base.OnModelCreating(modelBuilder);
        }
    }

    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseNpgsql("Host=my_host;Database=my_db;Username=my_user;Password=my_password");

            return new MyDbContext(optionsBuilder.Options);
        }
    }
}

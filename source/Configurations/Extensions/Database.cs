using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Configurations.Extensions
{
    public static class Database
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<DataContext>();
            
            context.Database.EnsureCreated();
            DbInitializer.Initialize(context);
        }
    }

    public static class DbInitializer
    {
        private const int total = 10;
        public static void Initialize(DataContext context)
        {
            if (context.Devices.Any())
                return;

            var devices = new List<Device>(total);

            for (var i = 0; i < total; i++)
            {
                string name = Guid.NewGuid().ToString().ToUpper()[..6];
          
                devices.Add(new Device
                {
                    Name = name,
                    Signal = Random.Shared.NextDouble()
                });
            }

            context.AddRange(devices);

            context.SaveChanges();
        }
    }
}

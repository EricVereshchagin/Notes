using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.DependencyInjection;
using Notes.Persistence;

namespace Notes.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvoder = scope.ServiceProvider;
                
                    var context = serviceProvoder.GetRequiredService<NotesDbContext>();
                    DbInitializer.Initialize(context);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

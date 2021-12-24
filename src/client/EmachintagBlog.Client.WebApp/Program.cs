using EmachintagBlog.Client.WebApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace EmachintagBlog.Client.WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                try
                {
                    var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                    var getUser = await userManager.FindByEmailAsync("admin1@admin.com");

                    if (getUser == null)
                    {
                        var result = await userManager.CreateAsync(new ApplicationUser
                        {
                            Email = "admin1@admin.com",
                            FullName = "Admin User",
                            UserName = "adminuser2222",
                            Type = Common.Enums.UserTypeEnum.ADMIN
                        }, "123");
                    }
                }
                catch (Exception ex)
                {
                }
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
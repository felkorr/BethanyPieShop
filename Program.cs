using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BethanysPieShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //BuildWebHost(args).Run();

            var host = BuildWebHost(args);//cria uma variavel para poder usar o CreateScope

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();//usando o dependency injection container 
                    //para ter acesso ao AppDbContext no qual precisamos para chamar 
                    //o metodo Seed localizado no DbInitializer

                    DbInitializer.Seed(context);
                }
                catch (Exception)
                {

                    throw;
                }

            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)//puxa as informacoes automaticamente do arquivo appsettings.json
                .UseStartup<Startup>()
                .Build();
    }
}

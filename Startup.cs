using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BethanysPieShop
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)//adiciona dependency injection in the startup para usar os dados pegos da classe programa e appsettings.json
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            //o comando a baixo adiciona a funcionalidade de EF Core usando o ConnectionStrings setado 
            //no appsettings.json com o nome "DefaultConnection" usando SQL Server
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));//puxa a informacao direto do appsettings.json(do tipo appsettings)

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();//adiciona a configuracao padrao do Identity, passando um usuario e um role.
            //tambem aponta ao metodo que deve-se usar o AppDbContext para basicamente armazenar a informacao
            //excluindo a necessidade de criar queries para gerenciar os dados junto com o banco de dados.

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPieRepository, PieRepository>();//AddTransient= toda vez que um IPieRepository é solicitado, ele retornará uma nova instancia de MockPieRepository
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();//adiciona o FeedbackRepository no depenency injection container

            services.AddMvc();





        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //adiciona funcoes de middleware, a ordem é importante
            app.UseDeveloperExceptionPage();//adiciona suporte para exceptions sendo mostradas no browser
            app.UseStatusCodePages();//retorna codigos de erro
            app.UseStaticFiles();//adiciona suporte a arquivos estaticos como imagens/css localizados no wwwroot
            //app.UseMvcWithDefaultRoute();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            }
            );
        }
    }
}

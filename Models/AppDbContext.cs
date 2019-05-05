using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>//como IdentityDbContext é uma classe generica
        //usamos o built-in IdentityUser para afunilar as opcoes e funcoes pois ja define as propriedades que
        //eu quero capturar de um usuario
    {

        public AppDbContext(DbContextOptions<AppDbContext> options): base (options)//**ver projetos passados para aencontrar alternativas
        {
            
        }

        public DbSet<Pie> Pies { get; set; }//ira criar uma tabela Pies do tipo Pie

        public DbSet<Feedback> Feedbacks { get; set; }//ira criar uma tabela de Feedback do tipo Feedback

        public DbSet<Category> Categories { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}

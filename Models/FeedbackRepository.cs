using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly AppDbContext _appDbContext;

        public FeedbackRepository(AppDbContext appDbContext)//ja que o feedback sera adicionado
        // ao DB, deve-se ter um DbContext para ser usado no metodo abaixo                                              
        {
            _appDbContext = appDbContext;
        }

        public void AddFeedback(Feedback feedback)//Metodo para adicionar um feedback sendo implementado
        {
            _appDbContext.Feedbacks.Add(feedback);//junta as informacoes inseridas na pagina de feedback
            _appDbContext.SaveChanges();//salva no DB (Commit)
        }

    }
}

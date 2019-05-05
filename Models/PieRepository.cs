using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class PieRepository : IPieRepository
    {

        private readonly AppDbContext _appDbContext;

        public PieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public IEnumerable<Pie> Pies //irá carregar todas as pies e incluir suas categorias
        {
            get { return _appDbContext.Pies.Include(c => c.Category); }
        }

        public IEnumerable<Pie> PiesOfTheWeek //irá carregar todas as pies e incluir suas categorias somente as OfTheWeek forem true
        {
            get { return _appDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek); }
        }

        public IEnumerable<Pie> GetAllPies()//retorna todas as Pies do context
        {
            return _appDbContext.Pies;
        }

      

        public Pie GetPieByID(int pieId)//retorna a primeira Pie do context que bate com o ID passado 
        {
            return _appDbContext.Pies.FirstOrDefault(p => p.Id == pieId);

        }
    }
}

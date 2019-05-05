using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public interface IPieRepository
    {
        //IEnumerable<Pie> Pies { get; }//Mesmo que GetAllPies

        IEnumerable<Pie> GetAllPies(); //metodo para retornar todas as tortas, mesmo que Pies

        IEnumerable<Pie> PiesOfTheWeek { get; }

        Pie GetPieByID(int pieId);//Como é uma interface, nao é necessario fazera implementacao do metodo, sera implementado no MockPieRepository


    }
}

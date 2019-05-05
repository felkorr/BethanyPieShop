using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        
        private readonly IFeedbackRepository _feedbackRepository;//determina a depedencia da interface IFeedbackRepository

        public FeedbackController(IFeedbackRepository feedbackRepository)//injeta a dependencia do 
        //feedbackRepository via constructor injection neste controler
        {
            _feedbackRepository = feedbackRepository;
        }


        // GET: /<controller>/
        public IActionResult Index()//action method
        {
            return View();
        }

        [HttpPost]//indica que este metodo somente sera invocado quando o metodo post for chamado no controller
        public IActionResult Index(Feedback feedback)//se chama index pois é o que esta definido no view Index
        {
            if (ModelState.IsValid)
            {
                _feedbackRepository.AddFeedback(feedback);//passa o feedback para o feedbackRepository
                return RedirectToAction("FeedbackComplete");//redireciona para outro action method
            }
            else
            {
                return View(feedback);//se nao for valido, retorna o usuario para a pagina
                //que estava antes com as informacoes inseridas por ele junto com as validacoes
            }
            
        }

        public IActionResult FeedbackComplete()//action method
        {
            return View();
        }
    }
}

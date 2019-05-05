using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class AccountController : Controller
    {
        //a serem usados no dependency injection
        private readonly SignInManager<IdentityUser> _signInManager;//permite adicionar funcoes de login, logout e etc
        private readonly UserManager<IdentityUser> _userManager;//permite gerenciar user roles, criar usuarios e etc


        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);//se os dados do usuario forem invalidos, retorna para a tela com os dados digitados e mensagens de erro

            //Abaixo: cria uma variavel user usando o UserName digitado pelo usuario e usa o UserManager para buscar o nome do usuario
            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if (user != null)//se o metodo acima retornar um usuario, entao tenta logar com o usuario
            {
                var result = await _signInManager.PasswordSignInAsync
                    (user, loginViewModel.Password, false, false);//usa o metodo de login async usando nome e senha digitados pelo usuario

                if (result.Succeeded)//se correto, redireciona para o index action do HomeController
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "User name/password not found");//Se nao, mostra mensagem de erro no summary da pagina
            return View(loginViewModel);

        }

        public IActionResult Register()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {

                var user = new IdentityUser()//cria um objeto de IdentityUser baseado no user que foi digitado pelo usuario
                { UserName = loginViewModel.UserName };

                var result = await _userManager.CreateAsync(user, loginViewModel.Password);//solicita ao userManager
                //que crie um novo usuario com o nome dentro do objeto Identity user + o password 
                //se criado com sucesso, retorna verdadeito para a variavel result

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }


                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                //ModelState.AddModelError("", result.ToString());
                return View(loginViewModel);

            }
            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

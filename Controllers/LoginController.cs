using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        [TempData]
        public string Mensagem { get; set; }
        Jogador JogaModel = new Jogador();
        public IActionResult Index(){
            return View();
        }
        
        [Route("Logar")]
        public IActionResult Logar(IFormCollection form){
            
            List<string> JogadoresCSV = JogaModel.LerTodasLinhasCSV("Database/jogador.csv");

            var logado = JogadoresCSV.Find(
                x =>
                x.Split(";")[3] == form["Email"] &&
                x.Split(";")[4] == form["Senha"]
            );

            if (logado != null)
            {
                HttpContext.Session.SetString("_UserName", logado.Split(";")[1]);
                return LocalRedirect("~/");
            }
            
            Mensagem = "Dados Incorretos, tente novamente...";
            return LocalRedirect("~/Login");
        }

        [Route("Logout")]
        public IActionResult Logout(){
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/");
        }
    }
}
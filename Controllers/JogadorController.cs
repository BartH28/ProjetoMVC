
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogaModel = new Jogador();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Jogadores = jogaModel.LerTodos();
            return View();
        }


        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Jogador jojo = new Jogador();
            jojo.Idjogador = Int32.Parse(form["Idjogador"]);
            jojo.Nome = form["Nome"];
            jojo.idequipe = Int32.Parse(form["idequipe"]);
            jojo.Email = form["Email"];
            jojo.Senha= form["Senha"];

            jogaModel.Criar(jojo);

            ViewBag.Jogadores = jogaModel.LerTodos();

            return LocalRedirect("~/Jogador/Listar");
        }
    }
}

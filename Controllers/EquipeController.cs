using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();

        [Route("Listar")]
        public IActionResult Index()
        {
            ViewBag.Equipes = equipeModel.LerTodas();
            return View();
        }


        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe = new Equipe();
            novaEquipe.IDEquipe = Int32.Parse(form["IDEquipe"]);
            novaEquipe.Nome = form["Nome"];
            // novaEquipe.Imagem = form["Imagem"];

            if (form.Files.Count > 0)
            {
                var img = form.Files[0];
                var imgFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

                if (!Directory.Exists(imgFolder))
                {
                    Directory.CreateDirectory(imgFolder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwwroot/img/", imgFolder, img.FileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    img.CopyTo(stream);
                }

                novaEquipe.Imagem = img.FileName;
            }
            else
            {
                novaEquipe.Imagem = "padrao.png";
            }

            equipeModel.Criar(novaEquipe);

            ViewBag.Equipes = equipeModel.LerTodas();

            return LocalRedirect("~/Equipe/Listar");
        }
        [Route("Excluir/{id}")]
        public IActionResult Excluir(int id){
            equipeModel.Deletar(id);
            ViewBag.Equipes = equipeModel.LerTodas();
            return LocalRedirect("~/Equipe/Listar");
        }
    }
}
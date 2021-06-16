using System;
using EplayersMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayersMVC.Controllers
{
    [Route("Equipe")]
    public class EquipeController : Controller
    {
        Equipe equipeModel = new Equipe();//classe objeto pai

        [Route("Listar")]
        public IActionResult Index(){//index = padrão || está listando as equipes, nesse caso

            ViewBag.Equipes = equipeModel.LerTodas();  //viewbag é como uma variável que guarda os valores da lista que vem do ler todas
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form){  //formulário e nome formulário como argumentos ~= int 1
            Equipe novaEquipe = new Equipe();  //classe objeto filha usada para pegar os dados do formulário e criar uma equipe nova
            novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome = form["Nome"];
            novaEquipe.Imagem = form["Imagem"];

            equipeModel.Criar(novaEquipe);// pai cria o filho 

            ViewBag.Equipes = equipeModel.LerTodas(); //faz de novo pq adicionou uma equipe

            return LocalRedirect("~/Equipe/Listar"); // está redirecionando para um local, no caso é o mesmo então ele recarrega a página e mostra atualizado
        }
    }
}
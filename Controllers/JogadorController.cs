using System;
using EplayersMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayersMVC.Controllers
{
    [Route("Jogador")]
    public class JogadorController : Controller
    {
        Jogador jogadorModel = new Jogador();
        Equipe equipeModel = new Equipe();
        
        [Route("Listar")]
        public IActionResult Index(){
            
            ViewBag.Jogadores = jogadorModel.LerTodos();
            ViewBag.Equipes = equipeModel.LerTodas();
            return View();
        }

        [Route("Cadastrar")]
        public IActionResult Cadastrar(IFormCollection form){
            Jogador novoJogador = new Jogador();
            novoJogador.IdJogador = Int32.Parse(form["IdJogador"]);
            novoJogador.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novoJogador.Nome = form["Nome"];
            novoJogador.Email = form["Email"];
            novoJogador.Senha = form["Senha"];

            jogadorModel.Criar(novoJogador);

            ViewBag.Jogadores = jogadorModel.LerTodos();

            return LocalRedirect("~/Jogador/Listar");
        }
    }
}
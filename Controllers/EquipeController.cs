using System;
using System.IO;
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
            // novaEquipe.Imagem = form["Imagem"];

            if (form.Files.Count > 0)
            {
                var file = form.Files[0]; //armazena o arquivo do formulario dentro da variavel file
                var folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/Equipes"); //cria a variavel pasta

                if (!Directory.Exists(folder)) //cria a pasta
                {
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Img/", folder, file.FileName); //cria o caminho na variavel

                using (var stream = new FileStream(path, FileMode.Create)) //criando e salvando o arquivo
                {
                    file.CopyTo(stream);//copia o arquivo no stream 
                }

                novaEquipe.Imagem = file.FileName; //recebe o nome do arquivo

            } else
            {
                novaEquipe.Imagem = "padrao.png"; //padrao.png é uma img padrao que ficará salva para quem não colocar nenhuma imagem
            }

            equipeModel.Criar(novaEquipe);// pai cria o filho 

            ViewBag.Equipes = equipeModel.LerTodas(); //faz de novo pq adicionou uma equipe

            return LocalRedirect("~/Equipe/Listar"); // está redirecionando para um local, no caso é o mesmo então ele recarrega a página e mostra atualizado
        }

        [Route("Excluir/{id}")] //passando o id de deletar pela rota
        public IActionResult Excluir(int id){
            equipeModel.Deletar(id);
            ViewBag.Equipes = equipeModel.LerTodas();

            return LocalRedirect("~/Equipe/Listar");
        }
    }
}
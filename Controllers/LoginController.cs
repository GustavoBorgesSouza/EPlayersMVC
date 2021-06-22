using System.Collections.Generic;
using EplayersMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EPlayersMVC.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        [TempData]  //dado temporário
        public string Mensagem { get; set; }
        Jogador jogadorModel = new Jogador();
        public IActionResult Index()
        {

            return View();
        }

        [Route("Logar")]
        public IActionResult Logar(IFormCollection form)
        {
            List<string> jogadoresCSV = jogadorModel.LerTodasLinhasCSV("Database/jogador.csv");

            var logado = jogadoresCSV.Find(
                x =>
                x.Split(";")[3] == form["Email"] &&
                x.Split(";")[4] == form["Senha"]
                );

            if (logado != null)
            {
                HttpContext.Session.SetString("_UserName", logado.Split(";")[2]);
                return LocalRedirect("~/");
            }
            else
            {
                Mensagem = "Dados Incorretos, teste novamente...";
                return LocalRedirect("~/Login");
            }

        }

        [Route("Logout")]
        public IActionResult Logout(){
            HttpContext.Session.Remove("_UserName");
            return LocalRedirect("~/");
        }

    }
}
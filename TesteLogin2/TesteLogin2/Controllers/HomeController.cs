using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteLogin2.Models;

namespace TesteLogin2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult MenuPrincipal()
        {
            Login login = new Login();
            @ViewBag.usuario = login.getUsuario();
            return View();
        }

        [HttpPost]
        public ActionResult ControleLogin(FormCollection form)
        {
            Comandos comando = new Comandos(); //instancia a classe com o comando
            comando.verificarLogin(form["Usuario"].ToString(), form["Senha"].ToString());

            if (comando.mensagem.Equals("")) //se não tiver msg de erro (deu certo)
                if (comando.T) //se o bool for True
                {
                    Login login = new Login();
                    login.setUsuario(form["Usuario"].ToString());
                    return RedirectToAction("MenuPrincipal", "Home").Mensagem("Login efetuado com sucesso", "Logado!");
                }
                else //se o bool for False, ou seja, não encontrou o usuário e a senha
                {
                    return RedirectToAction("Index", "Home").Mensagem("Usuário/senha inválidos", "Erro!");
                }
            else //se houve erro ao executar a leitura do banco
            {
                return RedirectToAction("Index", "Home").Mensagem("Erro com banco de dados.", "Erro");
            }
        }

        public ActionResult Deslogar()
        {
            Login login = new Login();
            login.setUsuario("");
            return RedirectToAction("Index", "Home").Mensagem("Usuário deslogado com sucesso.", "Deslogado");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TesteLogin2.Models;

namespace TesteLogin2.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult CadastroClientes(int IdCliente = 0)
        {
            //primeira abertura da tela, para cadastrar ou alterar
            // a mesma tela vai cadastrar e editar, dependendo se já existe ID do cliente
            AcessoClientes acesso = new AcessoClientes();
            Clientes cliente = new Clientes();

            if (IdCliente > 0)
            {
                cliente = acesso.IdentificaCliente(IdCliente);
            }
            else
            {
                cliente.IdCliente = 0;
                cliente.DataCadastro = DateTime.Now;
            }

            return View(cliente);
        }

        [HttpPost]
        public ActionResult CadastroClientes(Clientes cliente)
        {
            //para efetuar a ação de cadastrar ou alterar, de acordo com o id
            AcessoClientes acesso = new AcessoClientes();

            if (ModelState.IsValid)
            {
                if (cliente.IdCliente == 0)
                {
                    acesso.CadastraCliente(cliente);
                }
                else
                {
                    acesso.AlteraCliente(cliente);
                }
                return RedirectToAction("ConsultaClientes", "Cliente").Mensagem(acesso.erro);
            }

            return View(cliente).Mensagem(acesso.erro);
            
        }


        public ActionResult ConsultaClientes()
        {
            string erro = "";
            AcessoClientes acesso = new AcessoClientes();

            List<Clientes> lclientes = acesso.ListaClientes();
            
            if (acesso.erro != "")
            {
                erro = acesso.erro;
            }
            if (erro.Length > 0)
            {
                return View(lclientes).Mensagem(erro); //se houver erro aqui, vai mostrar
            }
            return View(lclientes); //se não houver erro aqui, vai exibir as mensagens das páginas que direcionaram para cá
        }

        public ActionResult ConfirmaApagaCliente(int id = 0)
        {
            string erro = "";
            if (id > 0)
            {
                AcessoClientes acesso = new AcessoClientes();
                acesso.ApagaCliente(id);
                erro = acesso.erro;
            }
            else
            {
                erro = "Não é possivel excluir";
            }
            if (erro == "")
            {
                erro = "Cliente excluído com sucesso";
            }
            return RedirectToAction("ConsultaClientes", "Cliente").Mensagem(erro);
 
        }
    }
}
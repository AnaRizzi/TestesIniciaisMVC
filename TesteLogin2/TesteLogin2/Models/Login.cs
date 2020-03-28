using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteLogin2.Models
{
    public class Login
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }

        static string nomeUsuario;

        public void setUsuario(string nome)
        {
            nomeUsuario = nome;
        }

        public string getUsuario()
        {
            return nomeUsuario;
        }
    }
}
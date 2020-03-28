using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TesteLogin2.Models
{
    public class Conexao
    {
        SqlConnection con = new SqlConnection();

        public Conexao()
        {
            //inserir a string de conexão
            con.ConnectionString = @"Data Source=localhost;Initial Catalog=TesteMVC;User ID = sa;Password = 1234567";
            //para logar com o Windows, sem senha: trocar user e Pass por “Integrated Security = True"
            // se logar no BD com senha do SQL, inserir user e password
        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
}


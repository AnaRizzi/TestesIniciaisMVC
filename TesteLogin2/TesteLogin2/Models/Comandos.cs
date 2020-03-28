using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TesteLogin2.Models
{
    public class Comandos
    {
        
        public bool T = false; //para retornar se deu certo (true) ou não (false)
        public String mensagem = ""; //para salvar mensagens de erro
        SqlCommand cmd = new SqlCommand();
        Conexao con = new Conexao(); //instância da classe de Conexão
        SqlDataReader dr; //DataReader, para ler e salvar info do banco

        // método verificar login vai até o banco verificar ver se contém o usuário e senha
        // Se for igual, vai mudar a variável bool para True, que quer dizer que deu certo
        // O sistema vai entender o True como um sinal para entrar no sistema e vai logar
        // se não bater, vai dar mensagem de erro e o bool continua como falso

        public bool verificarLogin(String usuario, String senha)
        {
            // comandos SQl para verificar se tem no banco de dados:
            cmd.CommandText = "select * from Usuario where usuario= @usuario and senha =@senha";
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Parameters.AddWithValue("@senha", senha);

            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();
                if (dr.HasRows) //se tiver alguma linha, ou seja, se tiver encontrado uma combinação (tem no banco)
                {
                    T = true;
                }
                con.Desconectar();

            }
            catch (SqlException)
            {
                this.mensagem = "ERRO COM BANCO DE DADOS!";
            }

            return T; //retorna o bool dizendo se pode entrar (True) ou não (False)
        }

    }
}
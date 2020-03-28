using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TesteLogin2.Models
{
    public class AcessoClientes
    {
        public string erro { get; set; } = "";

        public List<Clientes> ListaClientes()
        {
            // Instancia nossos objetos
            List<Clientes> lclientes = new List<Clientes>();
            Clientes cliente = new Clientes();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();


            // Instancia nossa Conexao
            Conexao con = new Conexao();

            // Nosso comando SQL
            cmd.CommandText = "select * from Clientes order by nome";

            // Se existe erro na conexao move o erro para a classe de 
            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();

                // recebe os dados de nossa consulta
                while (dr.Read())
                {
                    lclientes.Add(read_Cliente(dr));
                }
                
                con.Desconectar();
            }
            catch (SqlException e)
            {
                // Trata os erros de nossa conexão
                this.erro = e.Message.ToString();
            }

            // Retorna nossa lista de dados
            return lclientes;
        }
        
        public Clientes IdentificaCliente(int idCliente)
        {
            Clientes cliente = new Clientes();
            SqlDataReader dr;
            SqlCommand cmd = new SqlCommand();

            // Instancia nossa Conexao
            Conexao con = new Conexao();

            // Nosso comando SQL
            cmd.CommandText = "select * from Clientes where id_cliente = " + idCliente;

            try
            {
                cmd.Connection = con.Conectar();
                dr = cmd.ExecuteReader();

                // recebe os dados de nossa consulta
                while (dr.Read())
                {
                    cliente = read_Cliente(dr);
                }

                con.Desconectar();
            }
            catch (SqlException e)
            {
                // Trata os erros de nossa conexão
                this.erro = e.Message.ToString();
            }

            // Retorna nossa lista de dados
            return cliente;
        }

        public bool CadastraCliente(Clientes cliente)
        {
            bool cadastro = false;
            SqlCommand cmd = new SqlCommand();

            // Instancia nossa Conexao
            Conexao con = new Conexao();

            // Nosso comando SQL
            cmd.CommandText = string.Format("insert into Clientes(nome, email, data_cadastro) values('{0}', '{1}', '{2}')", cliente.NomeCliente, cliente.Email, cliente.DataCadastro.ToString("yyyy'-'MM'-'dd"));

            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                cadastro = true;
            }
            catch (SqlException e)
            {
                // Trata os erros de nossa conexão
                this.erro = e.Message.ToString();
            }

            // Retorna nossa lista de dados
            return cadastro;
        }

        public bool AlteraCliente(Clientes cliente)
        {
            bool alterado = false;
            SqlCommand cmd = new SqlCommand();

            // Instancia nossa Conexao
            Conexao con = new Conexao();

            // Nosso comando SQL
            cmd.CommandText = string.Format("UPDATE Clientes SET nome = '{0}', email = '{1}' , data_cadastro = '{2}' WHERE id_cliente = '{3}'", cliente.NomeCliente, cliente.Email, cliente.DataCadastro.ToString("yyyy'-'MM'-'dd"), cliente.IdCliente);

            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery(); //quando atribuido a int, retorna o número de linhas que foram alteradas
                con.Desconectar();
                alterado = true;
            }
            catch (SqlException e)
            {
                // Trata os erros de nossa conexão
                this.erro = e.Message.ToString();
            }

            // Retorna nossa lista de dados
            return alterado;
        }

        public bool ApagaCliente(Clientes cliente)
        {
            return ApagaCliente(cliente.IdCliente);
        }

        public bool ApagaCliente(int idCliente)
        {
            bool apagado = false;
            SqlCommand cmd = new SqlCommand();

            // Instancia nossa Conexao
            Conexao con = new Conexao();

            // Nosso comando SQL
            cmd.CommandText = string.Format("delete from Clientes where id_cliente = " + idCliente);

            try
            {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                apagado = true;
            }
            catch (SqlException e)
            {
                // Trata os erros de nossa conexão
                this.erro = e.Message.ToString();
            }

            // Retorna nossa lista de dados
            return apagado;
        }
        
        private Clientes read_Cliente(SqlDataReader reader)
        {
            Clientes cliente = new Clientes();
            cliente.IdCliente = Convert.ToInt32(reader["id_cliente"]);
            cliente.NomeCliente = (string)reader["nome"] ?? "";
            cliente.Email = (string)reader["email"] ?? "";
            cliente.DataCadastro = Convert.ToDateTime(reader["data_cadastro"]);

            return cliente;
        }



    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TrabalhoPratico.Database;
using TrabalhoPratico.Models;
using TrabalhoPratico.Helpers;

namespace TrabalhoPratico.Dao
{
    internal class ClienteDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Cliente cliente)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "INSERT INTO Cliente VALUES " +
                "(null, @nome, @cpf, @email, @telefone, @data_nascimento);";

                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@cpf", cliente.Cpf);
                comando.Parameters.AddWithValue("@email", cliente.Email);
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@data_nascimento", cliente.DataNascimento?.ToString("yyyy-MM-dd"));


                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }
                else
                {
                    string saida = Directory.GetCurrentDirectory();
                    saida = saida.Substring(0, saida.Length - 9) + @"Clientes\";
                    Directory.CreateDirectory(saida + cliente.Nome);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cliente> List()
        {
            try
            {
                var lista = new List<Cliente>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Cliente";
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var cliente = new Cliente();

                    cliente.IdCliente = reader.GetInt32("idCliente");
                    cliente.Nome = DAOHelper.GetString(reader, "nome");
                    cliente.Cpf = DAOHelper.GetString(reader, "cpf");
                    cliente.Email = DAOHelper.GetString(reader, "email");
                    cliente.Telefone = DAOHelper.GetString(reader, "telefone");
                    cliente.DataNascimento = DAOHelper.GetDateTime(reader, "dataNascimento");

                    lista.Add(cliente);

                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Cliente t)
        {

            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Cliente WHERE idCliente = @idCliente";

                comando.Parameters.AddWithValue("@idCliente", t.IdCliente);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                    throw new Exception("Registro não removido da base de dados." +
                        " Verifique e tente novamente");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Cliente cliente)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "UPDATE Cliente SET nome = @nome, cpf = @cpf, email = @email, telefone = @telefone, dataNascimento = @data_nascimento WHERE idCliente = @idCliente";



                comando.Parameters.AddWithValue("@idCliente", cliente.IdCliente);
                comando.Parameters.AddWithValue("@nome", cliente.Nome);
                comando.Parameters.AddWithValue("@cpf", cliente.Cpf);
                comando.Parameters.AddWithValue("@email", cliente.Email);
                comando.Parameters.AddWithValue("@telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@data_nascimento", cliente.DataNascimento);



                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Business
{
    public class CadastroBusiness
    {
        public void NovoCadastro(Cliente cliente)
        {
            DbSession session = new DbSession();

            string query = "DECLARE @OutputTbl TABLE(ID INT)";

            query += $"INSERT INTO Cliente (Nome, Cpf, Rg, DataExpedicao, OrgaoExpedicao, UfExpedicao, DataNascimento, Sexo, EstadoCivil) OUTPUT INSERTED.IdCliente INTO @OutputTbl(ID)" +
                           $"VALUES ('{cliente.Nome}','{cliente.Cpf}','{cliente.Rg}','{cliente.DataExpedicao}','{cliente.OrgaoExpedicao}', '{cliente.UfExpedicao}'," +
                           $"'{cliente.DataNascimento}', '{cliente.Sexo}', '{cliente.EstadoCivil}')";

            var endereco = cliente.Enderecos.SingleOrDefault();

            query += $"INSERT INTO EnderecoCliente (Cep, Logradouro, Numero, Complemento, Bairro, Cidade, Uf, IdCliente)" +
                     $"VALUES('{endereco.Cep}', '{endereco.Logradouro}', '{endereco.Numero}', '{endereco.Complemento}', '{endereco.Bairro}', '{endereco.Cidade}', '{endereco.Uf}', (SELECT ID from @OutputTbl))";


            Query executar = session.CreateQuery(query);
            executar.ExecuteNonQuery();
        }

        public void AtualizarCadastro(int id, Cliente cliente)
        {
            DbSession session = new DbSession();

            string query = $"UPDATE Cliente SET Cpf = '{cliente.Cpf}', Nome = '{cliente.Nome}', Rg = '{cliente.Rg}', DataExpedicao = '{cliente.DataExpedicao}'," +
                $" OrgaoExpedicao = '{cliente.OrgaoExpedicao}', UfExpedicao = '{cliente.UfExpedicao}', Sexo = '{cliente.Sexo}', EstadoCivil = '{cliente.EstadoCivil}'," +
                $" DataNascimento= '{cliente.DataNascimento}' " +
                $"WHERE IdCliente = {id}";

            var endereco = cliente.Enderecos.SingleOrDefault();

            query += $"UPDATE EnderecoCliente SET Cep = '{endereco.Cep}', Logradouro = '{endereco.Logradouro}', Numero = '{endereco.Numero}', " +
                $"Complemento = '{endereco.Complemento}', Bairro = '{endereco.Bairro}', Cidade = '{endereco.Cidade}', Uf = '{endereco.Uf}' " +
                $"WHERE IdCliente = {id}";


            Query executar = session.CreateQuery(query);
            executar.ExecuteNonQuery();
        }

        public List<Cliente> BuscarClientes()
        {
            DbSession session = new DbSession();

            string query = $"SELECT * FROM Cliente C " +
                           $"INNER JOIN EnderecoCliente E " +
                           $"ON C.IdCliente = E.IdCliente";

            Query executar = session.CreateQuery(query);
            IDataReader reader = executar.ExecuteQuery();

            List<Cliente> lstClientes = new List<Cliente>();

            while (reader.Read())
            {
                Cliente cliente = new Cliente()
                {
                    IdCliente = int.Parse(reader["IdCliente"].ToString()),
                    Cpf = reader["Cpf"].ToString(),
                    Nome = reader["Nome"].ToString(),
                    Rg = reader["Rg"].ToString(),
                    DataExpedicao = DateTime.Parse(reader["DataExpedicao"].ToString()),
                    OrgaoExpedicao = reader["OrgaoExpedicao"].ToString(),
                    UfExpedicao = reader["UfExpedicao"].ToString(),
                    DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString()),
                    EstadoCivil = reader["EstadoCivil"].ToString(),
                    Sexo = reader["Sexo"].ToString()
                };

                EnderecoCliente endereco = new EnderecoCliente()
                {
                    IdEndereco = int.Parse(reader["IdEndereco"].ToString()),
                    Logradouro = reader["Logradouro"].ToString(),
                    Numero = reader["Numero"].ToString(),
                    Cep = reader["Cep"].ToString(),
                    Cidade = reader["Cidade"].ToString(),
                    Uf = reader["Uf"].ToString(),
                    Bairro = reader["Bairro"].ToString(),
                    Complemento = reader["Complemento"].ToString(),
                    IdCliente = int.Parse(reader["IdCliente"].ToString())
                };

                cliente.Enderecos = new List<EnderecoCliente>();
                cliente.Enderecos.Add(endereco);

                lstClientes.Add(cliente);

            };

            return lstClientes;
        }

        public void ExcluirCadastro(int id)
        {
            DbSession session = new DbSession();

            string query = $"DELETE FROM EnderecoCliente WHERE IdCliente = {id}" +
                           $"DELETE FROM Cliente WHERE IdCliente = {id}";

            Query executar = session.CreateQuery(query);
            executar.ExecuteNonQuery();
        }

        public Cliente BuscarCliente(int id)
        {
            DbSession session = new DbSession();

            string query = $"SELECT * FROM Cliente C " +
                $"INNER JOIN EnderecoCliente E " +
                $"ON C.IdCliente = E.IdCliente " +
                $"WHERE C.IdCliente = {id}";

            Query executar = session.CreateQuery(query);
            IDataReader reader = executar.ExecuteQuery();

            using (reader)
            {
                if (reader.Read())
                {
                    if (!string.IsNullOrEmpty(reader["IdCliente"].ToString()))
                    {
                        Cliente cliente = new Cliente()
                        {
                            IdCliente = int.Parse(reader["IdCliente"].ToString()),
                            Cpf = reader["Cpf"].ToString(),
                            Nome = reader["Nome"].ToString(),
                            Rg = reader["Rg"].ToString(),
                            DataExpedicao = DateTime.Parse(reader["DataExpedicao"].ToString()),
                            OrgaoExpedicao = reader["OrgaoExpedicao"].ToString(),
                            UfExpedicao = reader["UfExpedicao"].ToString(),
                            DataNascimento = DateTime.Parse(reader["DataNascimento"].ToString()),
                            EstadoCivil = reader["EstadoCivil"].ToString(),
                            Sexo = reader["Sexo"].ToString()
                        };

                        EnderecoCliente endereco = new EnderecoCliente()
                        {
                            IdEndereco = int.Parse(reader["IdEndereco"].ToString()),
                            Logradouro = reader["Logradouro"].ToString(),
                            Numero = reader["Numero"].ToString(),
                            Cep = reader["Cep"].ToString(),
                            Cidade = reader["Cidade"].ToString(),
                            Uf = reader["Uf"].ToString(),
                            Bairro = reader["Bairro"].ToString(),
                            Complemento = reader["Complemento"].ToString(),
                            IdCliente = int.Parse(reader["IdCliente"].ToString())
                        };

                        cliente.Enderecos = new List<EnderecoCliente>();
                        cliente.Enderecos.Add(endereco);

                        return cliente;
                    }

                }
                return null;
            }
        }
    }
}

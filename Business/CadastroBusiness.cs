using Domain.Models;
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
    }
}

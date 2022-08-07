using System;
using System.Data.SqlClient;

namespace Business
{
    public class DbSession
    {
        private SqlConnection conexao;

        public DbSession()
        {
            try
            {
                conexao = new SqlConnection("Data Source=.;Initial Catalog=pegi;Integrated Security=True");

                conexao.Open();

            }
            catch (Exception ex)
            {
                throw new Exception("Banco Inválido" + ex.Message);
            }
        }

        public void Close()
        {
            conexao.Close();
        }

        public Query CreateQuery(string sql)
        {
            return new Query(sql, conexao);
        }

        public Query ExecuteTransaction(string query)
        {
            return new Query(query, conexao, string.Empty);
        }

        public void ExecuteSqlTransaction(string query)
        {
            SqlCommand command = conexao.CreateCommand();
            SqlTransaction transaction;

            transaction = conexao.BeginTransaction("SisCastelo");

            command.Connection = conexao;
            command.Transaction = transaction;

            try
            {
                command.CommandText = query;
                command.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    Console.WriteLine("  Message: {0}", ex2.Message);
                }
            }
        }
    }
}

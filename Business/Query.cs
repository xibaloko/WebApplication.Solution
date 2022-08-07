using System;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
    public class Query
    {
        private SqlCommand comando;

        public Query(string sql, SqlConnection connection)
        {
            try
            {
                comando = connection.CreateCommand();
                comando.CommandText = sql;
            }
            catch (Exception ex)
            {
                comando.Dispose();
                throw new Exception(ex.Message);
            }
        }

        public Query(string sql, SqlConnection connection, string conexao)
        {
            SqlTransaction trans = connection.BeginTransaction("SisCastelo");
            try
            {
                comando = connection.CreateCommand();

                //comando.Connection = connection;
                //comando.Transaction = trans;

                comando = new SqlCommand(sql, connection, trans);
                comando.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                comando.Dispose();
                trans.Rollback();
                throw new Exception(ex.Message);
            }
        }

        public DataSet ExecuteDataSet(string table)
        {
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void ExecuteNonQuery()
        {
            comando.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteQuery()
        {
            return comando.ExecuteReader();
        }

        public DataTable fillDataTable(string table)
        {
            SqlDataAdapter da = new SqlDataAdapter(comando);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public Query SetParameter(string nome, object valor)
        {
            var parametro = comando.CreateParameter();
            parametro.ParameterName = nome;
            parametro.Value = valor;
            comando.Parameters.Add(parametro);
            return this;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikKatmani;

namespace EntityLayer
{
    public class DBContext : IDisposable 
    {
        private readonly SqlConnection connection;

        public DBContext()
        {
            connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\abdul\Downloads\Compressed\TeknolojiMagazasi\TeknolojiMagazasi\TeknolojiMagazasi\TeknoDB.mdf;Integrated Security=True");
        }
        public void OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
            }
            catch
            {
                throw;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            catch
            {
                throw;
            }
        }

        public SqlCommand CreateCommand(string procedureName, List<SqlParameter> parameters)
        {
            SqlCommand cmd = new SqlCommand(procedureName, connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameters.ToArray()); 

            return cmd;
        }

        public SqlCommand CreateCommand(string procedureName)
        {
            SqlCommand cmd = new SqlCommand(procedureName, connection);
            cmd.CommandType = CommandType.StoredProcedure;

            return cmd;
        }

        public List<T> ListItems<T>(SqlCommand cmd) where T : IModel 
        {
            OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            List<T> items = new List<T>();

            while (reader.HasRows && reader.Read())
            {
                T item = (T)Activator.CreateInstance(typeof(T));
                item.Read(reader);
                items.Add(item);
            }
            reader.Close();
            CloseConnection();

            return items;
        }

        public T GetItem<T>(SqlCommand cmd) where T : IModel 
        {
            OpenConnection();
            SqlDataReader reader = cmd.ExecuteReader();
            T item = default(T);

            if (reader.HasRows && reader.Read())
            {
                item = (T)Activator.CreateInstance(typeof(T));
                item.Read(reader);
            }
            reader.Close();
            CloseConnection();

            return item;
        }



        public object ExecuteScalar(SqlCommand cmd) 
        {
            OpenConnection();
            object val = cmd.ExecuteScalar();
            CloseConnection();
            return val;
        }

        public int ExecuteNonQuery(SqlCommand cmd) 
        {
            OpenConnection();
            int row_count = cmd.ExecuteNonQuery();
            CloseConnection();
            return row_count;
        }

        public void Dispose()
        {
            connection?.Dispose(); 
        }
    }
}

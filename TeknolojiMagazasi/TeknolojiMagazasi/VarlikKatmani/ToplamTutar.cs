using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class ToplamTutar : IModel
    {
        public int Id { get; set; }
        public decimal ToplamFiyat { get; set; }

        public List<SqlParameter> GetInsertParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@ToplamFiyat", SqlDbType.Decimal) { Value = ToplamFiyat }
        };
            return parameters;
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@Id", SqlDbType.Int) { Value = Id },
            new SqlParameter("@ToplamFiyat", SqlDbType.Decimal) { Value = ToplamFiyat }
        };
            return parameters;
        }

        public void Read(SqlDataReader reader)
        {
            if (reader["Id"] != DBNull.Value)
                Id = Convert.ToInt32(reader["Id"]);
            if (reader["ToplamFiyat"] != DBNull.Value)
                ToplamFiyat = Convert.ToDecimal(reader["ToplamFiyat"]);
        }
    }
}

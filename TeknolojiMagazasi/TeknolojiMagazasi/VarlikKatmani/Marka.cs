using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class Marka : IModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }


        public List<SqlParameter> GetInsertParameters()
        {
            throw new NotImplementedException();
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            throw new NotImplementedException();
        }

        public void Read(SqlDataReader reader)
        {
            this.Id = Convert.ToInt32(reader["marka_id"]);
            this.Ad = reader["marka_ad"].ToString();
        }
    }
}

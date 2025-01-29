using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public interface IModel
    {
        int Id { get; set; }

        List<SqlParameter> GetInsertParameters();
        List<SqlParameter> GetUpdateParameters();

        void Read(SqlDataReader reader); 
    }
}

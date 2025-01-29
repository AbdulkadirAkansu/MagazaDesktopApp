using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikKatmani;

namespace EntityLayer.Repository
{
    public class SatısToplamRepository : IDisposable, IRepository<ToplamTutar>
    {
        private readonly DBContext context;

        public SatısToplamRepository(DBContext context)
        {
            this.context = context;
        }

        public int Delete(object key)
        {
            using (SqlCommand cmd = context.CreateCommand("spDeleteToplamTutar"))
            {
                cmd.Parameters.AddWithValue("@Id", key);
                return context.ExecuteNonQuery(cmd);
            }
        }

        public void Dispose()
        {
            context?.Dispose();
        }

        public ToplamTutar GetItem(object key)
        {
            using (SqlCommand cmd = context.CreateCommand("spGetToplamTutar"))
            {
                cmd.Parameters.AddWithValue("@Id", key);
                return context.GetItem<ToplamTutar>(cmd);
            }
        }

        public int Insert(ToplamTutar item)
        {
            using (SqlCommand cmd = context.CreateCommand("spInsertToplamTutar", item.GetInsertParameters()))
            {
                return Convert.ToInt32(context.ExecuteScalar(cmd));
            }
        }

        public List<ToplamTutar> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("spGetAllToplamTutar"))
            {
                return context.ListItems<ToplamTutar>(cmd);
            }
        }

        public int Update(ToplamTutar item)
        {

            using (SqlCommand cmd = context.CreateCommand("spUpdateToplamTutar", item.GetUpdateParameters()))
            {
                return context.ExecuteNonQuery(cmd);
            }
        }
    }
}

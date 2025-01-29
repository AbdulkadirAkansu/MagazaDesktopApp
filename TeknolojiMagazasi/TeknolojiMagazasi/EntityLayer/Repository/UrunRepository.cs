using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikKatmani;

namespace EntityLayer.Repository
{
    public class UrunRepository : IDisposable, IRepository<Urun>
    {
        private readonly DBContext context;

        public UrunRepository(DBContext context)
        {
            this.context = context;
        }

        public int Delete(object key)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_urun_sil"))
            {
                cmd.Parameters.AddWithValue("@urun_id", key);
                return context.ExecuteNonQuery(cmd);
            }
        }


        public Urun GetItem(object key)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_urun_get"))
            {
                cmd.Parameters.AddWithValue("@urun_id", key);
                return context.GetItem<Urun>(cmd);
            }
        }

        public Urun GetItemWithBarkod(string barkod)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_urun_get_barkod"))
            {
                cmd.Parameters.AddWithValue("@barkod", barkod);
                return context.GetItem<Urun>(cmd);
            }
        }

        public int Insert(Urun item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_urun_ekle", item.GetInsertParameters()))
            {
                return Convert.ToInt32(context.ExecuteScalar(cmd));
            }
        }

        public List<Urun> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("sp_urun_listele"))
            {
                return context.ListItems<Urun>(cmd);
            }
        }

        public int Update(Urun item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_urun_guncelle", item.GetUpdateParameters()))
            {
                return context.ExecuteNonQuery(cmd);
            }
        }


        public void Dispose()
        {
            context?.Dispose();
        }
    }
}

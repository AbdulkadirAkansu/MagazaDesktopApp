using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikKatmani;

namespace EntityLayer.Repository
{
    public class MusteriRepository : IDisposable, IRepository<Musteri>
    {
        private readonly DBContext context;


        public MusteriRepository(DBContext context) 
        {  
            this.context = context; 
        }

        public int Delete(object key)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_musteri_sil"))
            {
                cmd.Parameters.AddWithValue("@musteri_id", key);
                return context.ExecuteNonQuery(cmd);
            }
        }

        public void Dispose()
        {
            context?.Dispose();
        }

        public Musteri GetItem(object key)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_musteri_get"))
            {
                cmd.Parameters.AddWithValue("@musteri_id", key);
                return context.GetItem<Musteri>(cmd);
            }
        }

        public int Insert(Musteri item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_musteri_ekle", item.GetInsertParameters()))
            {
                return Convert.ToInt32(context.ExecuteScalar(cmd));
            }
        }

        public List<Musteri> ToList()
        {
            using (SqlCommand cmd = context.CreateCommand("sp_musteri_listele"))
            {
                return context.ListItems<Musteri>(cmd);
            }
        }

        public int Update(Musteri item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_musteri_guncelle", item.GetUpdateParameters()))
            {
                return context.ExecuteNonQuery(cmd);
            }
        }
    }
}

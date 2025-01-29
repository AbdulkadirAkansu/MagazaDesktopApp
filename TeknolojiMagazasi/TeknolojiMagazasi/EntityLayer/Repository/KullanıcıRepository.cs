using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikKatmani;

namespace EntityLayer.Repository
{
    public class KullanıcıRepository : IDisposable, IRepository<Kullanıcı>
    {
        private readonly DBContext context;

        public KullanıcıRepository(DBContext context) 
        {
            this.context = context;
        }

        public int Delete(object key)
        {
            throw new NotImplementedException();
        }


        public Kullanıcı GetItem(object key)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_kullanici_get"))
            {
                cmd.Parameters.AddWithValue("@kullaniciadi", key); 
                return context.GetItem<Kullanıcı>(cmd);
            }
        }

        public int Insert(Kullanıcı item)
        {
            throw new NotImplementedException();
        }

        public List<Kullanıcı> ToList()
        {
            throw new NotImplementedException();
        }

        public int Update(Kullanıcı item)
        {
            throw new NotImplementedException();
        }

        public bool Login(Kullanıcı item)
        {
            using (SqlCommand cmd = context.CreateCommand("sp_kullanici_giris"))
            {
                cmd.Parameters.AddWithValue("@kullaniciadi", item.KullanıcıAdı);
                cmd.Parameters.AddWithValue("@parola", item.Parola);
                 
                return Convert.ToBoolean(context.ExecuteScalar(cmd));
            }
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}

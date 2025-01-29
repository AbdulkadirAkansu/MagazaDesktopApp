using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikKatmani
{

    public enum Yetkiler
    {
        Mudur = 1,
        Kasiyer

    }

    public class Kullanıcı : IModel
    {
        public int Id { get; set; }
        public string KullanıcıAdı { get; set; }
        public string Parola { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string AdSoyad { get { return Ad + " " + Soyad; } }
        public Yetkiler Yetki { get; set; }


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
            Id = Convert.ToInt32(reader["kullanici_id"]);
            KullanıcıAdı = reader["kullanici_adi"].ToString();
            Parola = reader["parola"].ToString();
            Yetki = (Yetkiler)Convert.ToInt32(reader["yetki"]);
            Ad = reader["ad"].ToString();
            Soyad = reader["soyad"].ToString();
        }
    }

  
}

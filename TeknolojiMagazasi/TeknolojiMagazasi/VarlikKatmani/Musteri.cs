using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class Musteri : IModel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelNo { get; set; }
        public string Adres { get; set; }

        public List<SqlParameter> GetInsertParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@musteri_ad", this.Ad),
                new SqlParameter("@musteri_soyad", this.Soyad),
                new SqlParameter("@musteri_telno", this.TelNo),
                new SqlParameter("@musteri_adres", this.Adres)
            };
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            var parameters = GetInsertParameters();
            parameters.Add(new SqlParameter("@musteri_id", Id));
            return parameters;
        }

        public void Read(SqlDataReader reader)
        {
            this.Id = Convert.ToInt32(reader["musteri_id"]);
            this.Ad = reader["musteri_ad"].ToString();
            this.Soyad = reader["musteri_soyad"].ToString();
            this.TelNo = reader["musteri_telno"].ToString();
            this.Adres = reader["musteri_adres"].ToString();

        }
    }
}

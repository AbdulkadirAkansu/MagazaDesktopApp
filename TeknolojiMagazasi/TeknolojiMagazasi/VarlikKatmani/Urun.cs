using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class Urun : IModel
    {
        private Marka _marka;

        public int Id { get; set; }
        public string Barkod { get; set; }
        public string Ad { get; set; }
        public int StokAdet { get; set; }
        public decimal Fiyat { get; set; }

        public string MarkaAd { get { return _marka.Ad; } }
        public int MarkaId { get; set; }
        public Marka Marka
        {
            get { return _marka; }
            set { _marka = value; MarkaId = _marka.Id; }
        }


        public List<SqlParameter> GetInsertParameters()
        {
            return new List<SqlParameter>
            {
                new SqlParameter("@barkod", this.Barkod),
                new SqlParameter("@urun_ad", this.Ad),
                new SqlParameter("@marka_id", MarkaId),
                new SqlParameter("@stok_adet", StokAdet),
                new SqlParameter("@fiyat", Fiyat)
            };
        }

        public List<SqlParameter> GetUpdateParameters()
        {
            var parameters = GetInsertParameters();
            parameters.Add(new SqlParameter("@urun_id", Id));
            return parameters;
        }

        public void Read(SqlDataReader reader)
        {
            this.Id = Convert.ToInt32(reader["urun_id"]);
            this.Barkod = reader["barkod"].ToString();
            this.Ad = reader["urun_ad"].ToString();
            this.StokAdet = Convert.ToInt32(reader["stok_adet"]);
            this.Fiyat = Convert.ToDecimal(reader["fiyat"]);
            this.Marka = new Marka
            {
                Id = Convert.ToInt32(reader["marka_id"]),
                Ad = reader["marka_ad"].ToString()
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarlikKatmani
{
    public class SatısDetay : IModel
    {
        private Urun _urun;

        public int Id { get; set; }
        public int SatısId { get; set; }
        public int UrunId { get; set; }
        public Urun Urun
        {
            get { return _urun; }
            set
            {
                _urun = value;
                UrunId = _urun.Id;
            }
        }
        public int Adet { get; set; }
        public decimal Tutar { get; set; }

        public string UrunAd { get { return Urun.Ad; } }
        public string UrunBarkod { get { return Urun.Barkod; } }

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
            throw new NotImplementedException();
        }
    }
}

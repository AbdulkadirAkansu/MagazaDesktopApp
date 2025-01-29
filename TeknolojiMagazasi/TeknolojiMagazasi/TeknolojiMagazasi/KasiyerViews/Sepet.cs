using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VarlikKatmani;

namespace TeknolojiMagazasi.KasiyerViews
{
    public class Sepet
    {
        public List<SatısDetay> Items { get; set; } = new List<SatısDetay>();

        public void Ekle(Urun urun)
        {
            if (Items.FirstOrDefault(x => x.Urun.Barkod == urun.Barkod) != null)
            {
                var item = Items.FirstOrDefault(x => x.Urun.Barkod == urun.Barkod);
                item.Adet++;
                item.Tutar = item.Adet * urun.Fiyat;
            }
            else
            {
                Items.Add(new SatısDetay
                {
                    Id = 0,
                    SatısId = 0,
                    Adet = 1,
                    Urun = urun,
                    Tutar = urun.Fiyat
                });
            }
        }
    }
}

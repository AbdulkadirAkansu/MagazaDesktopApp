using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeknolojiMagazasi.AdminViews;
using TeknolojiMagazasi.KasiyerViews;
using VarlikKatmani;

namespace TeknolojiMagazasi
{
    static class Program
    {
       public static Kullanıcı GirisKullanıcı { get; set; }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmLogin loginFrm = new FrmLogin();
            if (loginFrm.ShowDialog() == DialogResult.OK)
            {
                if (GirisKullanıcı.Yetki == Yetkiler.Mudur)
                    Application.Run(new FrmUrunList());
                else if (GirisKullanıcı.Yetki == Yetkiler.Kasiyer)
                    Application.Run(new FrmSatis());

            }
        }
    }
}

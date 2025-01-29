using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VarlikKatmani;

namespace TeknolojiMagazasi.KasiyerViews
{
    public partial class FrmGuncelle : Form
    {

        public Musteri Musteri { get; set; }

        public FrmGuncelle(): this(new Musteri()) { }


        public FrmGuncelle(Musteri musteri)
        {
            InitializeComponent();
            this.Musteri = musteri;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmGuncelle_Load(object sender, EventArgs e)
        {
            txtAd.Text = Musteri.Ad;
            txtSoyad.Text = Musteri.Soyad;
            txtTelNo.Text = Musteri.TelNo;
            txtAdres.Text = Musteri.Adres;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Musteri.Ad = txtAd.Text;
            Musteri.Soyad = txtSoyad.Text;
            Musteri.TelNo = txtTelNo.Text;
            Musteri.Adres = txtAdres.Text;

            DialogResult = DialogResult.OK;
        }
    }
}

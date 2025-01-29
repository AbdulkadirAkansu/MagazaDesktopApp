using EntityLayer;
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

namespace TeknolojiMagazasi.AdminViews
{
    public partial class FrmUrunGuncelle : Form
    {
        public Urun Urun { get; set; }

        public FrmUrunGuncelle() : this(new Urun()) { }
        public FrmUrunGuncelle(Urun urun)
        {
            InitializeComponent();
            this.Urun = urun;
        }

        private void FrmUrunGuncelle_Load(object sender, EventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                cbxMarka.DataSource = uow.MarkaRepo.ToList();
                cbxMarka.DisplayMember = "Ad";
                cbxMarka.ValueMember = "Id";

                txtBarkod.Text = Urun.Barkod;
                txtAd.Text = Urun.Ad;
                txtFiyat.Text = Urun.Fiyat.ToString();
                txtStokAdet.Text = Urun.StokAdet.ToString();
                cbxMarka.SelectedValue = Urun.MarkaId;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Urun.Barkod = txtBarkod.Text;
            Urun.Ad = txtAd.Text;
            Urun.Fiyat = Convert.ToDecimal(txtFiyat.Text);
            Urun.StokAdet = Convert.ToInt32(txtStokAdet.Text);
            Urun.Marka = cbxMarka.SelectedItem as Marka;

            DialogResult = DialogResult.OK;
        }
    }
}

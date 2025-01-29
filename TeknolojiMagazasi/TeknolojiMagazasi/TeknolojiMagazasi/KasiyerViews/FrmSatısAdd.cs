using EntityLayer;
using EntityLayer.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeknolojiMagazasi.AdminViews;
using VarlikKatmani;

namespace TeknolojiMagazasi.KasiyerViews
{
    public partial class FrmSatısAdd : Form
    {
        Sepet sepet = new Sepet();
        BindingSource source = new BindingSource();

        public FrmSatısAdd()
        {
            InitializeComponent();

            lblToplam.Text = String.Format("{0:C2}", 0);

            source.DataSource = sepet.Items;

            lstAd.DataSource = source;
            lstBarkod.DataSource = source;
            lstAdet.DataSource = source;
            lstFiyat.DataSource = source;

            lstAd.DisplayMember = "UrunAd";
            lstBarkod.DisplayMember = "UrunBarkod";
            lstFiyat.DisplayMember = "Tutar";
            lstAdet.DisplayMember = "Adet";

            source.ResetBindings(false);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Urun urun = uow.UrunRepo.GetItemWithBarkod(txtBarkod.Text.Trim());
                if (urun == null)
                    MessageBox.Show("Bu barkoda sahip ürün yok...");
                else
                {
                    sepet.Ekle(urun);
                    lblToplam.Text = sepet.Items.Sum(x => x.Tutar).ToString("C2");
                    source.ResetBindings(false);
                }
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (lstAd.SelectedIndex != -1 &&
             DialogResult.Yes == MessageBox.Show("Seçili ürünü silmek istiyor musunuz?", "Ürün sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                int selectedIndex = lstAd.SelectedIndex;
                sepet.Items.RemoveAt(selectedIndex);
                lblToplam.Text = sepet.Items.Sum(x => x.Tutar).ToString("C2");
                source.ResetBindings(false);
            }
        }

        private void FrmSatısAdd_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (sepet.Items.Count > 0)
            {
                DialogResult result = MessageBox.Show("Siparişi onaylamak istiyor musunuz?", "Sipariş Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    decimal toplamFiyat = sepet.Items.Sum(x => x.Tutar);

                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        SatısToplamRepository satısToplamRepo = uow.SatısRepo;
                        ToplamTutar toplamTutar = new ToplamTutar { ToplamFiyat = toplamFiyat };
                        satısToplamRepo.Insert(toplamTutar);
                    }

                    sepet.Items.Clear();
                    lblToplam.Text = String.Format("{0:C2}", 0);
                    source.ResetBindings(false);
                }
            }
            else
            {
                MessageBox.Show("Sepetiniz boş. Lütfen önce ürün ekleyin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          
        }
     
    }
}




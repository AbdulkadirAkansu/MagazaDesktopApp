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
using VarlikKatmani;

namespace TeknolojiMagazasi.AdminViews
{
    public partial class FrmToplam : Form
    {
        BindingSource source = new BindingSource();
        private readonly UnitOfWork uow;

        public FrmToplam()
        {
            InitializeComponent();

            uow = new UnitOfWork();
            List<ToplamTutar> toplamTutarlar = uow.SatısRepo.ToList();
            source.DataSource = toplamTutarlar;

            lstFiyat.DataSource = source;
            lstFiyat.DisplayMember = "ToplamFiyat";

        }

        private void lstFiyat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void UpdateLabel()
        {
            decimal toplamFiyatlarToplam = source.List.Cast<ToplamTutar>().Sum(x => x.ToplamFiyat);
            label1.Text = toplamFiyatlarToplam.ToString("C2");
        }

        private void FrmToplam_Load(object sender, EventArgs e)
        {
            UpdateLabel();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (source.Current != null &&
                DialogResult.Yes == MessageBox.Show("Seçili ürünü silmek istiyor musunuz?", "Ürün sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                ToplamTutar toplamt = source.Current as ToplamTutar;
                using (UnitOfWork uow = new UnitOfWork())
                {
                    uow.SatısRepo.Delete(toplamt.Id);
                    source.Remove(toplamt);
                    source.ResetBindings(false);

                    UpdateLabel();
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (source.Current != null)
            {
                ToplamTutar toplamt = source.Current as ToplamTutar;
                FrmToplamGuncelle Toplamguncelle = new FrmToplamGuncelle(toplamt);
                if (Toplamguncelle.ShowDialog() == DialogResult.OK)
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        uow.SatısRepo.Update(Toplamguncelle.ToplamTutar);
                        source.ResetBindings(false);

                        UpdateLabel();

                    }
                }
            }
        }
    }
}

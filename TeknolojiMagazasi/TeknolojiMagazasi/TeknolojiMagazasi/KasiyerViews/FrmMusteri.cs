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
using TeknolojiMagazasi.AdminViews;
using VarlikKatmani;

namespace TeknolojiMagazasi.KasiyerViews
{
    public partial class FrmMusteri : Form
    {
        BindingSource source = new BindingSource();
        private readonly UnitOfWork uow;


        public FrmMusteri()
        {
            InitializeComponent();

            uow = new UnitOfWork();
            List<Musteri> musteriler = uow.MusteriRepo.ToList();
            source.DataSource = musteriler;

            lstAd.DataSource = source;
            lstSoyad.DataSource = source;
            lstTelNo.DataSource = source;
            lstAdres.DataSource = source;

            lstAd.DisplayMember = "Ad";
            lstSoyad.DisplayMember = "Soyad";
            lstTelNo.DisplayMember = "TelNo";
            lstAdres.DisplayMember = "Adres";

            source.ResetBindings(false);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMusteri_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmMusteriEkle musteriFrm = new FrmMusteriEkle();
            if (musteriFrm.ShowDialog() == DialogResult.OK)
            {
                uow.MusteriRepo.Insert(musteriFrm.Musteri);
                source.Add(musteriFrm.Musteri);
                source.ResetBindings(false);
            }
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {


            if (source.Current != null)
            {
                Musteri musteri = source.Current as Musteri;
                FrmGuncelle frmguncelle = new FrmGuncelle(musteri);
                if (frmguncelle.ShowDialog() == DialogResult.OK)
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        uow.MusteriRepo.Update(frmguncelle.Musteri);
                        source.ResetBindings(false);

                    }
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FrmMusteriSil frmsil = new FrmMusteriSil();

            if (frmsil.ShowDialog() == DialogResult.OK)
            {
                if (frmsil.IsConfirmed && source.Current != null)
                {

                    Musteri musteri = source.Current as Musteri;
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        uow.MusteriRepo.Delete(musteri.Id);
                        source.Remove(musteri);
                        source.ResetBindings(false);
                    }
                }
            }
        }
    }
}

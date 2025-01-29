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
    public partial class FrmUrunList : Form
    {

        BindingSource source;

        public FrmUrunList()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmUrun urunFrm = new FrmUrun();
            if (urunFrm.ShowDialog() == DialogResult.OK)
            {
                using (UnitOfWork uow = new UnitOfWork())
                {
                    urunFrm.Urun.Id = uow.UrunRepo.Insert(urunFrm.Urun);
                    source.Add(urunFrm.Urun);
                }
            }
        }

        private void FrmUrunList_Load(object sender, EventArgs e)
        {
            source = new BindingSource();
            using (UnitOfWork uow = new UnitOfWork())
                source.DataSource = uow.UrunRepo.ToList(); 

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnCount = 6;
            dataGridView1.Columns[0].HeaderText = "Id";
            dataGridView1.Columns[0].DataPropertyName = "Id";
            dataGridView1.Columns[1].HeaderText = "Barkod";
            dataGridView1.Columns[1].DataPropertyName = "Barkod";
            dataGridView1.Columns[2].HeaderText = "Ad";
            dataGridView1.Columns[2].DataPropertyName = "Ad";
            dataGridView1.Columns[3].HeaderText = "Stok Adet";
            dataGridView1.Columns[3].DataPropertyName = "StokAdet";
            dataGridView1.Columns[4].HeaderText = "MarkaAd";
            dataGridView1.Columns[4].DataPropertyName = "MarkaAd";
            dataGridView1.Columns[5].HeaderText = "Fiyat";
            dataGridView1.Columns[5].DataPropertyName = "Fiyat";

            dataGridView1.DataSource = source;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (source.Current != null)
            {
                Urun urun = source.Current as Urun;
                FrmUrunGuncelle urunGuncelleFrm = new FrmUrunGuncelle(urun);
                if (urunGuncelleFrm.ShowDialog() == DialogResult.OK)
                {
                    using (UnitOfWork uow = new UnitOfWork())
                    {
                        uow.UrunRepo.Update(urunGuncelleFrm.Urun);
                        source.ResetCurrentItem();

                    }
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            FrmSil frmsil = new FrmSil();

            if (frmsil.ShowDialog() == DialogResult.OK)
            {
                if (frmsil.IsConfirmed && source.Current != null)
                {
                   
                        Urun urun = source.Current as Urun;
                        using (UnitOfWork uow = new UnitOfWork())
                        {
                            uow.UrunRepo.Delete(urun.Id);
                            source.Remove(urun);
                            source.ResetBindings(false);
                        }
                    }
                }        
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FrmToplam frmToplam = new FrmToplam();
            frmToplam.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
            System.Diagnostics.Process.Start(Application.ExecutablePath);
        }
    }
}

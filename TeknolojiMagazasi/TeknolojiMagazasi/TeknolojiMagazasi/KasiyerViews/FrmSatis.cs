using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknolojiMagazasi.KasiyerViews
{
    public partial class FrmSatis : Form
    {

        public void UpdateTotalAmount(string totalAmount)
        {
            label11.Text = totalAmount;
        }

        private void AyarlarıUygula()
        {
            this.BackColor = TeknolojiMagazasi.Properties.Settings.Default.Color;
            this.Font = TeknolojiMagazasi.Properties.Settings.Default.Font;
        }

        public FrmSatis()
        {
            InitializeComponent();
            AyarlarıUygula();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            FrmSatısAdd frmsatisekle = new FrmSatısAdd();
            frmsatisekle.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            FrmMusteri frmmusteri = new FrmMusteri();
            frmmusteri.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
            System.Diagnostics.Process.Start(Application.ExecutablePath);
        }

        private void button17_Click_1(object sender, EventArgs e)
        {
            FrmAyarlar ayarlarFrm = new FrmAyarlar();
            if (ayarlarFrm.ShowDialog() == DialogResult.OK)
            {
                AyarlarıUygula();
            }
        }

        private void FrmSatis_Load(object sender, EventArgs e)
        {
            
        }

        private void panel_header_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

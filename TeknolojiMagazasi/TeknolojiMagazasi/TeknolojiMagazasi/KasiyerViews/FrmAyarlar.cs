using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknolojiMagazasi.KasiyerViews
{
    public partial class FrmAyarlar : Form
    {

        private Color varsayilanRenk = Color.FromArgb(18, 18, 32);

        public FrmAyarlar()
        {
            InitializeComponent();
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            txtFont.Text = TeknolojiMagazasi.Properties.Settings.Default.Font.ToString();
            txtColor.Text = TeknolojiMagazasi.Properties.Settings.Default.Color.ToString();

            varsayilanRenk = Color.FromArgb(18, 18, 32);
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            TeknolojiMagazasi.Properties.Settings.Default.Save();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            TeknolojiMagazasi.Properties.Settings.Default.Reload();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FontDialog dialog = new FontDialog();
            dialog.Font = TeknolojiMagazasi.Properties.Settings.Default.Font;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TeknolojiMagazasi.Properties.Settings.Default.Font = dialog.Font;
                txtFont.Text = dialog.Font.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            dialog.Color = TeknolojiMagazasi.Properties.Settings.Default.Color;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                TeknolojiMagazasi.Properties.Settings.Default.Color = dialog.Color;
                txtColor.Text = dialog.Color.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            TeknolojiMagazasi.Properties.Settings.Default.Color = varsayilanRenk;
            txtColor.Text = varsayilanRenk.ToString();
        }
    }
}


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
    public partial class FrmToplamGuncelle : Form
    {
        public ToplamTutar ToplamTutar {  get; set; }

        public FrmToplamGuncelle(): this(new ToplamTutar()) { }
        public FrmToplamGuncelle(ToplamTutar toplamtutar)
        {
            InitializeComponent();
            this.ToplamTutar = toplamtutar;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            ToplamTutar.ToplamFiyat = Convert.ToDecimal(txtfiyat.Text);
            DialogResult = DialogResult.OK;
        }

        private void FrmToplamGuncelle_Load(object sender, EventArgs e)
        {
            using(UnitOfWork uow = new UnitOfWork())
            {
                txtfiyat.Text = ToplamTutar.ToplamFiyat.ToString();
            }
        }
    }
}

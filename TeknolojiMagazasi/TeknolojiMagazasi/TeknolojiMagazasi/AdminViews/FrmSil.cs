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
    public partial class FrmSil : Form
    {

        public bool IsConfirmed { get; private set; }

        public FrmSil()
        {
            InitializeComponent();
        }

        private void FrmSil_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            IsConfirmed = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            IsConfirmed = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

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

namespace TeknolojiMagazasi
{
    public partial class FrmLogin : Form
    {
        private string defaultText = "Username";
        private string defaultPassword = "Password";

        public FrmLogin()
        {
            InitializeComponent();
            textBox1.Text = defaultText;
            textBox2.Text = defaultPassword;

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == defaultText)
            {
                textBox1.Text = string.Empty;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == defaultPassword)
            {
                textBox2.Text = string.Empty;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                Kullanıcı item = new Kullanıcı
                {
                    KullanıcıAdı = textBox1.Text,
                    Parola = textBox2.Text
                };

                if (uow.KullanıcıRepo.Login(item))
                {
                    Program.GirisKullanıcı = uow.KullanıcıRepo.GetItem(item.KullanıcıAdı);
                    lblMesaj.Visible = false;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    lblMesaj.Visible = true;
                }
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
            if (textBox2.PasswordChar == '\0')
            {
                textBox2.PasswordChar = '•';
            }
            else
            {            
                textBox2.PasswordChar = '\0';
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

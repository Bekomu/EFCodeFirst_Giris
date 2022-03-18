using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFCodeFirst_Giris
{
    public partial class DuzenleForm : Form
    {
        private readonly UygulamaDbContext _db;
        private readonly Kisi _kisi;

        public DuzenleForm(UygulamaDbContext db, Kisi kisi)
        {
            _db = db;
            _kisi = kisi;
            InitializeComponent();

            txtTamAd.Text = _kisi.Ad;
            chkEvliMi.Checked = _kisi.EvliMi;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTamAd.Text))
            {
                _kisi.Ad = txtTamAd.Text;
                _kisi.EvliMi = chkEvliMi.Checked;
                _db.SaveChanges();
                this.DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Tam Ad boş olamaz...");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

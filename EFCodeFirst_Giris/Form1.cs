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
    public partial class Form1 : Form
    {
        UygulamaDbContext db = new UygulamaDbContext();
        public Form1()
        {
            OrnekVerileriYukle();
            InitializeComponent();
            Listele();
            lblArama.Hide();
        }

        private void Listele()
        {
            dgvKisiler.DataSource = null;
            dgvKisiler.DataSource = db.Kisiler.ToList();
        }

        private void OrnekVerileriYukle()
        {
            if (!db.Kisiler.Any())
            {
                db.Kisiler.Add(new Kisi() { Ad = "Ali", EvliMi = false });
                db.Kisiler.Add(new Kisi() { Ad = "Ece", EvliMi = true });
                db.Kisiler.Add(new Kisi() { Ad = "Ege", EvliMi = true });
                db.Kisiler.Add(new Kisi() { Ad = "Gül", EvliMi = false });
                db.SaveChanges();
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTamAd.Text))
            {
                Kisi yeniKisi = new Kisi() { Ad = txtTamAd.Text, EvliMi = checkBox1.Checked ? true : false };
                db.Kisiler.Add(yeniKisi);
                db.SaveChanges();
            }
            Listele();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            db.SaveChanges();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Seçili kişiyi silmek istediğinize emin misiniz ? ",
                "Silme Onayı",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (dr == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(dgvKisiler.SelectedRows[0].Cells[0].Value.ToString()))
                {
                    int seciliId = (int)dgvKisiler.SelectedRows[0].Cells[0].Value;
                    Kisi silinenKisi = db.Kisiler.First(x => x.Id == seciliId);
                    db.Kisiler.Remove(silinenKisi);
                    db.SaveChanges();
                }
                Listele();
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dgvKisiler.SelectedRows[0].Cells[0].Value.ToString()))
            {
                int seciliId = (int)dgvKisiler.SelectedRows[0].Cells[0].Value;
                Kisi duzenlenenKisi = db.Kisiler.First(x => x.Id == seciliId);
                DuzenleForm form = new DuzenleForm(db, duzenlenenKisi);

                if (form.ShowDialog() == DialogResult.OK)
                {
                    Listele();
                }
            }
        }

        private void dgvKisiler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvKisiler.SelectedRows.Count == 0)
            {
                btnDuzenle.Enabled = false;
                btnSil.Enabled = false;
            }
            else
            {
                btnDuzenle.Enabled = true;
                btnSil.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            if(!string.IsNullOrEmpty(txtArama.Text))
            {
                lblArama.Show();
                dgvKisiler.DataSource = db.Kisiler.Where(x => x.Ad.Contains(txtArama.Text)).ToList();
            }
            else
            {
                lblArama.Hide();
                Listele();
            }
        }
    }
}

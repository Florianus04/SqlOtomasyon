using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EmlakKayitOtomasyonu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-K6R87ON; Initial Catalog=EmlakKayit; Integrated Security=True");

        void VeriGoster()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *From sitebilgi",baglan);
            SqlDataReader oku = komut.ExecuteReader();
            Siteler();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["site"].ToString());
                ekle.SubItems.Add(oku["oda"].ToString());
                ekle.SubItems.Add(oku["metre"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["blok"].ToString());
                ekle.SubItems.Add(oku["no"].ToString());
                ekle.SubItems.Add(oku["adsoyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["notlar"].ToString());
                ekle.SubItems.Add(oku["satkira"].ToString());

                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        void Siteler()
        {
            if (comboBox1.Text == "Zambak Sitesi")
            {
                btnZambak.BackColor = Color.Yellow;
                btnGul.BackColor = Color.DarkOliveGreen;
                btnMenekse.BackColor = Color.DarkOliveGreen;
                btnPapatya.BackColor = Color.DarkOliveGreen;
            }
            if (comboBox1.Text == "Gül Sitesi")
            {
                btnZambak.BackColor = Color.DarkOliveGreen;
                btnGul.BackColor = Color.Yellow;
                btnMenekse.BackColor = Color.DarkOliveGreen;
                btnPapatya.BackColor = Color.DarkOliveGreen;
            }
            if (comboBox1.Text == "Menekşe Sitesi")
            {
                btnZambak.BackColor = Color.DarkOliveGreen;
                btnGul.BackColor = Color.DarkOliveGreen;
                btnMenekse.BackColor = Color.Yellow;
                btnPapatya.BackColor = Color.DarkOliveGreen;
            }
            if (comboBox1.Text == "Papatya Sitesi")
            {
                btnZambak.BackColor = Color.DarkOliveGreen;
                btnGul.BackColor = Color.DarkOliveGreen;
                btnMenekse.BackColor = Color.DarkOliveGreen;
                btnPapatya.BackColor = Color.Yellow;
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Siteler();   
        }

        private void btnGoruntule_Click(object sender, EventArgs e)
        {
            VeriGoster();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kaydet();
        }
        void Kaydet()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("insert into sitebilgi (id,site,oda,metre,fiyat,blok,no,adsoyad,telefon,notlar,satkira) values ('" + textBox5.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + textBox1.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + comboBox2.Text.ToString() + "')", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            VeriGoster();
        }
        int id = 0;
        void Sil()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from sitebilgi where id =(" + id + ")", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            VeriGoster();
        }
        private void btnSil_Click(object sender, EventArgs e)
        {
            Sil();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            textBox5.Text = listView1.SelectedItems[0].SubItems[0].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            comboBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox4.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[9].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[10].Text;
        }

        private void btnDuzelt_Click(object sender, EventArgs e)
        {
            Duzelt();
        }
        void Duzelt()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("update sitebilgi set id='" + textBox5.Text.ToString() + "',site='" + comboBox1.Text.ToString() + "',oda='" + comboBox3.Text.ToString() + "',metre='" + textBox1.Text.ToString() + "',fiyat='" + textBox3.Text.ToString() + "',blok='" + comboBox4.Text.ToString() + "',no='" + textBox7.Text.ToString() + "',adsoyad='" + textBox6.Text.ToString() + "',telefon='" + textBox4.Text.ToString() + "',notlar='" + textBox2.Text.ToString() + "',satkira='" + comboBox2.Text.ToString() + "'where id=" + id + "", baglan);
            komut.ExecuteNonQuery();
            baglan.Close();
            VeriGoster();
        }
    }
}

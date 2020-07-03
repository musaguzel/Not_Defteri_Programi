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

namespace Not_Defteri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLNOTLAR", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void BtnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBLNOTLAR (NOTBASLIGI,NOTLAR) VALUES (@P1,@P2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtNotBaslıgı.Text);
            komut.Parameters.AddWithValue("@P2", RchNot.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut1 = new SqlCommand("Delete from TBLNOTLAR WHERE NOTID=@P1", bgl.baglanti());
            komut1.Parameters.AddWithValue("@P1", TxtNotID.Text);
            komut1.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update TBLNOTLAR set NOTBASLIGI=@P1,NOTLAR=@P2 WHERE NOTID=@P3", bgl.baglanti());
            komut2.Parameters.AddWithValue("@P1", TxtNotBaslıgı.Text);
            komut2.Parameters.AddWithValue("@P2", RchNot.Text);
            komut2.Parameters.AddWithValue("@P3", TxtNotID.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtNotID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtNotBaslıgı.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            RchNot.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            TxtNotID.Text = "";
            TxtNotBaslıgı.Text = "";
            RchNot.Text = "";
            TxtNotBaslıgı.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(RchNot.Text);
        }

    }
}

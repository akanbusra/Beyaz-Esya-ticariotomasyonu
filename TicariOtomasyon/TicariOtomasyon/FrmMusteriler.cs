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

namespace TicariOtomasyon
{
    public partial class FrmMusteriler : Form
    {
        public FrmMusteriler()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_MUSTERILER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            Txtad.Text = " ";
            TxtSoyad.Text = " ";
            txtvergi.Text = " ";
            Txtid.Text = " ";
            txtmail.Text = " ";
            txtvergi.Text = " ";
            tel1msk.Text = " ";
            tel2msk.Text = " ";
            tcmsk.Text = " ";
            ilcmb.Text = " ";
            ilçecmb.Text = " ";
            adresrich.Text = " ";
        }

        void sehirListesi()
        {
            SqlCommand komut = new SqlCommand("select * from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ilcmb.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();

        }
        private void FrmMusteriler_Load(object sender, EventArgs e)
        {
            listele();
            sehirListesi();
            temizle();
        }
        private void btnkaydet_Click(object sender, EventArgs e)
        {
            //VERİLERİ KAYDETME

            SqlCommand komut = new SqlCommand("insert into TBL_MUSTERILER (AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)",
                bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtad.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", tel1msk.Text);
            komut.Parameters.AddWithValue("@p4", tel2msk.Text);
            komut.Parameters.AddWithValue("@p5", tcmsk.Text);
            komut.Parameters.AddWithValue("@p6", txtmail.Text);
            komut.Parameters.AddWithValue("@p7", ilcmb.Text);
            komut.Parameters.AddWithValue("@p8", ilçecmb.Text);
            komut.Parameters.AddWithValue("@p9", adresrich.Text);
            komut.Parameters.AddWithValue("@p10",txtvergi.Text );

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri KAYDEDİLDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            //VERİLERİ TEMİZLEME
            temizle();
        }

        //seçilen ile göre o ilin  ilçelerinin gelmesi
        private void ilcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilçecmb.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("select ILCE from TBL_ILCELER where SEHIR=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", ilcmb.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ilçecmb.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                Txtad.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                tel1msk.Text = dr["TELEFON"].ToString();
                tel2msk.Text = dr["TELEFON2"].ToString();
                tcmsk.Text = dr["TC"].ToString();
                txtmail.Text = dr["MAIL"].ToString();
                ilcmb.Text = dr["IL"].ToString();
                ilçecmb.Text = dr["ILCE"].ToString();
                adresrich.Text = dr["ADRES"].ToString();
                txtvergi.Text = dr["VERGIDAIRE"].ToString();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //Verileri Silme
            SqlCommand komut = new SqlCommand("DELETE from TBL_MUSTERILER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_MUSTERILER set AD=@P1,SOYAD=@P2,TELEFON=@P3,TELEFON2=@P4,TC=@P5,MAIL=@P6,IL=@P7,ILCE=@P8,ADRES=@P9,VERGIDAIRE=@P10 where ID=@P11", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtad.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", tel1msk.Text);
            komut.Parameters.AddWithValue("@p4", tel2msk.Text);
            komut.Parameters.AddWithValue("@p5", tcmsk.Text);
            komut.Parameters.AddWithValue("@p6", txtmail.Text);
            komut.Parameters.AddWithValue("@p7", ilcmb.Text);
            komut.Parameters.AddWithValue("@p8", ilçecmb.Text);
            komut.Parameters.AddWithValue("@p10", txtvergi.Text);
            komut.Parameters.AddWithValue("@p9", adresrich.Text);
            komut.Parameters.AddWithValue("@p11",Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Müşteri bilgileri GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}

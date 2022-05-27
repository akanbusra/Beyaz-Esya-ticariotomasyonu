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
    public partial class FrmPersoneller : Form
    {
        public FrmPersoneller()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_PERSONELLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
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

        void temizle()
        {
            Txtad.Text="";
            TxtSoyad.Text="";
            Txtid.Text="";
            txtmail.Text ="";
            txtgörev.Text="";
            telmsk.Text ="";
            tcmsk.Text ="";
            ilcmb.Text ="";
            ilçecmb.Text ="";
            adresrich.Text="";
        }

        private void FrmPersoneller_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
            sehirListesi();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            //VERİLERİ KAYDETME

            SqlCommand komut = new SqlCommand("insert into TBL_PERSONELLER (AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)",
                bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtad.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", telmsk.Text);
            komut.Parameters.AddWithValue("@p4", tcmsk.Text);
            komut.Parameters.AddWithValue("@p5", txtmail.Text);
            komut.Parameters.AddWithValue("@p6", ilcmb.Text);
            komut.Parameters.AddWithValue("@p7", ilçecmb.Text);
            komut.Parameters.AddWithValue("@p8", adresrich.Text);
            komut.Parameters.AddWithValue("@p9", txtgörev.Text);
            
          
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel KAYDEDİLDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void ilcmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilçecmb.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("select ILCE from TBL_ILCELER where SEHIR=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", ilcmb.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ilçecmb.Properties.Items.Add(dr[0]);
            }
            //bgl.baglanti().Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                Txtad.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                telmsk.Text = dr["TELEFON"].ToString();
                tcmsk.Text = dr["TC"].ToString();
                txtmail.Text = dr["MAIL"].ToString();
                ilcmb.Text = dr["IL"].ToString();
                ilçecmb.Text = dr["ILCE"].ToString();
                adresrich.Text = dr["ADRES"].ToString();
                txtgörev.Text = dr["GOREV"].ToString();
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //Verileri Silme
            SqlCommand komut = new SqlCommand("DELETE from TBL_PERSONELLER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel  SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_PERSONELLER set AD=@P1,SOYAD=@P2,TELEFON=@P3,TC=@P4,MAIL=@P5,IL=@P6,ILCE=@P7,ADRES=@P8,GOREV=@P9 where ID=@P10", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtad.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", telmsk.Text);
            komut.Parameters.AddWithValue("@p4", tcmsk.Text);
            komut.Parameters.AddWithValue("@p5", txtmail.Text);
            komut.Parameters.AddWithValue("@p6", ilcmb.Text);
            komut.Parameters.AddWithValue("@p7", ilçecmb.Text);
            komut.Parameters.AddWithValue("@p8", adresrich.Text);
            komut.Parameters.AddWithValue("@p9", txtgörev.Text);
           komut.Parameters.AddWithValue("@p10", Txtid.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personl bilgileri GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}

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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
          Txtid.Text = "";
          aycmb.Text = "";
          yılcmb.Text = "";
          Txtelektrik.Text = "";
          txtsu.Text = "";
          txtdoğalgaz.Text = "";
          Txtinternet .Text = "";
          txtmaaşlar.Text = "";
          txtekstra.Text = "";
          notrich.Text = "";
        }
        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            listele();
            temizle();

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            //Kaydetme

            SqlCommand komut = new SqlCommand("insert into TBL_GIDERLER (AY,YIL,ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)",
                bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", aycmb.Text);
            komut.Parameters.AddWithValue("@p2", yılcmb.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(Txtelektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtsu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtdoğalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(Txtinternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtmaaşlar.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(txtekstra.Text));
            komut.Parameters.AddWithValue("@p9", notrich.Text);


            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider KAYDEDİLDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //Verileri Silme
            SqlCommand komut = new SqlCommand("DELETE from TBL_GIDERLER where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider  SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                aycmb.Text = dr["AY"].ToString();
                yılcmb.Text = dr["YIL"].ToString();
                Txtelektrik.Text = dr["ELEKTRIK"].ToString();
                txtsu.Text = dr["SU"].ToString();
                txtdoğalgaz.Text = dr["DOGALGAZ"].ToString();
                Txtinternet.Text = dr["INTERNET"].ToString();
                txtmaaşlar.Text = dr["MAASLAR"].ToString();
                txtekstra.Text = dr["EKSTRA"].ToString();
                notrich.Text = dr["NOTLAR"].ToString();
            }
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_GIDERLER set AY=@P1,YIL=@P2,ELEKTRIK=@P3,SU=@P4,DOGALGAZ=@P5,INTERNET=@P6,MAASLAR=@P7,EKSTRA=@P8,NOTLAR=@P9 where ID=@P10",
                bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", aycmb.Text);
            komut.Parameters.AddWithValue("@p2", yılcmb.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(Txtelektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtsu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtdoğalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(Txtinternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(txtmaaşlar.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(txtekstra.Text));
            komut.Parameters.AddWithValue("@p9", notrich.Text);
            komut.Parameters.AddWithValue("@p10", Txtid.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider bilgileri GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}

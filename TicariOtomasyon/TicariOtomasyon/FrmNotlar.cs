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
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void temizle()
        {
            Txtid.Text = " ";
            tarihmsk.Text = " ";
            saatmsk.Text = " ";
            başlıktxt.Text = " ";
            detayrch.Text = " ";
            olusturantxt.Text = " ";
            hitaptxt.Text = " ";
        }
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_NOTLAR", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
      

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

       

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_NOTLAR (TARIH,SAAT,BASLIK,DETAY,OLUSTURAN,HITAP) values (@p1,@p2,@p3,@p4,@p5,@p6)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", tarihmsk.Text);
            komut.Parameters.AddWithValue("@p2", saatmsk.Text);
            komut.Parameters.AddWithValue("@p3", başlıktxt.Text);
            komut.Parameters.AddWithValue("@p4", detayrch.Text);
            komut.Parameters.AddWithValue("@p5", olusturantxt.Text);
            komut.Parameters.AddWithValue("@p6", hitaptxt.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("YENİ NOT KAYDEDİLDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                tarihmsk.Text = dr["TARIH"].ToString();
                saatmsk.Text = dr["SAAT"].ToString();
                başlıktxt.Text = dr["BASLIK"].ToString();
                detayrch.Text = dr["DETAY"].ToString();
                olusturantxt.Text = dr["OLUSTURAN"].ToString();
                hitaptxt.Text = dr["HITAP"].ToString();
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //Verileri Silme
            SqlCommand komut = new SqlCommand("DELETE from TBL_NOTLAR where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("NOT SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_NOTLAR set TARIH=@P1,SAAT=@P2,BASLIK=@P3,DETAY=@P4,OLUSTURAN=@P5,HITAP=@P6 where ID=@P7", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", tarihmsk.Text);
            komut.Parameters.AddWithValue("@p2", saatmsk.Text);
            komut.Parameters.AddWithValue("@p3", başlıktxt.Text);
            komut.Parameters.AddWithValue("@p4", detayrch.Text);
            komut.Parameters.AddWithValue("@p5", olusturantxt.Text);
            komut.Parameters.AddWithValue("@p6", hitaptxt.Text);
            komut.Parameters.AddWithValue("@p7", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not  bilgileri GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            FrmNotDetay2 fr = new FrmNotDetay2();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr!=null)
            {
                fr.metin = dr[4].ToString();
            }
            fr.Show();
        }
    }
}

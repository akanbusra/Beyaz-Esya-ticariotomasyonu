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
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        //fatura bilgisi listeleme
         void faturabilgilistele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_FATURABILGI", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        //fatura detay listeleme
        void faturadetaylistele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_FATURADETAY", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        //fatura bilgisi temizleme
        void faturabilgitemizle()
        {
            Txtid.Text ="";
            seriTxt.Text ="";
            sıranotxt.Text ="";
            tarihmsk.Text ="";
            saatmsk.Text ="";
            vergidairetxt.Text ="";
            tedentxt.Text ="";
            talantxt.Text ="";
            alıcıtxt.Text ="";

        }
        //fatura detayı temizleme
        void faturadetaytemzile()
        {
            urunıdtxt.Text = "";
            urunadtxt.Text = "";
            adettxt.Text = "";
            fiyattxt.Text = "";
            tutartxt.Text = "";
            faturaidtxt.Text = "";
        }
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
           
            faturabilgilistele();
            faturadetaylistele();

            faturabilgitemizle();
            faturadetaytemzile();
        }

        //fatura detay üzerine çift tıklandığnda yerlerin dolması
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["FATURABILGID"].ToString();
                seriTxt.Text = dr["SERI"].ToString();
                sıranotxt.Text = dr["SIRANO"].ToString();
                tarihmsk.Text = dr["TARIH"].ToString();
                saatmsk.Text = dr["SAAT"].ToString();
                vergidairetxt.Text = dr["VERGIDAIRE"].ToString();
                alıcıtxt.Text = dr["ALICI"].ToString();
                tedentxt.Text = dr["TESLIMEDEN"].ToString();
                talantxt.Text = dr["TESLIMALAN"].ToString();
            }
        }

        //faatura bilgi üstüne ift tıklandığında yerlerin dolması
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                urunıdtxt.Text = dr["FATURAURUNID"].ToString();
                urunadtxt.Text = dr["URUNAD"].ToString();
                adettxt.Text = dr["ADET"].ToString();
                fiyattxt.Text = dr["FIYAT"].ToString();
                tutartxt.Text = dr["TUTAR"].ToString();
                faturaidtxt.Text = dr["FATURAID"].ToString();
            }
        }

        //fatura detay kaydetme
        private void simpleButton4_Click(object sender, EventArgs e)
        {
            double adet, fiyat, tutar;
            adet = Convert.ToDouble(adettxt.Text);
            fiyat = Convert.ToDouble(fiyattxt.Text);
            tutar = adet * fiyat;
            tutartxt.Text = tutar.ToString();

            SqlCommand komut = new SqlCommand("insert into TBL_FATURADETAY (URUNAD,ADET,FIYAT,TUTAR,FATURAID) VALUES (@P1,@P2,@P3,@P4,@P5)", bgl.baglanti());

            komut.Parameters.AddWithValue("@P1", urunadtxt.Text);
            komut.Parameters.AddWithValue("@P2", adettxt.Text);
            komut.Parameters.AddWithValue("@P3", Decimal.Parse(fiyattxt.Text));
            komut.Parameters.AddWithValue("@P4", Decimal.Parse(tutartxt.Text));
            komut.Parameters.AddWithValue("@P5", faturaidtxt.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Faturaya ait ürün kaydedildi", "fatura bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            faturadetaylistele();
        }

        //fatura bilgi kaydetme
        private void btnkaydet_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) VALUES(@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", seriTxt.Text);
            komut.Parameters.AddWithValue("@p2", sıranotxt.Text);
            komut.Parameters.AddWithValue("@p3", tarihmsk.Text);
            komut.Parameters.AddWithValue("@p4", saatmsk.Text);
            komut.Parameters.AddWithValue("@p5", vergidairetxt.Text);
            komut.Parameters.AddWithValue("@p6", alıcıtxt.Text);
            komut.Parameters.AddWithValue("@p7", tedentxt.Text);
            komut.Parameters.AddWithValue("@p8", talantxt.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura bilgisi sisteme kaydedildi", "fatura bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            faturabilgilistele();
        }


        //faturabilgi temizleme
        private void btntemizle_Click_1(object sender, EventArgs e)
        {
            faturabilgitemizle();
        }
        //fatura detay temizleme
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            faturadetaytemzile();
        }

        //FATURA BİLGİLERİ GÜNCELLEME
        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURABILGI set SERI=@p2,SIRANO=@p3,TARIH=@p4,SAAT=@p5,VERGIDAIRE=@p6,ALICI=@p7,TESLIMEDEN=@p8,TESLIMALAN=@p9 where FATURABILGID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p2", seriTxt.Text);
            komut.Parameters.AddWithValue("@p3", sıranotxt.Text);
            komut.Parameters.AddWithValue("@p4", tarihmsk.Text);
            komut.Parameters.AddWithValue("@p5", saatmsk.Text);
            komut.Parameters.AddWithValue("@p6", vergidairetxt.Text);
            komut.Parameters.AddWithValue("@p7", alıcıtxt.Text);
            komut.Parameters.AddWithValue("@p8", tedentxt.Text);
            komut.Parameters.AddWithValue("@p9", talantxt.Text);
            komut.Parameters.AddWithValue("@P1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura bilgileri GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            faturabilgilistele();
        }

        //FATURA DETAYLARI GÜNCELLEME
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURADETAY set URUNAD=@p2,ADET=@p3,FIYAT=@p4,TUTAR=@p5,FATURAID=@p6 where FATURAURUNID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p2",urunadtxt.Text);
            komut.Parameters.AddWithValue("@p3",adettxt.Text);
            komut.Parameters.AddWithValue("@p4",Decimal.Parse(fiyattxt.Text));
            komut.Parameters.AddWithValue("@p5",Decimal.Parse(tutartxt.Text));
            komut.Parameters.AddWithValue("@p6",faturaidtxt.Text);
            komut.Parameters.AddWithValue("@p1",urunıdtxt.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Detayları GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            faturadetaylistele();
        }
    }
}

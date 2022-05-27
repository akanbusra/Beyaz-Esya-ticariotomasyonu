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
    public partial class FrmÜrünler : Form
    {
        public FrmÜrünler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        //liSTELEME
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_URUNLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            
        }

        void temizle()
        {
            Txtad.Text = " ";
            Txtalısfiyat.Text = " ";
            Txtid.Text = " ";
            Txtmarka.Text = " ";
            Txtsatışfiyat.Text = " ";
            Mskmodel.Text = " ";
            Numericadet.Value = 0;
            mskyıl.Text = " ";
            Richtextdetay.Text = " ";
        }

        private void FrmÜrünler_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        //ÜRÜN EKLEME
        private void Btnkontrol_Click(object sender, EventArgs e)
        {
            //VERİLERİ KAYDETME

            SqlCommand komut = new SqlCommand("insert into TBL_URUNLER (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)",
                bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtad.Text);
            komut.Parameters.AddWithValue("@p2", Txtmarka.Text);
            komut.Parameters.AddWithValue("@p3", Mskmodel.Text);
            komut.Parameters.AddWithValue("@p4", mskyıl.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse((Numericadet.Value).ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(Txtalısfiyat.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(Txtsatışfiyat.Text));
            komut.Parameters.AddWithValue("@p8", Richtextdetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün KAYDEDİLDİ","BİLGİ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
        }

        //ÜRÜN SİLME
        private void btnsil_Click(object sender, EventArgs e)
        {
            //VERİ SİLME

            SqlCommand kmtsil = new SqlCommand("delete from TBL_URUNLER where ID=@p1", bgl.baglanti());
            kmtsil.Parameters.AddWithValue("@p1", Txtid.Text);
            kmtsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        //SEÇİLENLERİ TEMZİLEME
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            //VERİLERİ TEMİZLEME
            temizle();
        }

        //ÜRÜNE TIKLAYINCA TABLONUN DOLMASI
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Txtid.Text = dr["ID"].ToString();
            Txtad.Text = dr["URUNAD"].ToString();
            Txtmarka.Text = dr["MARKA"].ToString();
            Mskmodel.Text = dr["MODEL"].ToString();
            mskyıl.Text = dr["YIL"].ToString();
            Numericadet.Value =decimal.Parse(dr["ADET"].ToString()) ;
            Txtalısfiyat.Text = dr["ALISFIYAT"].ToString();
            Txtsatışfiyat.Text = dr["SATISFIYAT"].ToString();
            Richtextdetay.Text = dr["DETAY"].ToString();
        }

        //ÜRÜN GÜNCELLEME
        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand güncelle = new SqlCommand("update TBL_URUNLER set URUNAD=@P1,MARKA=@P2,MODEL=@P3,YIL=@P4,ADET=@P5,ALISFIYAT=@P6,SATISFIYAT=@P7,DETAY=@P8 where ID=@P9", bgl.baglanti());

            güncelle.Parameters.AddWithValue("@P1",Txtad.Text);
            güncelle.Parameters.AddWithValue("@P2",Txtmarka.Text);
            güncelle.Parameters.AddWithValue("@P3",Mskmodel.Text);
            güncelle.Parameters.AddWithValue("@P4",mskyıl.Text);
            güncelle.Parameters.AddWithValue("@P5",int.Parse((Numericadet.Value).ToString()));
            güncelle.Parameters.AddWithValue("@P6",decimal.Parse(Txtalısfiyat.Text));
            güncelle.Parameters.AddWithValue("@P7",decimal.Parse(Txtsatışfiyat.Text));
            güncelle.Parameters.AddWithValue("@P8",Richtextdetay.Text);
            güncelle.Parameters.AddWithValue("@P9",Txtid.Text);
            güncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();


        }
    }
}

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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        //listeleme
        void firmalistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_FIRMALAR",bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void temizle()
        {
            Txtid.Text = "";
            Txtad.Text = "";
            txtyetkiligörev.Text = "";
            Txtyetkili.Text = "";
            tcmsk.Text = "";
            txtsektör.Text = "";
            tel1msk.Text ="";
            tel2msk.Text ="";
            tel3msk.Text ="";
            txtmail.Text = "";
            txtfax.Text = "";
            ilcmb.Text = "";
            ilçecmb.Text = "";
            txtvergi.Text = "";
            adresrich.Text = "";
          //txtkod1.Text = " ";
         //txtkod2.Text = " ";
         //txtkod3.Text = " ";
        }

       /* void kodaciklama()
        {
            SqlCommand komut = new SqlCommand("select FIRMAKOD1 from Tbl_KODLAR",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                rchkod1.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();
        }
        */

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
        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            firmalistesi();

            sehirListesi();

            //kodaciklama();

            temizle();
        }
        
        //çift tıklandığında verilerin dolması
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                Txtad.Text = dr["AD"].ToString();
                txtyetkiligörev.Text = dr["YETKILISTATU"].ToString();
                Txtyetkili.Text = dr["YETKİLİADSOYAD"].ToString();
                tcmsk.Text = dr["YETKILITC"].ToString();
                txtsektör.Text = dr["SEKTOR"].ToString();
                tel1msk.Text = dr["TELEFON1"].ToString();
                tel2msk.Text = dr["TELEFON2"].ToString();
                tel3msk.Text = dr["TELEFON3"].ToString();
                txtmail.Text = dr["MAIL"].ToString();
                txtfax.Text = dr["FAX"].ToString();
                ilcmb.Text = dr["IL"].ToString();
                ilçecmb.Text = dr["ILCE"].ToString();
                txtvergi.Text = dr["VERGIDAIRE"].ToString();
                adresrich.Text = dr["ADRES"].ToString();
               // txtkod1.Text = dr["OZELKOD1"].ToString();
               // txtkod2.Text = dr["OZELKOD2"].ToString();
               // txtkod3.Text = dr["OZELKOD3"].ToString();
            }
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_FIRMALAR (AD,YETKILISTATU,YETKİLİADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE," +
                "VERGIDAIRE,ADRES) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14)",
               bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtyetkiligörev.Text);
            komut.Parameters.AddWithValue("@p3", Txtyetkili.Text);
            komut.Parameters.AddWithValue("@p4", tcmsk.Text);
            komut.Parameters.AddWithValue("@p5", txtsektör.Text);
            komut.Parameters.AddWithValue("@p6", tel1msk.Text);
            komut.Parameters.AddWithValue("@p7", tel2msk.Text);
            komut.Parameters.AddWithValue("@p8", tel3msk.Text);
            komut.Parameters.AddWithValue("@p9", txtmail.Text);
            komut.Parameters.AddWithValue("@p10", txtfax.Text);
            komut.Parameters.AddWithValue("@p11", ilcmb.Text);
            komut.Parameters.AddWithValue("@p12", ilçecmb.Text);
            komut.Parameters.AddWithValue("@p13", txtvergi.Text);
            komut.Parameters.AddWithValue("@p14", adresrich.Text);
            //komut.Parameters.AddWithValue("@p15", txtkod1.Text);
           // komut.Parameters.AddWithValue("@p16", txtkod2.Text);
           // komut.Parameters.AddWithValue("@p17", txtkod3.Text);
       
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Bilgileri KAYDEDİLDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmalistesi();
            temizle();
        }

        //Alanları temizleme
        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
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
            bgl.baglanti().Close();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            //Verileri Silme
            SqlCommand komut = new SqlCommand("DELETE from TBL_FIRMALAR where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Bilgileri SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmalistesi();
            
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FIRMALAR set AD=@p1,YETKILISTATU=@p2,YETKİLİADSOYAD=@p3,YETKILITC=@p4,SEKTOR=@p5,TELEFON1=@p6,TELEFON2=@p7,TELEFON3=@p8,MAIL=@p9,FAX=@p10,IL=@p11,ILCE=@p12, VERGIDAIRE=@p13,ADRES=@p14 where ID=@P18", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtyetkiligörev.Text);
            komut.Parameters.AddWithValue("@p3", Txtyetkili.Text);
            komut.Parameters.AddWithValue("@p4", tcmsk.Text);
            komut.Parameters.AddWithValue("@p5", txtsektör.Text);
            komut.Parameters.AddWithValue("@p6", tel1msk.Text);
            komut.Parameters.AddWithValue("@p7", tel2msk.Text);
            komut.Parameters.AddWithValue("@p8", tel3msk.Text);
            komut.Parameters.AddWithValue("@p9", txtmail.Text);
            komut.Parameters.AddWithValue("@p10", txtfax.Text);
            komut.Parameters.AddWithValue("@p11", ilcmb.Text);
            komut.Parameters.AddWithValue("@p12", ilçecmb.Text);
            komut.Parameters.AddWithValue("@p13", txtvergi.Text);
            komut.Parameters.AddWithValue("@p14", adresrich.Text);
           // komut.Parameters.AddWithValue("@p15", txtkod1.Text);
           // komut.Parameters.AddWithValue("@p16", txtkod2.Text);
           // komut.Parameters.AddWithValue("@p17", txtkod3.Text);
            komut.Parameters.AddWithValue("@p18", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma bilgileri GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            firmalistesi();
        }
    }
}

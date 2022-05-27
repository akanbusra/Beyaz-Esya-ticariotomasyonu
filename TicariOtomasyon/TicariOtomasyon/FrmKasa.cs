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
using DevExpress.Charts;


namespace TicariOtomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bg = new sqlbaglantisi();
        void musterihareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute MusteriHareketler", bg.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void firmahareket()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("execute FirmaHareketler", bg.baglanti());
            da2.Fill(dt2);
            gridControl3.DataSource = dt2;
        }

        void giderlistele()
        {
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("select * from TBL_GIDERLER", bg.baglanti());
            da3.Fill(dt3);
            gridControl2.DataSource = dt3;
        }

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            firmahareket();
            musterihareket();
            giderlistele();

            //toplam tutarı hesaplama
            SqlCommand komut1 = new SqlCommand("select sum(TUTAR) from TBL_FATURADETAY", bg.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                toplamtutarlbl.Text = dr1[0].ToString() + " TL";
            }
            bg.baglanti().Close();

            //son ayın faturaları
            SqlCommand komut2 = new SqlCommand("select (ELEKTRIK+SU+DOGALGAZ+INTERNET+EKSTRA) from TBL_GIDERLER order by ID asc", bg.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                ödemelerlbl.Text = dr2[0].ToString() + " TL";
            }
            bg.baglanti().Close();


            //personel maaşları
            SqlCommand komut3 = new SqlCommand("select sum(MAASLAR) from TBL_GIDERLER", bg.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                permaaşlbl.Text = dr3[0].ToString() + " TL";
            }
            bg.baglanti().Close();

            //müşteri sayısı
            SqlCommand komut4 = new SqlCommand("select count(*) from TBL_MUSTERILER", bg.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                müşterisayısılbl.Text = dr4[0].ToString();
            }
            bg.baglanti().Close();

            //Firma sayısı
            SqlCommand komut5 = new SqlCommand("SELECT COUNT(*) FROM TBL_FIRMALAR", bg.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                firmasayısılbl.Text = dr5[0].ToString();
            }
            bg.baglanti().Close();

            //personel sayısı
            SqlCommand komut6 = new SqlCommand("select count(*) from TBL_PERSONELLER", bg.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                personelsayısılbl.Text = dr6[0].ToString();
            }
            bg.baglanti().Close();

            //Toplam firma şehir sayısı
            SqlCommand komut7 = new SqlCommand("SELECT COUNT (distinct(IL)) FROM TBL_FIRMALAR ", bg.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                şehirsayısılbl.Text = dr7[0].ToString();
            }
            bg.baglanti().Close();

            //Toplam ürün sayısı
            SqlCommand komut8 = new SqlCommand("select sum(adet) from TBL_URUNLER", bg.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                stoksayısılbl.Text = dr8[0].ToString();
            }
            bg.baglanti().Close();



            //BİRİNCİ CHART KONTROLE ELEKTRİK FATURASI SON 4 AY LİSTELEME
            SqlCommand komut9 = new SqlCommand("select top 4 AY,ELEKTRIK FROM TBL_GIDERLER ORDER BY ID DESC", bg.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                chartControl1.Series["ELEKTRİK"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr9[0], dr9[1]));
            }
            bg.baglanti().Close();

            //İkinci chart kontrole son 4 ay su faturaası listeleme
            SqlCommand komut10 = new SqlCommand("select top 4 AY,SU FROM TBL_GIDERLER ORDER BY ID DESC", bg.baglanti());
            SqlDataReader dr10 = komut10.ExecuteReader();
            while (dr10.Read())
            {
                chartControl2.Series["SU"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr10[0], dr10[1]));
            }
            bg.baglanti().Close();

            //Üçüncü chart kontrole son 4 ay doğalgaz faturaası listeleme
            SqlCommand komut11 = new SqlCommand("select top 4 AY,DOGALGAZ FROM TBL_GIDERLER ORDER BY ID DESC", bg.baglanti());
            SqlDataReader dr11 = komut11.ExecuteReader();
            while (dr11.Read())
            {
                chartControl3.Series["DOĞALGAZ"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr11[0], dr11[1]));
            }
            bg.baglanti().Close();

            //Dördüncü chart kontrole son 4 ay ekstraları listeleme
            SqlCommand komut12 = new SqlCommand("select top 4 AY,EKSTRA FROM TBL_GIDERLER ORDER BY ID DESC", bg.baglanti());
            SqlDataReader dr12 = komut12.ExecuteReader();
            while (dr12.Read())
            {
                chartControl4.Series["EKSTRA"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr12[0], dr12[1]));
            }
            bg.baglanti().Close();


        }
    }
}

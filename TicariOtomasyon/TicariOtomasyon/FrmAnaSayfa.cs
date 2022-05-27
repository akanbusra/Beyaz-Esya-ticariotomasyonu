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
using System.Xml;

namespace TicariOtomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT URUNAD, SUM(ADET) AS 'ADET' FROM TBL_URUNLER GROUP BY URUNAD HAVING SUM(ADET)<=20 ORDER BY SUM(ADET)", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 15 tarıh,saat,BASLIK from TBL_NOTLAR order by ID desc", bgl.baglanti());
            da.Fill(dt);
            gridControl4.DataSource = dt;
        }

        void firmahareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("exec firmahareket2 ", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmloku.Read())
            {
                if (xmloku.Name=="title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }

        void firmatelefonrehberi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ad,telefon1 from TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            stoklar();
            ajanda();
            firmahareket();
            firmatelefonrehberi();
            haberler();

            webBrowser1.Navigate("http://www.tcmb.gov.tr/kurlar/today.xml");
        }
    }
}

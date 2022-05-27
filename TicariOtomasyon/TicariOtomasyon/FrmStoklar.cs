﻿using System;
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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("BUZDOLABI",15);
            //chartControl1.Series["Series 1"].Points.AddPoint("ÇAMAŞIR MAKİNESİ",10);
            //chartControl1.Series["Series 1"].Points.AddPoint("FIRIN",5);
            //chartControl1.Series["Series 1"].Points.AddPoint("BULAŞIK MAKİNESİ",1);
            //chartControl1.Series["Series 1"].Points.AddPoint("LAPTOP",12);
            //chartControl1.Series["Series 1"].Points.AddPoint("SU SITICISI",12);
            //chartControl1.Series["Series 1"].Points.AddPoint("KÜÇÜK EV ALETLERİ",12);

            SqlDataAdapter da = new SqlDataAdapter("select URUNAD,sum(ADET)  As'Miktar' from TBL_URUNLER group by URUNAD", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            //Charta stok miktarı listeleme
            SqlCommand komut = new SqlCommand("select URUNAD, sum(ADET)  As'Miktar' from TBL_URUNLER group by URUNAD", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse(dr[1].ToString()));
            }
            bgl.baglanti().Close();

            //Charta firma şehir sayısı çekme
            SqlCommand komut2 = new SqlCommand("select IL, count(*)  from TBL_FIRMALAR group by IL", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(Convert.ToString(dr2[0]), int.Parse(dr2[1].ToString()));
            }
            bgl.baglanti().Close();
        }
    }
}

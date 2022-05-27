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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("execute bankabilgileri", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void temizle()
        {
            txtbankaadı.Text ="";
            Txtyetkili.Text ="";
            txthesaptürü.Text = "";
            lookupeditfirma.Text="";
            Txtid.Text ="";
            txtşube.Text ="";
            msktarih.Text ="";
            hesapnomsk.Text ="";
            ilcmb.Text ="";
            ilçecmb.Text ="";
            
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

        void firmalistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ID,AD from TBL_FIRMALAR",bgl.baglanti());
            da.Fill(dt);
            lookupeditfirma.Properties.NullText = "Lütfen bir firma seçiniz";
            lookupeditfirma.Properties.ValueMember = "ID";
            lookupeditfirma.Properties.DisplayMember = "AD";
            lookupeditfirma.Properties.DataSource = dt;

        }
        private void FrmBankalar_Load(object sender, EventArgs e)
        {
                listele();
                sehirListesi();
                temizle();
                firmalistesi();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_BANKALAR (BANKAADI,IL,ILCE,SUBE,HESAPNO,YETKILI,TARIH,HESAPTURU,FIRMAID) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)",
               bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtbankaadı.Text);
            komut.Parameters.AddWithValue("@p2", ilcmb.Text);
            komut.Parameters.AddWithValue("@p3", ilçecmb.Text);
            komut.Parameters.AddWithValue("@p4", txtşube.Text);
            komut.Parameters.AddWithValue("@p5", hesapnomsk.Text);
            komut.Parameters.AddWithValue("@p6", Txtyetkili.Text);
            komut.Parameters.AddWithValue("@p7", msktarih.Text);
            komut.Parameters.AddWithValue("@p8", txthesaptürü.Text);
            komut.Parameters.AddWithValue("@p9", lookupeditfirma.EditValue);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("BANKA BİLGİLERİ KAYDEDİLDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

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

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                txtbankaadı.Text = dr["BANKAADI"].ToString();
                ilcmb.Text = dr["IL"].ToString();
                ilçecmb.Text = dr["ILCE"].ToString();
                txtşube.Text = dr["SUBE"].ToString();
                hesapnomsk.Text = dr["HESAPNO"].ToString();
                Txtyetkili.Text = dr["YETKILI"].ToString();
                msktarih.Text = dr["TARIH"].ToString();
                txthesaptürü.Text = dr["HESAPTURU"].ToString();
               // lookupeditfirma.Text = dr["FIRMAD"].ToString();
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("DELETE from TBL_BANKALAR where ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("BANKA BİLGİSİ SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_BANKALAR set BANKAADI=@P1,IL=@P2,ILCE=@P3,SUBE=@P4,HESAPNO=@P5,YETKILI=@P6,TARIH=@P7,HESAPTURU=@P8,FIRMAID=@P9 where ID=@P10", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", txtbankaadı.Text);
            komut.Parameters.AddWithValue("@P2", ilcmb.Text);
            komut.Parameters.AddWithValue("@P3", ilçecmb.Text);
            komut.Parameters.AddWithValue("@P4", txtşube.Text);
            komut.Parameters.AddWithValue("@P5", hesapnomsk.Text);
            komut.Parameters.AddWithValue("@P6", Txtyetkili.Text);
            komut.Parameters.AddWithValue("@P7", msktarih.Text);
            komut.Parameters.AddWithValue("@P8", txthesaptürü.Text);
            komut.Parameters.AddWithValue("@P9", lookupeditfirma.EditValue);
            komut.Parameters.AddWithValue("@P10",Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("BANKA bilgileri GÜNCELLENDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}

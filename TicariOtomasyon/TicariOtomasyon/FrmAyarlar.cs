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
    public partial class FrmAyarlar : Form
    {

        public FrmAyarlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        public void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_ADMIN", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        public void temizle()
        {
            kullanıcıaditxt.Text = "";
            şifretxt.Text = "";
            idtxt.Text = "";
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_ADMIN values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", kullanıcıaditxt.Text);
            komut.Parameters.AddWithValue("@p2", şifretxt.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Yeni kullanıcı sisteme kaydedildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand güncelle = new SqlCommand("update TBL_ADMIN set kullaniciad=@P1,şifre=@P2 where ID=@p3", bgl.baglanti());

            güncelle.Parameters.AddWithValue("@P1", kullanıcıaditxt.Text);
            güncelle.Parameters.AddWithValue("@P2", şifretxt.Text);
            güncelle.Parameters.AddWithValue("@P3", idtxt.Text);
            güncelle.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kullanıcı bilgileri güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            idtxt.Text = dr["ID"].ToString();
            kullanıcıaditxt.Text = dr["kullaniciad"].ToString();
            şifretxt.Text = dr["şifre"].ToString();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand kmtsil = new SqlCommand("delete from TBL_ADMIN where ID=@p1", bgl.baglanti());
            kmtsil.Parameters.AddWithValue("@p1", idtxt.Text);
            kmtsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kullanıcı bilgileri SİLİNDİ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
            temizle();
        }
    }
}

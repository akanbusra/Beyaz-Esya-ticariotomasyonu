using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariOtomasyon
{
    public partial class FrmGırısSayfası : Form
    {
        public FrmGırısSayfası()
        {
            InitializeComponent();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            FrmÜrünler ürün = new FrmÜrünler();
            ürün.Show();
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmAnaModul anasayfa = new FrmAnaModul();
            anasayfa.Show();
            
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            FrmStoklar stok = new FrmStoklar();
            stok.Show();
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            FrmMusteriler musteri = new FrmMusteriler();
            musteri.Show();
            
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            FrmFirmalar frma = new FrmFirmalar();
            frma.Show();
            
        }

        private void simpleButton9_Click(object sender, EventArgs e)
        {
            FrmPersoneller personel = new FrmPersoneller();
            personel.Show();
            
        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            FrmGiderler gider = new FrmGiderler();
            gider.Show();
            
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            FrmKasa kasa = new FrmKasa();
            kasa.Show();
            
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            FrmNotlar not = new FrmNotlar();
            not.Show();
           
        }

        private void simpleButton12_Click(object sender, EventArgs e)
        {
            FrmBankalar banka = new FrmBankalar();
            banka.Show();
            
        }

        private void simpleButton11_Click(object sender, EventArgs e)
        {
            FrmRehber rehber = new FrmRehber();
            rehber.Show();
           
        }

        private void simpleButton10_Click(object sender, EventArgs e)
        {
            FrmFaturalar fatura = new FrmFaturalar();
            fatura.Show();
           
        }

        private void simpleButton13_Click(object sender, EventArgs e)
        {
            FrmAyarlar ayar = new FrmAyarlar();
            ayar.Show();
            
        }
    }
}

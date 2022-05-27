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
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        FrmÜrünler fr;
        private void BtnÜrünler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null) {
                fr = new FrmÜrünler();
            fr.MdiParent = this;
            fr.Show();
            }
            
        }

        FrmMusteriler fm;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fm==null)
            {
               fm = new FrmMusteriler();
            fm.MdiParent = this;
            fm.Show();
            }
        }

        FrmFirmalar frf;
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frf == null)
            {
                frf = new FrmFirmalar();
                frf.MdiParent = this;
                frf.Show();
            }
        }
        FrmPersoneller fr4;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr4 == null)
            {
                fr4 = new FrmPersoneller();
                fr4.MdiParent = this;
                fr4.Show();
            }
        }
        FrmRehber fr5;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr5 == null)
            {
                fr5 = new FrmRehber();
                fr5.MdiParent = this;
                fr5.Show();
            }
        }

        FrmGiderler fr6;
        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr6 == null)
            {
                fr6 = new FrmGiderler();
                fr6.MdiParent = this;
                fr6.Show();
            }
        }

        FrmBankalar fr7;
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr7==null)
            {
                fr7 = new FrmBankalar();
                fr7.MdiParent = this;
                fr7.Show();
            }
        }

        FrmFaturalar fr8;
        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr8 == null)
            {
                fr8 = new FrmFaturalar();
                fr8.MdiParent = this;
                fr8.Show();
            }
        }

        FrmStoklar fr9;
        private void BtnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr9 == null)
            {
                fr9 = new FrmStoklar();
                fr9.MdiParent = this;
                fr9.Show();
            }
        }

        FrmNotlar fr10;
        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr10 == null)
            {
                fr10= new FrmNotlar();
                fr10.MdiParent = this;
                fr10.Show();
            }
        }

        FrmKasa fr11;
        private void BtnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr11 == null)
            {
                fr11 = new FrmKasa();
                fr11.MdiParent = this;
                fr11.Show();
            }
        }

        FrmAyarlar fr12;
        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr12 == null)
            {
                fr12 = new FrmAyarlar();
                fr12.MdiParent = this;
                fr12.Show();
            }
        }

        FrmAnaSayfa fr13;
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr13 == null)
            {
                fr13 = new FrmAnaSayfa();
                fr13.MdiParent = this;
                fr13.Show();
            }
        }

        private void FrmAnaModul_Load(object sender, EventArgs e)
        {
            if (fr13 == null)
            {
                fr13 = new FrmAnaSayfa();
                fr13.MdiParent = this;
                fr13.Show();
            }
        }
    }
}

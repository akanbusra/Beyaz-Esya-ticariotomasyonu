﻿using System;
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
    public partial class FrmNotDetay2 : Form
    {
        public FrmNotDetay2()
        {
            InitializeComponent();
        }

        public string metin;

        private void FrmNotDetay2_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = metin;
        }
    }
}

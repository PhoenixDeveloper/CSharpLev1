using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMO.GameDevUnity.CSharp1.Pract7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (long.Parse(lblNumber.Text) + 1).ToString();
            lblAmountClick.Text = (int.Parse(lblAmountClick.Text) + 1).ToString();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (long.Parse(lblNumber.Text) * 2).ToString();
            lblAmountClick.Text = (int.Parse(lblAmountClick.Text) + 1).ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "1";
            lblAmountClick.Text = "0";
        }
    }
}

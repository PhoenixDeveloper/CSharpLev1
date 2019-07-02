using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMO.GameDevUnity.CSharp1.Pract8
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void tBoxTask_TextChanged(object sender, EventArgs e)
        {
            try
            {
                numUpDownTask.Value = decimal.Parse(tBoxTask.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Введены некорректные данные!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void numUpDownTask_ValueChanged(object sender, EventArgs e)
        {
            tBoxTask.Text = numUpDownTask.Value.ToString();
        }
    }
}

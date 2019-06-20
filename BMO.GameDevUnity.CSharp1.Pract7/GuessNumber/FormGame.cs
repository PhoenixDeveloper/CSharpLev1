using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessNumber
{
    public partial class FormGame : Form
    {
        Random rnd = new Random();
        int result = 0;

        public FormGame()
        {
            InitializeComponent();
            lblInfo1.Text = "Я загадал число от 1 до 100.\nПопробуй его отгадать ;)";
            result = rnd.Next(1, 100);
        }

        public void CheckResult(int resultInput)
        {
            if (resultInput > result)
            {
                lblResult.Text = $"Я загадал\nменьше {resultInput}";
            }
            else if (resultInput < result)
            {
                lblResult.Text = $"Я загадал\nбольше {resultInput}";
            }
            else
            {
                MessageBox.Show("Ты угадал!", "Победа");
                Program.Restart();
            }
        }

        private void btnLink_Click(object sender, EventArgs e)
        {
            Form numberEnter = new FormEnter();
            numberEnter.ShowDialog();
            CheckResult(Number.number);
        }
    }
}

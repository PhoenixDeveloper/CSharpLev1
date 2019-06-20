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

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (int.Parse(tBoxNumber.Text) > result)
            {
                lblResult.Text = $"Я загадал\nменьше {tBoxNumber.Text}";
            }
            else if (int.Parse(tBoxNumber.Text) < result)
            {
                lblResult.Text = $"Я загадал\nбольше {tBoxNumber.Text}";
            }
            else
            {
                MessageBox.Show("Ты угадал!", "Победа");
                Program.Restart();
            }
        }
    }
}

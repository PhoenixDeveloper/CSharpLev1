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
    public partial class FormGame : Form
    {
        private Random rnd = new Random();
        int mission = 0;

        public FormGame()
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

        private void FormGame_Load(object sender, EventArgs e)
        {
            mission = rnd.Next(150, 60000);
            lblMission.Text = mission.ToString();
            MessageBox.Show($"Вам необходимо получить число {mission}, за наименьшее количество ходов", "Цель");
        }

        private void lblNumber_TextChanged(object sender, EventArgs e)
        {
            if (lblNumber.Text == lblMission.Text)
            {
                MessageBox.Show($"Вам удалось получить необходимое число {mission} за {lblAmountClick.Text} действий. Поздравляем!", 
                    "Победа");
                this.Close();
            }
        }
    }
}

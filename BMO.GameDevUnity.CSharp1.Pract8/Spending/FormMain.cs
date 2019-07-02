using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spending
{
    public partial class FormMain : Form
    {
        TrueFalse database;
        Dictionary<DateTime, int> numenator = new Dictionary<DateTime, int>();

        public FormMain()
        {
            InitializeComponent();
        }

        // Обработчик пункта меню Exit
        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Обработчик пункта меню New
        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                database.Add($"Введите здесь список покупок за {dtpSpeeding.Value.Date.ToShortDateString()}", 0, dtpSpeeding.Value.Date);
                numenator.Add(dtpSpeeding.Value.Date, database.Count-1);
                DtpSpeeding_ValueChanged(database, EventArgs.Empty);
                database.Save();
            };
        }

        // Обработчик кнопки Удалить
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (database == null) return;
            database.Remove(numenator[dtpSpeeding.Value.Date]);
            List<DateTime> buffer = new List<DateTime>();
            foreach (var keyValue in numenator)
            {
                if (keyValue.Value > numenator[dtpSpeeding.Value.Date])
                {
                    buffer.Add(keyValue.Key);
                }
            }
            foreach (var date in buffer)
            {
                numenator[date]--;
            }
            numenator.Remove(dtpSpeeding.Value.Date);
            DtpSpeeding_ValueChanged(database, EventArgs.Empty);
        }

        // Обработчик пункта меню Save
        private void miSave_Click(object sender, EventArgs e)
        {
            try
            {
                database.Save();
            }
            catch (Exception)
            {

                MessageBox.Show("База данных не создана!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик пункта меню Open
        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(ofd.FileName);
                database.Load();
                numenator.Clear();
                for (int i = 0; i < database.Count; i++)
                {
                    numenator.Add(database[i].Date, i);
                }
                DtpSpeeding_ValueChanged(database, EventArgs.Empty);
            }
        }

        // Обработчик кнопки Сохранить (вопрос)
        private void btnSaveQuest_Click(object sender, EventArgs e)
        {
            try
            {
                if (!numenator.ContainsKey(dtpSpeeding.Value.Date))
                {
                    numenator.Add(dtpSpeeding.Value.Date, database.Count);
                    database.Add(tBoxListSpending.Text, (double)nudMoney.Value, dtpSpeeding.Value.Date);
                }
                else
                {
                    database[numenator[dtpSpeeding.Value.Date]].Money = (double)nudMoney.Value;
                    database[numenator[dtpSpeeding.Value.Date]].Text = tBoxListSpending.Text;
                }                
            }
            catch (Exception)
            {

                MessageBox.Show("База данных не создана!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mi_aboutProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Учет расходов. v 1.0.0\n© Беленко Михаил Олегович. 2019 год.", "О программе",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog safd = new SaveFileDialog();
            try
            {
                if (safd.ShowDialog() == DialogResult.OK)
                {
                    database.FileName = safd.FileName;
                    database.Save();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("База данных не создана!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DtpSpeeding_ValueChanged(object sender, EventArgs e)
        {
            if (numenator.ContainsKey(dtpSpeeding.Value.Date))
            {
                tBoxListSpending.Text = database[numenator[dtpSpeeding.Value.Date]].Text;
                nudMoney.Value = (decimal)database[numenator[dtpSpeeding.Value.Date]].Money;
            }
            else
            {
                tBoxListSpending.Text = $"Введите сюда список покупок за {dtpSpeeding.Value.Date.ToShortDateString()}";
                nudMoney.Value = 0;
            }
            
        }
    }
}

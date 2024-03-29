﻿using System;
using System.Windows.Forms;

namespace BelieveOrNotBelieve
{
    public partial class FormGame : Form
    {
        // База данных с вопросами
        TrueFalse database;

        public FormGame()
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
                database.Add("123", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            };
        }

        // Обработчик события изменения значения numericUpDown
        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                tboxQuestion.Text = database[(int)nudNumber.Value - 1].text;
                cboxTrue.Checked = database[(int)nudNumber.Value - 1].trueFalse;
            }
            catch (Exception)
            {
                MessageBox.Show("Обращение к несуществующему вопросу!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        // Обработчик кнопки Добавить
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            database.Add((database.Count + 1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }

        // Обработчик кнопки Удалить
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (nudNumber.Maximum == 1 || database == null) return;
            database.Remove((int)nudNumber.Value);
            nudNumber.Maximum--;
            if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;
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
                if (database.Count < 100)
                {                    
                    nudNumber.Minimum = 1;
                    nudNumber.Maximum = database.Count;
                    nudNumber.Value = 1;
                    nudNumber_ValueChanged(string.Empty, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("Слишком большой файл!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Обработчик кнопки Сохранить (вопрос)
        private void btnSaveQuest_Click(object sender, EventArgs e)
        {
            try
            {
                database[(int)nudNumber.Value - 1].text = tboxQuestion.Text;
                database[(int)nudNumber.Value - 1].trueFalse = cboxTrue.Checked;
            }
            catch (Exception)
            {

                MessageBox.Show("База данных не создана!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void mi_aboutProgram_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Верю - Не верю. v 1.0.0\n© Беленко Михаил Олегович. 2019 год.", "О программе",
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
    }
}

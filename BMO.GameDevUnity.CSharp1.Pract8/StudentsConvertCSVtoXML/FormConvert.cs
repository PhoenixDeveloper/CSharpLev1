using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace StudentsConvertCSVtoXML
{
    public partial class FormConvert : Form
    {
        List<Student> students;

        public FormConvert()
        {
            InitializeComponent();
        }

        private void btnChoosePathCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog chooseCSVFile = new OpenFileDialog();
            chooseCSVFile.Filter = "CSV files(*.csv)| *.csv";
            if (chooseCSVFile.ShowDialog() == DialogResult.OK)
            {
                txtBoxPathCSV.Text = chooseCSVFile.FileName;
            }
        }

        private void btnChoosePathXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog createXMLFile = new SaveFileDialog();
            createXMLFile.Filter = "XML files(*.xml)| *.xml";
            if (createXMLFile.ShowDialog() == DialogResult.OK)
            {
                txtBoxPathXML.Text = createXMLFile.FileName;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                students = ReadCSV(txtBoxPathCSV.Text);
                SaveXML(txtBoxPathXML.Text, students);
                lblReady.Text = "Готово!";
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        static List<Student> ReadCSV(string csv_path)
        {
            List<Student> list = new List<Student>();                             // Создаем список студентов
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader(csv_path);
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            sr.Close();
            return list;
        }

        static void SaveXML(string xml_path, List<Student> students)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Student>));
            Stream fStream = new FileStream(xml_path, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, students);
            fStream.Close();
        }
    }
}

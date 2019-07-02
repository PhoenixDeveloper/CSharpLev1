using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Spending
{
    // Класс для вопроса    
    [Serializable]
    public class Spending
    {
        string text;
        double money;
        DateTime date;

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        public double Money
        {
            get
            {
                return money;
            }
            set
            {
                if (value > 0)
                {
                    money = value;
                }
                else
                {
                    money = -value;
                }
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        public Spending()
        {
        }

        public Spending(string text, double money, DateTime date)
        {
            this.text = text;
            this.money = money;
            this.date = date;
        }
    }

    // Класс для хранения списка вопросов. А также для сериализации в XML и десериализации из XML
    class TrueFalse
    {
        string fileName;
        List<Spending> list;

        public string FileName
        {
            set { fileName = value; }
        }

        public TrueFalse(string fileName)
        {
            this.fileName = fileName;
            list = new List<Spending>();
        }

        public void Add(string text, double money, DateTime date)
        {
            list.Add(new Spending(text, money, date));
        }

        public void Remove(int index)
        {
            if (list != null && index < list.Count && index >= 0) list.RemoveAt(index);
        }

        // Индексатор - свойство для доступа к закрытому объекту
        public Spending this[int index]
        {
            get { return list[index]; }
        }

        public void Save()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Spending>));
            Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlFormat.Serialize(fStream, list);
            fStream.Close();
        }

        public void Load()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Spending>));
            Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            list = (List<Spending>)xmlFormat.Deserialize(fStream);
            fStream.Close();
        }

        public int Count
        {
            get { return list.Count; }
        }
    }
}
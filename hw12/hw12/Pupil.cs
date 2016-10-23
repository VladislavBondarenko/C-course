using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw12
{
    class Pupil
    {
        public string Name { protected set; get; }
        public byte Age { set; get; }
        public Dictionary<string, byte> MarkList { set; get; }
        public Pupil Next { get; set; }
        public Pupil Prev { get; set; }

        public Pupil(string name, byte age)
        {
            this.Name = name;
            this.Age = age;
            this.MarkList = new Dictionary<string, byte>();
        }

        public void AddMark(string subject, byte mark)
        {
            if (this.MarkList.ContainsKey(subject))
            {
                this.MarkList.Remove(subject);
            }
            this.MarkList.Add(subject, mark);
        }

        public double GetAvgMark()
        {
            double sum = 0;
            int number = 0;
            foreach (var item in this.MarkList)
            {
                sum += item.Value;
                number++;
            }
            return sum/number;
        }

        public void ShowAllMarks()
        {
            foreach (var item in this.MarkList)
            {
                Console.WriteLine("{0} - {1}", item.Key, item.Value);
            }
        }
    }
}

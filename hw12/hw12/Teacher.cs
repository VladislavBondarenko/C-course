using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hw12
{
    class Teacher
    {
        protected Journal journal { set; get; }
        protected string path = @"pupils.dat";

        public Teacher()
        {
            this.journal = new Journal();
        }
        public void AddPupil()
        {
            Console.Write("Введите имя ученика: ");
            string name = Console.ReadLine();
            byte age = Tools.InputNumber("Введите возраст ученика: ", 1, 100);
            if (this.journal.Add(name, age) != null)
            {
                Console.WriteLine("Выполнено");
            }
            else
            {
                Console.WriteLine("Такой ученик уже существует");
            }
            
        }

        public void AddMark()
        {
            if (this.ShowAllPupils())
            {
                Console.Write("Введите имя ученика: ");
                string name = Console.ReadLine();
                Pupil curPupil = this.journal.GetPupilByName(name);
                if (curPupil != null)
                {
                    Console.Write("Введите название предмета: ");
                    string subject = Console.ReadLine();
                    byte mark = Tools.InputNumber("Введите оценку: ", this.journal.MinMark, this.journal.MaxMark);
                    curPupil.AddMark(subject, mark);
                    Console.WriteLine("Выполнено");
                }
                else
                {
                    Console.WriteLine("Некорректное значение");
                }
            }
        }
        
        public bool ShowAllPupils()
        {
            int count = 0;
            foreach (Pupil pupil in this.journal)
            {
                count++;
                Console.WriteLine("{0}. {1} ({2} лет)", count, pupil.Name, pupil.Age);
            }
            if (count > 0)
            {
                return true;
            }
            Console.WriteLine("Список учеников пуст");
            return false;
        }

        public void ShowAvgMarkSomePupil()
        {
            if (this.ShowAllPupils())
            {
                Console.Write("Введите имя ученика: ");
                string name = Console.ReadLine();
                Pupil curPupil = this.journal.GetPupilByName(name);
                if (curPupil != null)
                {
                    Console.WriteLine("Средний балл = {0}", curPupil.GetAvgMark());
                }
                else
                {
                    Console.WriteLine("Некорректное значение");
                }
            }
        }

        public void ShowAllMarks()
        {
            if (this.journal.Count > 0)
            {
                byte mainAge = Tools.InputNumber("Возраст ученика больше (лет): ", 0, 100);
                foreach (Pupil pupil in this.journal)
                {
                    if (pupil.Age > mainAge)
                    {
                        Console.WriteLine("{0}:", pupil.Name);
                        pupil.ShowAllMarks();
                        Console.WriteLine(new string('-', 30));
                    }
                }
            }
            else
            {
                Console.WriteLine("Список учеников пуст");
            }
        }

        public void WriteFile()
        {
            try
            {
                File.Delete(this.path);
                using (BinaryWriter writer = new BinaryWriter(File.Open(this.path, FileMode.OpenOrCreate)))
                {
                    foreach (Pupil pupil in this.journal)
                    {
                        writer.Write(pupil.Name);
                        writer.Write(pupil.Age);
                        writer.Write(pupil.MarkList.Count);
                        foreach (var mark in pupil.MarkList)
                        {
                            writer.Write(mark.Key);
                            writer.Write(mark.Value);
                        }
                    }
                }
                Console.WriteLine("Выполнено");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ReadFile()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open(this.path, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string name = reader.ReadString();
                        byte age = reader.ReadByte();
                        int numMarks = reader.ReadInt32();
                        Pupil curPupil = this.journal.Add(name, age);
                        for (int i = 0; i < numMarks; i++)
                        {
                            string subject = reader.ReadString();
                            byte mark = reader.ReadByte();
                            curPupil.AddMark(subject, mark);
                        }
                    }
                }
                Console.WriteLine("Выполнено");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

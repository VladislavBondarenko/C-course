using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw12
{
    class Program
    {
        static void Main(string[] args)
        {
            Teacher teacher = new Teacher();

            byte point;
            bool cont = true;
            while (cont)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить ученика");
                Console.WriteLine("2. Поставить оценку ученику");
                Console.WriteLine("3. Посмотреть средний балл ученика");
                Console.WriteLine("4. Посмотреть все оценки учеников");
                Console.WriteLine("5. Посмотреть список учеников");
                Console.WriteLine("6. Записать данные в файл");
                Console.WriteLine("7. Загрузить данные из файла");
                Console.WriteLine("0. Выйти");
                Console.WriteLine();
                point = (byte)Tools.InputNumber("Пункт: ", 0, 7);
                Console.WriteLine();
                switch (point)
                {
                    case 1:
                        teacher.AddPupil();
                        Console.ReadKey();
                        break;
                    case 2:
                        teacher.AddMark();
                        Console.ReadKey();
                        break;
                    case 3:
                        teacher.ShowAvgMarkSomePupil();
                        Console.ReadKey();
                        break;
                    case 4:
                        teacher.ShowAllMarks();
                        Console.ReadKey();
                        break;
                    case 5:
                        teacher.ShowAllPupils();
                        Console.ReadKey();
                        break;
                    case 6:
                        teacher.WriteFile();
                        Console.ReadKey();
                        break;
                    case 7:
                        teacher.ReadFile();
                        Console.ReadKey();
                        break;
                    case 0: cont = false; break;
                }
            }
        }
    }
}

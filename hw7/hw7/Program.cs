using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7
{
    class Program
    {
        static void Main(string[] args)
        {
            Doctor doctor = new Doctor("doctor", 3, 15, 20, 0);
            Psychologist psychologist = new Psychologist("psychologist", 4, 12, 16, 1.2m, 2);
            Worker worker = new Worker("worker", 1, 10, 1.2m, 4);
            Security security = new Security("security", 2, 8, 2, 2, 3);

            byte point;
            bool cont = true;
            while (cont)
            {
                Console.Clear();
                Console.WriteLine("Выберите работника, для подсчета его зарплаты\n");
                Console.WriteLine("1. Врач");
                Console.WriteLine("2. Психолог");
                Console.WriteLine("3. Обычный работник");
                Console.WriteLine("4. Охранник");
                Console.WriteLine("5. Стажер врача");
                Console.WriteLine("6. Стажер психолога");
                Console.WriteLine("7. Стажер обычного работника");
                Console.WriteLine("8. Стажер охранника");
                Console.WriteLine("0. Выйти");
                Console.WriteLine();
                point = (byte)Tools.InputNumber("Пункт: ", 0, 8);
                Console.WriteLine();
                switch (point)
                {
                    case 1: Accountant.CountSalary(doctor); break;
                    case 2: Accountant.CountSalary(psychologist); break;
                    case 3: Accountant.CountSalary(worker); break;
                    case 4: Accountant.CountSalary(security); break;
                    case 5: Accountant.CountSalary(new Trainee(doctor, "Стажер доктора", 1.5m)); break;
                    case 6: Accountant.CountSalary(new Trainee(psychologist, "Стажер психолога", 1.5m)); break;
                    case 7: Accountant.CountSalary(new Trainee(worker, "Стажер обычного работника", 1.5m)); break;
                    case 8: Accountant.CountSalary(new Trainee(security, "Стажер охранника", 1.5m)); break;
                    case 0: cont = false; break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7
{
    class Accountant
    {
        public static void CountSalary(Employee employee)
        {
            decimal salary = 0;
            employee.AskData();
            employee.AskBonus();
            salary = employee.CountBasicSalary() + employee.CountBonusHoursSalary() + employee.CountBonusSalary();
            Console.WriteLine("\nЗаработок этого работника за месяц = " + salary);
            Console.ReadKey();
        }
    }
}

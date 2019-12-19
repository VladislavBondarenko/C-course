using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7
{
    sealed class Trainee : Employee
    {
        public Employee Master { set; get; }

        public Trainee(Employee employee, string name, decimal ratioBonusHours) :
            base(name, 0, employee.Rate, ratioBonusHours)
        {
            this.Master = employee;
        }

        public override void AskBonus() {}

        public override decimal CountBonusSalary()
        {
            return 0;
        }
    }
}

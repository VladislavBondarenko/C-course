using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7
{
    abstract class Employee
    {
        public int Experience { protected set; get; }
        public decimal Rate { protected set; get; }
        public string Name { protected set; get; }
        public decimal RatioBonusHours { protected set; get; }
        public byte Days { protected set; get; }
        public byte Hours { protected set; get; }
        public byte BonusHours { protected set; get; }

        public Employee(string name, int experience, decimal rate, decimal ratioBonusHours)
        {
            this.Name = name;
            this.Experience = experience;
            this.Rate = rate;
            this.RatioBonusHours = ratioBonusHours;
        }

        public virtual void AskData()
        {
            this.Days = (byte)Tools.InputNumber("Сколько дней в этом месяце работал?: ", 0, 31);
            this.Hours = (byte)Tools.InputNumber("Сколько часов в день?: ", 0, 24);
            this.BonusHours = (byte)Tools.InputNumber("Сколько насчитано премиальных часов?: ", 0, 200);
        }

        public virtual decimal CountBasicSalary()
        {
            return this.Days * this.Hours * this.Rate;
        }

        public virtual decimal CountBonusHoursSalary()
        {
            return this.BonusHours * this.Rate * this.RatioBonusHours;
        }

        public abstract void AskBonus();
        public abstract decimal CountBonusSalary();
    }
}

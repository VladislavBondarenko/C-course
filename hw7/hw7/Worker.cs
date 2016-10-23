using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7
{
    class Worker : Employee
    {
        private decimal RatioRateOvertime { set; get; }
        private int overtimeHours { set; get; }

        public Worker(string name, int experience, decimal rate, decimal ratioRateOvertime, decimal ratioBonusHours)
            :base(name, experience, rate, ratioBonusHours)
        {
            this.RatioRateOvertime = ratioRateOvertime;
        }

        public override void AskBonus()
        {
            this.overtimeHours = Tools.InputNumber("Сколько было сверхурочных часов?: ", 0, 200);
        }

        public override decimal CountBonusSalary()
        {
            return this.overtimeHours * this.RatioRateOvertime * this.Rate;
        }
    }
}

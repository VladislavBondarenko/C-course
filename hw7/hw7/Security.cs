using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7
{
    class Security: Employee
    {
        private decimal RatioRateNight { set; get; }
        private decimal RatioBonusNightHours { set; get; }
        private int NightHours { set; get; }


        public Security(string name, int experience, decimal rate, decimal ratioRateNight, decimal ratioBonusHours, decimal ratioBonusNightHours)
            :base(name, experience, rate, ratioBonusHours)
        {
            this.RatioRateNight = ratioRateNight;
            this.RatioBonusNightHours = ratioBonusNightHours;
        }

        public override void AskBonus()
        {
            this.NightHours = Tools.InputNumber("Сколько из всех часов в этом месяце было ночных?: ", 0, 200);
        }
        public override decimal CountBasicSalary()
        {
            return (this.Days * this.Hours - this.NightHours) * this.Rate;
        }

        public override decimal CountBonusSalary()
        {
            return this.NightHours * this.Rate * this.RatioRateNight;
        }
    }
}

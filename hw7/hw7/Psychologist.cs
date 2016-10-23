using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7
{
    class Psychologist : Employee
    {
        private decimal RatePatient { set; get; }
        private decimal RatioRateAdditionalPatient { set; get; }
        private int AdditionalPatiens { set; get; }

        public Psychologist(string name, int experience, decimal rate, decimal ratePatient, decimal ratioRateAdditionalPatient, decimal ratioBonusHours)
            :base(name, experience, rate, ratioBonusHours)
        {
            this.RatePatient = ratePatient;
            this.RatioRateAdditionalPatient = ratioRateAdditionalPatient;
        }

        public override void AskBonus()
        {
            this.AdditionalPatiens = Tools.InputNumber("Сколько пациентов были дополнительными?: ", 0, 200);
        }

        public override decimal CountBonusSalary()
        {
            return this.AdditionalPatiens * this.RatePatient * this.RatioRateAdditionalPatient;
        }
    }
}

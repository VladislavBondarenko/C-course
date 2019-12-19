using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw7
{
    class Doctor : Employee
    {
        private decimal BonusOneCured { set; get; }
        private byte NumberCured { set; get; }

        public Doctor(string name, int experience, decimal rate, decimal bonusOneCured, decimal ratioBonusHours)
            :base(name, experience, rate, ratioBonusHours)
        {
            this.BonusOneCured = bonusOneCured;
        }

        public override void AskBonus()
        {
            this.NumberCured = (byte)Tools.InputNumber("Сколько больных вылечил?: ", 0, 200);
        }

        public override decimal CountBonusSalary()
        {
            return this.NumberCured * this.BonusOneCured;
        }
    }
}

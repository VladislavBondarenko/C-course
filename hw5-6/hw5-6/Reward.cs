using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5_6
{
    class Reward
    {
        public string Name { set; get; }
        public byte Mark { set; get; }

        public Reward(string nameArg, byte markArg)
        {
            this.Name = nameArg;
            this.Mark = markArg;
        }
    }
}

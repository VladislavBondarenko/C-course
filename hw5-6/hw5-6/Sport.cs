using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5_6
{
    class Sport
    {
        public string Name { set; get; }
        private List<Reward> rewards = new List<Reward>();
        public bool IsMaleSport;
        
        public Sport(string nameArg, bool IsMaleSportArg)
        {
            this.Name = nameArg;
            this.IsMaleSport = IsMaleSportArg;
        }

        public byte GetRewardsLength()
        {
            return (byte)this.rewards.Count;
        }

        public bool ExistsReward(string nameArg)
        {
            foreach(Reward reward in this.rewards)
            {
                if (reward.Name == nameArg)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddReward(string nameArg, byte markArg)
        {
            this.rewards.Add(new Reward(nameArg, markArg));
        }

        public double GetAvgAllMarks()
        {
            if (this.rewards.Count != 0)
            {
                return (double)(this.GetSumMarks()) / this.rewards.Count;
            }
            return 0;
        }

        public int GetSumMarks()
        {
            int result = 0;
            foreach (Reward reward in this.rewards)
            {
                result += reward.Mark;
            }
            return result;
        }
    }
}

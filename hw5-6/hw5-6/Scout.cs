using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5_6
{
    class Scout
    {
        public string Name { set; get; }
        protected List<Sport> sports = new List<Sport>();

        public Scout(string nameArg)
        {
            this.Name = nameArg;
        }

        public int GetSportsLength()
        {
            return this.sports.Count;
        }

        public void ShowAllSports()
        {
            for (int i = 0; i < this.sports.Count; i++)
            {
                Console.WriteLine("{0}. {1}", i + 1, this.sports[i].Name);
            }
        }

        public bool ExistSport(string nameArg)
        {
            foreach(Sport sport in this.sports)
            {
                if (sport.Name == nameArg)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddSport(Sport sportArg)
        {
            this.sports.Add(sportArg);
        }

        public void RemoveSport(int number)
        {
            this.sports.Remove(this.sports[number]);
        }

        public bool AddReward(byte numberSport, string nameArg, byte markArg)
        {
            if (this.sports[numberSport].ExistsReward(nameArg))
            {
                return false;
            }
            this.sports[numberSport].AddReward(nameArg, markArg);
            return true;
        }

        public double GetAvgAllSports()
        {
            if (this.sports.Count != 0)
            {
                return (double)(this.GetSumAllMarks()) / this.sports.Count;
            }
            return 0;
        }

        public byte GetNumberRewards()
        {
            byte result = 0;
            foreach (Sport sport in this.sports)
            {
                result += sport.GetRewardsLength();
            }
            return result;
        }

        public int GetSumAllMarks()
        {
            int result = 0;
            foreach(Sport sport in this.sports)
            {
                result += sport.GetSumMarks();
            }
            return result;
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5_6
{
    class Menu
    {
        private List<Scout> scouts = new List<Scout>();
        private List<Sport> sportsAvailable = new List<Sport>();

        public void AddBoyScout()
        {
            Console.Write("Имя: ");
            string name = Console.ReadLine();
            this.scouts.Add(new BoyScout(name));
            Console.WriteLine("Выполнено");
        }

        public void AddGirlScout()
        {
            Console.Write("Имя: ");
            string name = Console.ReadLine();
            this.scouts.Add(new GirlScout(name));
            Console.WriteLine("Выполнено");
        }

        public void ShowAllScouts()
        {
            if (this.scouts.Count == 0)
            {
                Console.WriteLine("Скаутов в лагере нет");
            }
            else
            {
                for (int i = 0; i < this.scouts.Count; i++)
                {
                    Console.Write("{0}. {1}", i + 1, this.scouts[i].Name);
                    if (this.scouts[i] is BoyScout)
                    {
                        Console.WriteLine(" М");
                    }
                    else
                    {
                        Console.WriteLine(" Ж");
                    }
                }
            }
        }

        public int ShowAllBoyScouts()
        {
            byte i = 0;
            foreach (Scout scout in this.scouts)
            {
                if (scout is BoyScout)
                {
                    Console.WriteLine("{0}. {1} М", i+1, scout.Name);
                    i++;
                }
            }
            if (i == 0)
            {
                Console.WriteLine("Мальчиков скаутов в лагере нет");
            }
            return i;
        }

        public int ShowAllGirlScouts()
        {
            byte i = 1;
            foreach (Scout scout in this.scouts)
            {
                if (scout is GirlScout)
                {
                    Console.WriteLine("{0}. {1} Ж", i, scout.Name);
                    i++;
                }
            }
            if (i == 1)
            {
                Console.WriteLine("Девочек скаутов в лагере нет");
            }
            return i - 1;
        }

        public void ShowAvailableSports()
        {
            for (int i = 0; i < this.sportsAvailable.Count; i++)
            {
                Console.Write("{0}. {1}", i + 1, this.sportsAvailable[i].Name);
                if (this.sportsAvailable[i].IsMaleSport)
                {
                    Console.WriteLine(" М");
                }
                else
                {
                    Console.WriteLine(" Ж");
                }
            }
        }

        public void AddSport()
        {
            this.ShowAvailableSports();
            Console.WriteLine("0. Добавить новый спорт");
            byte numberSport = this.InputNumber("Выберите: ", 0, this.sportsAvailable.Count);
            Sport selectedSport;
            if (numberSport == 0)
            {
                Console.Write("Введите название спорта: ");
                string sportName = Console.ReadLine();
                if (this.ExistAvailableSport(sportName))
                {
                    Console.WriteLine("Данный спорт уже был задан ранее");
                    return;
                }
                else
                {
                    bool IsMaleSport;
                    Console.WriteLine("1. Это спорт для мальчков");
                    Console.WriteLine("2. Этот спорт для девочек");
                    byte point = this.InputNumber("Выберите: ", 1, 2);
                    if (point == 1)
                    {
                        IsMaleSport = true;
                    }
                    else
                    {
                        IsMaleSport = false;
                    }
                    selectedSport = new Sport(sportName, IsMaleSport);
                    this.sportsAvailable.Add(selectedSport);
                }
            }
            else
            {
                selectedSport = this.sportsAvailable[numberSport - 1];
            }
            if (this.scouts.Count != 0)
            {
                this.ShowAllScouts();
                byte numberScout;
                Scout selectedScout;
                numberScout = this.InputNumber("Выберите скаута: ", 1, this.scouts.Count);
                selectedScout = this.scouts[numberScout - 1];
                if (selectedSport.IsMaleSport)
                {
                    if (selectedScout is BoyScout)
                    {
                        selectedScout.AddSport(selectedSport);
                        Console.WriteLine("Выполнено");
                    }
                    else
                    {
                        Console.WriteLine("Это спорт для мальчиков, его нельзя добавить девочке скауту");
                    }
                }
                else
                {
                    if (selectedScout is GirlScout)
                    {
                        selectedScout.AddSport(selectedSport);
                        Console.WriteLine("Выполнено");
                    }
                    else
                    {
                        Console.WriteLine("Это спорт для девочек, его нельзя добавить мальчику скауту");
                    }
                }
            }
            else
            {
                Console.WriteLine("Нет скаутов для добавления спорта");
            }
        }

        public bool ExistAvailableSport(string nameArg)
        {
            foreach (Sport sport in this.sportsAvailable)
            {
                if (sport.Name == nameArg)
                {
                    return true;
                }
            }
            return false;
        }

        public void AddReward()
        {
            this.ShowAllScouts();
            if (this.scouts.Count != 0)
            {
                byte numberScout = this.InputNumber("Выберите скаута: ", 1, this.scouts.Count);
                if (this.scouts[numberScout - 1].GetSportsLength() != 0)
                {
                    this.scouts[numberScout - 1].ShowAllSports();
                    byte numberSport = this.InputNumber("Выберите спорт: ", 1, this.scouts[numberScout - 1].GetSportsLength());
                    Console.Write("Награда: ");
                    string reward = Console.ReadLine();
                    Console.Write("Оценка: ");
                    byte mark = this.InputNumber("Оценка (0-100): ", 0, 100);
                    bool result = this.scouts[numberScout - 1].AddReward((byte)(numberSport - 1), reward, mark);
                    if (result)
                    {
                        Console.WriteLine("Выполнено");
                    }
                    else
                    {
                        Console.WriteLine("Данная награда уже была задана ранее");
                    }
                } else
                {
                    Console.WriteLine("Нет спорта для добавления награды");
                }
            }
        }

        public void DeleteSport()
        {
            this.ShowAllScouts();
            if (this.scouts.Count != 0)
            {
                byte numberScout = InputNumber("Выберите скаута: ", 1, this.scouts.Count);
                if (this.scouts[numberScout - 1].GetSportsLength() != 0)
                {
                    this.scouts[numberScout - 1].ShowAllSports();
                    byte numberSport = InputNumber("Выберите спорт: ", 1, this.scouts[numberScout - 1].GetSportsLength());
                    this.scouts[numberSport - 1].RemoveSport(numberSport - 1);
                    Console.WriteLine("Выполнено");
                }
                else
                {
                    Console.WriteLine("Удалять нечего");
                }
            }
        }

        public void CalcAvgMarkScout()
        {
            Console.WriteLine("Выберите скаута: ");
            this.ShowAllScouts();
            if (this.scouts.Count != 0)
            {
                byte numberScout = this.InputNumber("Выберите скаута: ", 1, this.scouts.Count);
                Console.WriteLine("Средний балл у скаута = " + this.scouts[numberScout - 1].GetAvgAllSports());
            }
        }

        public double GetAvgMarkAllScouts()
        {
            double result = 0;
            foreach(Scout scout in this.scouts)
            {
                result += scout.GetAvgAllSports();
            }
            return result;
        }

        public void ShowAllCalc()
        {
            Scout bestBoyScout = new BoyScout("отсутствует");
            Scout smashBoyScout = bestBoyScout;
            Scout activeBoyScout = bestBoyScout;
            Scout lazyBoyScout = bestBoyScout;
            Scout bestGirlScout = new GirlScout("отсутствует");
            Scout smashGirlScout = bestGirlScout;
            Scout activeGirlScout = bestGirlScout;
            Scout lazyGirlScout = bestGirlScout;

            foreach(Scout scout in this.scouts)
            {
                if (scout is BoyScout)
                {
                    lazyBoyScout = scout;
                    break;
                }
            }

            foreach (Scout scout in this.scouts)
            {
                if (scout is GirlScout)
                {
                    lazyGirlScout = scout;
                    break;
                }
            }

            foreach (Scout scout in this.scouts)
            {
                if(scout is BoyScout)
                {
                    if (scout.GetAvgAllSports() >= bestBoyScout.GetAvgAllSports())
                    {
                        bestBoyScout = scout;
                    }
                    if (scout.GetSumAllMarks() >= smashBoyScout.GetSumAllMarks())
                    {
                        smashBoyScout = scout;
                    }
                    if (scout.GetNumberRewards() >= activeBoyScout.GetNumberRewards())
                    {
                        activeBoyScout = scout;
                    }
                    if (scout.GetNumberRewards() <= lazyBoyScout.GetNumberRewards())
                    {
                        lazyBoyScout = scout;
                    }
                } else
                {
                    if (scout.GetAvgAllSports() >= bestGirlScout.GetAvgAllSports())
                    {
                        bestGirlScout = scout;
                    }
                    if (scout.GetSumAllMarks() >= smashGirlScout.GetSumAllMarks())
                    {
                        smashGirlScout = scout;
                    }
                    if (scout.GetNumberRewards() >= activeGirlScout.GetNumberRewards())
                    {
                        activeGirlScout = scout;
                    }
                    if (scout.GetNumberRewards() <= lazyGirlScout.GetNumberRewards())
                    {
                        lazyGirlScout = scout;
                    }
                }
            }

            Console.WriteLine("Средний балл лагеря = " + this.GetAvgMarkAllScouts());
            Console.WriteLine("Лучший скаут мальчик - {0}, его средний балл = {1}", 
                bestBoyScout.Name, 
                bestBoyScout.GetAvgAllSports());
            Console.WriteLine("Лучшая скаут девочка - {0}, ее средний балл = {1}",
                bestGirlScout.Name,
                bestGirlScout.GetAvgAllSports());
            Console.WriteLine("Самый успешный скаут мальчик - {0}, его сумма баллов = {1}",
                smashBoyScout.Name,
                smashBoyScout.GetSumAllMarks());
            Console.WriteLine("Самая успешная скаут девочка - {0}, ее сумма баллов = {1}",
                smashGirlScout.Name,
                smashGirlScout.GetSumAllMarks());
            Console.WriteLine("Самый активный скаут мальчик - {0}, количество его наград = {1}",
                activeBoyScout.Name,
                activeBoyScout.GetNumberRewards());
            Console.WriteLine("Самая активная скаут девочка - {0}, количество ее наград = {1}",
                activeGirlScout.Name,
                activeGirlScout.GetNumberRewards());
            Console.WriteLine("Самый ленивый скаут мальчик - {0}, количество его наград = {1}",
                lazyBoyScout.Name,
                lazyBoyScout.GetNumberRewards());
            Console.WriteLine("Самая ленивая скаут девочка - {0}, количество ее наград = {1}",
                lazyGirlScout.Name,
                lazyGirlScout.GetNumberRewards());
        }

        public byte InputNumber(string field, int min, int max)
        {
            byte result;
            while (true)
            {
                Console.Write(field);
                string buf = Console.ReadLine();
                if (Byte.TryParse(buf, out result) && (result <= max) && (result >= min) )
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Некорректное значение. Попробуйте еще раз");
                }
            }
        }
    }
}

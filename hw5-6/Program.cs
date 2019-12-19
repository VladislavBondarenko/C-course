using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw5_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            byte point;
            bool cont = true;
            while (cont)
            {
                Console.Clear();
                Console.WriteLine("Лагерь скаутов\n");
                Console.WriteLine("1. Добавить скаута мальчика");
                Console.WriteLine("2. Добавить скаута девочку");
                Console.WriteLine("3. Добавить скауту спорт");
                Console.WriteLine("4. Удалить у скаута спорт");
                Console.WriteLine("5. Добавить скауту награду");
                Console.WriteLine("6. Показать всех скаутов");
                Console.WriteLine("7. Показать всех скаутов мальчиков");
                Console.WriteLine("8. Показать всех скаутов девочек");
                Console.WriteLine("9. Расчитать средний балл скаута");
                Console.WriteLine("10. Показать другие расчеты");
                Console.WriteLine("0. Выйти");
                Console.WriteLine();

                point = menu.InputNumber("Пункт: ", 0, 10);
                Console.WriteLine();
                switch (point)
                {
                    case 1: menu.AddBoyScout();
                        Console.ReadKey();
                        break;
                    case 2: menu.AddGirlScout();
                        Console.ReadKey();
                        break;
                    case 3: menu.AddSport();
                        Console.ReadKey();
                        break;
                    case 4: menu.DeleteSport();
                        Console.ReadKey();
                        break;
                    case 5: menu.AddReward();
                        Console.ReadKey();
                        break;
                    case 6: menu.ShowAllScouts();
                        Console.ReadKey();
                        break;
                    case 7: menu.ShowAllBoyScouts();
                        Console.ReadKey();
                        break;
                    case 8: menu.ShowAllGirlScouts();
                        Console.ReadKey();
                        break;
                    case 9: menu.CalcAvgMarkScout();
                        Console.ReadKey();
                        break;
                    case 10: menu.ShowAllCalc();
                        Console.ReadKey();
                        break;
                    case 0: cont = false;
                        break;
                }
            }
        }
    }
}

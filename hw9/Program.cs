using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw9
{
    class Program
    {
        static void Main(string[] args)
        {
            string phrase = Console.ReadLine();
            Console.WriteLine();
            Bot bot = phrase.GetBot();

            bot.Greet();
            bot.AskWho();
            Console.WriteLine();

            phrase = Console.ReadLine();
            Console.WriteLine();
            bot = phrase.GetBot();

            bot.AnswerAboutMyself();
            bot.AskHowAreYou();
            Console.WriteLine();

            phrase = Console.ReadLine();
            Console.WriteLine();
            bot = phrase.GetBot();

            bot.SayGood();
            Console.WriteLine();

            phrase = Console.ReadLine();
            Console.WriteLine();
            bot = phrase.GetBot();

            bot.SayNotUnderstood();
            bot.SayGoodbye();

            Console.ReadLine();
        }
    }
}

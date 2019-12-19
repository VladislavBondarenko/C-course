using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw9
{
    class American : Bot
    {
        public American(string name)
        {
            this.Name = name;
        }
        public override void Greet()
        {
            Console.WriteLine("Hi");
        }
        public override void SayGoodbye()
        {
            Console.WriteLine("Goodbye");
        }
        public override void AskHowAreYou()
        {
            Console.WriteLine("How are you?");
        }
        public override void SayNotUnderstood()
        {
            Console.WriteLine("I do not understand you");
        }
        public override void AskWho()
        {
            Console.WriteLine("Who are you?");
        }
        public override void AnswerAboutMyself()
        {
            Console.WriteLine("I am a bot, I can talk to you in your language");
        }
        public override void SayGood()
        {
            Console.WriteLine("Good");
        }
    }
}

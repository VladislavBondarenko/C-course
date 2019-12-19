using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw9
{
    class Ukrainian : Bot
    {
        public Ukrainian(string name)
        {
            this.Name = name;
        }
        public override void Greet()
        {
            Console.WriteLine("Привiт");
        }
        public override void SayGoodbye()
        {
            Console.WriteLine("Бувай");
        }
        public override void AskHowAreYou()
        {
            Console.WriteLine("Як справи?");
        }
        public override void SayNotUnderstood()
        {
            Console.WriteLine("Я тебе не розумiю");
        }
        public override void AskWho()
        {
            Console.WriteLine("Ты хто?");
        }
        public override void AnswerAboutMyself()
        {
            Console.WriteLine("А я бот, я вмiю розмовляти з тобою на твоїй мовi");
        }
        public override void SayGood()
        {
            Console.WriteLine("Добре");
        }
    }
}

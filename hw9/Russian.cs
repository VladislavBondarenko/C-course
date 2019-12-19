using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw9
{
    class Russian : Bot
    {
        public Russian(string name)
        {
            this.Name = name;
        }
        public override void Greet()
        {
            Console.WriteLine("Привет");
        }
        public override void SayGoodbye()
        {
            Console.WriteLine("Пока");
        }
        public override void AskHowAreYou()
        {
            Console.WriteLine("Как твои дела?");
        }
        public override void SayNotUnderstood()
        {
            Console.WriteLine("Я тебя не понимаю");
        }
        public override void AskWho()
        {
            Console.WriteLine("Ты кто?");
        }
        public override void AnswerAboutMyself()
        {
            Console.WriteLine("А я бот, я умею разговаривать с тобой на твоем языке");
        }
        public override void SayGood()
        {
            Console.WriteLine("Хорошо");
        }
    }
}

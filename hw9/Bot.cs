using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw9
{
    abstract class Bot
    {
        public string Name { set; get; }

        abstract public void Greet();
        abstract public void SayGoodbye();
        abstract public void AskHowAreYou();
        abstract public void SayNotUnderstood();
        abstract public void AskWho();
        abstract public void AnswerAboutMyself();
        abstract public void SayGood();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw9
{
    static class Tools
    {
        static private lang CheckLanguage(this string text)
        {
            text = text.ToLower();

            int engCount = text.Count(c => (c >= 'a' && c <= 'z'));
            int rusCount = text.Count(c => (c >= 'а' && c <= 'я'));
            int ukrCount = text.Count(c => ((c == '?' || c == 'є' || c == 'ї') ||
                ((c >= 'а' && c <= 'я') && (c != 'ы' && c != 'ъ' && c != 'э'))));

            return (rusCount > engCount ?
                (rusCount >= ukrCount ? lang.rus : lang.ukr) :
                (engCount > ukrCount ? lang.eng : lang.ukr));
        }

        public static Bot GetBot(this string phrase)
        {
            lang language = phrase.CheckLanguage();
            switch (language)
            {
                case lang.rus: return new Russian("russian");
                case lang.ukr: return new Ukrainian("ukrainian");
                case lang.eng: return new American("american");
                default: return null;
            }
        }

        enum lang
        {
            rus,
            ukr,
            eng
        }
    }
}

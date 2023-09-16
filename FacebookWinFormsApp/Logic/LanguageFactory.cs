using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Logic
{
    static internal class LanguageFactory
    {
        static internal ILanguageStrategy Create(string i_Language)
        {
            ILanguageStrategy languageStrategy;

            if(i_Language == "en-US")
            {
                languageStrategy = new EnglishStrategy();
            }
            else if(i_Language == "he-IL")
            {
                languageStrategy = new HebrewStrategy();
            }
            else
            {
                languageStrategy = new EnglishStrategy(); //Default
            }

            return languageStrategy;
        }
    }
}

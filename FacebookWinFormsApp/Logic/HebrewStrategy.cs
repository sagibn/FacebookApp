using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Logic
{
    class HebrewStrategy : ILanguageStrategy
    {
        public string Execute()
        {
            return "he-IL";
        }
    }
}

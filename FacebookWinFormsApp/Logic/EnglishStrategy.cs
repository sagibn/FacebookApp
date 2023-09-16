using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Logic
{
    class EnglishStrategy : ILanguageStrategy
    {
        public string Execute()
        {
            return "en-US";
        }
    }
}

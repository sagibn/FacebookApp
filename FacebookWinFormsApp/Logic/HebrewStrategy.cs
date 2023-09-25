using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Logic
{
    class HebrewStrategy : ILanguageStrategy
    {
        public KeyValuePair<string, ContentAlignment> Execute()
        {
            return new KeyValuePair<string, ContentAlignment>("he-IL", ContentAlignment.TopRight);
        }
    }
}

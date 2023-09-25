using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Logic
{
    class EnglishStrategy : ILanguageStrategy
    {
        public KeyValuePair<string, ContentAlignment> Execute()
        {
            return new KeyValuePair<string, ContentAlignment>("en-US",ContentAlignment.TopLeft);
        }
    }
}

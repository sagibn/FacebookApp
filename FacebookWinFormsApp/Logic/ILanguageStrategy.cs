using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Logic
{
    internal interface ILanguageStrategy
    {
        KeyValuePair<string, ContentAlignment> Execute();
    }
}

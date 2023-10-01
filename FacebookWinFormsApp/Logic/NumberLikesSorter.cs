using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Logic
{
    public class NumberLikesSorter : NameSorter
    {
        public NumberLikesSorter() : base()
        {
        }

        protected override bool elementSelected(PageProxy i_Item1, PageProxy i_Item2)
        {
            return i_Item1.LikesCount > i_Item2.LikesCount;
        }
    }
}

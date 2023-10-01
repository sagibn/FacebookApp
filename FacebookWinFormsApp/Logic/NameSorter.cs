using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures.Logic
{
    public class NameSorter
    {
        public NameSorter()
        {
        }

        protected virtual bool elementSelected(PageProxy i_Item1, PageProxy i_Item2)
        {
            return string.Compare(i_Item1.Name, i_Item2.Name) <= 0;
        }

        internal FacebookObjectCollection<PageProxy> MergeSort(FacebookObjectCollection<PageProxy> i_Unsorted)
        {
            if (i_Unsorted.Count <= 1)
            {
                return i_Unsorted;
            }

            FacebookObjectCollection<PageProxy> left = new FacebookObjectCollection<PageProxy>();
            FacebookObjectCollection<PageProxy> right = new FacebookObjectCollection<PageProxy>();
            int middle = i_Unsorted.Count / 2;

            for (int i = 0; i < middle; i++)  
            {
                left.Add(i_Unsorted[i]);
            }
            for (int i = middle; i < i_Unsorted.Count; i++)
            {
                right.Add(i_Unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return merge(left, right);
        }

        private FacebookObjectCollection<PageProxy> merge(FacebookObjectCollection<PageProxy> i_Left, FacebookObjectCollection<PageProxy> i_Right)
        {
            FacebookObjectCollection<PageProxy> result = new FacebookObjectCollection<PageProxy>();

            while (i_Left.Count > 0 || i_Right.Count > 0)
            {
                if (i_Left.Count > 0 && i_Right.Count > 0)
                {
                    if (elementSelected(i_Left[0], i_Right[0]))
                    {
                        result.Add(i_Left[0]);
                        i_Left.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(i_Right[0]);
                        i_Right.RemoveAt(0);
                    }
                }
                else if (i_Left.Count > 0)
                {
                    result.Add(i_Left[0]);
                    i_Left.RemoveAt(0);
                }
                else if (i_Right.Count > 0)
                {
                    result.Add(i_Right[0]);
                    i_Right.RemoveAt(0);
                }
            }
            return result;
        }
    }
}

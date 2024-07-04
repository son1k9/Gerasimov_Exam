using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    public static class Sort
    {
        public static void QuickSort<T>(T[] array, int l, int r, Comparer<T> comparer)
        {
            if (l >= r)
            {
                return;
            }

            int pivot = Partion(array, l, r, comparer);
            QuickSort(array, l, pivot, comparer);
            QuickSort(array, pivot + 1, r, comparer);
        }

        private static int Partion<T>(T[] array, int l, int r, Comparer<T> comparer)
        {
            T pivot = array[l + (r - l) / 2];

            int i = l;
            int j = r;
            while (true)
            {
                while(comparer.Compare(array[i], pivot) < 0)
                {
                    i++;
                }

                while(comparer.Compare(array[j], pivot) > 0)
                {
                    j--;
                }

                if (i >= j)
                {
                    return j;
                }

                (array[i], array[j]) = (array[j], array[i]);
                i++;
                j--;
            }
        }
    }
}

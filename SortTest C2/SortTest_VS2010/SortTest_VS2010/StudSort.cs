using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

#if VALUE_IS_DOUBLE
	using ValueType = System.Double;
#else
#if VALUE_IS_SHORT
	using ValueType = System.Int16;
#else
#if VALUE_IS_LONG
	using ValueType = System.Int64;
#else
using ValueType = System.Int32;
#endif
#endif
#endif

namespace SortTest
{
    class StudSort
    {
        // You may add more method(s) here, if needed 
        // (f.e., for recursive quicksort or recursive mergesort)

        public static ValueType[] Sort(ValueType[] data) // DON'T CHANGE this line!!!
        {
            ValueType temp = 0;
            bool swapped = true;
            int start = 0;
            int end = data.Length - 1;

            while (swapped)
            {
                swapped = false;

                // Прохід вправо
                for (int i = start; i < end; ++i)
                {
                    if (data[i + 1] < data[i])
                    {
                        temp = data[i + 1];
                        data[i + 1] = data[i];
                        data[i] = temp;
                        swapped = true;
                    }
                }

                // Якщо не було обмінів, завершуємо
                if (!swapped)
                break;

                swapped = false;
                end--;

                // Прохід вліво
                for (int i = end - 1; i >= start; --i)
                {
                    if (data[i + 1] < data[i])
                    {
                        temp = data[i + 1];
                        data[i + 1] = data[i];
                        data[i] = temp;
                        swapped = true;
                    }
                }

                start++;
            }
            // Add code which actually sorts.
            // Use int type for indice and ValueType for values in array.
            // If you change ValueType[] data (it IS allowed andf weakly recommended), 
            // just leave "return data" as is.
            // If you create another array with sorted data, change "return data" with returning of that new array
            return data;
        }
    }
}

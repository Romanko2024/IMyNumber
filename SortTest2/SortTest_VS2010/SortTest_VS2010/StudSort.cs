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
            
                
            for (int i = 0; i < data.Length - 1; ++i)
             {
                bool localSwapped = false;
                for (int j = 0; j < data.Length - i - 1; ++j)
                {
                    if(data[j + 1] < data[j])
                    {
                        temp = data[j + 1];
                        data[j + 1] = data[j];
                        data[j] = temp;
                        localSwapped = true;

                    }
                } 
                if (!localSwapped)
                        {
                        break;
                        }
                
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

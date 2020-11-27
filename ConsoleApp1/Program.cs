using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string [ ] args)
        {
            int[] arr1 = new int[]{1,3};
            int[] arr2 = new int[]{2};
          double result =  FindMedianSortedArrays( arr2, arr2 );
            Console.WriteLine(result);
        }
        public static double FindMedianSortedArrays(int [ ] nums1, int [ ] nums2)
        {
            for ( int i = 0; i < length; i++ )
            {

            }
            return ( nums1.Skip(1).Sum() + nums2.SkipLast(1).Sum() / 2));
        }
    }
}

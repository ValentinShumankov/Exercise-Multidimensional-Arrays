using System;
using System.Linq;

namespace Maximal_Sum
{
    class Program
    {
        static void Main(string [ ] args)
        {
            int[] size = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int row1 = size[0];
            int col1 = size[1];
            int[,] matrix = new int[row1,col1];
            for ( int rowSize = 0; rowSize < matrix.GetLength( 0 ); rowSize++ )
            {
                int[] Row = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for ( int colSize = 0; colSize < Row.Length; colSize++ )
                {
                    matrix [ rowSize, colSize ] = Row [ colSize ];
                }
            }
            int a,b,c,d,e,f,g,h,i;
            int aa = 0; int bb = 0;
            int cc = 0; int dd = 0;
            int ee = 0; int ff = 0;
            int gg = 0; int hh = 0;
            int ii = 0;
            int bestSum = int.MinValue;
            int row = 0;
            int col = 0;

            for ( row = 0; row <= matrix.GetLength( 0 ) - 3; row++ )
            {
                for ( col = 0; col <= matrix.GetLength( 1 ) - 3; col++ )
                { 
                    a = matrix [ row, col ];
                    b = matrix [ row, col + 1 ];
                    c = matrix [ row, col + 2 ];

                    d = matrix [ row + 1, col ];
                    e = matrix [ row + 1, col + 1 ];
                    f = matrix [ row + 1, col + 2 ];

                    g = matrix [ row + 2, col ];
                    h = matrix [ row + 2, col + 1 ];
                    i = matrix [ row + 2, col + 2 ];
                    int[] chars = new int[]{a,b,c,d,e,f,g,h,i};
                    if ( chars.Sum( ) > bestSum )
                    {
                        bestSum = chars.Sum( );
                        aa = a; bb = b;
                        cc = c; dd = d;
                        ee = e; ff = f;
                        gg = g; hh = h;
                        ii = i;
                    }
                }
            }
            Console.WriteLine( $"Sum = {bestSum}" );
            Console.WriteLine( $"{aa} {bb} {cc}" );
            Console.WriteLine( $"{dd} {ee} {ff}" );
            Console.WriteLine( $"{gg} {hh} {ii}" );
        }
    }
}

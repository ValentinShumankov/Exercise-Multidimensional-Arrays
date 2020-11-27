using System;
using System.Linq;

namespace Diagonal_Difference
{
    class Program
    {
        static void Main(string [ ] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] cube = new int[size,size];
            for ( int row = 0; row < cube.GetLength(0); row++ )
            {
                var curRow = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for ( int col = 0; col < cube.GetLength(1); col++ )
                {
                    cube [ row, col ] = curRow [ col ];
                }
            }
            int primariDiagonal = 0;
            int secondaryDiagonal = 0;
            int secondaryCounter = cube.GetLength(0) - 1;
            for ( int i = 0; i < cube.GetLength(0); i++ )
            {
                primariDiagonal += cube [ i, i ];
                secondaryDiagonal += cube [ i, secondaryCounter ];
                secondaryCounter--;
            }
            
            int result = Math.Abs(primariDiagonal - secondaryDiagonal);
            Console.WriteLine(result);
        }
    }
}

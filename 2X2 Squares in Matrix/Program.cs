using System;
using System.Linq;

namespace _2X2_Squares_in_Matrix
{
    class Program
    {
        static void Main(string [ ] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int row = size[0];
            int col = size[1];
            char[,] matrix = new char[row,col];
            for ( int rowSize = 0; rowSize < matrix.GetLength( 0 ); rowSize++ )
            {
                string[] curRow = Console.ReadLine().Split().ToArray();
                for ( int colSize = 0; colSize < matrix.GetLength( 1 ); colSize++ )
                {
                    matrix [ rowSize, colSize ] = char.Parse( curRow [ colSize ] );
                }
            }
            int cellCounter = 0;
            for ( int curRow = 0; curRow < matrix.GetLength( 0 ) - 1; curRow++ )
            {
                for ( int curCol = 0; curCol < matrix.GetLength( 1 ) - 1; curCol++ )
                {
                    char a = matrix[curRow,curCol];
                    char b = matrix [ curRow, curCol + 1 ];
                    char c =  matrix [ curRow + 1, curCol ];
                    char d = matrix [ curRow + 1, curCol + 1 ];
                    var chars = new char[]{a,b,c,d };
                    bool fail = false;
                    for ( int i = 0; i < chars.Length; i++ )
                    {
                        if ( chars [ i ] != a )
                        {
                            fail = true;
                        }
                    }
                    if ( fail == false )
                    {
                        cellCounter++;
                    }
                }
            }
            Console.WriteLine( cellCounter );
        }
    }
}

//2X2 Squares in Matrix
//Find the count of 2 x 2 squares of equal chars in a matrix.
//Input
//On the first line, you are given the integers rows and cols – the matrix’s dimensions
//Matrix characters come at the next rows lines (space separated)
//Output
//Print the number of all the squares matrixes you have found
//Examples
//Input
//Output
//Comments
//3 4
//A B B D
//E B B B
//I J B B
//2
//Two 2 x 2 squares of equal cells:
//A B B D	A B B D
//E B B B	E B B B
//I J B B	I J B B
//2 2
//a b
//c d
//0
//No 2 x 2 squares of equal cells exist.

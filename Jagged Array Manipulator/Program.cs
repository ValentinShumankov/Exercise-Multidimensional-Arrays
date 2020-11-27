using System;
using System.Linq;

namespace Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string [ ] args)
        {
            double[][] array = new double[int.Parse(Console.ReadLine())][];
            for ( int i = 0; i < array.Length; i++ )
            {
                var curArr = Console.ReadLine( ).Split( ).Select( double.Parse ).ToArray( ) ;
                array [ i ] = new double [ curArr.Length ];
                for ( int k = 0; k < curArr.Length; k++ )
                {
                    array [ i ] [ k ] = curArr [ k ];
                }
            }

            for ( int i = 0; i < array.GetLength( 0 ) - 1; i++ )
            {
                if ( array [ i ].Length == array [ i + 1 ].Length )
                {
                    for ( int k = i; k <= i + 1; k++ )
                    {
                        for ( int h = 0; h < array[k].Length; h++ )
                        {
                            array [ k ] [ h ] *= 2;
                        }
                    }
                }
                else
                {
                    for ( int k = i; k <= i + 1; k++ )
                    {
                        for ( int h = 0; h < array [ k ].Length; h++ )
                        {
                            array [ k ] [ h ] /= 2;
                        }
                    }
                }
            }

            string input = string.Empty;
            while ( (input = Console.ReadLine()) != "End" )
            {
                var curComm = input.Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                int x = int.Parse(curComm[1]);
                int y = int.Parse(curComm[2]);
                int value = int.Parse(curComm[3]);
                if ( x >= 0 && y >= 0 && x < array.GetLength(0) )
                {
                    if ( y < array[x].Length )
                    {
                        switch ( curComm [ 0 ] )
                        {
                            case "Add":
                                array [ x ] [ y ] += value;
                                break;
                            case "Subtract":
                                array [ x ] [ y ] -= value;
                                break;
                        }
                    }
                }
            }

            foreach ( var item in array )
            {
                Console.WriteLine(string.Join(" ",item));
            }
        }
    }
}

//Jagged Array Manipulator
//Create a program that populates, analyzes and manipulates the elements 
//of a matrix with unequal length of its rows.
//First you will receive an integer N equal to the number of rows in your matrix.
//On the next N lines, you will receive sequences of integers, 
//separated by a single space. Each sequence is a row in the matrix.
//After populating the matrix, start analyzing it. If a row and 
//the one below it have equal length, multiply each element in both of them by 2, otherwise - divide by 2.
//Then, you will receive commands. There are three possible commands:
//"Add {row} {column} {value}" - add { value}
//to the element at the given indexes, if they are valid
//"Subtract {row} {column} {value}" - subtract {value} from the
//                                                     element at the given indexes, if they are valid
//"End" - print the final state of the matrix (all elements separated by a single space)
//    and stop the program
//Input
//On the first line, you will receive the number of rows of the matrix - integer N
//On the next N lines, you will receive each row - sequence of integers, 
//separated by a single space
//{value} will always be integer number
//Then you will be receiving commands until reading "End"
//Output
//The output should be printed on the console and it should consist of N lines
//Each line should contain a string representing the respective row of the final matrix,
//elements separated by a single space
//Constraints
//The number of rows N of the matrix will be integer in the range [2 … 12]
//The input will always follow the format above
//Think about data types

//Examples

//Input
//5
//10 20 30
//1 2 3
//2
//2
//10 10
//End
//Output
//20 40 60
//1 2 3
//2
//2
//5 5 

//Input
//5
//10 20 30
//1 2 3
//2
//2
//10 10
//Add 0 10 10
//Add 0 0 10
//Subtract -3 0 10
//Subtract 3 0 10
//End
//Output
//30 40 60
//1 2 3
//2
//-8
//5 5

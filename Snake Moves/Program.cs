using System;
using System.Collections.Generic;
using System.Linq;

namespace Snake_Moves
{
    class Program
    {
        static void Main(string [ ] args)
        {
            int[] stairsSize = Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries )
                .Select(int.Parse)
                .ToArray();
            int[,] stairs = new int[stairsSize[0],stairsSize[1]];
            Queue<char> snake = new Queue<char>(Console.ReadLine().ToCharArray());
            for ( int row = 0; row < stairs.GetLength( 0 ); row++ )
            {
                string curStep = string.Empty; 
                for ( int col = 0; col < stairs.GetLength( 1 ); col++ )
                {
                    var curSnakePart = snake.Peek();
                    stairs [ row, col ] = curSnakePart;
                    snake.Enqueue( snake.Dequeue( ) );
                    curStep +=  (char)stairs [ row, col ] ;
                }
                if ( row % 2 == 0 )
                {
                    Console.WriteLine(curStep);
                }
                else
                {
                    Console.WriteLine(string.Join("", curStep.ToCharArray( ).Reverse( ) ) );
                }
            }
           
        }
    }
}

//Snake Moves
//You are walking in the park and you encounter a snake! You are terrified,
//and you start running zig-zag, so the snake starts following you. 
//You have a task to visualize the snake’s path in a square form. 
//A snake is represented by a string. 
//The isle is a rectangular matrix of size NxM. 
//A snake starts going down from the top-left corner and slithers its way down. 
//    The first cell is filled with the first symbol of the snake,
//the second cell is filled with the second symbol, etc.
//    The snake is as long as it takes in order to fill the stairs completely – if you reach the end of the string representing the snake,
//    start again at the beginning. After you fill the matrix with the snake’s path, you should print it.
//Input
//The input data should be read from the console. It consists of exactly two lines
//On the first line, you’ll receive the dimensions of the stairs in format: "N M", where N is the number of rows, and M is the number of columns. 
//They’ll be separated by a single space
//On the second line you’ll receive the string representing the snake
//Output
//The output should be printed on the console. It should consist of N lines
//Each line should contain a string representing the respective row of the matrix
//Constraints
//The dimensions N and M of the matrix will be integers in the range [1 … 12]
//The snake will be a string with length in the range [1 … 20] and will not contain any whitespace characters
//Examples

//Input
//5 6
//SoftUni

//Output
//SoftUn
//UtfoSi
//niSoft
//foSinU
//tUniSo

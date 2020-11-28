using System;
using System.Collections.Generic;

namespace _02._Knight_Game
{
    internal class Program
    {
        private static void Main(string [ ] args)
        {
            var size = int.Parse(Console.ReadLine());

            var manipulatedBoard = new char[size][];

            for ( int i = 0; i < size; i++ )
            {
                manipulatedBoard [ i ] = Console.ReadLine( ).Trim( ).ToCharArray( );
            }

            var counter = 0;

            while ( true )
            {
                var conflict = false;
                var mostDangerous = 0;
                var location = new KeyValuePair<int, int>();

                for ( int i = 0; i < size; i++ )
                {
                    for ( int j = 0; j < size; j++ )
                    {
                        var currentEnemies = 0;
                        if ( manipulatedBoard [ i ] [ j ].Equals( '0' ) )
                        {
                            continue;
                        }

                        try
                        {
                            if ( manipulatedBoard [ i - 2 ] [ j - 1 ].Equals( 'K' ) )
                            {
                                currentEnemies++;
                            }
                        }
                        catch ( Exception )
                        {
                            //ignored
                        }

                        try
                        {
                            if ( manipulatedBoard [ i - 2 ] [ j + 1 ].Equals( 'K' ) )
                            {
                                currentEnemies++;
                            }
                        }
                        catch ( Exception )
                        {
                            //ignored
                        }
                        try
                        {
                            if ( manipulatedBoard [ i + 2 ] [ j - 1 ].Equals( 'K' ) )
                            {
                                currentEnemies++;
                            }
                        }
                        catch ( Exception )
                        {
                            //ignored
                        }
                        try
                        {
                            if ( manipulatedBoard [ i + 2 ] [ j + 1 ].Equals( 'K' ) )
                            {
                                currentEnemies++;
                            }
                        }
                        catch ( Exception )
                        {
                            //ignored
                        }
                        try
                        {
                            if ( manipulatedBoard [ i - 1 ] [ j - 2 ].Equals( 'K' ) )
                            {
                                currentEnemies++;
                            }
                        }
                        catch ( Exception )
                        {
                            //ignored
                        }
                        try
                        {
                            if ( manipulatedBoard [ i - 1 ] [ j + 2 ].Equals( 'K' ) )
                            {
                                currentEnemies++;
                            }
                        }
                        catch ( Exception )
                        {
                            //ignored
                        }
                        try
                        {
                            if ( manipulatedBoard [ i + 1 ] [ j - 2 ].Equals( 'K' ) )
                            {
                                currentEnemies++;
                            }
                        }
                        catch ( Exception )
                        {
                            //ignored
                        }
                        try
                        {
                            if ( manipulatedBoard [ i + 1 ] [ j + 2 ].Equals( 'K' ) )
                            {
                                currentEnemies++;
                            }
                        }
                        catch ( Exception )
                        {
                            //ignored
                        }

                        if ( currentEnemies <= mostDangerous )
                        {
                            continue;
                        }

                        mostDangerous = currentEnemies;
                        location = new KeyValuePair<int, int>( i, j );
                    }
                }

                if ( mostDangerous > 0 )
                {
                    conflict = true;
                    manipulatedBoard [ location.Key ] [ location.Value ] = '0';
                }
                if ( !conflict )
                {
                    break;
                }

                counter++;
            }

            Console.WriteLine( counter );
        }
    }
}

/*
 Knight Game
Chess is the oldest game, but it is still popular these days. For this task we will use only one chess piece – the Knight. 
The knight moves to the nearest square but not on the same row, column, or diagonal. (This can be thought of as moving two squares horizontally, then one square vertically, or moving one square horizontally then two squares vertically— i.e. in an "L" pattern.) 
The knight game is played on a board with dimensions N x N and a lot of chess knights 0 <= K <= N2. 
You will receive a board with K for knights and '0' for empty cells. Your task is to remove a minimum of the knights, so there will be no knights left that can attack another knight. 
Input
On the first line, you will receive the N size of the board
On the next N lines, you will receive strings with Ks and 0s.
Output
Print a single integer with the minimum number of knights that needs to be removed
Constraints
Size of the board will be 0 < N < 30
Time limit: 0.3 sec. Memory limit: 16 MB.


Examples
Input
5 
0K0K0
K000K
00K00
K000K 
0K0K0
Output
1
Input
2
KK
KK
OutPut
0

Input
8
0K0KKK00
0K00KKKK
00K0000K
KKKKKK0K
K0K0000K
KK00000K
00K0K000
000K00KK
OutPut
12
 */
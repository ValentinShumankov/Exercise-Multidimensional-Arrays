using System;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string [ ] args)
        {
            int[] sizes = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new char[sizes[0], sizes[1]];
            int currentRow = 0;
            int currentCol = 0;

            for ( int i = 0; i < matrix.GetLength( 0 ); i++ )
            {
                string row = Console.ReadLine();

                for ( int j = 0; j < matrix.GetLength( 1 ); j++ )
                {
                    matrix [ i, j ] = row [ j ];

                    if ( row [ j ] == 'P' )
                    {
                        currentRow = i;
                        currentCol = j;
                    }
                }
            }

            string moves = Console.ReadLine().ToLower();

            foreach ( char direction in moves )
            {
                switch ( direction )
                {
                    case 'u':
                        MoveUp( matrix, currentRow, currentCol );
                        currentRow--;
                        if ( Populate( ref matrix, currentRow, currentCol ) )
                        {
                            Die( matrix, currentRow, currentCol );
                        }
                        break;
                    case 'd':
                        MoveDown( matrix, currentRow, currentCol );
                        currentRow++;
                        if ( Populate( ref matrix, currentRow, currentCol ) )
                        {
                            Die( matrix, currentRow, currentCol );
                        }
                        break;
                    case 'l':
                        MoveLeft( matrix, currentRow, currentCol );
                        currentCol--;
                        if ( Populate( ref matrix, currentRow, currentCol ) )
                        {
                            Die( matrix, currentRow, currentCol );
                        }
                        break;
                    case 'r':
                        MoveRight( matrix, currentRow, currentCol );
                        currentCol++;
                        if ( Populate( ref matrix, currentRow, currentCol ) )
                        {
                            Die( matrix, currentRow, currentCol );
                        }
                        break;
                }
            }
        }

        private static void MoveRight(char [ , ] matrix, int currentRow, int currentCol)
        {
            matrix [ currentRow, currentCol ] = '.';

            if ( currentCol == matrix.GetLength( 1 ) - 1 )
            {
                Populate( ref matrix, currentRow, currentCol );
                Win( matrix, currentRow, currentCol );
            }
            else
            {
                if ( matrix [ currentRow, currentCol + 1 ] == 'B' )
                {
                    Populate( ref matrix, currentRow, currentCol );
                    Die( matrix, currentRow, currentCol + 1 );
                }
                else
                {
                    matrix [ currentRow, currentCol + 1 ] = 'P';
                }
            }
        }

        private static void MoveLeft(char [ , ] matrix, int currentRow, int currentCol)
        {
            matrix [ currentRow, currentCol ] = '.';

            if ( currentCol == 0 )
            {
                Populate( ref matrix, currentRow, currentCol );

                Win( matrix, currentRow, currentCol );
            }
            else
            {
                if ( matrix [ currentRow, currentCol - 1 ] == 'B' )
                {
                    Populate( ref matrix, currentRow, currentCol );

                    Die( matrix, currentRow, currentCol - 1 );
                }
                else
                {
                    matrix [ currentRow, currentCol - 1 ] = 'P';
                }
            }
        }

        private static void MoveDown(char [ , ] matrix, int currentRow, int currentCol)
        {
            matrix [ currentRow, currentCol ] = '.';

            if ( currentRow == matrix.GetLength( 0 ) - 1 )
            {
                Populate( ref matrix, currentRow, currentCol );

                Win( matrix, currentRow, currentCol );
            }
            else
            {
                if ( matrix [ currentRow + 1, currentCol ] == 'B' )
                {
                    Populate( ref matrix, currentRow, currentCol );

                    Die( matrix, currentRow + 1, currentCol );
                }
                else
                {
                    matrix [ currentRow + 1, currentCol ] = 'P';
                }
            }
        }

        private static void MoveUp(char [ , ] matrix, int currentRow, int currentCol)
        {
            matrix [ currentRow, currentCol ] = '.';

            if ( currentRow == 0 )
            {
                Populate( ref matrix, currentRow, currentCol );

                Win( matrix, currentRow, currentCol );
            }
            else
            {
                if ( matrix [ currentRow - 1, currentCol ] == 'B' )
                {
                    Populate( ref matrix, currentRow, currentCol );

                    Die( matrix, currentRow - 1, currentCol );
                }
                else
                {
                    matrix [ currentRow - 1, currentCol ] = 'P';
                }
            }
        }

        private static bool Populate(ref char [ , ] matrix, int currentRow, int currentCol)
        {
            char[,] result = new char[matrix.GetLength(0), matrix.GetLength(1)];
            Array.Copy( matrix, result, matrix.Length );

            for ( int i = 0; i < matrix.GetLength( 0 ); i++ )
            {
                for ( int j = 0; j < matrix.GetLength( 1 ); j++ )
                {
                    if ( i > 0 && matrix [ i, j ] == 'B' )
                    {
                        result [ i - 1, j ] = 'B';
                    }

                    if ( i < matrix.GetLength( 0 ) - 1 && matrix [ i, j ] == 'B' )
                    {
                        result [ i + 1, j ] = 'B';
                    }

                    if ( j > 0 && matrix [ i, j ] == 'B' )
                    {
                        result [ i, j - 1 ] = 'B';
                    }

                    if ( j < matrix.GetLength( 1 ) - 1 && matrix [ i, j ] == 'B' )
                    {
                        result [ i, j + 1 ] = 'B';
                    }
                }
            }

            bool isDead = true;

            for ( int i = 0; i < result.GetLength( 0 ); i++ )
            {
                for ( int j = 0; j < result.GetLength( 1 ); j++ )
                {
                    if ( result [ i, j ] == 'P' )
                    {
                        isDead = false;
                    }
                }
            }

            matrix = result;

            return isDead;
        }

        private static void Die(char [ , ] matrix, int currentRow, int currentCol)
        {
            Print( matrix );
            Console.WriteLine( $"dead: {currentRow} {currentCol}" );
            Environment.Exit( 0 );
        }

        private static void Win(char [ , ] matrix, int currentRow, int currentCol)
        {
            Print( matrix );
            Console.WriteLine( $"won: {currentRow} {currentCol}" );
            Environment.Exit( 0 );
        }

        private static void Print(char [ , ] matrix)
        {
            for ( int i = 0; i < matrix.GetLength( 0 ); i++ )
            {
                for ( int j = 0; j < matrix.GetLength( 1 ); j++ )
                {
                    Console.Write( matrix [ i, j ] );
                }

                Console.WriteLine( );
            }
        }
    }
}



/* 
 10. *Radioactive Mutant Vampire Bunnies
Browsing through GitHub, you come across an old JS Basics teamwork game. It is about very nasty bunnies that multiply extremely fast. There’s also a player that has to escape from their lair. You really like the game, so you decide to port it to C# because that’s your language of choice. The last thing that is left is the algorithm that decides if the player will escape the lair or not.
First, you will receive a line holding integers N and M, which represent the rows and columns in the lair. Then you receive N strings that can only consist of “.”, “B”, “P”. The bunnies are marked with “B”, the player is marked with “P”, and everything else is free space, marked with a dot “.”. They represent the initial state of the lair. There will be only one player. Then you will receive a string with commands such as LLRRUUDD – where each letter represents the next move of the player (Left, Right, Up, Down).
After each step of the player, each of the bunnies spread to the up, down, left and right (neighboring cells marked as “.” changes their value to B). If the player moves to a bunny cell or a bunny reaches the player, the player has died. If the player goes out of the lair without encountering a bunny, the player has won.
When the player dies or wins, the game ends. All the activities for this turn continue (e.g. all the bunnies spread normally), but there are no more turns. There will be no stalemates where the moves of the player end before he dies or escapes.
Finally, print the final state of the lair with every row on a separate line. On the last line, print either “dead: {row} {col}” or “won: {row} {col}”. Row and col are the coordinates of the cell where the player has died or the last cell he has been in before escaping the lair.
Input
On the first line of input, the numbers N and M are received – the number of rows and columns in the lair
On the next N lines, each row is received in the form of a string. The string will contain only “.”, “B”, “P”. All strings will be the same length. There will be only one “P” for all the input
On the last line, the directions are received in the form of a string, containing “R”, “L”, “U”, “D”
Output
On the first N lines, print the final state of the bunny lair
On the last line, print the outcome – “won:” or “dead:” + {row} {col}
Constraints
The dimensions of the lair are in range [3…20]
The directions string length is in range [1…20]
Examples 

Input
5 8
.......B
...B....
....B..B
........
..P.....
ULLL

Output
BBBBBBBB
BBBBBBBB
BBBBBBBB
.BBBBBBB
..BBBBBB
won: 3 0

___________
Input
4 5
.....
.....
.B...
...P.
LLLLLLLL

__________
Output

.B...
BBB..
BBBB.
BBB..
dead: 3 1


 */
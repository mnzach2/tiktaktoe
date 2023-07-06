using System.Data;

namespace tiktaktoe
{
    internal class Program
    {
        static string[,] board = {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };
        static string[,] blankBoard = {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" }
            };
        static void Main(string[] args)
        {
            Console.WriteLine("Player X, please input your first move (1-9)");
            string[] usedMoves = { "0", "0", "0", "0", "0", "0", "0", "0", "0"}; 
            string currentPlayer = "X";
            string input = "";
            bool weHaveWinner = false;
            int turnCount = 0;
            bool noRepeatMoves = true;


            while (input != "Exit")
            {
                while (weHaveWinner == false)
                {
                    DisplayBoard(board);
                    
                    
                    //gets move
                    input = Console.ReadLine();

                    //checks move validity or desire to exit the game
                    if (input == "Exit")
                    {
                        break;
                    }

                    noRepeatMoves = RepeatChecker(input, usedMoves);


                    while (noRepeatMoves == false || input != "1" && input != "2" && input != "3" && input != "4" && input != "5" && input != "6" && input != "7" && input != "8" && input != "9" || input == null)
                    {
                        Console.WriteLine("Please input a valid, non-repeat move (1-9)");
                        input = Console.ReadLine();
                        noRepeatMoves = RepeatChecker(input, usedMoves);
                    }


                    //find place to put move
                    for (int i = 0; i < 3; i++) { 
                        for(int j = 0; j < 3; j++)
                        {
                            if (board[i,j] == input) { board[i, j] = currentPlayer;}
                        }
                    }
                    usedMoves[turnCount] = input;
                    weHaveWinner = Checker(board);
                    if (weHaveWinner == true) { break; }
                    currentPlayer = PlayerTurnSwap(currentPlayer);
                    turnCount++;
                    input = "fuck you";
                    if (turnCount == 9) {break;}
                    Console.Clear();
                    Console.WriteLine("Please input next move");



                }
                //add player who won
                Console.Clear() ;
                DisplayBoard(board);
                if (weHaveWinner){ Console.WriteLine($"We have a winner! Player {currentPlayer}!\nPress any key to start a new game or type \"Exit\" to quit!)");}
                else { Console.WriteLine("Tie game!");}
                Console.ReadLine();

                Console.WriteLine("\n\n\n\n");

                board = blankBoard;
                currentPlayer = "X";
                weHaveWinner = false;
                turnCount = 0;
                Console.Clear();
                Console.WriteLine("Player X, please input your first move (1-9)");

            }
            Console.WriteLine("Cya nerd");
            Console.ReadLine();


        }

        public static string PlayerTurnSwap(string currentPlayer)
        {
            if (currentPlayer == "X") { return "O";}
            return "X";      
        }

        public static bool Checker(string[,] board)
        {
            // here we perform horizontal and vertical checks
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    return true;
                if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    return true;
            }
            // here diagonal checks 
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
                return true;
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                return true;
            return false;
        }

        //checks for repeat moves
        public static bool RepeatChecker(string input, string[] usedMoves)
        {
            for (int i = 0; i < usedMoves.Length; i++)
            {
                if (usedMoves[i] == input) return false;
            }
            return true;
        }
        public static void DisplayBoard(string[,] board)
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {board[0, 0]}  |  {board[0, 1]}  |  {board[0, 2]}");
            Console.WriteLine("-----------------");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {board[1, 0]}  |  {board[1, 1]}  |  {board[1, 2]}");
            Console.WriteLine("-----------------");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {board[2, 0]}  |  {board[2, 1]}  |  {board[2, 2]}");
        }
    }
}
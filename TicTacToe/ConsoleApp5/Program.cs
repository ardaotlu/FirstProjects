namespace ConsoleApp5
{



    internal class Program
    {
        public static string[,] board = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
        public static string[,] boardActual = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };
        public static void Main(string[] args)
        {

            ShowBoard();
            Player1MoveO();
        }

        public static void ShowBoard()
        {
            Console.Clear();
            Console.WriteLine("   |   |   ");
            Console.Write(" ");
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (i == 2)
                    Console.Write(boardActual[0, i] + " ");
                else
                    Console.Write(boardActual[0, i] + " | ");
            }
            Console.WriteLine("\n___|___|___");
            Console.WriteLine("   |   |   ");
            Console.Write(" ");
            for (int i = 0; i < boardActual.GetLength(0); i++)
            {
                if (i == 2)
                    Console.Write(boardActual[1, i] + " ");
                else
                    Console.Write(boardActual[1, i] + " | ");
            }
            Console.WriteLine("\n___|___|___");
            Console.WriteLine("   |   |   ");
            Console.Write(" ");
            for (int i = 0; i < boardActual.GetLength(0); i++)
            {
                if (i == 2)
                    Console.Write(boardActual[2, i] + " ");
                else
                    Console.Write(boardActual[2, i] + " | ");
            }
            Console.WriteLine("\n   |   |   ");
        }
        public static void Player1MoveO()
        {
            Console.Write("Player 1 Move: ");
            while (true)
            {
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out int x);
                if (!isNumber)
                {
                    Console.WriteLine("Enter a valid input");
                    continue;
                }
                else if (x < 1 || x > 9)
                {
                    Console.WriteLine("Enter a input between 1-9");
                    continue;
                }
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == input)
                        {
                            if (boardActual[i,j]!="O" && boardActual[i, j] != "X")
                                boardActual[i, j] = "O";
                            else { 
                                Console.WriteLine("Already taken");
                                Player1MoveO();
                            }
                        }

                    }
                }
                break;
            }
            ShowBoard();
            if (Checker()) {
                Console.WriteLine("Player 1 wins");
                Reset();
            }
                
            else
                Player2MoveX();
        }
        public static void Player2MoveX()
        {
            while (true)
            {
                Console.Write("Player 2 Move: ");
                string input = Console.ReadLine();
                bool isNumber = int.TryParse(input, out int x);
                if (!isNumber)
                {
                    Console.WriteLine("Enter a valid input");
                    continue;
                }
                else if (x < 1 || x > 9)
                {
                    Console.WriteLine("Enter a input between 1-9");
                    continue;
                }
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        if (board[i, j] == input)
                        {
                            if (boardActual[i, j] != "O" && boardActual[i, j] != "X")
                                boardActual[i, j] = "X";
                            else
                            {
                                Console.WriteLine("Already taken");
                                Player2MoveX();
                            }
                        }

                    }
                }
                break;
            }
            ShowBoard();
            if (Checker())
            {
                Console.WriteLine("Player 2 wins");
                Reset();
            }
            else
                Player1MoveO();
        }
        public static bool Checker()
        {
            for (int i = 0; i < boardActual.GetLength(0); i++)
            {
                if ((boardActual[i, 0] == boardActual[i, 1]) && (boardActual[i, 1] == boardActual[i, 2]))
                    return true;
                if ((boardActual[0, i] == boardActual[1, i]) && (boardActual[1, i] == boardActual[2, i]))
                    return true;
            }
            if ((boardActual[0, 0] == boardActual[1, 1]) && (boardActual[1, 1] == boardActual[2, 2]))
                return true;
            if ((boardActual[0, 2] == boardActual[1, 1]) && (boardActual[1, 1] == boardActual[2, 0]))
                return true;
            else
                return false;
        }
        public static void Reset()
        {
            Console.WriteLine("Press any key to reset the game or write end to close program");
            string input= Console.ReadLine();
            if (input != "end")
            {
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        boardActual[i, j] = board[i, j];
                    }
                }
                ShowBoard();
                Player1MoveO();
            }
        }

    }
}
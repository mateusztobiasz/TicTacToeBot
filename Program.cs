
using System.Net.Http.Headers;
using TicTacToeBotNs;

class Program
{
    public static void Main(string[] args)
    {
        var board = new char[3, 3];
        board.Fill('_');
        Console.WriteLine("Welcome! Do you want to play as O or X?: ");
        char choice = Convert.ToChar(Console.Read());
        bool botMaximizing = (choice == 'O') ? false : true;
        var bot = new TicTacToeBot(botMaximizing);

        while (true)
        {
            if (choice == 'O')
            {
                PlayerMove(board, choice);
                if (bot.CheckIfGameOver(board).gameOver) 
                {
                    int result = bot.EvaluatePosition(board);

                    if (result == 1) Console.WriteLine("Bot won!");
                    else if (result == 0) Console.WriteLine("Draw!");
                    else Console.WriteLine("You won!");
                    break;
                }
                BotMove(bot, board, botMaximizing);
                if (bot.CheckIfGameOver(board).gameOver)
                {
                    int result = bot.EvaluatePosition(board);

                    if (result == 1) Console.WriteLine("Bot won!");
                    else if (result == 0) Console.WriteLine("Draw!");
                    else Console.WriteLine("You won!");
                    break;
                }
            }
            else if (choice == 'X')
            {
                BotMove(bot, board, botMaximizing);
                if (bot.CheckIfGameOver(board).gameOver)
                {
                    int result = bot.EvaluatePosition(board);

                    if (result == 1) Console.WriteLine("Bot won!");
                    else if (result == 0) Console.WriteLine("Draw!");
                    else Console.WriteLine("You won!");
                    break;
                }
                PlayerMove(board, choice);
                if (bot.CheckIfGameOver(board).gameOver)
                {
                    int result = bot.EvaluatePosition(board);

                    if (result == 1) Console.WriteLine("Bot won!");
                    else if (result == 0) Console.WriteLine("Draw!");
                    else Console.WriteLine("You won!");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Bad option!");
                return;
            }
        }
        

    }

    public static void BotMove(TicTacToeBot bot, char[, ] board, bool botMaximizing)
    {
        int res = bot.MakeMove(board, botMaximizing, 0);
        board[bot.LastBestMove.i, bot.LastBestMove.j] = (botMaximizing) ? 'O' : 'X';
        Console.WriteLine("Bot made a move: ");
        board.Print();
    }

    public static void PlayerMove(char[, ] board, char choice)
    {
        Console.WriteLine("Make a move. Type a number 0 - 0,0, 1 - 0,1, 2 - 0,2, 3 - 1, 0 ...: ");
        Console.Read();
        Console.Read();
        var move = Console.Read() - '0';
        (int i, int j) position = (move / 3, move % 3);
        board[position.i, position.j] = choice;
        board.Print();
    }

}
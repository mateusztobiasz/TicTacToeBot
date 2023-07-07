
using TicTacToeBotNs;

class Program
{
    public static void Main(string[] args)
    {
        var bot = new TicTacToeBot();
        int result = bot.MakeMove(new char[3, 3], false, true);
    }
}
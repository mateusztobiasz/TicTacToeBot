namespace TicTacToeBotNs
{
    public static class _2DArrayExtensions
    {
        public static void Fill<T>(this T[,] board, T value)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = value;
                }
            }
        }

        public static void Print<T>(this T[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

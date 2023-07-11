namespace TicTacToeBotNs
{
    public class TicTacToeBot
    {
        public (int, int) LastBestMove { get; private set; }


        public int MakeMove(char[,] board, bool botTurn, int depth)
        {
            if (CheckIfGameOver(board)) return EvaluatePosition(board, botTurn);
            List<(int, int)> blankSpaces = DetermineBlankSpaces(board);

            if (botTurn) // maximizing player
            {
                int maxVal = int.MinValue;
                foreach ((int i, int j) blankSpace in blankSpaces)
                {
                    board[blankSpace.i, blankSpace.j] = 'O';
                    int val = MakeMove(board, !botTurn, depth++);
                    if (val > maxVal)
                    {
                        maxVal = val;
                        if (depth == 0) LastBestMove = blankSpace;
                    }
                    board[blankSpace.i, blankSpace.j] = '_';
                }
                return maxVal;
            }
            else // minimazing player
            {
                int minVal = int.MaxValue;
                foreach ((int i, int j) blankSpace in blankSpaces)
                {
                    board[blankSpace.i, blankSpace.j] = 'X';
                    int val = MakeMove(board, !botTurn, depth++);
                    if (val < minVal)
                    {
                        minVal = val;
                        if (depth == 0) LastBestMove = blankSpace;
                    }
                    board[blankSpace.i, blankSpace.j] = '_';
                }
                return minVal;
            }
        }

        private List<(int, int)> DetermineBlankSpaces(char[,] board)
        {
            List<(int, int)> blankSpaces = new List<(int, int)> ();

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '_') blankSpaces.Add((i, j));
                }
            }

            return blankSpaces;

        }

        private bool CheckIfGameOver(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '_') return false;
                }
            }

            return true;
        }

        private int EvaluatePosition(char[,] board, bool botTurn)
        {
            bool horizontalWin = (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2]) ||
                                 (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2]) ||
                                 (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2]);

            bool verticalWin = (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0]) ||
                               (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1]) ||
                               (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2]);

            bool diagonalWin = (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2]) ||
                               (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2]);

            bool result = horizontalWin || verticalWin || diagonalWin;

            if (result && botTurn) return (board[0, 0] == 'O') ? 1 : -1;
            else if (result && !botTurn) return (board[0, 0] == 'X') ? 1 : -1;
            else return 0;
        }


    }
}

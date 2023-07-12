using System.Text;

namespace TicTacToeBotNs
{
    public class TicTacToeBot
    {
        public (int i, int j) LastBestMove { get; private set; }

        private bool botMaximizing { get; set; }


        public TicTacToeBot(bool botMaximizing)
        {
            this.botMaximizing = botMaximizing;
        }

        public int MakeMove(char[,] board, bool maximizingPlayer, int depth)
        {
            (bool gameOver, int staticVal) = CheckIfGameOver(board);
            if (gameOver) return staticVal;

            List<(int, int)> blankSpaces = DetermineBlankSpaces(board);
            if (maximizingPlayer)
            {
                int maxVal = int.MinValue;
                foreach ((int i, int j) in blankSpaces)
                {
                    board[i, j] = 'O';
                    int val = MakeMove(board, false, depth + 1);
                    board[i, j] = '_';
                    if (val > maxVal)
                    {
                        maxVal = val;
                        if (depth == 0) LastBestMove = (i, j);
                    }
                }
                return maxVal;
            }
            else
            {
                int minVal = int.MaxValue;
                foreach ((int i, int j) in blankSpaces)
                {
                    board[i, j] = 'X';
                    int val = MakeMove(board, true, depth + 1);
                    board[i, j] = '_';
                    if (val < minVal)
                    {
                        minVal = val;
                        if (depth == 0) LastBestMove = (i, j);
                    }
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

        public (bool gameOver, int val) CheckIfGameOver(char[,] board)
        {
            int val = EvaluatePosition(board);
            if (val == 1 || val == -1) return (true, val);

            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == '_') return (false, -2);
                }
            }
            return (true, val);
        }

        public int EvaluatePosition(char[,] board)
        {

            bool horizontalWinX = (board[0, 0] == 'X' && board[0, 1] == 'X' && board[0, 2] == 'X') ||
                                 (board[1, 0] == 'X' && board[1, 1] == 'X' && board[1, 2] == 'X') ||
                                 (board[2, 0] == 'X' && board[2, 1] == 'X' && board[2, 2] == 'X');

            bool verticalWinX = (board[0, 0] == 'X' && board[1, 0] == 'X' && board[2, 0] == 'X') ||
                               (board[0, 1] == 'X' && board[1, 1] == 'X' && board[2, 1] == 'X') ||
                               (board[0, 2] == 'X' && board[1, 2] == 'X' && board[2, 2] == 'X');

            bool diagonalWinX = (board[0, 0] == 'X' && board[1, 1] == 'X' && board[2, 2] == 'X') ||
                               (board[2, 0] == 'X' && board[1, 1] == 'X' && board[0, 2] == 'X');


            bool horizontalWinO = (board[0, 0] == 'O' && board[0, 1] == 'O' && board[0, 2] == 'O') ||
                                (board[1, 0] == 'O' && board[1, 1] == 'O' && board[1, 2] == 'O') ||
                                (board[2, 0] == 'O' && board[2, 1] == 'O' && board[2, 2] == 'O');

            bool verticalWinO = (board[0, 0] == 'O' && board[1, 0] == 'O' && board[2, 0] == 'O') ||
                               (board[0, 1] == 'O' && board[1, 1] == 'O' && board[2, 1] == 'O') ||
                               (board[0, 2] == 'O' && board[1, 2] == 'O' && board[2, 2] == 'O');

            bool diagonalWinO = (board[0, 0] == 'O' && board[1, 1] == 'O' && board[2, 2] == 'O') ||
                               (board[2, 0] == 'O' && board[1, 1] == 'O' && board[0, 2] == 'O');

            bool resultX = horizontalWinX || verticalWinX || diagonalWinX;
            bool resultO = horizontalWinO || verticalWinO || diagonalWinO;

            if (resultX && botMaximizing) return -1;
            else if (resultO && botMaximizing) return 1;
            else if (resultX && !botMaximizing) return -1;
            else if (resultO && !botMaximizing) return 1;
            else return 0;
        }
    }
}

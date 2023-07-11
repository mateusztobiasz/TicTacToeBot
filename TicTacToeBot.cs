namespace TicTacToeBotNs
{
    public class TicTacToeBot
    {
        public int MakeMove(char[,] board, bool botTurn)
        {
            if (CheckIfGameOver(board)) return EvaluatePosition(board, botTurn);

            if (botTurn) // maximizing player
            {
                return 1;
            }
            else // minimazing player
            {
                return -1;
            }
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
            else if (result && !botTurn) return (board[0, 0] == 'O') ? -1 : 1;
            else return 0;
        }


    }
}

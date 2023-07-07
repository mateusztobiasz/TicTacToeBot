namespace TicTacToeBotNs
{
    public class TicTacToeBot
    {
        public int MakeMove(char[,] board, bool gameOver, bool botTurn)
        {
            if (gameOver) return EvaluatePosition(board);

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
            return false;
        }

        private int EvaluatePosition(char[,] board)
        {
            return 1;
        }


    }
}

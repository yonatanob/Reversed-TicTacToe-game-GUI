using System;
using WindowsUIManager;

namespace TicTacToeLogic
{
    public class GameHandlerForTicTacToe
    {
        public static LogicManagerForTicTacToe CreateGame(int i_BoardSize, eOpponentType i_TypeOfGame, string i_NamePlayer1, string i_NamePlayer2)
        {
            int boardSize = i_BoardSize;
            Player player1 = new HumanPlayer(eFieldType.FieldX, i_NamePlayer1, eOpponentType.Human);
            Player player2;
            if (i_TypeOfGame == eOpponentType.Computer)
            {
                player2 = new ComputerPlayer(eFieldType.FieldO, i_NamePlayer2, i_TypeOfGame, boardSize);
            }
            else
            {
                player2 = new HumanPlayer(eFieldType.FieldO, i_NamePlayer2, i_TypeOfGame);
            }

            LogicManagerForTicTacToe roundOfGame = new LogicManagerForTicTacToe(boardSize, player1, player2);
            return roundOfGame;
        }

        public static void PlayGame(LogicManagerForTicTacToe i_LogicManagerForTicTacToe)
        {
            playerTurn(i_LogicManagerForTicTacToe);
            doAfterPlayerTurn(i_LogicManagerForTicTacToe);
            if (i_LogicManagerForTicTacToe.CurrPlayer.PlayerType == eOpponentType.Computer)
            {
                playerTurn(i_LogicManagerForTicTacToe);
                doAfterPlayerTurn(i_LogicManagerForTicTacToe);
            }
        }

        private static void playerTurn(LogicManagerForTicTacToe i_LogicManagerForTicTacToe)
        {
            getPlayerPosition(i_LogicManagerForTicTacToe);
            i_LogicManagerForTicTacToe.NotifyCellValuesChangedAndChange(i_LogicManagerForTicTacToe.CurrPlayer);
        }

        private static void getPlayerPosition(LogicManagerForTicTacToe i_LogicManagerForTicTacToe)
        {
            if (i_LogicManagerForTicTacToe.CurrPlayer.PlayerType == eOpponentType.Computer)
            {
                getComputerPosition(i_LogicManagerForTicTacToe);
            }
        }

        private static void getComputerPosition(LogicManagerForTicTacToe i_LogicManagerForTicTacToe)
        {
            Position position;

            while (true)
            {
                position = (i_LogicManagerForTicTacToe.CurrPlayer as ComputerPlayer).ReadRowFromComputer();
                if (i_LogicManagerForTicTacToe.Board[position.Row, position.Col].FieldState == eFieldType.FieldEmpty)
                {
                    break;
                }
            }

            i_LogicManagerForTicTacToe.CurrPlayer.RowClicked = position.Row;
            i_LogicManagerForTicTacToe.CurrPlayer.ColClicked = position.Col;
        }

        private static void doAfterPlayerTurn(LogicManagerForTicTacToe i_LogicManagerForTicTacToe)
        {
            if (i_LogicManagerForTicTacToe.CheckLoser())
            {
                doAfterPlayerLostTheGame(i_LogicManagerForTicTacToe);
            }
            else if (i_LogicManagerForTicTacToe.CheckDraw())
            {
                doAfterADreawInGame(i_LogicManagerForTicTacToe);
            }

            i_LogicManagerForTicTacToe.NotifySwitchedTurn();
        }

        private static void doAfterPlayerLostTheGame(LogicManagerForTicTacToe i_LogicManagerForTicTacToe)
        {
            i_LogicManagerForTicTacToe.NotifySwitchedTurn();
            i_LogicManagerForTicTacToe.NotifyPlayersScoreUpdated();
            GameFormForTicTacToe.WinningMessegeBox(i_LogicManagerForTicTacToe);
            i_LogicManagerForTicTacToe.NotifySwitchedTurn();
            i_LogicManagerForTicTacToe.NotifyResetBoard();
        }

        private static void doAfterADreawInGame(LogicManagerForTicTacToe i_LogicManagerForTicTacToe)
        {
            i_LogicManagerForTicTacToe.NotifySwitchedTurn();
            GameFormForTicTacToe.DrawGameMessegeBox();
            i_LogicManagerForTicTacToe.NotifySwitchedTurn();
            i_LogicManagerForTicTacToe.NotifyResetBoard();
        }
    }
}
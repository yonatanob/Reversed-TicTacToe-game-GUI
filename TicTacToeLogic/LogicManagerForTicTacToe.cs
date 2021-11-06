using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeLogic
{
    public delegate void Notifier();

    public delegate void Notifier<T1, T2>(T1 i_Param1, T2 i_Param2);

    public class LogicManagerForTicTacToe
    {
        private readonly Cell[,] r_TicTacToeBoard;
        public readonly int r_BoardSize;
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private int m_NumOfTakenCells;
        private Player m_CurrPlayer;

        public event Notifier SwitchedTurn = null; // Notify after switching a turn

        public event Notifier ResetBoard = null; // Notify after the board id clear and ready to another round

        public event Notifier PlayersScoreUpdated = null; // Notify after the players score was updated

        public event Notifier<int, int> CellValuesChanged = null; // Notify Cell values were changed

        public LogicManagerForTicTacToe(int i_BoardSize, Player i_Player1, Player i_Player2)
        {
            r_BoardSize = i_BoardSize;
            r_TicTacToeBoard = new Cell[r_BoardSize, r_BoardSize];
            initializeBoard();
            r_Player1 = i_Player1;
            r_Player2 = i_Player2;
            m_NumOfTakenCells = 0;
            m_CurrPlayer = r_Player1;
        }

        private void initializeBoard()
        {
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    r_TicTacToeBoard[i, j] = new Cell();
                }
            }
        }

        public Cell[,] Board
        {
            get { return r_TicTacToeBoard; }
        }

        public int BoardSize
        {
            get
            {
                return r_BoardSize;
            }
        }

        public Player Player1
        {
            get { return r_Player1; }
        }

        public Player Player2
        {
            get { return r_Player2; }
        }

        public Player CurrPlayer
        {
            get { return m_CurrPlayer; }
        }

        public bool IsTaken(Player i_Player)
        {
            return !r_TicTacToeBoard[i_Player.RowClicked, i_Player.ColClicked].IsCellEmpty();
        }

        private bool checkRowsForLoser()
        {
            bool flag = false;
            int counter = 0;

            for (int i = 0; i < r_BoardSize; i++)
            {
                eFieldType firstFieldToCompare = r_TicTacToeBoard[i, 0].FieldState;

                if (firstFieldToCompare == eFieldType.FieldEmpty)
                {
                    break;
                }

                for (int j = 0; j < r_BoardSize; j++)
                {
                    if (r_TicTacToeBoard[i, j].FieldState == firstFieldToCompare)
                    {
                        ++counter;
                    }
                    else
                    {
                        break;
                    }
                }

                if (counter == r_BoardSize)
                {
                    flag = true;
                }

                counter = 0;
            }

            return flag;
        }

        private bool checkColumnsForLoser()
        {
            bool flag = false;
            int counter = 0;

            for (int i = 0; i < r_BoardSize; i++)
            {
                eFieldType firstFieldToCompare = r_TicTacToeBoard[0, i].FieldState;

                for (int j = 0; j < r_BoardSize; j++)
                {
                    if (firstFieldToCompare == eFieldType.FieldEmpty)
                    {
                        break;
                    }

                    if (r_TicTacToeBoard[j, i].FieldState == firstFieldToCompare)
                    {
                        ++counter;
                    }
                    else
                    {
                        break;
                    }
                }

                if (counter == r_BoardSize)
                {
                    flag = true;
                }

                counter = 0;
            }

            return flag;
        }

        private bool checkLeftDiagonalsForLoser()
        {
            bool flag = false;
            int counter = 0;
            eFieldType firstFieldToCompare = r_TicTacToeBoard[0, 0].FieldState;

            for (int i = 0; i < r_BoardSize; i++)
            {
                if (firstFieldToCompare == eFieldType.FieldEmpty)
                {
                    break;
                }

                if (r_TicTacToeBoard[i, i].FieldState == firstFieldToCompare)
                {
                    ++counter;
                }
                else
                {
                    break;
                }
            }

            if (counter == r_BoardSize)
            {
                flag = true;
            }

            return flag;
        }

        private bool checkRightDiagonalsForLoser()
        {
            bool flag = false;
            int counter = 0;
            eFieldType firstFieldToCompare = r_TicTacToeBoard[0, r_BoardSize - 1].FieldState;

            for (int i = 0; i < r_BoardSize; i++)
            {
                if (firstFieldToCompare == eFieldType.FieldEmpty)
                {
                    break;
                }

                if (r_TicTacToeBoard[i, r_BoardSize - 1 - i].FieldState == firstFieldToCompare)
                {
                    ++counter;
                }
                else
                {
                    break;
                }
            }

            if (counter == r_BoardSize)
            {
                flag = true;
            }

            return flag;
        }

        public bool CheckLoser()
        {
            return checkRowsForLoser() || checkColumnsForLoser() ||
              checkLeftDiagonalsForLoser() || checkRightDiagonalsForLoser();
        }

        public bool CheckDraw()
        {
            return m_NumOfTakenCells == r_BoardSize * r_BoardSize;
        }

        public void NotifySwitchedTurn()
        {
            if (m_CurrPlayer == r_Player1)
            {
                m_CurrPlayer = r_Player2;
            }
            else
            {
                m_CurrPlayer = r_Player1;
            }

            if (SwitchedTurn != null)
            {
                SwitchedTurn.Invoke();
            }
        }

        public void NotifyPlayersScoreUpdated()
        {
            m_CurrPlayer.NumOfWins++;

            if (PlayersScoreUpdated != null)
            {
                PlayersScoreUpdated.Invoke();
            }
        }

        public void NotifyResetBoard()
        {
            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    r_TicTacToeBoard[i, j].FieldState = eFieldType.FieldEmpty;
                }
            }

            m_NumOfTakenCells = 0;

            if (ResetBoard != null)
            {
                ResetBoard.Invoke();
            }
        }

        public void NotifyCellValuesChangedAndChange(Player i_Player)
        {
            r_TicTacToeBoard[i_Player.RowClicked, i_Player.ColClicked].FieldState = i_Player.GetSign();

            if (CellValuesChanged != null)
            {
                CellValuesChanged.Invoke(i_Player.RowClicked, i_Player.ColClicked);
            }

            increaceNumOfTakenCells();
        }

        private void increaceNumOfTakenCells()
        {
            m_NumOfTakenCells++;
        }
    }
}

using System;

namespace TicTacToeLogic
{
    public class ComputerPlayer : Player
    {
        public readonly int r_BoardSize;
        private readonly Random r_Random = new Random();

        public ComputerPlayer(eFieldType i_PlayerSign, string i_Name, eOpponentType i_PlayerType, int i_BoardSize) : base(i_PlayerSign, i_Name, i_PlayerType)
        {
            this.r_BoardSize = i_BoardSize;
        }

        public Position ReadRowFromComputer()
        {
            Position computerPosition = new Position() 
            {
                Row = r_Random.Next(0, r_BoardSize),
                Col = r_Random.Next(0, r_BoardSize)
            };

            return computerPosition;
        }
    }
}

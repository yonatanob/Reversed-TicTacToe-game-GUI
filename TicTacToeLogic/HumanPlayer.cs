using System;

namespace TicTacToeLogic
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(eFieldType i_PlayerSign, string i_Name, eOpponentType i_PlayerType) : base(i_PlayerSign, i_Name, i_PlayerType)
        {
        }
    }
}

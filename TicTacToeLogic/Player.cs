namespace TicTacToeLogic
{
    public class Player
    {
        protected readonly eFieldType r_Sign;
        private readonly string r_Name;
        private readonly eOpponentType r_PlayerType;
        private byte m_NumOfWins;
        private int m_RowClicked;
        private int m_ColClicked;

        public Player(eFieldType i_PlayerSign, string i_Name, eOpponentType i_PlayerType)
        {
            r_Sign = i_PlayerSign;
            r_Name = i_Name;
            r_PlayerType = i_PlayerType;
            m_NumOfWins = 0;
        }

        public int RowClicked
        {
            get 
            { 
                return m_RowClicked;
            }

            set 
            {
                m_RowClicked = value;
            }
        }

        public int ColClicked
        {
            get
            { 
                return m_ColClicked; 
            }

            set 
            {
                m_ColClicked = value; 
            }
        }

        public byte NumOfWins
        {
            get
            {
                return m_NumOfWins;
            }

            set
            {
                m_NumOfWins = value;
            }
        }

        public eOpponentType PlayerType
        {
            get
            { 
                return r_PlayerType; 
            }
        }

        public string PlayerName
        {
            get 
            { 
                return r_Name; 
            }
        }

        public eFieldType GetSign()
        {
            return r_Sign;
        }
    }
}

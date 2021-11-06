namespace TicTacToeLogic
{
    public class Cell
    {
        private eFieldType m_FieldState = eFieldType.FieldEmpty;

        public Cell()
        {
            m_FieldState = eFieldType.FieldEmpty;
        }

        public eFieldType FieldState
        {
            get
            {
                return m_FieldState;
            }

            set
            {
                m_FieldState = value;
            }
        }

        public bool IsCellEmpty()
        {
            bool flag = false;
            if (!(m_FieldState != eFieldType.FieldEmpty))
            {
                flag = true;
            }

            return flag;
        }
    }
}
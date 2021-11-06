using System;
using System.Windows.Forms;

namespace WindowsUIManager
{
    public partial class SettingsWindowForTicTacToe : Form
    { 
        private const string k_Computer = "[Computer]";

        public SettingsWindowForTicTacToe()
        {
            InitializeComponent();
        }

        private void SettingsWindowForTicTacToe_Load(object sender, EventArgs e) 
        { 
        }

        private void m_NumericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            m_NumericUpDownCols.Value = m_NumericUpDownRows.Value;
        }

        private void m_NumericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            m_NumericUpDownRows.Value = m_NumericUpDownCols.Value;
        }

        private void m_CheckBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (m_CheckBoxPlayer2.CheckState == CheckState.Checked)
            {
                m_TextBoxPlayer2.Enabled = true;
                m_TextBoxPlayer2.Text = string.Empty;
            }
            else
            {
                m_TextBoxPlayer2.Enabled = false;
                m_TextBoxPlayer2.Text = k_Computer;
            }
        }

        private bool isTextBoxEmpty(TextBox i_TextBox)
        {
            return string.IsNullOrWhiteSpace(i_TextBox.Text);
        }

        public bool IsAgaintComputer()
        {
            return m_CheckBoxPlayer2.CheckState == CheckState.Unchecked;
        }

        private void m_ButtonStart_Click(object sender, EventArgs e)
        {
            setPlayer1Name();
            setPlayer2Name();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void setPlayer2Name()
        {
            if (IsAgaintComputer())
            {
                m_TextBoxPlayer2.Text = "Computer";
            } 
            else if (isTextBoxEmpty(m_TextBoxPlayer2))
            {
                m_TextBoxPlayer2.Text = "Player 2";
            }
        }

        private void setPlayer1Name()
        {
            if (isTextBoxEmpty(m_TextBoxPlayer1))
            {
                m_TextBoxPlayer1.Text = "Player 1";
            }
        }

        public int BoardSize
        {
            get { return (int)m_NumericUpDownRows.Value; }
        }

        public string NamePlayer1
        {
            get { return m_TextBoxPlayer1.Text; }
        }

        public string NamePlayer2
        {
            get { return m_TextBoxPlayer2.Text; }
        }

        private void Settings_FormClosed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

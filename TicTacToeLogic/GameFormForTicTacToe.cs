using System;
using System.Drawing;
using System.Windows.Forms;
using TicTacToeLogic;

namespace WindowsUIManager
{
    public partial class GameFormForTicTacToe : Form
    {
        private readonly int r_BoardSize;
        private readonly Button[,] r_ButtonsBoardTicTacToe;
        private readonly eOpponentType r_GameType;
        private readonly SettingsWindowForTicTacToe r_SettingsWindowForTicTacToe = new SettingsWindowForTicTacToe();
        private readonly LogicManagerForTicTacToe r_LogicManagerForTicTacToe;
        private readonly Label r_LabelPlayer1 = new Label();
        private readonly Label r_LabelPlayer2 = new Label();

        public GameFormForTicTacToe()
        {
            r_SettingsWindowForTicTacToe.ShowDialog();
            r_BoardSize = r_SettingsWindowForTicTacToe.BoardSize;
            r_ButtonsBoardTicTacToe = new Button[r_BoardSize, r_BoardSize];
            r_GameType = initGameType();
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Padding = new Padding(0, 0, 20, 20);
            r_LogicManagerForTicTacToe = GameHandlerForTicTacToe.CreateGame(r_BoardSize, r_GameType, r_SettingsWindowForTicTacToe.NamePlayer1, r_SettingsWindowForTicTacToe.NamePlayer2);
            r_LogicManagerForTicTacToe.CellValuesChanged += putMarkInCell;
            r_LogicManagerForTicTacToe.PlayersScoreUpdated += setLabelsFormatandInfo;
            r_LogicManagerForTicTacToe.SwitchedTurn += changeLabelTurn;
            r_LogicManagerForTicTacToe.ResetBoard += resetBoardVisual;
            InitializeComponent();
        }

        public static void WinningMessegeBox(LogicManagerForTicTacToe i_LogicManagerForTicTacToe)
        {
            string winnerName = i_LogicManagerForTicTacToe.CurrPlayer.PlayerName;
            string messegeText = string.Format(@"The winner is {0}!{1} Would you like to play another round?", winnerName, Environment.NewLine);

            if (MessageBox.Show(messegeText, "A win!", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                NoButton_Click();
            }
            else
            {
                YesButton_Click();
            }
        }

        public static void DrawGameMessegeBox()
        {
            string messegeText = string.Format(@"Tie!{0} Would you like to play another round?", Environment.NewLine);

            if (MessageBox.Show(messegeText, "A Tie!", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                NoButton_Click();
            }
            else
            {
                YesButton_Click();
            }
        }

        public static void YesButton_Click() 
        {
        }

        public static void NoButton_Click()
        {
            Environment.Exit(0);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            char emptyCellText = (char)eFieldType.FieldEmpty;
            if (r_SettingsWindowForTicTacToe.DialogResult != DialogResult.OK)
            {
                Environment.Exit(0);
            }
            else
            {
                for (int i = 0; i < r_BoardSize; i++)
                {
                    for (int j = 0; j < r_BoardSize; j++)
                    {
                        Button currentButton = new Button()
                        {
                            Text = emptyCellText.ToString(),
                            Location = new Point(10 + (i * 110), 12 + (j * 90)),
                            Size = new Size(80, 80),
                            Margin = new Padding(2),
                        };
                        currentButton.Click += new EventHandler(currentButton_Click);
                        r_ButtonsBoardTicTacToe[i, j] = currentButton;
                        Controls.Add(currentButton);
                    }
                }

                placeAndEditLabels();
                setLabelsFormatandInfo();
                Controls.AddRange(new Control[] { r_LabelPlayer1, r_LabelPlayer2 });
            }
        }

        private void currentButton_Click(object sender, EventArgs e)
        {
            int row = 0;
            int col = 0;

            for (int i = 0; i < r_BoardSize; i++)
            {
                for (int j = 0; j < r_BoardSize; j++)
                {
                    if (r_ButtonsBoardTicTacToe[i, j].Equals(sender as Button))
                    {
                        row = i;
                        col = j;
                    }
                }
            }

        r_LogicManagerForTicTacToe.CurrPlayer.RowClicked = row;
        r_LogicManagerForTicTacToe.CurrPlayer.ColClicked = col;
        GameHandlerForTicTacToe.PlayGame(r_LogicManagerForTicTacToe);
        }

        private void resetBoardVisual()
        {
            char emptyCellText = (char)eFieldType.FieldEmpty;

            foreach (Button btn in r_ButtonsBoardTicTacToe)
            {
                btn.Text = emptyCellText.ToString();
                btn.Enabled = true;
            }
        }

        private eOpponentType initGameType()
        {
            eOpponentType gameType = eOpponentType.Human;
            if (r_SettingsWindowForTicTacToe.IsAgaintComputer())
            {
                gameType = eOpponentType.Computer;
            }

            return gameType;
        }

        private void placeAndEditLabels()
        {
            r_LabelPlayer1.AutoSize = true;
            r_LabelPlayer2.AutoSize = true;
            r_LabelPlayer1.Font = new Font(r_LabelPlayer1.Font, FontStyle.Bold);
            r_LabelPlayer1.Location = new Point(r_BoardSize * 60 / 2, 10 + (r_BoardSize * 90));
            r_LabelPlayer2.Location = new Point(r_BoardSize * 60, 10 + (r_BoardSize * 90));
        }

        private void setLabelsFormatandInfo()
        {
            string namePlayer1FromSettings = r_SettingsWindowForTicTacToe.NamePlayer1;
            string namePlayer2FromSettings = r_SettingsWindowForTicTacToe.NamePlayer2;

            int playerOneScore = r_LogicManagerForTicTacToe.Player1.NumOfWins;
            int playerTwoScore = r_LogicManagerForTicTacToe.Player2.NumOfWins;
            r_LabelPlayer1.Text = string.Format("{0}: {1}", namePlayer1FromSettings, playerOneScore);
            r_LabelPlayer2.Text = string.Format("{0}: {1}", namePlayer2FromSettings, playerTwoScore);
        }

        private void putMarkInCell(int i_Row, int i_Col)
        {
            char currFieldState = (char)r_LogicManagerForTicTacToe.CurrPlayer.GetSign();
            r_ButtonsBoardTicTacToe[i_Row, i_Col].Text = currFieldState.ToString();
            r_ButtonsBoardTicTacToe[i_Row, i_Col].Enabled = false;
        }

        private void changeLabelTurn()
        {
            if (r_LogicManagerForTicTacToe.CurrPlayer.PlayerName == r_SettingsWindowForTicTacToe.NamePlayer1)
            {
                r_LabelPlayer1.Font = new Font(r_LabelPlayer1.Font, FontStyle.Bold);
                r_LabelPlayer2.Font = new Font(r_LabelPlayer2.Font, FontStyle.Regular);
            }
            else
            {
                r_LabelPlayer2.Font = new Font(r_LabelPlayer2.Font, FontStyle.Bold);
                r_LabelPlayer1.Font = new Font(r_LabelPlayer1.Font, FontStyle.Regular);
            }
        }
    }
}

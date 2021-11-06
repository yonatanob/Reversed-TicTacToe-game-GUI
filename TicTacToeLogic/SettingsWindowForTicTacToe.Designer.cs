namespace WindowsUIManager
{
    public partial class SettingsWindowForTicTacToe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_LabelPlayers = new System.Windows.Forms.Label();
            this.r_LabelPlayer1 = new System.Windows.Forms.Label();
            this.m_CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.m_TextBoxPlayer1 = new System.Windows.Forms.TextBox();
            this.m_TextBoxPlayer2 = new System.Windows.Forms.TextBox();
            this.m_LabelBoardSize = new System.Windows.Forms.Label();
            this.m_NumericUpDownRows = new System.Windows.Forms.NumericUpDown();
            this.m_NumericUpDownCols = new System.Windows.Forms.NumericUpDown();
            this.m_LabelRows = new System.Windows.Forms.Label();
            this.m_LabelCols = new System.Windows.Forms.Label();
            this.m_ButtonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // m_LabelPlayers
            // 
            this.m_LabelPlayers.AutoSize = true;
            this.m_LabelPlayers.Location = new System.Drawing.Point(13, 13);
            this.m_LabelPlayers.Name = "m_LabelPlayers";
            this.m_LabelPlayers.Size = new System.Drawing.Size(44, 13);
            this.m_LabelPlayers.TabIndex = 0;
            this.m_LabelPlayers.Text = "Players:";
            // 
            // r_LabelPlayer1
            // 
            this.r_LabelPlayer1.AutoSize = true;
            this.r_LabelPlayer1.Location = new System.Drawing.Point(23, 44);
            this.r_LabelPlayer1.Name = "r_LabelPlayer1";
            this.r_LabelPlayer1.Size = new System.Drawing.Size(45, 13);
            this.r_LabelPlayer1.TabIndex = 1;
            this.r_LabelPlayer1.Text = "Player1:";
            // 
            // m_CheckBoxPlayer2
            // 
            this.m_CheckBoxPlayer2.AutoSize = true;
            this.m_CheckBoxPlayer2.Location = new System.Drawing.Point(26, 78);
            this.m_CheckBoxPlayer2.Name = "m_CheckBoxPlayer2";
            this.m_CheckBoxPlayer2.Size = new System.Drawing.Size(64, 17);
            this.m_CheckBoxPlayer2.TabIndex = 3;
            this.m_CheckBoxPlayer2.Text = "Player2:";
            this.m_CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.m_CheckBoxPlayer2.CheckedChanged += new System.EventHandler(this.m_CheckBoxPlayer2_CheckedChanged);
            // 
            // m_TextBoxPlayer1
            // 
            this.m_TextBoxPlayer1.Location = new System.Drawing.Point(96, 44);
            this.m_TextBoxPlayer1.Name = "m_TextBoxPlayer1";
            this.m_TextBoxPlayer1.Size = new System.Drawing.Size(100, 20);
            this.m_TextBoxPlayer1.TabIndex = 4;
            // 
            // m_TextBoxPlayer2
            // 
            this.m_TextBoxPlayer2.Enabled = false;
            this.m_TextBoxPlayer2.Location = new System.Drawing.Point(96, 76);
            this.m_TextBoxPlayer2.Name = "m_TextBoxPlayer2";
            this.m_TextBoxPlayer2.Size = new System.Drawing.Size(100, 20);
            this.m_TextBoxPlayer2.TabIndex = 5;
            this.m_TextBoxPlayer2.Text = "[Computer]";
            // 
            // m_LabelBoardSize
            // 
            this.m_LabelBoardSize.AutoSize = true;
            this.m_LabelBoardSize.Location = new System.Drawing.Point(13, 121);
            this.m_LabelBoardSize.Name = "m_LabelBoardSize";
            this.m_LabelBoardSize.Size = new System.Drawing.Size(61, 13);
            this.m_LabelBoardSize.TabIndex = 6;
            this.m_LabelBoardSize.Text = "Board Size:";
            // 
            // m_NumericUpDownRows
            // 
            this.m_NumericUpDownRows.Location = new System.Drawing.Point(80, 156);
            this.m_NumericUpDownRows.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.m_NumericUpDownRows.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_NumericUpDownRows.Name = "m_NumericUpDownRows";
            this.m_NumericUpDownRows.Size = new System.Drawing.Size(38, 20);
            this.m_NumericUpDownRows.TabIndex = 7;
            this.m_NumericUpDownRows.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_NumericUpDownRows.ValueChanged += new System.EventHandler(this.m_NumericUpDownRows_ValueChanged);
            // 
            // m_NumericUpDownCols
            // 
            this.m_NumericUpDownCols.Location = new System.Drawing.Point(177, 156);
            this.m_NumericUpDownCols.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.m_NumericUpDownCols.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_NumericUpDownCols.Name = "m_NumericUpDownCols";
            this.m_NumericUpDownCols.Size = new System.Drawing.Size(38, 20);
            this.m_NumericUpDownCols.TabIndex = 8;
            this.m_NumericUpDownCols.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.m_NumericUpDownCols.ValueChanged += new System.EventHandler(this.m_NumericUpDownCols_ValueChanged);
            // 
            // m_LabelRows
            // 
            this.m_LabelRows.AutoSize = true;
            this.m_LabelRows.Location = new System.Drawing.Point(37, 158);
            this.m_LabelRows.Name = "m_LabelRows";
            this.m_LabelRows.Size = new System.Drawing.Size(37, 13);
            this.m_LabelRows.TabIndex = 9;
            this.m_LabelRows.Text = "Rows:";
            // 
            // m_LabelCols
            // 
            this.m_LabelCols.AutoSize = true;
            this.m_LabelCols.Location = new System.Drawing.Point(141, 158);
            this.m_LabelCols.Name = "m_LabelCols";
            this.m_LabelCols.Size = new System.Drawing.Size(30, 13);
            this.m_LabelCols.TabIndex = 10;
            this.m_LabelCols.Text = "Cols:";
            // 
            // m_ButtonStart
            // 
            this.m_ButtonStart.Location = new System.Drawing.Point(16, 197);
            this.m_ButtonStart.Name = "m_ButtonStart";
            this.m_ButtonStart.Size = new System.Drawing.Size(193, 23);
            this.m_ButtonStart.TabIndex = 11;
            this.m_ButtonStart.Text = "Start!";
            this.m_ButtonStart.UseVisualStyleBackColor = true;
            this.m_ButtonStart.Click += new System.EventHandler(this.m_ButtonStart_Click);
            // 
            // SettingsWindowForTicTacToe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 241);
            this.Controls.Add(this.m_ButtonStart);
            this.Controls.Add(this.m_LabelCols);
            this.Controls.Add(this.m_LabelRows);
            this.Controls.Add(this.m_NumericUpDownCols);
            this.Controls.Add(this.m_NumericUpDownRows);
            this.Controls.Add(this.m_LabelBoardSize);
            this.Controls.Add(this.m_TextBoxPlayer2);
            this.Controls.Add(this.m_TextBoxPlayer1);
            this.Controls.Add(this.m_CheckBoxPlayer2);
            this.Controls.Add(this.r_LabelPlayer1);
            this.Controls.Add(this.m_LabelPlayers);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsWindowForTicTacToe";
            this.Text = "Game Settings";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
           // this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.SettingsWindowForTicTacToe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_LabelPlayers;
        private System.Windows.Forms.Label r_LabelPlayer1;
        private System.Windows.Forms.CheckBox m_CheckBoxPlayer2;
        private System.Windows.Forms.TextBox m_TextBoxPlayer1;
        private System.Windows.Forms.TextBox m_TextBoxPlayer2;
        private System.Windows.Forms.Label m_LabelBoardSize;
        private System.Windows.Forms.NumericUpDown m_NumericUpDownRows;
        private System.Windows.Forms.NumericUpDown m_NumericUpDownCols;
        private System.Windows.Forms.Label m_LabelRows;
        private System.Windows.Forms.Label m_LabelCols;
        private System.Windows.Forms.Button m_ButtonStart;
    }
}
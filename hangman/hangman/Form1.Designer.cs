namespace hangman
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtGuess = new TextBox();
            btnSubmit = new Button();
            btnQuit = new Button();
            lblGuess = new Label();
            hmPB = new PictureBox();
            cbWordLists = new ComboBox();
            btnNewGame = new Button();
            lblgameWon = new Label();
            lblgameLost = new Label();
            lblNumGameWon = new Label();
            lblNumGameLost = new Label();
            winCount = new Label();
            lostCount = new Label();
            lblGuessedLetters = new Label();
            lblWrongLetter = new Label();
            lblWrongGussed = new Label();
            ((System.ComponentModel.ISupportInitialize)hmPB).BeginInit();
            SuspendLayout();
            // 
            // txtGuess
            // 
            txtGuess.Location = new Point(334, 421);
            txtGuess.Name = "txtGuess";
            txtGuess.Size = new Size(100, 23);
            txtGuess.TabIndex = 1;
            txtGuess.TextChanged += txtGuess_TextChanged;
            txtGuess.KeyPress += TxtGuess_KeyPress;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(46, 546);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 3;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // btnQuit
            // 
            btnQuit.Location = new Point(666, 546);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(75, 23);
            btnQuit.TabIndex = 4;
            btnQuit.Text = "Quit";
            btnQuit.UseVisualStyleBackColor = true;
            btnQuit.Click += btnQuit_Click;
            // 
            // lblGuess
            // 
            lblGuess.AutoSize = true;
            lblGuess.Location = new Point(22, 377);
            lblGuess.Name = "lblGuess";
            lblGuess.Size = new Size(87, 15);
            lblGuess.TabIndex = 5;
            lblGuess.Text = "Correct Letters:";
            // 
            // hmPB
            // 
            hmPB.Location = new Point(303, 166);
            hmPB.Name = "hmPB";
            hmPB.Size = new Size(149, 187);
            hmPB.SizeMode = PictureBoxSizeMode.StretchImage;
            hmPB.TabIndex = 6;
            hmPB.TabStop = false;
            hmPB.UseWaitCursor = true;
            // 
            // cbWordLists
            // 
            cbWordLists.FormattingEnabled = true;
            cbWordLists.Location = new Point(343, 482);
            cbWordLists.Name = "cbWordLists";
            cbWordLists.Size = new Size(121, 23);
            cbWordLists.TabIndex = 7;
            cbWordLists.SelectedIndexChanged += cbWordLists_SelectedIndexChanged;
            // 
            // btnNewGame
            // 
            btnNewGame.Location = new Point(235, 482);
            btnNewGame.Name = "btnNewGame";
            btnNewGame.Size = new Size(75, 23);
            btnNewGame.TabIndex = 8;
            btnNewGame.Text = "New Game";
            btnNewGame.UseVisualStyleBackColor = true;
            btnNewGame.Click += btnNewGame_Click;
            // 
            // lblgameWon
            // 
            lblgameWon.AutoSize = true;
            lblgameWon.Location = new Point(25, 166);
            lblgameWon.Name = "lblgameWon";
            lblgameWon.Size = new Size(74, 15);
            lblgameWon.TabIndex = 9;
            lblgameWon.Text = "Games Won:";
            // 
            // lblgameLost
            // 
            lblgameLost.AutoSize = true;
            lblgameLost.Location = new Point(22, 199);
            lblgameLost.Name = "lblgameLost";
            lblgameLost.Size = new Size(71, 15);
            lblgameLost.TabIndex = 10;
            lblgameLost.Text = "Games Lost:";
            // 
            // lblNumGameWon
            // 
            lblNumGameWon.AutoSize = true;
            lblNumGameWon.Location = new Point(99, 166);
            lblNumGameWon.Name = "lblNumGameWon";
            lblNumGameWon.Size = new Size(0, 15);
            lblNumGameWon.TabIndex = 11;
            // 
            // lblNumGameLost
            // 
            lblNumGameLost.AutoSize = true;
            lblNumGameLost.Location = new Point(99, 199);
            lblNumGameLost.Name = "lblNumGameLost";
            lblNumGameLost.Size = new Size(0, 15);
            lblNumGameLost.TabIndex = 12;
            // 
            // winCount
            // 
            winCount.AutoSize = true;
            winCount.Location = new Point(112, 166);
            winCount.Name = "winCount";
            winCount.Size = new Size(0, 15);
            winCount.TabIndex = 13;
            // 
            // lostCount
            // 
            lostCount.AutoSize = true;
            lostCount.Location = new Point(114, 201);
            lostCount.Name = "lostCount";
            lostCount.Size = new Size(0, 15);
            lostCount.TabIndex = 14;
            // 
            // lblGuessedLetters
            // 
            lblGuessedLetters.AutoSize = true;
            lblGuessedLetters.Location = new Point(128, 377);
            lblGuessedLetters.Name = "lblGuessedLetters";
            lblGuessedLetters.Size = new Size(0, 15);
            lblGuessedLetters.TabIndex = 15;
            // 
            // lblWrongLetter
            // 
            lblWrongLetter.AutoSize = true;
            lblWrongLetter.Location = new Point(22, 407);
            lblWrongLetter.Name = "lblWrongLetter";
            lblWrongLetter.Size = new Size(84, 15);
            lblWrongLetter.TabIndex = 16;
            lblWrongLetter.Text = "Wrong Letters:";
            // 
            // lblWrongGussed
            // 
            lblWrongGussed.AutoSize = true;
            lblWrongGussed.Location = new Point(128, 407);
            lblWrongGussed.Name = "lblWrongGussed";
            lblWrongGussed.Size = new Size(0, 15);
            lblWrongGussed.TabIndex = 17;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 595);
            Controls.Add(lblWrongGussed);
            Controls.Add(lblWrongLetter);
            Controls.Add(lblGuessedLetters);
            Controls.Add(lostCount);
            Controls.Add(winCount);
            Controls.Add(lblNumGameLost);
            Controls.Add(lblNumGameWon);
            Controls.Add(lblgameLost);
            Controls.Add(lblgameWon);
            Controls.Add(btnNewGame);
            Controls.Add(cbWordLists);
            Controls.Add(hmPB);
            Controls.Add(lblGuess);
            Controls.Add(btnQuit);
            Controls.Add(btnSubmit);
            Controls.Add(txtGuess);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)hmPB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtGuess;
        private Button btnSubmit;
        private Button btnQuit;
        private Label lblGuess;
        private PictureBox hmPB;
        private ComboBox cbWordLists;
        private Button btnNewGame;
        private Label lblgameWon;
        private Label lblgameLost;
        private Label lblNumGameWon;
        private Label lblNumGameLost;
        private Label winCount;
        private Label lostCount;
        private Label lblGuessedLetters;
        private Label lblWrongLetter;
        private Label lblWrongGussed;
    }
}
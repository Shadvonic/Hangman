using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace hangman
{
    public partial class Form1 : Form
    {
        private string wordToGuess;
        private List<Label> labels = new List<Label>();
        private int wrongGuesses = 0;
        private string path;
        private Image[] hangmanImages;
        private int numCorrectGuesses = 0;
        private List<string> wordList;
        private List<string> usedWords = new List<string>(); // declare a list to store used words


        public Form1()
        {
            InitializeComponent();

            path = "C:\\Users\\moxey\\Desktop\\Cs234\\Hangman-images\\";
            //path = "C:\\Users\\moxey\\Desktop\\Cs234\\Hangman-images\\";
            hangmanImages = new Image[]
            {
            Image.FromFile(path + "hang1.gif"),
            Image.FromFile(path + "hang2.gif"),
            Image.FromFile(path + "hang3.gif"),
            Image.FromFile(path + "hang4.gif"),
            Image.FromFile(path + "hang5.gif"),
            Image.FromFile(path + "hang6.gif"),
            Image.FromFile(path + "hang7.gif")
            };

            // Load the word list files into memory
            LoadWordLists();

            // Display the word lists in the combo box
            foreach (string file in Directory.GetFiles(path, "*.txt"))
            {
                cbWordLists.Items.Add(Path.GetFileName(file));
            }

            // Display the initial hangman image
            hmPB.SizeMode = PictureBoxSizeMode.StretchImage;
            hmPB.Image = hangmanImages[0];
        }

        private void LoadWordLists()
        {
            string[] wordListFiles = {
         "C:\\Users\\moxey\\Desktop\\Cs234\\Hangman-wordlist\\words_0020.txt",
        "C:\\Users\\moxey\\Desktop\\Cs234\\Hangman-wordlist\\words_0100.txt"
            };
            foreach (string file in wordListFiles)
            {
                string selectedFilePath = Path.Combine(file);
                if (!File.Exists(selectedFilePath))
                {
                    MessageBox.Show("File not found: " + selectedFilePath);
                    continue;
                }
                wordList = new List<string>();
                wordList.AddRange(File.ReadAllLines(selectedFilePath));
                cbWordLists.Items.Add(Path.GetFileName(file));
            }
        }


        private void cbWordLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFileName = cbWordLists.SelectedItem.ToString();
            string selectedFilePath = Path.Combine("C:\\Users\\moxey\\Desktop\\Cs234\\Hangman-wordlist", selectedFileName);
            wordList = File.ReadAllLines(selectedFilePath).ToList();

            // Clear the labels list and reset the game counters
            labels.Clear();
            numCorrectGuesses = 0;
            wrongGuesses = 0;
            winCount.Text = "0";
            lostCount.Text = "0";

            Random rand = new Random();
            List<string> filteredWords = wordList.Where(w => !w.Contains(" ")).Except(usedWords).ToList(); // exclude used words
            if (filteredWords.Count == 0) // if all words have been used, reset the list
            {
                usedWords.Clear();
                filteredWords = wordList.Where(w => !w.Contains(" ")).ToList();
            }
            wordToGuess = filteredWords[rand.Next(filteredWords.Count)];
            usedWords.Add(wordToGuess); // add the word to the used words list

            // Generate the correct number of labels on the form, based on the word to be guessed
            int labelWidth = 15; // adjust this as needed
            int padding = 10; // adjust this as needed
            int x = (this.ClientSize.Width - (wordToGuess.Length * (labelWidth + padding))) / 2;

            for (int i = 0; i < wordToGuess.Length; i++)
            {


                Label label = new Label();
                label.Location = new Point(x, 100);
                if (wordToGuess[i] == ' ')
                {
                    label.Text = " ";

                }
                else
                {
                    label.Text = "_";
                }

                label.Parent = this;
                label.Font = new Font("Arial", 16);
                label.AutoSize = false;
                label.Size = new Size(labelWidth, label.Height); // set the label size
                label.TextAlign = ContentAlignment.MiddleCenter; // center the label text
                labels.Add(label);

                x += labelWidth + padding * 2;
            }


            // Reset the hangman image and enable the submit button
            hmPB.Image = hangmanImages[0];
            btnSubmit.Enabled = true;
        }



        private void TxtGuess_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the entered character is a letter and the length of the TextBox is not greater than 1
            if (!char.IsLetter(e.KeyChar) || txtGuess.Text.Length >= 1)
            {
                // Indicate that the event is handled and the character should not be added to the TextBox
                e.Handled = true;
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtGuess.Text.Length == 1)
            {
                string guess = txtGuess.Text.ToLower();
                if (!wordToGuess.Contains(guess))
                {
                    // Incorrect guess
                    wrongGuesses++;
                    hmPB.Image = hangmanImages[wrongGuesses];

                    // Display the incorrect guess in red color
                    lblWrongGussed.Text += guess.ToUpper() + " ";
                    lblWrongGussed.ForeColor = Color.Red;
                }
                else
                {
                    // Correct guess
                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuess[i] == guess[0])
                        {
                            if (wordToGuess[i] == ' ')
                            {
                                continue; // Skip the iteration for space character
                            }
                            if (i >= labels.Count)
                            {
                                break; // Exit the loop if index is out of range
                            }
                            labels[i].Text = guess;
                            numCorrectGuesses++;
                        }
                    }
                    // Display the correct guess in green color
                    lblGuessedLetters.Text += guess.ToUpper() + " ";
                    lblGuessedLetters.ForeColor = Color.Green;
                }

                // Check game over conditions
                if (numCorrectGuesses == wordToGuess.Length)
                {
                    // Increase the number of games won and display it
                    int numGamesWon = int.Parse(winCount.Text);
                    numGamesWon++;
                    winCount.Text = numGamesWon.ToString();

                    MessageBox.Show("Congratulations! You guessed the word.");
                    btnSubmit.Enabled = false;
                }
                else if (wrongGuesses >= hangmanImages.Length - 1)
                {
                    // Increase the number of games lost and display it
                    int numGamesLost = int.Parse(lostCount.Text);
                    numGamesLost++;
                    lostCount.Text = numGamesLost.ToString();

                    MessageBox.Show("Game over! You ran out of guesses. The word was: " + wordToGuess.ToUpper());
                    btnSubmit.Enabled = false;
                }

                // Clear the guess textbox and give it focus
                txtGuess.Clear();
                txtGuess.Focus();
            }
            else
            {
                MessageBox.Show("Please enter only one letter.");
            }
        }




        private void btnNewGame_Click(object sender, EventArgs e)
        {
            try
            {
                // Load a new word to be guessed
                Random rand = new Random();
                List<string> filteredWords = wordList.Where(w => !w.Contains(" ")).ToList();
                wordToGuess = filteredWords[rand.Next(filteredWords.Count)];

                // Clear the previous labels
                foreach (Label label in labels)
                {
                    label.Dispose();
                }
                labels.Clear();

                // Generate new labels for the new word to guess
                int labelWidth = 20; // adjust this as needed
                int padding = 5; // adjust this as needed
                int x = (this.ClientSize.Width - (wordToGuess.Length * (labelWidth + padding))) / 2;

                for (int i = 0; i < wordToGuess.Length; i++)
                {


                    Label label = new Label();
                    label.Location = new Point(x, 100);
                    if (wordToGuess[i] == ' ')
                    {
                        label.Text = " ";

                    }
                    else
                    {
                        label.Text = "_";
                    }

                    label.Parent = this;
                    label.Font = new Font("Arial", 16);
                    label.AutoSize = false;
                    label.Size = new Size(labelWidth, label.Height); // set the label size
                    label.TextAlign = ContentAlignment.MiddleCenter; // center the label text
                    labels.Add(label);

                    x += labelWidth + padding * 2;
                }

                // Reset the game counters
                wrongGuesses = 0;
                numCorrectGuesses = 0;
                lblGuessedLetters.Text = "";
                hmPB.Image = hangmanImages[0];

                // Enable the submit button
                btnSubmit.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void LoadWordToGuess()
        {
            // Load the list of words from the selected file
            List<string> wordList = new List<string>();
            string selectedFile = cbWordLists.SelectedItem.ToString();

            try
            {
                wordList = File.ReadAllLines(selectedFile).ToList();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error reading word list file: " + ex.Message);
                return;
            }

            // Remove any words that have already been guessed
            wordList.RemoveAll(w => w.Equals(wordToGuess));

            // If all words have been guessed, reset the list
            if (wordList.Count == 0)
            {
                wordList = File.ReadAllLines(selectedFile).ToList();
            }

            // Randomly select a new word to be guessed
            wordToGuess = wordList[new Random().Next(wordList.Count)];

            // Generate the correct number of labels on the form, based on the new word to be guessed.
            labels.Clear();
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                Label label = new Label();
                label.Location = new Point(30 * i + 10, 100);
                label.Font = new Font("Arial", 20, FontStyle.Bold);
                label.AutoSize = false;
                label.Size = new Size(30, 30);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BackColor = Color.White;
                label.BorderStyle = BorderStyle.FixedSingle;
                if (wordToGuess[i] == ' ')
                {
                    label.Text = " ";

                }
                else
                {
                    label.Text = "_";
                }
                labels.Add(label);
                this.Controls.Add(label);
            }
        }




        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtGuess_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
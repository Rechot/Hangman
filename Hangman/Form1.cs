using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Form1 : Form
    {
        //Properties
        //Below properties cannot be public for some reason.
        string word;
        int missCount = 0;

        public Form1()
        {
            InitializeComponent();
            pickRandomWord();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( missCount < 5)
            {
                string letter = textBox1.Text; // interesting ?, no try catch ?
                textBox1.Text = null;
                bool guessRight = false;
                int guessPlacement = 0;

                // We have words of 9 letters only, no more, no less. First and last are already shown to make it easier.
                for (int i = 1; i < 8; i++)
                {
                    if (Convert.ToString(word[i]) == letter)
                    {
                        guessRight = true;
                        guessPlacement = i;

                        switch (guessPlacement)
                        {
                            case 1:
                                label2.Text = letter;
                                break;
                            case 2:
                                label3.Text = letter;
                                break;
                            case 3:
                                label4.Text = letter;
                                break;
                            case 4:
                                label5.Text = letter;
                                break;
                            case 5:
                                label6.Text = letter;
                                break;
                            case 6:
                                label7.Text = letter;
                                break;
                            case 7:
                                label8.Text = letter;
                                break;
                            default:
                                Console.WriteLine("Something has gone terribly wrong ...");
                                break;
                        }
                    }

                }

                if (!guessRight)
                {
                    missCount += 1;
                    switch (missCount)
                    {
                        case 1:
                            pictureBox1.Image = Hangman.Properties.Resources.hangman01;
                            break;
                        case 2:
                            pictureBox1.Image = Hangman.Properties.Resources.hangman02;
                            break;
                        case 3:
                            pictureBox1.Image = Hangman.Properties.Resources.hangman03;
                            break;
                        case 4:
                            pictureBox1.Image = Hangman.Properties.Resources.hangman04;
                            break;
                        case 5:
                            pictureBox1.Image = Hangman.Properties.Resources.hangman05;
                            break;
                        case 6:
                            pictureBox1.Image = Hangman.Properties.Resources.hangman06;
                            break;
                        default:
                            Console.WriteLine("Something has gone terribly wrong ...");
                            break;
                    }
                }

                youWin();
            } else
            {
                youLoose();
            }
        }

        private void pickRandomWord()
        {
            string[] words = { "marchewka", "platforma", "filologia", "krakersik", "franczyza", "patologia",
                            "konstrukt", "elektryka", "naleśniki", "buraczana", "łososiowy", };
            // Each word above in polish has to have exactly 9 letters, no more, no less.
            int wordsAmount = words.Length;

            Random randomGenerator = new Random();
            int randomWordsIndex = randomGenerator.Next(0, wordsAmount - 1);

            word = words[randomWordsIndex];
            //Showing the first and the last letter, so the game can be a bit easier.
            label1.Text = Convert.ToString(word[0]);
            label9.Text = Convert.ToString(word[8]);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void youWin() // This NEEDS some serious refactor! Some collection and foreach loop ?
        {
            if( label2.Text != "_")
            {
                if (label3.Text != "_")
                {
                    if (label4.Text != "_")
                    {
                        if (label5.Text != "_")
                        {
                            if (label6.Text != "_")
                            {
                                if (label7.Text != "_")
                                {
                                    if (label8.Text != "_")
                                    {
                                        pictureBox1.Image = Hangman.Properties.Resources.Victory;
                                        button1.Visible = false;
                                        button2.Visible = true;

                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        private void youLoose()
        {
            pictureBox1.Image = Hangman.Properties.Resources.TheEnd;
            button1.Visible = false;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pickRandomWord();

            label2.Text = "_";
            label3.Text = "_";
            label4.Text = "_";
            label5.Text = "_";
            label6.Text = "_";
            label7.Text = "_";
            label8.Text = "_";

            missCount = 0;

            button1.Visible = true;
            button2.Visible = false;
            pictureBox1.Image = Hangman.Properties.Resources.hangman01;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        //List that contains field combinations that would win you the game
        List<Combination> Combinations = new List<Combination>();

        List<int> Player1Inventory = new List<int>();
        List<int> Player2Inventory = new List<int>();

        //Random class used for the initial step of the AI.
        Random random = new Random();


        private bool Player2FirstTurn
        {
            get
            {
                if (Player2Inventory.Count > 0)
                    return false;
                else
                    return true;
            }
        }

        private Players _turn;
        public Players Turn
        {
            get { return _turn; }
            set
            {
                _turn = value;
            }
        }

        public Form1()
        {
            //Initialize winning combo list
            AddCombinationsToList();
            InitializeComponent();
        }

        private void AddCombinationsToList()
        {
            //Horizontal wins
            Combinations.Add(new Combination { first = 0, second = 1, third = 2 });
            Combinations.Add(new Combination { first = 3, second = 4, third = 5 });
            Combinations.Add(new Combination { first = 6, second = 7, third = 8 });
            //Vertical wins
            Combinations.Add(new Combination { first = 0, second = 3, third = 6 });
            Combinations.Add(new Combination { first = 1, second = 4, third = 7 });
            Combinations.Add(new Combination { first = 2, second = 5, third = 8 });

            //Diagonal win
            Combinations.Add(new Combination { first = 0, second = 4, third = 8 });
            Combinations.Add(new Combination { first = 2, second = 4, third = 6 });
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Turn = Players.Player2;
            AIMakeMove();
        }


        public struct Combination
        {
            public int first { get; set; }
            public int second { get; set; }
            public int third { get; set; }
        }

        private void FieldClicked(object sender, EventArgs e)
        {
            if (Turn == Players.Player1)
            {
                (sender as Button).Text = "X";
                (sender as Button).Enabled = false;
                Player1Inventory.Add(int.Parse((sender as Button).Name.Substring(1, 1)));
                Turn = Players.Player2;
                PlayingField.Enabled = false;

                if (!CheckForWins())
                {
                    AIMakeMove();
                }
            }
            else if (Turn == Players.Player2)
            {
                (sender as Button).Text = "O";
                (sender as Button).Enabled = false;
                Player2Inventory.Add(int.Parse((sender as Button).Name.Substring(1, 1)));
                Turn = Players.Player1;
                PlayingField.Enabled = true;
            }


            CheckForWins();
            CheckForDraws();
        }

        private bool CheckForWins()
        {
            foreach (var combination in Combinations)
            {
                if (Player1Inventory.Contains(combination.first) && Player1Inventory.Contains(combination.second) && Player1Inventory.Contains(combination.third))
                {
                    MessageBox.Show("Player 1 wins!");
                    player1Score.Text = (int.Parse(player1Score.Text) + 1).ToString();
                    ResetGame();
                    return true;
                }
                if (Player2Inventory.Contains(combination.first) && Player2Inventory.Contains(combination.second) && Player2Inventory.Contains(combination.third))
                {
                    MessageBox.Show("Player 2 wins!");
                    player2Score.Text = (int.Parse(player2Score.Text) + 1).ToString();
                    ResetGame();
                    return true;
                }
            }
            return false;
        }

        private void CheckForDraws()
        {
            if(Player1Inventory.Count + Player2Inventory.Count == 9)
            {
                MessageBox.Show("Draw!");
                drawScore.Text = (int.Parse(drawScore.Text) + 1).ToString();
                ResetGame();
            }
        }

        private async void AIMakeMove()
        {
            PlayingField.Enabled = false;

            //Add a delay to make it feel a bit more realistic
            await Task.Delay(1000);

            if(!Player2FirstTurn)
            {
                //AI Checks if I am close to a combination
                if (Player2Inventory.Count > 1)
                {
                    foreach (var combination in Combinations)
                    {
                        int neroticy = 0;
                        if (Player2Inventory.Contains(combination.first))
                        {
                            neroticy++;
                        }

                        if (Player2Inventory.Contains(combination.second))
                        {
                            neroticy++;
                        }

                        if (Player2Inventory.Contains(combination.third))
                        {
                            neroticy++;
                        }

                        if (neroticy == 2)
                        {
                            //Get the buttons that opponent needs to combo out.
                            Button[] buttons = PlayingField.Controls.Cast<Button>().Where(f =>
                                f.Name.Contains(combination.first.ToString()) ||
                                f.Name.Contains(combination.second.ToString()) ||
                                f.Name.Contains(combination.third.ToString())).ToArray();

                            Button button;

                            //Make sure the tile is free
                            button = buttons.Where(f => f.Text == "").FirstOrDefault();

                            if (button != null)
                            {
                                PlayingField.Enabled = true;
                                button.PerformClick();
                                return;
                            }
                        }
                    }
                }

                if (Player1Inventory.Count > 1) //AI Checks if opponent is close to a combination
                {
                    foreach (var combination in Combinations)
                    {
                        int neroticy = 0;

                        if (Player1Inventory.Contains(combination.first))
                        {
                            neroticy++;
                        }

                        if (Player1Inventory.Contains(combination.second))
                        {
                            neroticy++;
                        }

                        if (Player1Inventory.Contains(combination.third))
                        {
                            neroticy++;
                        }

                        if (neroticy == 2)
                        {
                            //Get the buttons that opponent needs to combo out.
                            Button[] buttons = PlayingField.Controls.Cast<Button>().Where(f =>
                                f.Name.Contains(combination.first.ToString()) ||
                                f.Name.Contains(combination.second.ToString()) ||
                                f.Name.Contains(combination.third.ToString())).ToArray();

                            Button button;

                            //Make sure the tile is free
                            button = buttons.Where(f => f.Text == "").FirstOrDefault();

                            if (button != null)
                            {
                                PlayingField.Enabled = true;
                                button.PerformClick();
                                return;
                            }
                        }
                    }
                }
            }
            //Perform a regular move
            Button btn;
            while (true)
            {
                int num = random.Next(0, 8);
                btn = PlayingField.Controls.Cast<Button>().Where(f => f.Name.Contains(num.ToString())).FirstOrDefault();
                if (btn.Text == "X" || (btn.Text == "O"))
                    continue;
                else
                    break;
            }
            PlayingField.Enabled = true;
            btn.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void ResetGame()
        {
            foreach (Button button in PlayingField.Controls)
            {
                button.Text = "";
                button.Enabled = true;
            }

            Player1Inventory.Clear();
            Player2Inventory.Clear();

            Turn = Players.Player2;
            AIMakeMove();
        }
    }

    public enum Players
    {
        Player1,
        Player2
    }
}

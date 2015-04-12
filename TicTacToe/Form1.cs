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
        int[] Corners = new int[] { 0, 2, 6, 8 };
        int[] Edges = new int[] { 1, 3, 5, 7 };

        List<int> Player1Inventory = new List<int>();
        List<int> Player2Inventory = new List<int>();

        Dictionary<int, int> CornerOpposites = new Dictionary<int, int>();

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
        private int Player2TurnCount
        {
            get
            {
                return Player2Inventory.Count() + 1;
            }
        }
        private GameMode Gamemode { get; set; }
        private int Player2CornersOwned
        {
            get
            {
                int count = 0;

                foreach (int x in Corners)
                {
                    if (Player2Inventory.Contains(x))
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        private int PlayerCornersOwned(Players player)
        {
            if (player == Players.Player1)
            {
                int count = 0;
                foreach (int x in Corners)
                {
                    if (Player1Inventory.Contains(x))
                    {
                        count++;
                    }
                }
                return count;
            }
            else
            {
                int count = 0;
                foreach (int x in Corners)
                {
                    if (Player2Inventory.Contains(x))
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        private int PlayerEdgesOwned(Players player)
        {
            if (player == Players.Player1)
            {
                int count = 0;
                foreach (int x in Edges)
                {
                    if (Player1Inventory.Contains(x))
                    {
                        count++;
                    }
                }
                return count;
            }
            else
            {
                int count = 0;
                foreach (int x in Edges)
                {
                    if (Player2Inventory.Contains(x))
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        private int Player1EdgesOwned
        {
            get
            {
                int count = 0;

                foreach (int x in Corners)
                {
                    if (Player2Inventory.Contains(x))
                    {
                        count++;
                    }
                }
                return count;
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
            //Initialize lists
            AddCombinationsToList();
            AddOppositesToList();
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
        private void AddOppositesToList()
        {
            CornerOpposites.Add(0, 8);
            CornerOpposites.Add(2, 6);
            CornerOpposites.Add(6, 2);
            CornerOpposites.Add(8, 0);
        }
        private int GetOppositeOfCorner(int corner)
        {
            return CornerOpposites[corner];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Gamemode = GameMode.PlayervsPC;
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

                if (Gamemode == GameMode.PlayervsPC)
                {
                    PlayingField.Enabled = false;

                    if (!CheckForWins())
                    {
                        AIMakeMove();
                    }
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
            if (Player1Inventory.Count + Player2Inventory.Count == 9)
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

            //Prioritize these steps
            if (CloseMyWin())
                return;
            if (BlockFromWin())
                return;

            //On first turn
            if (Player2TurnCount == 1)
            {
                //Always start on a corner
                int move = Corners[random.Next(0, 4)];

                PlayingField.Enabled = true;
                PlayingField.Controls.Cast<Button>().Where(f => f.Name.Contains(move.ToString())).FirstOrDefault().PerformClick();
                return;
            }

            //On second turn
            if (Player2TurnCount == 2 || Player2TurnCount == 3 || Player2TurnCount == 4)
            {
                //Opponent made a corner move
                if (PlayerCornersOwned(Players.Player1) > 0)
                {
                    MakeCornerMove();
                    return;
                }

                //Opponent made the middle move
                if (Player1Inventory.Contains(4))
                {
                    if (Player1Inventory.Contains(0) || Player1Inventory.Contains(2) || Player1Inventory.Contains(6) || Player1Inventory.Contains(8))
                    {
                        PlayingField.Enabled = true;
                        PlayingField.Controls.Cast<Button>().Where(f => f.Name.Contains(GetOppositeOfCorner(Player1Inventory[1]).ToString())).FirstOrDefault().PerformClick();
                        return;
                    }

                    PlayingField.Enabled = true;
                    PlayingField.Controls.Cast<Button>().Where(f => f.Name.Contains(GetOppositeOfCorner(Player2Inventory[0]).ToString())).FirstOrDefault().PerformClick();
                    return;
                }

                //Opponent made edge move on first turn (Opponent will lose badly..)
                if (PlayerHasEdge && Player2TurnCount == 2)
                {
                    //Holds the move that will be set based on the decision the AI makes
                    int move = 0;

                    #region Long switch statement that allows the computer to win instantaneously if player 2 starts out on an edge block
                    switch (Player1Inventory[0])
                    {
                        case 1:
                            if (Player2Inventory[0] == 0)
                            {
                                move = 6;
                            }
                            else if (Player2Inventory[0] == 2)
                            {
                                move = 8;
                            }
                            else if (Player2Inventory[0] == 6)
                            {
                                move = 8;
                            }
                            else if (Player2Inventory[0] == 8)
                            {
                                move = 6;
                            }
                            break;

                        case 3:
                            if (Player2Inventory[0] == 0)
                            {
                                move = 2;
                            }
                            else if (Player2Inventory[0] == 2)
                            {
                                move = 8;
                            }
                            else if (Player2Inventory[0] == 6)
                            {
                                move = 8;
                            }
                            else if (Player2Inventory[0] == 8)
                            {
                                move = 2;
                            }
                            break;

                        case 5:
                            if (Player2Inventory[0] == 0)
                            {
                                move = 6;
                            }
                            else if (Player2Inventory[0] == 2)
                            {
                                move = 0;
                            }
                            else if (Player2Inventory[0] == 6)
                            {
                                move = 0;
                            }
                            else if (Player2Inventory[0] == 8)
                            {
                                move = 6;
                            }
                            break;

                        case 7:
                            if (Player2Inventory[0] == 0)
                            {
                                move = 2;
                            }
                            else if (Player2Inventory[0] == 2)
                            {
                                move = 0;
                            }
                            else if (Player2Inventory[0] == 6)
                            {
                                move = 0;
                            }
                            else if (Player2Inventory[0] == 8)
                            {
                                move = 2;
                            }
                            break;
                    }
                    #endregion

                    PlayingField.Enabled = true;
                    PlayingField.Controls.Cast<Button>().Where(f => f.Name.Contains(move.ToString())).FirstOrDefault().PerformClick();
                    return;
                }
            }

            if(Player2TurnCount == 3)
            {
                //If player1's first two moves were an edge move, make an opposite corner move
                if(PlayerEdgesOwned(Players.Player1) > 1)
                {
                    PlayingField.Enabled = true;
                    PlayingField.Controls.Cast<Button>().Where(f => f.Name.Contains(4.ToString())).FirstOrDefault().PerformClick();
                    return;
                }
            }

            MakeCornerMove();
            return;
        }
        private bool PlayerHasEdge
        {
            get
            {
                foreach (int i in Edges)
                    if (Player1Inventory.Contains(i))
                        return true;

                return false;
            }
        }
        private void MakeRandomMove()
        {
            //Perform a regular move
            Button btn;
            while (true)
            {
                int num = random.Next(0, 9);
                btn = PlayingField.Controls.Cast<Button>().Where(f => f.Name.Contains(num.ToString())).FirstOrDefault();
                if (btn.Text == "X" || (btn.Text == "O"))
                    continue;
                else
                    break;
            }
            PlayingField.Enabled = true;
            btn.PerformClick();
        }
        private void MakeCornerMove()
        {
            Button bt;
            while (true)
            {
                int move = Corners[random.Next(0, 4)];
                bt = PlayingField.Controls.Cast<Button>().Where(f => f.Name.Contains(move.ToString())).FirstOrDefault();
                if (bt.Text == "X" || (bt.Text == "O"))
                    continue;
                else
                    break;
            }

            PlayingField.Enabled = true;
            bt.PerformClick();
        }
        private bool CloseMyWin()
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
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        private bool BlockFromWin()
        {
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
                            return true;
                        }
                    }
                }
            }
            return false;
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

            if (Gamemode == GameMode.PlayervsPC)
            {
                AIMakeMove();
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            Gamemode = GameMode.PlayervsPlayer;
            ResetGame();
            button1.Enabled = false;

            //Avoid game mode switch spam shennanigans
            await Task.Delay(2000);
            button2.Enabled = true;
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            Gamemode = GameMode.PlayervsPC;
            ResetGame();
            button2.Enabled = false;

            //Avoid game mode switch spam shennanigans
            await Task.Delay(2000);
            button1.Enabled = true;
        }
    }
    public enum Players
    {
        Player1,
        Player2
    }
    public enum GameMode
    {
        PlayervsPC,
        PlayervsPlayer,
    }
}

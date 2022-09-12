using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows;
using System.Linq;

namespace Spellendoos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Start the creation of the List of players which will be used in the games
        List<Player> players = new List<Player>();

        public MainWindow()
        {
            SplashScreen sp = new SplashScreen("Assets/SplashScreen.jpg");
            InitializeComponent();
            sp.Show(true);
        }

        /// <summary>
        /// Use the text 'from the UI's textboxes to fill in the list of players
        /// </summary>
        public void StartButton_Click(object sender, RoutedEventArgs e)
        {

            string p1 = playerName1.Text;
            string p2 = playerName2.Text;
            string p3 = playerName3.Text;
            string p4 = playerName4.Text;

            string[] playernames = new string[] { p1, p2, p3, p4 };

            if (playernames.All(playername => isInvalidName(playername))) 
            {
                Player pl1 = new Player(p1);
                Player pl2 = new Player(p2);
                Player pl3 = new Player(p3);
                Player pl4 = new Player(p4);

                this.players.Add(pl1);
                this.players.Add(pl2);
                this.players.Add(pl3);
                this.players.Add(pl4);

                //Show the players participating and go to the gameselector screen
                MessageBox.Show($"Spelers {playerName1.Text}, {playerName2.Text}, {playerName3.Text}, {playerName4.Text} gaan een spel starten, Veel plezier!");
                GameSelector gs = new GameSelector(players);
                this.Visibility = Visibility.Hidden;
                gs.Show();
            }
            else {
                MessageBox.Show("Niet alle namen bevatten alleen letters of nummers!");
            }
        }

        public bool isInvalidName(string playername) 
        {
            //Check whether the player name is invalid, as in it uses more than letters and characters
            if (Regex.IsMatch(playername, @"^[a-zA-Z0-9]+$"))
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        public static List<Player> getPlayers()
        {
            MainWindow mw = new MainWindow();
            List<Player> players = mw.players;

            return players;
        }
    }
}

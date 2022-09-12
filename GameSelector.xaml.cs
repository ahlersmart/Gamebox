using Spellendoos.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Spellendoos
{
    /// <summary>
    /// Interaction logic for GameSelector.xaml
    /// </summary>
    public partial class GameSelector : Window
    {
        public List<Player> players;

        public GameSelector(List<Player> players)
        {
            InitializeComponent();
            this.players = players;

        }

        //closes the program
        private void Quit_Btn_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(1);
        }

        //Opens the options menu
        private void Options_Btn_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //start a Yathzee game
        public void Start_Yahtzee_Click(object sender, RoutedEventArgs e)
        {
            YahtzeeUI ytz = new YahtzeeUI(players);
            this.Visibility = Visibility.Hidden;
            ytz.Show();
        }

        //opens the score window
        private void Score_Btn_Click(object sender, RoutedEventArgs e)
        {
            ScoreWindow sw = new ScoreWindow(players);
            this.Visibility = Visibility.Hidden;
            sw.Show();
        }

        //start a game of Mens Erger Je Niet
        private void Start_MEJN_Click(object sender, RoutedEventArgs e)
        {
            ///MensErgerJeNietUI MEJNUI = new MensErgerJeNietUI("Mens erger je niet", players);
            ///MensErgerJeNiet MEJN = new MensErgerJeNiet("Mens erger je niet", players, 44);
            ///MEJNUI.Show();
        }

        //return players list
        public List<Player> GetPlayers()
        {
            return players;
        }
    }
}

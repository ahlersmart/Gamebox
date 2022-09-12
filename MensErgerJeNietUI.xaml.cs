using Spellendoos.Classes;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Spellendoos
{
    /// <summary>
    /// Interaction logic for MensErgerJeNietUI.xaml
    /// This XAML file is not used at the moment but is intended for later usage
    /// </summary>
    public partial class MensErgerJeNietUI : Window
    {
        private MensErgerJeNietWithUI MEJN;
        private string playerName;

        public MensErgerJeNietUI(List<Player> players)
        {
            //this
            playerName = "test";

            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void Throw_dice_Click(object sender, RoutedEventArgs e)
        {

        }

        private void quit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
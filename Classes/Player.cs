using System;
using System.Windows.Media;

namespace Spellendoos
{
    public class Player
    {
        public string playerName;
        public int winScore;
        public Color[] colors = new Color[6];
        public Color colour;
        public int random;


        public Player(String name)
        {
            this.playerName = name;
            this.winScore = 0;
            setColour();
        }

        ///return player name
        public string getPlayerName()
        {
            return this.playerName;
        }

        ///set the players name
        public void setPlayerName(string playerName)
        {
            this.playerName = playerName;
        }

        ///return how many times a player has won
        public int getWinScore()
        {
            return this.winScore;
        }

        ///set the score for a player
        public void setWinScore(int winScore)
        {
            this.winScore = winScore;
        }

        ///return the players colour
        public Color getColour()
        {
            return this.colour;
        }

        ///set the players colour
        public void setColour()
        {
            this.colors[0] = Color.FromRgb(255, 0, 0);
            this.colors[1] = Color.FromRgb(255, 255, 0);
            this.colors[2] = Color.FromRgb(0, 0, 255);
            this.colors[3] = Color.FromRgb(0, 128, 0);
            this.colors[4] = Color.FromRgb(255, 0, 255);
            Random randomGenerator = new Random();
            this.random = randomGenerator.Next(0, 4);
            this.colour = colors[this.random];
        }
    }
}

using System.Collections.Generic;

namespace Spellendoos
{
    class Game 
    {
        public List<Player> players;

        ///standard constructor
        public Game(List<Player> players)
        {
            this.players = players;
        }

        ///get all players names
        public void GetPlayersNames(List<Player> players)
        {
            foreach(Player p in players)
            {
                p.getPlayerName();
            }
        }

        ///how many players are there
        public int getPlayerCount(List<Player> players)
        {
            return players.Count;
        }

        ///return the player list
        public List<Player> getList()
        {
            return this.players;
        }
    }
}

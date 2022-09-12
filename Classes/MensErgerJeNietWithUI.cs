using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellendoos.Classes
{
    class MensErgerJeNietWithUI : BoardGame
    {
        private Dictionary<string, int> gameScore;

        public MensErgerJeNietWithUI(string name, List<Player> players)
        {
            this.name = name;
            this.players = players;
            this.score = new int[players.Count];
            this.active = true;
            this.gameScore = new Dictionary<string, int>();

            foreach (Player player in players)
            {
                gameScore.Add(player.playerName, 0);
            }
        }

        public override void EndGame()
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override string GetGameName()
        {
            throw new NotImplementedException();
        }

        public override LinkedList<int> GetGrid()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool IsActive()
        {
            throw new NotImplementedException();
        }

        public override void PlayGame()
        {
            bool onGoing = true;
            int currentTurn = 0;

            while (onGoing)
            {
                if (currentTurn > (players.Count - 1))
                {
                    currentTurn = 0;
                }
                ///Check if turn return false, if it does continue game.
                if (Turn(currentTurn) == false)
                {
                    currentTurn++;
                }
                else
                {
                    onGoing = false;
                }
            }
            Console.WriteLine("Game has Ended.");
        }

        public override void SetGrid(int horizontal, int vertical)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Turn(int playerTurn)
        {
            throw new NotImplementedException();
        }
    }
}

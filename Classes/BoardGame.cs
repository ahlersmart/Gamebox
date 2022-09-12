using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellendoos.Classes
{
    abstract class BoardGame
    {
        ///Name of the game.
        public string name;
        ///Dices in the game.
        public DiceTray dices;
        ///Is the game active
        public bool active;
        ///public int PlayerTurn;
        ///List of players.
        public List<Player> players;
        ///Array of score in the game
        public int[] score;
        ///Grid of the board
        public LinkedList<int> Grid;

        public abstract bool IsActive();
        ///Return a boolean if the game is finished
        public abstract bool Turn(int playerTurn);

        public abstract void PlayGame();

        public abstract void SetGrid(int horizontal, int vertical);

        public abstract LinkedList<int> GetGrid();

        public abstract string GetGameName();

        public abstract void EndGame();

    }
}

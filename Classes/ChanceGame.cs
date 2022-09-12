using Spellendoos.Classes;
using System;
using System.Collections.Generic;

namespace Spellendoos
{
    abstract class ChanceGame
    {
        ///Name of the game.
        public string name;
        ///List of players.
        public List<Player> players;
        ///Dices in the game.
        public DiceTray dices;
        ///Array of score in the game
        public int[] score;
        ///Determines how many actions the player can perform in their turn
        public int maxActionCount;
        ///For checking whether or not the game is supposed to be active.
        public bool active;
        ///Maximum amount of rounds in the game
        public int maxRounds;
        ///Rule list for the game.
        public YahtzeeRules rules;
        ///Score for the game
        public Dictionary<string, int> gameScore;
        public abstract bool IsActive();

        public abstract void Turn(int playerTurn);

        public abstract void PlayGame();
        public abstract void EndGame();
        public abstract string GetGameName();

        public abstract int GetMaxRounds();
    }
}

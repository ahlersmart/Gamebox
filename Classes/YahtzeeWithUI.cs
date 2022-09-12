using Spellendoos.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Spellendoos
{
    class YahtzeeWithUI : ChanceGame
    {

        //Yahtzee version for User Interface
        public YahtzeeWithUI(string name, List<Player> players, int diceAmount, int diceEyeAmount, int maxActionCount, int maxRounds)
        {
            this.name = name;
            this.players = players;
            //Create a dicetray with predetermined amount of dices
            this.dices = new DiceTray(diceAmount, diceEyeAmount);
            //Maximum amount of actions a player can take per turn
            this.maxActionCount = maxActionCount;
            this.score = new int[players.Count];
            this.active = true;
            this.maxRounds = maxRounds;
            this.rules = new YahtzeeRules();
            this.gameScore = new Dictionary<string, int>();

            foreach (Player player in players)
            {
                gameScore.Add(player.playerName, 0);
            }
            
        }

        public override bool IsActive()
        {
            //This method is simply to check whether or not the game is currently active for testing purposes.
            if(active == true)
            {
                Console.WriteLine("Yahtzee is actief!");
                return true;
            }
            else
            {
                Console.WriteLine("Yahtzee is niet actief.");
                return false;
            }
        }

        public int[] RollDice()
        {
            int[] results = dices.RollDices();
            //int for displaying dice number
            int diceNumber = 1;

            foreach (int result in results)
            {
                diceNumber++;
                
            }
            return results;
        }

        //method to color the playername of the player who is currently rolling
        public void playerColor(string playerName)
        {

        }

        //Make known what options the player has to choose from
        public void giveOptions()
        {

        }

        public override void Turn(int playerTurn)
        {
            
            //Get player name so we don't have to constantly call that method
            string playerName = players[playerTurn].getPlayerName();
            //Amount of actions player can still perform
            int actionCount = 0;
            //Score for the player
            int score = 0;
            //int list to store the scores the player selects in.
            List<int> pointStorage = new List<int>();
            //Index for options
            //int optionIndex = 0;
            foreach (KeyValuePair<string, int> gameScore in gameScore) 
            {
                //Show stuff
            }
            while (actionCount < maxActionCount)
            {
                if (actionCount == 0)
                {

                    //Roll the pre-defined dices
                    int [] results = RollDice();
                    //Gives the current player the points that can be earned with the current dicethrow
                    
                    //Dictionary<string, int> options = rules.checkRules(results);
                    pointStorage.Clear();
                    //foreach (KeyValuePair<string, int> option in options)
                    //{
                    //    Console.WriteLine(option.Key);
                    //    Console.WriteLine(option.Value);
                    //    pointStorage.Add(option.Value);
                    //    optionIndex++;
                    //}
                    Console.WriteLine(results.ToString());
                    actionCount++;
                }
                else
                {
                    //Gives the current player the option to keep rollin or end the turn, if the player wants to keep rolling the player can insert which dice to hold
                    Console.WriteLine("Do you wish to continue rolling or end the turn? Y/N");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        Console.WriteLine("Type down the indexes of the dices you wish to hold seperated by commas.");
                        string input = Console.ReadLine().ToString();
                        int[] heldDices = input.Split(',').Select(Int32.Parse).ToArray();
                        int[] results = dices.RollDices(heldDices);
                        int diceNumber = 1;
                        Console.WriteLine("The following results came from the dice rolls:");
                        foreach (int result in results)
                        {
                            Console.WriteLine($"Dice {diceNumber}'s result was {result}.");
                            diceNumber++;
                        }
                        Console.WriteLine("And the following options are possible:");
                        //Dictionary<string, int> options = rules.checkRules(results);
                        //optionIndex = 0;
                        pointStorage.Clear();
                        //foreach (KeyValuePair<string, int> option in options)
                        //{
                        //   Console.WriteLine(option.Key);
                        //    Console.WriteLine(option.Value);
                        //    pointStorage.Add(option.Value);
                        //    optionIndex++;
                        //}
                        Console.WriteLine(results.ToString());
                        actionCount++;
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.N)
                    {
                        Console.WriteLine("Select the index of the score you wish to keep.");
                        string input = Console.ReadLine().ToString();
                        score = pointStorage[Int32.Parse(input)];
                        actionCount += maxActionCount;
                    }
                }
            }
            if (score == 0) 
            {
                Console.WriteLine("LAST CHANCE, Select the index of the score you wish to keep.");
                string input = Console.ReadLine().ToString();
                score = pointStorage[Int32.Parse(input)];
            }
            gameScore[playerName] += score;
            Console.WriteLine("Turn End.");
        }

        /// <summary>
        /// Method continues the game untill all the rounds (usually 5) are completed
        /// This method calls the turn() method to to activate gameplay
        /// </summary>
        public override void PlayGame()
        {
            int roundCount = 1;
            int currentTurn = 0;
            while (roundCount < maxRounds + 1)
            { 
                if (currentTurn > (players.Count - 1))
                {
                    currentTurn = 0;
                    roundCount++;
                }
                //Prevent roundcount from overflowing
                if (roundCount < maxRounds + 1)
                {
                    Console.Write($"Round {roundCount} ");
                    Turn(currentTurn);
                    currentTurn++;
                }
            }
            Console.WriteLine("Game has Ended.");
        }

        public override void EndGame()
        {
            //Close the game.
            active = false;
        }

        public override string GetGameName()
        {
            return name;
        }

        public override int GetMaxRounds()
        {
            return maxRounds;
        }
    }
}

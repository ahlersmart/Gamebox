using Spellendoos.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Spellendoos
{
    class Yahtzee : ChanceGame
    {
        ///Yahtzee version for Command line.
        public Yahtzee(string name, List<Player> players, int diceAmount, int diceEyeAmount, int maxActionCount, int maxRounds)
        {
            this.name = name;
            this.players = players;
            ///Create a dicetray with predetermined amount of dices
            this.dices = new DiceTray(diceAmount, diceEyeAmount);
            ///Maximum amount of actions a player can take per turn
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
            ///This method is simply to check whether or not the game is currently active for testing purposes.
            if (active == true)
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

        public override void Turn(int playerTurn)
        {
            ///Get player name so we don't have to constantly call that method
            string playerName = players[playerTurn].getPlayerName();
            ///Amount of actions player can still perform
            int actionCount = 0;
            ///int for displaying dice number
            int diceNumber = 1;
            ///StringBuilder for neat string creation
            StringBuilder diceResults = new StringBuilder();
            ///Score for the player
            int score = 0;
            ///int list to store the scores the player selects in.
            List<int> pointStorage = new List<int>();
            ///Index for options
            int optionIndex = 0;
            foreach (KeyValuePair<string, int> gameScore in gameScore) 
            {
                ///Print to a gamescore UI
                Console.WriteLine($"Score for {gameScore.Key} is {gameScore.Value}");
            }
            while (actionCount < maxActionCount)
            {
                
                if (actionCount == 0)
                {
                    ///Write to a section of the main game ui where it shows who's turn it is.
                    Console.WriteLine($"It's {playerName}'s turn. Press any key to roll the dice");
                    Console.ReadKey();
                    ///Roll the pre-defined dices
                    int[] results = dices.RollDices();
                    ///This entire thing should be changed to show the results and options in the UI
                    diceResults.AppendLine("The following results came from the dice rolls:");
                    foreach (int result in results)
                    {
                        diceResults.AppendLine($"Dice {diceNumber}'s result was {result}.");
                        diceNumber++;
                    }
                    diceResults.AppendLine("And the following options are possible:");
                    //Dictionary<string, int> options = rules.checkRules(results);
                    pointStorage.Clear();
                    //foreach (KeyValuePair<string, int> option in options)
                    //{
                    //    diceResults.AppendLine($"{option.Key} with a score of {option.Value}.");
                    //    pointStorage.Add(option.Value);
                    //    optionIndex++;
                    //}
                    Console.WriteLine(diceResults.ToString());
                    diceResults.Clear();
                    actionCount++;
                }
                else
                {
                    ///This entire thing should be changed to show the results and options in the UI
                    Console.WriteLine("Do you wish to continue rolling or end the turn? Y/N");
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        Console.WriteLine("Type down the indexes of the dices you wish to hold seperated by commas.");
                        string input = Console.ReadLine().ToString();
                        int[] heldDices = input.Split(',').Select(Int32.Parse).ToArray();
                        int[] results = dices.RollDices(heldDices);
                        diceNumber = 1;
                        diceResults.AppendLine("The following results came from the dice rolls:");
                        foreach (int result in results)
                        {
                            diceResults.AppendLine($"Dice {diceNumber}'s result was {result}.");
                            diceNumber++;
                        }
                        diceResults.AppendLine("And the following options are possible:");
                        //Dictionary<string, int> options = rules.checkRules(results);
                        optionIndex = 0;
                        pointStorage.Clear();
                        //foreach (KeyValuePair<string, int> option in options)
                        //{
                        //    diceResults.AppendLine($"{option.Key} with a score of {option.Value}.");
                        //    pointStorage.Add(option.Value);
                        //    optionIndex++;
                        //}
                        Console.WriteLine(diceResults.ToString());
                        diceResults.Clear();
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
            ///This would be removed as ideally there'd be a check for selecting something in the ui.
            if (score == 0) 
            {
                Console.WriteLine("LAST CHANCE, Select the index of the score you wish to keep.");
                string input = Console.ReadLine().ToString();
                score = pointStorage[Int32.Parse(input)];
            }
            gameScore[playerName] += score;
            Console.WriteLine("Turn End.");
        }

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
                ///Prevent roundcount from overflowing
                if (roundCount < maxRounds + 1)
                {
                    //Display the roundcount in the UI
                    Console.Write($"Round {roundCount}");
                    Turn(currentTurn);
                    currentTurn++;
                }
            }
            Console.WriteLine("Game has Ended.");
        }

        public override void EndGame()
        {
            ///Close the game.
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

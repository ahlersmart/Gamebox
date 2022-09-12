using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spellendoos.Classes
{
    class MensErgerJeNiet : BoardGame
    {
        private int numberOfFields;
        ///String is the player, int[] the array of pawn positions
        private Dictionary<string, int[]> pawnPositions;

        public MensErgerJeNiet(string name, List<Player> players, int numberOfFields)
        {
            this.name = name;
            this.dices = new DiceTray(1, 6);
            this.players = players;

            this.active = true;
            this.numberOfFields = numberOfFields;
            this.Grid = new LinkedList<int>();
            pawnPositions = new Dictionary<string, int[]>();
            //Fill in the dictionairy
            foreach (Player player in players) 
            {
                pawnPositions.Add(player.playerName, new int[4]);
            }
        }

        public override void EndGame()
        {
            ///Close the game.
            active = false;
        }

        public override string GetGameName()
        {
            return this.name;
        }

        public override LinkedList<int> GetGrid()
        {
            throw new NotImplementedException();
        }

        public override bool IsActive()
        {
            ///This method is simply to check whether or not the game is currently active for testing purposes.
            if (active == true)
            {
                Console.WriteLine("Mens erger je niet is actief!");
                return true;
            }
            else
            {
                Console.WriteLine("Mens erger je niet is niet actief.");
                return false;
            }
        }

        public override bool Turn(int playerTurn)
        {
            ///Get player name so we don't have to constantly call that method
            string playerName = players[playerTurn].getPlayerName();
            ///StringBuilder for neat string creation
            StringBuilder sb = new StringBuilder();
            int[] playerPositions = pawnPositions[playerName];
            Console.WriteLine($"It's player {playerName}'s turn");
            ///All checks all elements in the playerpositions Array whether they're all 0.
            if (playerPositions.All(i => i == 0))
            {
                Console.WriteLine("No pawns are on the field, roll a 6 to get a pawn onto the field.");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
                ///Roll the pre-defined dices
                int result = dices.RollDices()[0];
                Console.WriteLine($"You rolled a {result}");
                ///Once the player rolls a 6, a pawn is moved onto the board and they can play proper
                if (result == 6)
                {
                    pawnPositions[playerName][0] = 1;
                    Console.WriteLine("Pawn is on the board. Press a key to roll again and move it.");
                    Console.ReadKey();
                    int moveresult = dices.RollDices()[0];
                    pawnPositions[playerName][0] += moveresult;
                    Console.WriteLine($"You rolled a {moveresult}");
                    Console.WriteLine($"Pawn has moved {moveresult} spaces.");
                    StrikeCheck(playerTurn, 0);
                }
                else
                {
                    Console.WriteLine("Better luck next time!");
                }
            }
            else 
            {
                sb.AppendLine("You currently have the following pawns on these positions:");
                foreach (int pos in playerPositions)
                {
                    sb.AppendLine(pos.ToString());
                }
                sb.AppendLine("Press any key to roll the dice.");
                sb.ToString();
                sb.Clear();
                Console.ReadKey();
                int result = dices.RollDices()[0];
                ///If a player rolls a 6 and not all pawns are on the board, they put another one on it and are forced to play it.
                if (result == 6 && playerPositions.Any(i => i == 0)) 
                {
                    int currentPawn = 0;
                    foreach(int pawn in playerPositions)
                    {
                        if (pawn == 0)
                        {
                            break;
                        }
                        else 
                        {
                            currentPawn++;
                        }
                    }
                    Console.WriteLine("You rolled a 6, a new pawn is on the board. Press a key to roll again and move it.");
                    Console.ReadKey();
                    int moveresult = dices.RollDices()[0];
                    pawnPositions[playerName][currentPawn] += moveresult;
                    Console.WriteLine($"You rolled a {moveresult}");
                    Console.WriteLine($"Pawn {currentPawn} has moved {moveresult} spaces.");
                    StrikeCheck(playerTurn, currentPawn);
                }
                else
                {
                    Console.WriteLine($"You rolled a {result}");
                    Console.WriteLine($"Type down which pawn you wish to move {result} spaces");
                    int selectedPawn = Int32.Parse(Console.ReadLine());
                    pawnPositions[playerName][selectedPawn] += result;
                    Console.WriteLine($"You rolled a {result}");
                    Console.WriteLine($"Pawn {selectedPawn} has moved {result} spaces.");
                    StrikeCheck(playerTurn, selectedPawn);
                }
            }
            ///No clue why, but stringbuilder is not working here.
            Console.WriteLine("These are all the pawns currently in the field:");
            foreach (string name in pawnPositions.Keys) 
            {
                Console.WriteLine($"{name}'s pawns:");
                foreach (int pawnPos in pawnPositions[name]) 
                {
                    if (pawnPos != 0)
                    {
                        Console.WriteLine(pawnPos.ToString());
                    }
                }
                if (pawnPositions[name].All(i => i > numberOfFields)) 
                {
                    Console.WriteLine($"Player {name} has won");
                    return true;
                }
            }
            return false;
        }

        public void StrikeCheck(int playerTurn, int selectedPawn) 
        {
            string playerName = players[playerTurn].getPlayerName();
            int currentPos = pawnPositions[playerName][selectedPawn];
            ///Check whether or not the currently moved pawn can strike an already existing pawn.
            foreach (string name in pawnPositions.Keys) 
            {
                ///For every int[] in pawnPositions except the players, check for same spaces
                ///Though for only the player's int[], check for same spaces except for the selected pawn.
                int index = 0;
                foreach (int pawnPos in pawnPositions[name])
                {
                    ///Check if name is the same as playername and whether or not the index and selected pawn are the same
                    if (name == playerName && selectedPawn == index)
                    {
                    }
                    ///Check if pawnpos is not 0 and the same.. the 0 & greater than check is mostly in case the program does freak out on same space where the pawns aren't technically
                    ///on the same space on the board.
                    else if (pawnPos != 0 && pawnPos == currentPos && pawnPos < numberOfFields)
                    {

                        Console.Write($"Player {name}'s pawn {index + 1} occupied the same space and has been reset.");
                        ///Reset the hit pawn
                        pawnPositions[name][index] = 0;
                    }
                    index++;
                }
            }
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

       

    }
}

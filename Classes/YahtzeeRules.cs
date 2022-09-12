using System.Collections.Generic;

namespace Spellendoos.Classes
{
    class YahtzeeRules
    {
        private List<string> rules;
        private Dictionary<string, int> score_options;
        public YahtzeeRules()
        {
            this.rules = new List<string>();
            addRule("Drie gelijke");
            addRule("Vier gelijke");
            addRule("Kleine straat");
            addRule("Grote straat");
            addRule("Full House");
            addRule("Kans");
            addRule("Yahtzee");
            score_options = new Dictionary<string, int>();
        }

        public void addRule(string rule)
        {
            this.rules.Add(rule);
        }

        public Dictionary<string, int> getScoreOptions() 
        {
            return score_options;
        }

        public Dictionary<string, int> checkOptions(int[] results)
        {
            score_options.Clear();

            int[] thrownDie = checkThrownDie(results);

            ///Kans is always an option.
            score_options.Add("Kans", thrownDie[0] * 1 + thrownDie[1] * 2 + thrownDie[2]
            * 3 + thrownDie[3] * 4 + thrownDie[4] * 5 + thrownDie[5] * 6);

            checkPairs(thrownDie);
            checkStraat(thrownDie);

            return score_options;
        }


        public int[] checkThrownDie(int[] results)
        {
            ///Check potential scores and add the thrown die possible to the array
            int one = 0, two = 0, three = 0, four = 0, five = 0, six = 0;

            foreach (int result in results)
            {
                switch (result)
                {
                    case 1:
                        one++;
                        break;
                    case 2:
                        two++;
                        break;
                    case 3:
                        three++;
                        break;
                    case 4:
                        four++;
                        break;
                    case 5:
                        five++;
                        break;
                    case 6:
                        six++;
                        break;
                }
            }
            return new int[] { one, two, three, four, five, six };
            
        }

        public void checkPairs(int[] dieCombo) {
            ///checked if number appears more than three times
            if (dieCombo[0] >= 3 || dieCombo[1] >= 3 || dieCombo[2] >= 3 || dieCombo[3] >= 3
            || dieCombo[4] >= 3 || dieCombo[5] >= 3)
            {
                score_options.Add("Drie gelijk", (1 * dieCombo[0] + 2 * dieCombo[1] + 3 * dieCombo[2] + 4 * dieCombo[3] + 5 * dieCombo[4] + 6 * dieCombo[5]));
                ///checked if number appears more than three times and the others have the same value
                if (dieCombo[0] >= 2 || dieCombo[1] >= 2 || dieCombo[2] >= 2 || dieCombo[3] >= 2 || dieCombo[4] >= 2 || dieCombo[5] >= 2)
                {
                    score_options.Add("Full House", 25);
                }
                ///checked if number appears more than four times
                if (dieCombo[0] >= 4 || dieCombo[1] >= 4 || dieCombo[2] >= 4 || dieCombo[3] >= 4 || dieCombo[4] >= 4 || dieCombo[5] >= 4)
                {
                    score_options.Add("Vier Gelijk", 1 * dieCombo[0] + 2 * dieCombo[1] + 3 * dieCombo[2] + 4 * dieCombo[3] + 5 * dieCombo[4] + 6 * dieCombo[5]);
                }
                ///checked if number appears five times
                if (dieCombo[0] == 5 || dieCombo[1] == 5 || dieCombo[2] == 5 || dieCombo[3] == 5 || dieCombo[4] == 5 || dieCombo[5] == 5)
                {
                    score_options.Add("Yahtzee", 50);
                }
            }
        }
        public void checkStraat(int[] dieCombo) {
            ///Check array of thrown die for possible straat-options
            if (dieCombo[0] == 1){
                if (dieCombo[1] == 1)
                {
                    if (dieCombo[2] == 1)
                    {
                        if (dieCombo[3] == 1)
                        {
                            score_options.Add("Kleine straat", 30);
                            if (dieCombo[4] == 1)
                            {
                                score_options.Add("Grote straat", 40);
                            }
                        }
                    }
                }
            }
            else if (dieCombo[1] == 1)
            {
                if (dieCombo[2] == 1)
                {
                    if (dieCombo[3] == 1)
                    {
                        if (dieCombo[4] == 1)
                        {
                            score_options.Add("Kleine straat", 30);
                            if (dieCombo[5] == 1)
                            {
                                score_options.Add("Grote straat", 40);
                            }
                        }
                    }
                }
            }
            else if (dieCombo[2] == 1)
            {
                if (dieCombo[3] == 1)
                {
                    if (dieCombo[4] == 1)
                    {
                        if (dieCombo[5] == 1)
                        {
                            score_options.Add("Kleine straat", 30);
                        }
                    }
                }
            }
        }
    }
}

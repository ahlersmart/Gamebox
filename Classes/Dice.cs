using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spellendoos
{
    class Dice
    {
        ///Currently defunct due to the nature of the Random object, might be used for mens erger je niet.
        ///Determines the amount of eyes the dice has, while for the games we are doing the amount should be always 6. Its nice to  be able to determine these things.
        private int numberOfEyes;
        public Dice(int numberOfEyes) 
        {
            this.numberOfEyes = numberOfEyes;  
        }

    }
}

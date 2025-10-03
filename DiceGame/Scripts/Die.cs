using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Lucy.Scripts
{
    public class Die
    {
        //creates a random instance so each roll is different
        private Random random = new Random();

        private string[] diceNames = new[] {"d6", "d8", "d12", "d20"};
        private int[] sidesValue = new[] {6, 8, 12, 20};

        internal int GetRollFromName(string givenName)
        {
            int indexOfDice = -1;
            for (int i = 0; i < diceNames.Length; i++)
            {
                if (diceNames[i] == givenName)
                {
                    indexOfDice = i;
                    break;
                }
            }
            if (indexOfDice == -1)
                return -1;

            return random.Next(1, sidesValue[indexOfDice] + 1); // need + 1 for random exclusive
        }
        internal int Roll(int faces)
        {
            return random.Next(1, faces + 1);
        }
    }


}

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


        internal int d6() // rolls a d6 
        {
            return random.Next(1, 7);

        }
        internal int d8() // rolls a d8 
        {
            return random.Next(1, 9);
        }
        internal int d12() // rolls a d12 
        {
            return random.Next(1, 13);
        }
        internal int d20() // rolls a d20
        {
            return random.Next(1, 21);
        }
    }
}

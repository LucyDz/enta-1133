﻿using System;
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

        // two arrays that correllate with each other
        internal int GetRollFromName(string givenName)
        {
            int indexOfDice = -1;
            for (int i = 0; i < diceNames.Length; i++) //i starts at zero and goes up by one until it matches                                                     
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
        //still confused about how to read above function but understand how it works mostly
        //couldnt figure out how to use the same method for the cpu and its random choice so it is just uses if else
        internal int Roll(int faces)
        {
            return random.Next(1, faces + 1);
        }
    }

    //wanted to use a list to be able to take away dice and have the game end when the players are out of dice, but was too nervous to try that with the array stuff already set up
    //wanted to make it so that the player can roll 2 dice at a time with more dice at their disposal but didn't know how/ran out of time
    //wanted to make a snakeeyes or crit mechaninic that made a round win worth more than 1 point, or minus 1 point from opponent but didn't know how/ran out of time
}

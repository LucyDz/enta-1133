using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Lucy.Scripts
{
    internal class Player
    {
        public int recentRoll = 0;
        public int playerScore = 0;
        string playerName = "Player"; // sets player name to "Player" by default just to instantiate it out here
                                      // wanted to bring this name so it could be put on the scoreboard at the end of a round but couldn't figure it out
        internal string GetPlayerName()
        {


            //ask player to enter name
            Console.WriteLine("Please enter your name");

            //player gives their name
            playerName = Console.ReadLine();

            Console.WriteLine("Alright " + playerName + ", Let's play!");

            return playerName;
        }


        internal int FetchPlayerScore() // trying to make a way to bring the score to another Class
        {
            return playerScore;
        }
        internal void InitializePlayerScore()
        {
            // set playerScore to 0 because they start with nothing
            playerScore = 0;
        }
        // couldn't figure out how to make another GameManager Class call these scores and be able to add to them. So I just had different variables store the scores in the GameManager...
    }
}

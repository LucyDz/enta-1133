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
        public bool isplaying;
        public bool IsPlaying => isplaying;
        internal string GetPlayerName()
        {


            //ask player to enter name
            Console.WriteLine("Please enter your name");

            //player gives their name
            playerName = Console.ReadLine();

            Console.WriteLine("Welcome " + playerName + "!");

            return playerName;
        }
        public string FetchPlayerName()
        {
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

        internal void ReadyToPlay()
        {
            Console.WriteLine("We will both be given a choice of 1 out of 4 dice to roll against eachother");
            Console.WriteLine("The player with the higher roll wins the round");
            Console.WriteLine("First to 5 rounds wins the match");
            Console.WriteLine("Ready to play?");
            Console.WriteLine("Type 'Y' for yes, or 'N' for no");
            string readyInput = Console.ReadLine();


            if (readyInput != "N" && readyInput != "n")
            {
                
                Console.WriteLine("Alright " + playerName + ", Let's play!");
                isplaying = true;

            }
            else
            {
                //outro message
                isplaying = false;
            }
        }
    }
}

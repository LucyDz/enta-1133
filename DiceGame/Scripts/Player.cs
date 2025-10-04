using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Lucy.Scripts
{
    internal class Player
    {
        //setting score, rolls, name, and if they want to play variables
        public int recentRoll = 0;
        public int playerScore = 0;
        string playerName = "Player"; // sets player name to "Player" by default just to instantiate it out here                                
        public bool isplaying;
        public bool IsPlaying => isplaying; // so that the isplaying variable can be called in GameManager (had help with this)
        internal string GetPlayerName() // asks player to enter their name
        {


            //ask player to enter name
            Console.WriteLine("Please enter your name");

            //player gives their name
            playerName = Console.ReadLine();

            Console.WriteLine("Welcome " + playerName + "!");

            return playerName;
        }
        public string FetchPlayerName()// gets player name so that it can be used in scoreboard
        {
            return playerName;
        }
        internal void ReadyToPlay()// explains rules and asks if the player is ready to play
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
                isplaying = false;
            }
        }
        // wanted to have inventory of dice and also powerups that allow you to steal the roll of the opponent once per match but didn't know how/ran out of time
    }
}

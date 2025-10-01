using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Lucy.Scripts
{
    internal class GameManager
    {
        //setting new player and cpu
        Player user = new Player();

        Player cpu = new Player();

        //created variable to store players roll
        int playerRoll = 0;

        //created variable to store cpu roll
        int cpuRoll = 0;

        internal void Play() 
        {
            //welcome message.
            Console.WriteLine("Welcome to Dice Game! My name is Lucy and today is 2025-09-26");
            Console.WriteLine("");

            //calling function to get players info
            user.GetPlayerName();
            Coinflip();
        }
        internal int Coinflip() // decides who goes first
        {
            //explaining the coinflip to decide first
            Console.WriteLine(""); 
            Console.WriteLine("Lets flip a coin to see who goes first");
            Console.WriteLine("If it's heads, I'll go first, if it's tails, you will go first.");

            // making the computer pick 0 or 1
            Random flip = new Random();
            int flipResult = flip.Next(0,2);

            

            //0 is heads so the GameManager calls the cpu turn first
            if (flipResult == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("Heads!");
                Console.WriteLine("");
                Console.WriteLine("It's my turn first...");
                CpuTurn();
                //Console.WriteLine("");
                //Console.WriteLine("It's now your turn...");
                PlayerTurn();
                ScoreCheck();
            }
            //1 is tails so the GameManager calls the players turn first
            else if (flipResult == 1)
            {
                Console.WriteLine("");
                Console.WriteLine("Tails!");
                Console.WriteLine("");
                Console.WriteLine("You go first...");
                PlayerTurn();
                Console.WriteLine("");
                Console.WriteLine("It's now my turn...");
                CpuTurn();
                ScoreCheck();
            }
            return flipResult;
        }
        internal void PlayerTurn()
        {
           
            //player gets dice options
            Console.WriteLine("");
            Console.WriteLine("Please choose a dice to roll");
            Console.WriteLine("Your choices are; d6, d8, d12, or d20");
            
            //player enters which die they would like to roll
            string dieInput = Console.ReadLine();
            Die die = new Die();

            
            // if statements to call each possible die choice
            if (dieInput == "d6")
            {
                Console.WriteLine("");
                Console.WriteLine("Rolling your d6...");
                playerRoll = die.d6(); // calls d6 from Die Class
            }

            else if (dieInput == "d8")
            {
                Console.WriteLine("");
                Console.WriteLine("Rolling your d8...");
                playerRoll = die.d8(); // calls d8 from Die Class
            }

            else if (dieInput == "d12")
            {
                Console.WriteLine("");
                Console.WriteLine("Rolling your d12...");
                playerRoll = die.d12(); // calls d12 from Die Class
            }

            else if (dieInput == "d20")
            {
                Console.WriteLine("");
                Console.WriteLine("Rolling your d20...");
                playerRoll = die.d20(); // calls d20 from Die Class
            }
            else 
            { 
                Console.WriteLine("please input a valid dice"); // asks them to pick again if the typed something else
                PlayerTurn();
            }
            // roll result printed
                Console.WriteLine("Your " + dieInput + " rolled " + playerRoll + " !");     
        }
        internal void CpuTurn()
        {
            //created a new die instance
            Die die = new Die();

            //making the computer pick a random number from 1 - 4
            Random diceRandom = new Random();
            int diceChoice = diceRandom.Next(1, 5);

            //making the chosen number align with and roll one of the dice
            if (diceChoice == 1) 
            {
                Console.WriteLine("");
                Console.WriteLine("I'll roll my d6...");
                cpuRoll = die.d6(); // calls d6 from Die Class
                Console.WriteLine("My d6 rolled " + cpuRoll + " !");
            }
            else if (diceChoice == 2)
            {
                Console.WriteLine("");
                Console.WriteLine("I'll roll my d8...");
                cpuRoll = die.d8(); // calls d8 from Die Class
                Console.WriteLine("My d8 rolled " + cpuRoll + " !");
            }
            else if (diceChoice == 3)
            {
                Console.WriteLine("");
                Console.WriteLine("I'll roll my d12...");
                cpuRoll = die.d12(); // calls d12 from Die Class
                Console.WriteLine("My d12 rolled " + cpuRoll + " !");
            }
            else if (diceChoice == 4)
            {
                Console.WriteLine("");
                Console.WriteLine("I'll roll my d20...");
                cpuRoll = die.d20(); // calls d20 from Die Class
                Console.WriteLine("My d20 rolled " + cpuRoll + " !");
            }

        }
        internal void ScoreCheck() // creating a function to check the score and show a scoreboard
        {
            Console.WriteLine("");
            Console.WriteLine("Lets see who won that round!");
            if (cpuRoll > playerRoll)
            {
                cpu.FetchPlayerScore();// trying to fetch the scores from the Player Classes here but not sure what to do with them afterwards
                cpu.playerScore++; //just added to GameManager stored score instead
            }
            else if (cpuRoll < playerRoll)
            {
                user.FetchPlayerScore();// trying to fetch the scores from the Player Classes here but not sure what to do with them afterwards
                user.playerScore++; //just added to GameManager stored score instead
            }

            //scoreboard display
            Console.WriteLine("");
            Console.WriteLine("=============================");
            Console.WriteLine("         SCOREBOARD          ");
            Console.WriteLine("         Lucy: " + cpu.playerScore);
            Console.WriteLine("         You: " + user.playerScore);
            Console.WriteLine("=============================");

            //if statement to write a line depending on who won the round
            if (cpu.playerScore > user.playerScore)
            {
                Console.WriteLine("");   
                Console.WriteLine("Looks like I win this round!");
            }
            else if (cpu.playerScore < user.playerScore)
            {
                Console.WriteLine("");
                Console.WriteLine("Looks like you win this round!");
            }

            //outro message
            Console.WriteLine("");
            Console.WriteLine("Thanks for playing my game!");
        }
    }
} 

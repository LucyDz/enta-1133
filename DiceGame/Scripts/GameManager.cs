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
        int playerRoll = -1;

        //created variable to store cpu roll
        int cpuRoll = 0;

        // created bool to check if its the players turn or not
        bool playerTurnTrue;
        



        internal void Play() 
        {
            //welcome message.
            Console.WriteLine("=============================================================");
            Console.WriteLine("Welcome to Dice Game! My name is Lucy and today is 2025-10-03");
            Console.WriteLine("=============================================================");
            Console.WriteLine("");

            //calling function to get players info
            user.GetPlayerName();
            user.ReadyToPlay();

            
            if (user.IsPlaying)
            {
                Coinflip();
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Thanks for playing my game!");
            }

        }
        public int Coinflip() // decides who goes first
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
                playerTurnTrue = false;
                NextTurn();
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
                playerTurnTrue = true;
                NextTurn();
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

            // validate input

            //string validInput = ""; //to do 
            

            playerRoll = die.GetRollFromName(dieInput);
            while (playerRoll <= 0)
            {
              
                Console.WriteLine("please input a valid dice"); // asks them to pick again if the typed something else
                dieInput = Console.ReadLine();
                playerRoll = die.GetRollFromName(dieInput);
            }
            Console.WriteLine("Rolling your " + dieInput + "...");
            // roll result printed
            Console.WriteLine("Your " + dieInput + " rolled " + playerRoll + " !");
            return;
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
                cpuRoll = die.Roll(6); // calls d6 from Die Class
                Console.WriteLine("My d6 rolled " + cpuRoll + " !");
            }
            else if (diceChoice == 2)
            {
                Console.WriteLine("");
                Console.WriteLine("I'll roll my d8...");
                cpuRoll = die.Roll(8); // calls d8 from Die Class
                Console.WriteLine("My d8 rolled " + cpuRoll + " !");
            }
            else if (diceChoice == 3)
            {
                Console.WriteLine("");
                Console.WriteLine("I'll roll my d12...");
                cpuRoll = die.Roll(12); // calls d12 from Die Class
                Console.WriteLine("My d12 rolled " + cpuRoll + " !");
            }
            else if (diceChoice == 4)
            {
                Console.WriteLine("");
                Console.WriteLine("I'll roll my d20...");
                cpuRoll = die.Roll(20); // calls d20 from Die Class
                Console.WriteLine("My d20 rolled " + cpuRoll + " !");
            }

        }
        internal void ScoreCheck() // creating a function to check the score and show a scoreboard
        {
            Console.WriteLine("");
            Console.WriteLine("Lets see who won that round!");
            // decides who won based on higher roll
            if (cpuRoll > playerRoll) 
            { 
                cpu.playerScore++; 
            }
            else if (cpuRoll < playerRoll)
            {
                user.playerScore++; 
            }
            else
            {
                Console.WriteLine("It's a tie! no points won.");
            }

                //scoreboard display
                Console.WriteLine("");
            Console.WriteLine("=============================");
            Console.WriteLine("         SCOREBOARD          ");
            Console.WriteLine("         Lucy: " + cpu.playerScore);
            Console.WriteLine("         " + user.FetchPlayerName() + ": " + user.playerScore);
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

            // checks if either player has reached 5 points or not and continues if they have not
            if (cpu.playerScore >= 5)
            {
                Console.WriteLine("");    
                Console.WriteLine("Lucy wins!");
                Console.WriteLine("Better luck next match");
                Console.WriteLine("");
                Console.WriteLine("=============================");
                Console.WriteLine("         FINAL SCORE         ");
                Console.WriteLine("         Lucy: " + cpu.playerScore);
                Console.WriteLine("         " + user.FetchPlayerName() + ": " + user.playerScore);
                Console.WriteLine("=============================");
                Console.WriteLine("");
                Rematch();
            }
            else if (user.playerScore >= 5)
            {
                Console.WriteLine("");
                Console.WriteLine(user.FetchPlayerName() + " wins!");
                Console.WriteLine("What a match!");
                Console.WriteLine("");
                Console.WriteLine("=============================");
                Console.WriteLine("         FINAL SCORE         ");
                Console.WriteLine("         Lucy: " + cpu.playerScore);
                Console.WriteLine("         " + user.FetchPlayerName() + ": " + user.playerScore);
                Console.WriteLine("=============================");
                Console.WriteLine("");
                Rematch();
            }
            else
            {
                ContinueGame();
            }
            
        }
        internal void NextTurn()
        {
            if (playerTurnTrue == true)
            {
                Console.WriteLine("");
                Console.WriteLine("It's now my turn...");
                
                CpuTurn();
                playerTurnTrue = false;
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("It's now your turn...");
                
                PlayerTurn();
                playerTurnTrue = true;
            }
        }
        internal void ContinueGame()
        {
             

            Console.WriteLine("");
            Console.WriteLine("Good round! want to play another?");
            Console.WriteLine("Type 'Y' for yes, or 'N' for no");

            string continueInput = Console.ReadLine();

            if (continueInput != "N" && continueInput != "n")
            {
                Console.WriteLine("Alright " + user.FetchPlayerName() + " let's play another round!!");
                NextTurn();
                NextTurn();
                ScoreCheck();
            }
            else
            {
                //outro message
                Console.WriteLine(""); 
                Console.WriteLine("Thats okay...");
                Console.WriteLine("Thanks for playing my game!");
            }
        }
        internal void Rematch()
        {
            Console.WriteLine("");
            Console.WriteLine("How about a rematch?");
            Console.WriteLine("Type 'Y' for yes, or 'N' for no");
            
            string rematchInput = Console.ReadLine();

            if (rematchInput != "N" && rematchInput != "n")
            {
                Console.WriteLine("Alright " + user.FetchPlayerName() + " let's play another match!!");
                cpu.playerScore = 0;
                user.playerScore = 0;
                Coinflip();
            }
            else
            {
                //outro message
                Console.WriteLine("");
                Console.WriteLine("Thats okay...");
                Console.WriteLine("Thanks for playing my game!");
                Console.WriteLine("Goodbye");
                Console.WriteLine("");
            }
        }
    }
} 

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
        public Player GetPlayer()
        {
            return user;
        }
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
            Console.WriteLine("                       COMBAT STARTS!                        ");
            Console.WriteLine("=============================================================");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            //calling function to get players info
            user.GetPlayerName();
            user.ReadyToPlay();

            
            if (user.IsPlaying)//checks if they are ready to play and continues if they are
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
            //Console.WriteLine(""); 
           //Console.WriteLine("Lets flip a coin to see who goes first");
            //Console.WriteLine("If it's heads, I'll go first, if it's tails, you will go first.");

            // making the computer pick 0 or 1
            Random flip = new Random();
            int flipResult = flip.Next(0,2);

            

            //0 is heads so the GameManager calls the cpu turn first
            if (flipResult == 0)
            {
                
               // Console.WriteLine("");
                //Console.WriteLine("Heads!");
                Console.WriteLine("");
                Console.WriteLine("The Ghost moves first...");
                CpuTurn();
                playerTurnTrue = false;
                NextTurn();
                ScoreCheck();
            }
            //1 is tails so the GameManager calls the players turn first
            else if (flipResult == 1)
            {
                
                //Console.WriteLine("");
                //Console.WriteLine("Tails!");
                Console.WriteLine("");
                Console.WriteLine("You move first...");
                PlayerTurn();
                playerTurnTrue = true;
                NextTurn();
                ScoreCheck();
            }
            return flipResult;
            
        }
        internal void PlayerTurn() // does player's turn
        {
           
            //player gets dice options
            Console.WriteLine("");
            Console.WriteLine("Please choose a dice to roll");
            Console.WriteLine("Your choices are; d6, d8, d12, or d20");
            
            //player enters which die they would like to roll
            string dieInput = Console.ReadLine();
            Die die = new Die();

          
            playerRoll = die.GetRollFromName(dieInput); //feeds their input to arrays in Die class
            while (playerRoll <= 0)
            {
              
                Console.WriteLine("please input a valid dice"); // asks them to pick again if the typed something else
                dieInput = Console.ReadLine();
                playerRoll = die.GetRollFromName(dieInput);
            }
            Console.WriteLine("Rolling your " + dieInput + "...");
            Console.WriteLine("Your " + dieInput + " rolled " + playerRoll + " !"); // roll result printed
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
                Console.WriteLine("The Ghost rolls a d6...");
                cpuRoll = die.Roll(6); // calls d6 from Die Class
                Console.WriteLine("Its d6 rolled " + cpuRoll + " !");
            }
            else if (diceChoice == 2)
            {
                Console.WriteLine("");
                Console.WriteLine("The Ghost rolls a d8...");
                cpuRoll = die.Roll(8); // calls d8 from Die Class
                Console.WriteLine("Its d8 rolled " + cpuRoll + " !");
            }
            else if (diceChoice == 3)
            {
                Console.WriteLine("");
                Console.WriteLine("The Ghost rolls a d12...");
                cpuRoll = die.Roll(12); // calls d12 from Die Class
                Console.WriteLine("Its d12 rolled " + cpuRoll + " !");
            }
            else if (diceChoice == 4)
            {
                Console.WriteLine("");
                Console.WriteLine("The Ghost rolls a d20...");
                cpuRoll = die.Roll(20); // calls d20 from Die Class
                Console.WriteLine("Its d20 rolled " + cpuRoll + " !");
            }

        } // does cpu's turn
        internal bool ScoreCheck() // creating a function to check the score and show a scoreboard
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
            Console.WriteLine("         Ghost: " + cpu.playerScore);
            Console.WriteLine("         " + user.FetchPlayerName() + ": " + user.playerScore);
            Console.WriteLine("=============================");

            //if statement to write a line depending on who won the round
            if (cpu.playerScore > user.playerScore)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The Ghost wins this round!");
                Console.WriteLine("Your conciousness fades for a brief moment");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (cpu.playerScore < user.playerScore)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Looks like you win this round!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("The Ghost hisses at you");
                
            }

            // checks if either player has reached 5 points or not and continues if they have not
            if (cpu.playerScore >= 5)
            {
                Console.WriteLine("");
                Console.WriteLine("The Ghost wins!");
                Console.WriteLine("You faint on the floor and lose consiousness");
                Console.WriteLine("");
                Console.WriteLine("=============================");
                Console.WriteLine("         FINAL SCORE         ");
                Console.WriteLine("         Ghost: " + cpu.playerScore);
                Console.WriteLine("         " + user.FetchPlayerName() + ": " + user.playerScore);
                Console.WriteLine("=============================");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("               ('-.     _   .-')       ('-.                           (`-.      ('-.  _  .-')   \r\n              ( OO ).-.( '.( OO )_   _(  OO)                        _(OO  )_  _(  OO)( \\( -O )  \r\n  ,----.      / . --. / ,--.   ,--.)(,------.       .-'),-----. ,--(_/   ,. \\(,------.,------.  \r\n '  .-./-')   | \\-.  \\  |   `.'   |  |  .---'      ( OO'  .-.  '\\   \\   /(__/ |  .---'|   /`. ' \r\n |  |_( O- ).-'-'  |  | |         |  |  |          /   |  | |  | \\   \\ /   /  |  |    |  /  | | \r\n |  | .--, \\ \\| |_.'  | |  |'.'|  | (|  '--.       \\_) |  |\\|  |  \\   '   /, (|  '--. |  |_.' | \r\n(|  | '. (_/  |  .-.  | |  |   |  |  |  .--'         \\ |  | |  |   \\     /__) |  .--' |  .  '.' \r\n |  '--'  |   |  | |  | |  |   |  |  |  `---.         `'  '-'  '    \\   /     |  `---.|  |\\  \\  \r\n  `------'    `--' `--' `--'   `--'  `------'           `-----'      `-'      `------'`--' '--' \n");
                // Rematch();
                return false;
            }
            else if (user.playerScore >= 5)
            {
                Console.WriteLine("");
                Console.WriteLine(user.FetchPlayerName() + " wins!");
                Console.WriteLine("The Ghost disappears with a final hiss");
                Console.WriteLine("");
                Console.WriteLine("=============================");
                Console.WriteLine("         FINAL SCORE         ");
                Console.WriteLine("         Ghost: " + cpu.playerScore);
                Console.WriteLine("         " + user.FetchPlayerName() + ": " + user.playerScore);
                Console.WriteLine("=============================");
                Console.WriteLine("");
                //Rematch();
                return true;
            }
            else
            {
                //ContinueGame();
                NextTurn();
                NextTurn();
                ScoreCheck();
                return true;
            }
            
        }
        internal void NextTurn()
        {
            if (playerTurnTrue == true)
            {
                Console.WriteLine("");
                Console.WriteLine("It's now the Ghost's turn...");
                
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
        }// allows the next player to go based off of who went last
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
                Console.WriteLine("Goodbye");
                Console.WriteLine("");
            }
        }// asks if player wants to continue after each round
        internal void Rematch() // asks for rematch after one player wins
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

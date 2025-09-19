using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Lucy.Scripts
{
    internal class DieRoller
    { 
        // created random class instance.
        Random Random = new Random();

        internal void Roll()
        {
            int d6 = Random.Next(1, 7); //created random number roller for d6 die.
            int d8 = Random.Next(1, 9); //created random number roller for d8 die.
            int d12 = Random.Next(1, 13); //created random number roller for d12 die.
            int d20 = Random.Next(1, 21); //created random number roller for d20 die.
            int total = d6 + d8 + d12 + d20; // created total sum counter.

            //printed roll outcomes.
            Console.WriteLine("Your d6 result is " + d6 + "!");
            Console.WriteLine("Your d8 result is " + d8 + "!");
            Console.WriteLine("Your d12 result is " + d12 + "!");
            Console.WriteLine("Your d20 result is " + d20 + "!");

            //printed total outcome.
            Console.WriteLine("Your total sum is " + total + "!");
        }
    
    }
    internal class Operators
    {
        //created function to show examples of Arithmetic Operators.
        internal void Arithmetics()
        {
            int a = 1;
            int b = 2;
            int c = 4;
            int d = 5;

            //explained what each operator does. 
            Console.WriteLine("");
            Console.WriteLine("I will now explain what operators do and give examples");
            Console.WriteLine("The operators (+,-,++,--,*,/, and %) function as follows");
            Console.WriteLine(" + adds two integers together");
            Console.WriteLine(" - subtracts an integer from the other");
            Console.WriteLine(" ++ increases an integer's value by 1");
            Console.WriteLine(" -- decreases an integer's value by 1");
            Console.WriteLine(" * multiplies two integers together");
            Console.WriteLine(" / divides one integer by the other");
            Console.WriteLine("");
            
            //performed examples of each operator.
            Console.WriteLine("I will now show some examples");
           
            Console.WriteLine("");
            Console.WriteLine("lets use + to create the sum of 1 + 2");
            Console.WriteLine(a + b);
            Console.WriteLine("our result was 3");
           
            Console.WriteLine("");
            Console.WriteLine("lets use - to subtract 1 from 2");
            Console.WriteLine(b - a);
            Console.WriteLine("our result was 1");
            
            Console.WriteLine("");
            Console.WriteLine("lets use ++ to increase 2 by one increment");
            Console.WriteLine(++b);
            Console.WriteLine("our result was 3");
           
            Console.WriteLine("");
            Console.WriteLine("lets use -- to decrease 3 by one increment");
            Console.WriteLine(--b);
            Console.WriteLine("our result was 2");
           
            Console.WriteLine("");
            Console.WriteLine("lets use * to multiply 2 by 2");
            Console.WriteLine(b * b);
            Console.WriteLine("our result was 4");

            Console.WriteLine("");
            Console.WriteLine("lets use / to divide 2 by 1");
            Console.WriteLine(b / a);
            Console.WriteLine("our result was 2");

            Console.WriteLine("");
            Console.WriteLine("lets use % to find the remainder of 5 - (5 / 4) x 4");
            Console.WriteLine(d % c);
            Console.WriteLine("our result is 1 because 'int' variables ignore decimal values");

        }   

    }



    internal class GameManager
    {
        internal void Play()
        {
            //welcome message.
            Console.WriteLine("Welcome to Dice Game! My name is Lucy and today is 2025-09-18");
            Console.WriteLine("");

            //created an instance to call DieRoller to GameManager.
            DieRoller DieRollerInstance = new DieRoller();

            //called Roll function from within DieRollerInstance Class.
            DieRollerInstance.Roll();

            //instantiated and called Operatorinstance to run Arithmetics.
            Operators operatorinstance = new Operators();
            operatorinstance.Arithmetics();

            //goodbye message.
            Console.WriteLine("");
            Console.WriteLine("Thank you for rolling and viewing! Goodbye.");
        }
    }
}

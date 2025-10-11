using GD14_1133_DiceGame_Lucy.Scripts;

namespace GD14_1133_DiceGame_Lucy
{
    internal class Program
    {
        static void Main(string[] args)

        {// Created instance to call the game manager
            
            
            MapGen house = new MapGen();
            house.Start();
        }
    }
}

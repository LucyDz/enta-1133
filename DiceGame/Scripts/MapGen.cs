using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Lucy.Scripts
{
    internal class MapGen
    {
        public void GenerateHouse()
        {
            int[,] house =
        {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

            Console.WriteLine(house + " Generated");
        }
        
    

    }
}

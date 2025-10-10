using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Lucy.Scripts
{
    internal class MapGen
    {
        public static void HouseMap(Room[,] house, Room playerRoom) // visualize player location
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (house[i, j] == playerRoom)
                        Console.Write("[X]");
                    else
                    {
                        Console.Write("[ ]");
                    }
                }
                Console.WriteLine();
            }
        }
        public void Start()
        {
            Console.WriteLine("Welcome to the Haunted House");
            Room[,] house = new Room[3, 3];
            int roomNumber = 0;
            Random random = new Random();

            //generate house layout
            for (int y = 0; y < house.GetLength(0); y++)
            {
                for (int x = 0; x < house.GetLength(1); x++)
                {
                    int roomType = random.Next (0, 3);
                    switch(roomType)
                    {
                        case 0:
                            house[y, x] = new Room.EmptyRoom(roomNumber, y, x); 
                            break;
                       
                        case 1:
                            house[y, x] = new Room.TreasureRoom(roomNumber, y, x);
                            break;
                        
                        case 2:
                            house[y, x] = new Room.CombatRoom(roomNumber, y, x);
                            break;
                        
                        default:
                            house[y, x] = new Room.EmptyRoom(roomNumber, y, x);
                            break;
                    }
                    roomNumber++;
                }
            }
            for (int y = 0; y < house.GetLength(0); y++) // linking rooms
            {
                for (int x = 0; x < house.GetLength(1); x++)
                {
                   Room currentRoom = house[y, x];
                   if (y > 0)
                        currentRoom.North = house[y - 1, x];
                   if (y < house.GetLength(0) - 1)
                        currentRoom.South = house[y + 1, x];
                   if (x > 0)
                        currentRoom.West = house[y, x - 1];
                   if (x < house.GetLength(1) - 1)
                        currentRoom.East = house[y, x + 1];







                }
            }
            //spawns player in random room
            random = new Random();

            int randx = random.Next(0, 3);
            int randy = random.Next(0, 3);
            Room current = house[randy, randx];
            current.OnRoomEntered();
            current.RoomDescription();
            HouseMap(house, current);
        }






    }
}

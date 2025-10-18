using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Lucy.Scripts
{
    internal class MapGen
    {
        GameManager manager = new GameManager();
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
            //manager.GetPlayer().AddRoom();
            //Player temp = manager.GetPlayer();
            //temp.AddRoom()
            //manager.Play();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("             ('-. .-.               .-')    .-') _          _  .-')                                      ('-.  _  .-')   \r\n            ( OO )  /              ( OO ). (  OO) )        ( \\( -O )                                   _(  OO)( \\( -O )  \r\n  ,----.    ,--. ,--. .-'),-----. (_)---\\_)/     '._        ,------.  .-'),-----.  ,--.      ,--.     (,------.,------.  \r\n '  .-./-') |  | |  |( OO'  .-.  '/    _ | |'--...__)       |   /`. '( OO'  .-.  ' |  |.-')  |  |.-')  |  .---'|   /`. ' \r\n |  |_( O- )|   .|  |/   |  | |  |\\  :` `. '--.  .--'       |  /  | |/   |  | |  | |  | OO ) |  | OO ) |  |    |  /  | | \r\n |  | .--, \\|       |\\_) |  |\\|  | '..`''.)   |  |          |  |_.' |\\_) |  |\\|  | |  |`-' | |  |`-' |(|  '--. |  |_.' | \r\n(|  | '. (_/|  .-.  |  \\ |  | |  |.-._)   \\   |  |          |  .  '.'  \\ |  | |  |(|  '---.'(|  '---.' |  .--' |  .  '.' \r\n |  '--'  | |  | |  |   `'  '-'  '\\       /   |  |          |  |\\  \\    `'  '-'  ' |      |  |      |  |  `---.|  |\\  \\  \r\n  `------'  `--' `--'     `-----'  `-----'    `--'          `--' '--'     `-----'  `------'  `------'  `------'`--' '--' ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nWelcome to Ghost Roller!");
            Console.WriteLine("You are a brave ghost hunter with a mission to document paranormal activity");
            Console.WriteLine("You must loot what you can and survive against the evils of the house");
            Console.WriteLine("Good Hunting...");
            Console.WriteLine("\n\n\nYou enter into an old House");
            Console.WriteLine("Rumors say the place is Haunted\n\n");
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
            current.RoomDescription(manager);
            
            //exploring the house loop, can't figure out how to break it when the player dies
            bool isexploring = true;
            while (isexploring)
            {
                Console.ForegroundColor = ConsoleColor.White;
                HouseMap(house, current);
                Console.WriteLine("\nYou stand in the dim light...");
                Console.WriteLine("What will you do?");
                Console.WriteLine("You may search the room by typing 'search' ");
                Console.WriteLine("Or you may leave by typing the direction you wish to go");
                Console.WriteLine("'north', 'south', 'east', or 'west'");
                string playerChoice = Console.ReadLine().ToLower();
                switch (playerChoice) //switches rooms and triggers their events
                {
                    case "north":
                        if (current.North != null)
                        {
                            current.OnRoomExit();
                            current = current.North;
                            
                            current.OnRoomEntered();
                            current.RoomDescription(manager);
                        }
                        else 
                        {
                            Console.WriteLine("There is no where to go in that direction");
                        }
                        break;
                    case "south":
                        if (current.South != null)
                        {
                            current.OnRoomExit();
                            current = current.South;
                            
                            current.OnRoomEntered();
                            current.RoomDescription(manager);
                        }
                        else
                        {
                            Console.WriteLine("There is no where to go in that direction");
                        }
                        break;
                    case "east":
                        if (current.East != null)
                        {
                            current.OnRoomExit();
                            current = current.East;
                            
                            current.OnRoomEntered();
                            current.RoomDescription(manager);
                        }
                        else
                        {
                            Console.WriteLine("There is no where to go in that direction");
                        }
                        break;
                    case "west":
                        if (current.West != null)
                        {
                            current.OnRoomExit();
                            current = current.West;
                            
                            current.OnRoomEntered();
                            current.RoomDescription(manager);
                        }
                        else
                        {
                            Console.WriteLine("There is no where to go in that direction");
                        }
                        break;
                    case "search":
                        current.OnRoomSearched(manager);

                        break;
                }
            }
        }






    }
}

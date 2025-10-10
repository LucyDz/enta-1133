using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Lucy.Scripts
{
    internal abstract class Room
    {
        public bool WasVisited { get; set; }
        public int RoomNumber { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public Room North { get; set; }
        public Room South { get; set; }
        public Room West { get; set; }
        public Room East { get; set; }

        public void RoomDescription()
        {
            if (!WasVisited)
            {
                Console.WriteLine("You've already been in this room");
            }
            else
            {

            }
        }
        public void OnRoomEntered()
        {
            Console.WriteLine("You enter the next room...");
        }
        public void OnRoomSearched()
        {
            Console.WriteLine("You search the room");
        }
        public void OnRoomExit()
        {
            Console.WriteLine("You leave this room");
        }
        public Room(int roomNumber, int row, int column)
        {
            RoomNumber = roomNumber;
            Row = row;
            Column = column;
            WasVisited = false;
        }
        
        internal class TreasureRoom : Room
        {
            public TreasureRoom(int roomNumber, int row, int column) : base(roomNumber, row, column)
            {

            }
        }
        internal class EmptyRoom : Room
        {
            public EmptyRoom(int roomNumber, int row, int column) : base(roomNumber, row, column)
            {

            }
        }

        internal class CombatRoom : Room
        {
            public CombatRoom(int roomNumber, int row, int column) : base(roomNumber, row, column)
            {

            }
        }

         








        public void MoveRooms(int x, int y, string direction)
        {
            switch (direction)
            {
                case "north":
                    break;

                case "south":
                    break;

                case "west":
                    break;

                case "east":
                    break;

            }
        }






    }
}    




    

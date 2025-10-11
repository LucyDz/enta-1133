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

        public virtual void RoomDescription()
        {
            
            
                

        }
        public virtual void OnRoomEntered()
        {
            Console.WriteLine("You enter the room...\n\n");
            if (WasVisited)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\nYou've already been in this room\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            WasVisited = true;
        }
        public virtual void OnRoomSearched()
        {
            Console.WriteLine("You search the room");
        }
        public virtual void OnRoomExit()
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
            public override void RoomDescription()
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You emerge into a storage room...\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            public override void OnRoomSearched()
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Couldn't figure out Inventory :(");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        internal class EmptyRoom : Room
        {
            public EmptyRoom(int roomNumber, int row, int column) : base(roomNumber, row, column)
            {

            }
            public override void RoomDescription()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You emerge into an empty room...\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            public override void OnRoomSearched()
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("There is nothing of use here...");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        internal class CombatRoom : Room
        {
            public CombatRoom(int roomNumber, int row, int column) : base(roomNumber, row, column)
            {

            }
            public override void RoomDescription()
            {
                GameManager manager = new GameManager();
                
                Console.WriteLine("You emerge into a cold and damp room...");
                Console.WriteLine("A chill runs down your spine and a ghost attacks!");
                Console.ForegroundColor = ConsoleColor.Red;
                manager.Play();
            }
        }

         








        //public void MoveRooms(int x, int y, string direction)
      //  {
       //     switch (direction)
         //   {
           //     case "north":
          //          break;

           //     case "south":
            //        break;

             //   case "west":
             //       break;

               // case "east":
                 //   break;

           // }
       // }






    }
}    




    

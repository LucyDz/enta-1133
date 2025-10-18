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

        public virtual void RoomDescription(GameManager manager)
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
        public virtual void OnRoomSearched(GameManager manager)
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
            public override void RoomDescription(GameManager manager)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You emerge into a storage room...\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            public override void OnRoomSearched(GameManager manager)
            {
                Random randomloot = new Random();
                int lootfound = randomloot.Next(0, 8);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("\nYou search the room for anything of use...\n");

                Console.ForegroundColor = ConsoleColor.Green;
                switch (lootfound)
                {
                    case 0:
                        manager.GetPlayer().AddItem(new Items.Camera(false));                        
                        manager.GetPlayer().Inventory[manager.GetPlayer().Inventory.Count - 1].OnPickup();
                        break;
                    case 1:
                        manager.GetPlayer().AddItem(new Items.Salt( false));
                        manager.GetPlayer().Inventory[manager.GetPlayer().Inventory.Count - 1].OnPickup();
                        break;
                    case 2:
                        manager.GetPlayer().AddItem(new Items.Flashlight(false));
                        manager.GetPlayer().Inventory[manager.GetPlayer().Inventory.Count - 1].OnPickup();
                        break;
                    case 3:
                        manager.GetPlayer().AddItem(new Items.Crucifix(false));
                        manager.GetPlayer().Inventory[manager.GetPlayer().Inventory.Count - 1].OnPickup();
                        break;
                    case 4:
                        manager.GetPlayer().AddItem(new Items.Camera(true));
                        manager.GetPlayer().Inventory[manager.GetPlayer().Inventory.Count - 1].OnPickup();
                        break;
                    case 5:
                        manager.GetPlayer().AddItem(new Items.Salt(true));
                        manager.GetPlayer().Inventory[manager.GetPlayer().Inventory.Count - 1].OnPickup();
                        break;
                    case 6:
                        manager.GetPlayer().AddItem(new Items.Flashlight(true));
                        manager.GetPlayer().Inventory[manager.GetPlayer().Inventory.Count - 1].OnPickup();
                        break;
                    case 7:
                        manager.GetPlayer().AddItem(new Items.Crucifix(true));
                        manager.GetPlayer().Inventory[manager.GetPlayer().Inventory.Count - 1].OnPickup();
                        break;
                    case 8:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("You find nothing of use");
                        break;
                       
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        internal class EmptyRoom : Room
        {
            public EmptyRoom(int roomNumber, int row, int column) : base(roomNumber, row, column)
            {

            }
            public override void RoomDescription(GameManager manager)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("You emerge into an empty room...\n");
                Console.ForegroundColor = ConsoleColor.White;
            }

            public override void OnRoomSearched(GameManager manager)
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
            public override void RoomDescription(GameManager manager)
            {
                
                
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




    

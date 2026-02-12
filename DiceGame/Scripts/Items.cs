using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Lucy.Scripts
{
    internal abstract class Items
    {
        public bool isDepleted { get; set; }
        public string ItemName { get; set; }
        public int itemCharges { get; set; }

        public virtual void OnPickup()
        {
            Console.WriteLine("You pickup an item");
        }
        public virtual void OnUse()
        {
            if (itemCharges > 0)
            {
                Console.WriteLine("You use your " + ItemName + " !");
                itemCharges--;
            }
            else
            {
                isDepleted = true;
                OnDepletion();

            }

        }
        public virtual void OnDepletion()
        {
            Console.WriteLine("Your " + ItemName + " has been depleted");
        }
        public Items(bool depleted)
        {
            isDepleted = depleted;
        }
        internal class Camera : Items
        {
            public Camera( bool depleted) : base(depleted)
            {
                ItemName = "Camera";
            }
            public override void OnPickup()
            {
                Console.WriteLine("\nYou pickup a " + ItemName + "...\n");
                if (isDepleted == true)
                {
                    Console.WriteLine("It is out of film\n\n");
                }
                else
                {
                    Console.WriteLine("It has film in it, enough for 5 photos\n\n");
                    itemCharges = 5;
                }
            }
        }
        internal class Salt : Items
        {
            public Salt(bool depleted) : base(depleted)
            {
                ItemName = "Salt Packet";
            }
            public override void OnPickup()
            {
                Console.WriteLine("\nYou pickup a " + ItemName + "...\n");
                if (isDepleted == true)
                {
                    Console.WriteLine("It is empty\n\n");
                }
                else
                {
                    Console.WriteLine("It is full, and has enough salt to damage a ghost\n\n");
                    itemCharges = 5;
                }
            }
        }
        internal class Crucifix : Items
        {
            public Crucifix(bool depleted) : base(depleted)
            {
                ItemName = "Crucifix";
            }
            public override void OnPickup()
            {
                Console.WriteLine("\nYou pickup a " + ItemName + "...\n");
                if (isDepleted == true)
                {
                    Console.WriteLine("It is broken, and probably ineffective\n\n");
                }
                else
                {
                    Console.WriteLine("It is old, but should help you against any ghosts\n\n");
                    itemCharges = 5;
                }
            }
        }
        internal class Flashlight : Items
        {
            public Flashlight( bool depleted) : base(depleted)
            {
                ItemName = "Flashlight";
            }
            public override void OnPickup()
            {
                Console.WriteLine("\nYou pickup a " + ItemName + "...\n");
                if (isDepleted == true)
                {
                    Console.WriteLine("It is out of battery\n\n");
                }
                else
                {
                    Console.WriteLine("It is has low battery, but may be enough to damage a ghost a few times \n\n");
                    itemCharges = 5;
                }
            }
        }
    }
}

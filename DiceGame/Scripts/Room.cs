using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GD14_1133_DiceGame_Lucy.Scripts
{
    internal abstract class Room
    {
        public void RoomDescription()
        {

        }
        public void OnRoomEntered()
        {

        }
        public void OnRoomSearched()
        {

        }
        public void OnRoomExit()
        {

        }
    }
    internal class TreasureRoom : Room
    {

    }
    internal class CombatRoom : Room
    {

    }
}

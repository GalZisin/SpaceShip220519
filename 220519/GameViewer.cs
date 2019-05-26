using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _220519
{
    class GameViewer
    {
        public void GoodSpaceShipHpChangedEventHandler(object sender, PointsEventArgs e)
        {
            Console.WriteLine($"Good space ship HP: {e.HitPoins}");
        }
        public void GoodSpaceShipLocationChangedEventHandler(object sender, LocationEventArgs e)
        {
            Console.WriteLine($"Good space ship location X,Y is: {e.X}, {e.Y}");
        }
        public void GoodSpaceShipDestroyedEventHandler(object sender, LocationEventArgs e)
        {
            Console.WriteLine($"Good space ship Destroy location X,Y is: {e.X}, {e.Y}");
        }
        public void BadShipsExplodedEventHandler(object sender, BadShipsExplodedEventArgs e)
        {
            Console.WriteLine($"Bad ships exploded: {e.NumberOfExplodedBadShips}");
        }
        public void LevelUpReachedEventHandler(object sender, LevelEventArgs e)
        {
            Console.WriteLine($"Level up reached: {e.CurrentLevel}");
        }
    }
}

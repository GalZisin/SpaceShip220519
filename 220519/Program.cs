using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _220519
{
    class Program
    {
        static void Main(string[] args)
        {
            SpaceQuestGameManager space = new SpaceQuestGameManager(5,50,50,3);
            GameViewer game = new GameViewer();
            space.BadShipsExploded += game.BadShipsExplodedEventHandler;
            space.GoodSpaceShipHpChanged += game.GoodSpaceShipHpChangedEventHandler;
            space.GoodSpaceShipLocationChanged += game.GoodSpaceShipLocationChangedEventHandler;
            space.GoodSpaceShipLocationDestroyed += game.GoodSpaceShipDestroyedEventHandler;
            space.LevelUpReached += game.LevelUpReachedEventHandler;

           
                space.run();
            Console.ReadLine();
        }
    }
}

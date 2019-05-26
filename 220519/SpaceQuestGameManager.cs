using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _220519
{
    class SpaceQuestGameManager
    {
        private int _goodSpaceShipHitPoints;
        private int _shipXLocation;
        private int _shipYLocation;
        private int _numberOfBadShips;
        public int _currentLevel = 1;
        private int _maxHpPoints;
        private bool ifLevelMaxReached= false;
        int countBadShipsDestroyed = 0;
        public SpaceQuestGameManager(int goodSpaceShipHitPoints, int shipXLocation, int shipYLocation, int numberOfBadShips)
        {
            _goodSpaceShipHitPoints = goodSpaceShipHitPoints;
            _shipXLocation = shipXLocation;
            _shipYLocation = shipYLocation;
            _numberOfBadShips = numberOfBadShips;
            _maxHpPoints = _goodSpaceShipHitPoints;
        }
        public event EventHandler<PointsEventArgs> GoodSpaceShipHpChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceShipLocationChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceShipLocationDestroyed;
        public event EventHandler<BadShipsExplodedEventArgs> BadShipsExploded;
        public event EventHandler<LevelEventArgs> LevelUpReached;
        public void MoveSpaceShip(int newX, int newY)
        {
            if (_currentLevel == 3)
            {
                ifLevelMaxReached = true;

            }
            _shipXLocation += newX;
            _shipYLocation += newY;

            OnGoodSpaceShipLocationChanged(_shipXLocation, _shipYLocation);
        }
        public void GoodSpaceShipGotDamaged(int damage)
        {
            if (_currentLevel == 3)
            {
                ifLevelMaxReached = true;

            }
            if (_goodSpaceShipHitPoints <= 0)
            {
                OnGoodSpaceShipLocationDestroyed(_shipXLocation, _shipYLocation);
                
            }
            else
            {
                _goodSpaceShipHitPoints -= damage;
                OnGoodSpaceShipHpChanged(_goodSpaceShipHitPoints);
            }
            
        }
        public void GoodSpaceShipGotExtraHP(int extra)
        {
            if (_currentLevel == 3)
            {
                ifLevelMaxReached = true;

            }
            _goodSpaceShipHitPoints += extra;
            OnGoodSpaceShipHpChanged(_goodSpaceShipHitPoints);
        }
        public void EnemyShipsDestroyed(int numberOfbadShipsDestroyed)
        {
            if (_currentLevel == 3)
            {
                ifLevelMaxReached = true;

            }
            if (_numberOfBadShips > 0)
            {
                _numberOfBadShips -= numberOfbadShipsDestroyed;
                countBadShipsDestroyed++;
                OnBadShipsExploded(countBadShipsDestroyed);
            }
            else
            {
                CurrentLevel(_numberOfBadShips);
            }
        }
        public void CurrentLevel(int numberOfBadShips)
        {
            if (_currentLevel == 3)
            {
                ifLevelMaxReached = true;

            }
            else
            {
                if (_numberOfBadShips <= 0)
                {
                    _currentLevel++;
                    _goodSpaceShipHitPoints = _maxHpPoints;
                    OnGoodSpaceShipHpChanged(_goodSpaceShipHitPoints);

                    OnLevelUpReached(_currentLevel);

                }
            }
        }
        private void OnGoodSpaceShipHpChanged(int hitPoints)
        {
            if( GoodSpaceShipHpChanged != null)
            {
                GoodSpaceShipHpChanged.Invoke(this, new PointsEventArgs { HitPoins = hitPoints });
            }
        }
        private void OnGoodSpaceShipLocationChanged(int shipXLocation, int shipYLocation)
        {
            if(GoodSpaceShipLocationChanged != null)
            {
                GoodSpaceShipLocationChanged.Invoke(this, new LocationEventArgs{X=shipXLocation, Y=shipYLocation });
            }
        }
        private void OnGoodSpaceShipLocationDestroyed(int shipXLocation, int shipYLocation)
        {
            if(GoodSpaceShipLocationDestroyed != null)
            {
                GoodSpaceShipLocationDestroyed.Invoke(this, new LocationEventArgs { X = shipXLocation, Y = shipYLocation });
            }
        }
        private void OnBadShipsExploded(int numberOfBadShipsDestroyed)
        {
            if(BadShipsExploded != null)
            {
                BadShipsExploded.Invoke(this, new BadShipsExplodedEventArgs { NumberOfExplodedBadShips = numberOfBadShipsDestroyed });
            }
        }
        private void OnLevelUpReached(int currentLevel)
        {
            if(LevelUpReached != null)
            {
                LevelUpReached.Invoke(this, new LevelEventArgs { CurrentLevel = currentLevel });
            }
        }

        public void run()
        {

            Random random = new Random();
            while (_goodSpaceShipHitPoints >= 0)
            {
                if (ifLevelMaxReached == true)
                {
                    break;
                }

                int x = random.Next(1, 4);
                    switch (x)
                    {
                        case 1:
                            GoodSpaceShipGotDamaged(2);
                            break;
                        case 2:
                            EnemyShipsDestroyed(1);
                            GoodSpaceShipGotExtraHP(1);
                            break;
                        case 3:
                            MoveSpaceShip(1, 1);
                            break;
                        default:
                            Console.WriteLine("Not in range");
                            break;
                    }
                Thread.Sleep(1000);
            }
            Console.WriteLine("GAME OVER");
            
        }
        
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests
{
    [TestClass()]
    public class SeaGridTests
    {
        [TestMethod()]
        /// <summary>
        /// AddShipTest
        /// This Unit test checks if a ship can be placed outside of the grid.
        /// The DeploymentController class is responible for handling this behaviour however it uses the MoveShip SeaGrid method.
        /// The MoveShip method uses AddShip which luckily gives us an expection that will explain the cause.
        /// We can use the gained information to assess wether or not MoveShip plays a hand in the dissapearing ship.
        /// If it does then it will place the ship anywhere regardless of size, grid location and direction and throw no exception.
        public void MoveShipTest()
        {
            Dictionary<ShipName, Ship> _Ships = new Dictionary<ShipName, Ship>();
            SeaGrid _playerGrid;
            _playerGrid = new SeaGrid(_Ships);
            //Fill ship directory for testing
            foreach (ShipName name in Enum.GetValues(typeof(ShipName)))
            {
                if (name != ShipName.None)
                {
                    _Ships.Add(name, new Ship(name));
                }
            }
            //Initiate variables that will be used in the moveship method
            int col = 0, row = 0;
            Direction direction = Direction.LeftRight;
            ShipName ship = ShipName.Tug;


            // PLACING TUG
            // AT 9,0
            // HORIZONTALLY
            col = 9;
            row = 0;
            direction = Direction.LeftRight;
            ship = ShipName.Tug;
            _playerGrid.MoveShip(col, row, ship, direction);

            // PLACING TUG
            // AT 9,9
            // VERTICALLY
            col = 9;
            row = 9;
            direction = Direction.UpDown;
            ship = ShipName.Tug;
            _playerGrid.MoveShip(col, row, ship, direction);

            // PLACING Battleship
            // AT 9,4
            // VERTICALLY
            col = 9;
            row = 4;
            direction = Direction.UpDown;
            ship = ShipName.Battleship;
            _playerGrid.MoveShip(col, row, ship, direction);
        }
    }
}

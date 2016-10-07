using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Tests
{
    [TestClass()]
    public class AttackResultTests
    {
        /// <summary>
        /// SetDifficultyTest
        /// This Test method runs assertions on the difficulty of the AI player in the game.
        /// This testing is quite complicated as there is no methods to pull an AI players difficulty.
        /// Instead we test that on a given difficulty, the appropriate AI player is made to match that difficulty.
        /// </summary>
        [TestMethod()]
        public void HitResultTest()
        {
            Ship Tug = new Ship(ShipName.Tug);

            
            
        }
    }
}
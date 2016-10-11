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
            //Create New game
            BattleShipsGame _game = new BattleShipsGame();

            //Create new player
            Player _player = new Player(_game);

            //Create new AI
            AIPlayer _ai = new AIHardPlayer(_game);
            AIOption _aiSetting;
            _aiSetting = AIOption.Easy;
            GameController.SetDifficulty(_aiSetting);
            GameController.CreateAI(_aiSetting, ref _ai, _game);

            _player.RandomizeDeployment();
            _ai.RandomizeDeployment();

            //Copy the tug ship in player to a variable
            //Need to do this in order to access the row and column
            Ship _aiTug = _ai.Ship(ShipName.Tug);

            //Get coordinates of the tug ship
            int _tugRow = _aiTug.Row;
            int _tugColumn = _aiTug.Column;

            //Expect result to be a hit
            ResultOfAttack _hitResult = ResultOfAttack.Hit;
            AttackResult _expectedResult = new AttackResult(_hitResult, "Hit", _tugRow, _tugColumn);

            ResultOfAttack _missResult = ResultOfAttack.Miss;
            AttackResult _actualResult = new AttackResult(_missResult, "Miss", 0, 0);
            //AttackResult _actualResult = default(AttackResult);
            _actualResult = _game.Shoot(0,0);

            Assert.AreEqual(_actualResult.Value, _expectedResult.Value);
        }
    }
}
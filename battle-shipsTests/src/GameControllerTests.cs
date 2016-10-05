using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Tests
{
    [TestClass()]
    public class GameControllerTests
    {
        /// <summary>
        /// SetDifficultyTest
        /// This Test method runs assertions on the difficulty of the AI player in the game.
        /// This testing is quite complicated as there is no methods to pull an AI players difficulty.
        /// Instead we test that on a given difficulty, the appropriate AI player is made to match that difficulty.
        /// </summary>
        [TestMethod()]
        public void SetDifficultyTest()
        {
            // Create game, ai, and difficulty for test purposes.
            BattleShipsGame _theGame = new BattleShipsGame();
            AIPlayer _ai = new AIHardPlayer(_theGame);
            AIOption _aiSetting;

            // Set difficulty to easy and assert that the correct AIPlayer is made.
            _aiSetting = AIOption.Easy;
            GameController.SetDifficulty(_aiSetting);
            GameController.CreateAI(_aiSetting,ref _ai, _theGame);
            Assert.IsInstanceOfType(_ai, typeof(AIEasyPlayer));

            // Set difficulty to medium and assert that the correct AIPlayer is made.
            _aiSetting = AIOption.Medium;
            GameController.SetDifficulty(_aiSetting);
            GameController.CreateAI(_aiSetting, ref _ai, _theGame);
            Assert.IsInstanceOfType(_ai, typeof(AIMediumPlayer));

            // Set difficulty to hard and assert that the correct AIPlayer is made.
             _aiSetting = AIOption.Hard;
            GameController.SetDifficulty(_aiSetting);
            GameController.CreateAI(_aiSetting, ref _ai, _theGame);
            Assert.IsInstanceOfType(_ai, typeof(AIHardPlayer));
        }
    }
}
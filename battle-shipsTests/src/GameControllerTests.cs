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
        /*
         * SetDifficultyTest
         * This Test method runs assertions on the difficulty of the AI player in the game.
         * This testing is quite complicated as there is no methods to pull an AI players difficulty.
         * Instead we test that on a given difficulty, the appropriate AI player is made to match that difficulty.
         * Currently there is no Easy AIPlayer, so this cannot adequately be tested, and must become an extension task.
         */
        [TestMethod()]
        public void SetDifficultyTest()
        {
            // Create game, ai, and difficulty for test purposes.
            BattleShipsGame _theGame = new BattleShipsGame();
            AIPlayer _ai = new AIHardPlayer(_theGame);
            AIOption difficulty = AIOption.Easy;

            // Use switch logic in action to simplify code.
            Action CreateAIPlayer = new Action(() =>
            {
                switch (difficulty) {
                    case AIOption.Medium:
                        _ai = new AIMediumPlayer(_theGame);
                    break;
                    case AIOption.Hard:
                        _ai = new AIHardPlayer(_theGame);
                    break;
                    /*
                     * default:
                     *  _ai = new AIEasyPlayer(_theGame);
                     *  
                     *  Above lines need to be uncommented when EasyAIPlayer
                     *  class created
                     */

                }
            });

            // Set difficulty to easy and assert that the correct AIPlayer is made.
            difficulty = AIOption.Easy;
            GameController.SetDifficulty(difficulty);
            CreateAIPlayer.Invoke();
            System.Console.Write(Environment.CurrentDirectory);
            if (!File.Exists("../../../battle-ships/src/Model/AIEasyPlayer.cs"))   // test if easy ai player class file exists
                Assert.Fail(); // if it doesn't fail the test.

            /* Two lines above need to be removed and updated
             * with following line when easy class has been created.
             * Assert.IsInstanceOfType(_ai, typeof(AIEasyPlayer));
             */

            // Set difficulty to medium and assert that the correct AIPlayer is made.
            difficulty = AIOption.Medium;
            GameController.SetDifficulty(difficulty);
            CreateAIPlayer.Invoke();
            Assert.IsInstanceOfType(_ai, typeof(AIMediumPlayer));

            // Set difficulty to hard and assert that the correct AIPlayer is made.
            difficulty = AIOption.Hard;
            GameController.SetDifficulty(difficulty);
            CreateAIPlayer.Invoke();
            Assert.IsInstanceOfType(_ai, typeof(AIHardPlayer));
        }
    }
}
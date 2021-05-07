using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect_ii.Database.Game;
using NUnit.Framework;

namespace proiect_ii.Tests.DataBaseTest.GameTest
{
    [TestFixture]
    public class GameControllerTest
    {
        protected Game generateTestGame()
        {
            Game game = new Game();
            game.name = "MineCraft";
            game.publisher = "tester523";
            game.developer = "Vanila";
            game.description = "Adventure game";
            game.category1= "g1";
            game.category2 = "g2";
            game.category3 = "g3";

            return game;
        }

        [Test]
        public void Test_AddDataBase_VerifTroughGamename()
        {
            Game game = generateTestGame();
            GameController gameController = new GameController();
            gameController.AddToDatabase(game);
            Game verif_through_name = gameController.GetGameByName(game.name);

            Assert.AreEqual(game.name, verif_through_name.name);
            Assert.AreEqual(game.publisher, verif_through_name.publisher);
            Assert.AreEqual(game.developer, verif_through_name.developer);
            Assert.AreEqual(game.description, verif_through_name.description);
            Assert.AreEqual(game.category1, verif_through_name.category1);
            Assert.AreEqual(game.category2, verif_through_name.category2);
            Assert.AreEqual(game.category3, verif_through_name.category3);
            gameController.DeleteGame(game);
        }
        
    }
}

using Logica.ranking;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class Rank
    {
        [TestMethod]
        public void Ranking()
        {
            RankingUser ranking = new RankingUser();
            List<Tuple<string, int>> ranks = ranking.GetWin();

            bool valid = ranks.Count > 0;

            Assert.AreEqual(true, valid);
        }
    }
}

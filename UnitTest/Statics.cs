using Logica.stats;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class Statics
    {
        [TestMethod]
        public void Matches_played()
        {
            Stats stats = new Stats(23);
            Assert.AreEqual(15, stats.getMatchesPlayed());
        }

        [TestMethod]
        public void Matches_win()
        {
            Stats stats = new Stats(23);
            Assert.AreEqual(1, stats.getMatchesW());
        }

        [TestMethod]
        public void eloMax()
        {
            Stats stats = new Stats(23);
            Assert.AreEqual(-90, stats.GetEloMax());
        }

        [TestMethod]
        public void eloActual()
        {
            Stats stats = new Stats(23);
            Assert.AreEqual(-100, stats.GetEloActual());
        }

        [TestMethod]
        public void Matches_playedInvalid()
        {
            Stats stats = new Stats(-1);
            Assert.AreEqual(-1, stats.getMatchesPlayed());
        }

        [TestMethod]
        public void Matches_winInvalid()
        {
            Stats stats = new Stats(-1);
            Assert.AreEqual(0, stats.getMatchesW());
        }

        [TestMethod]
        public void eloMaxInvalid()
        {
            Stats stats = new Stats(-1);
            Assert.AreEqual(-1, stats.GetEloMax());
        }

        [TestMethod]
        public void eloActualInvalid()
        {
            Stats stats = new Stats(-1);
            Assert.AreEqual(-1, stats.GetEloActual());
        }
    }
}

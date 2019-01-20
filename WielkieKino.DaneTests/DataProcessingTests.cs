using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Dane;
using WielkieKino.Lib;

namespace WielkieKino.Logic.Tests
{
    [TestClass()]
    public class DataProcessingTests
    {
        DataProcessing dataProcessing = new DataProcessing();
        [TestMethod()]
        public void WybierzFilmyZGatunkuTest()
        {
            List<string> wynik = dataProcessing.WybierzFilmyZGatunku(SkladDanych.Filmy, "Fantasy");
            Assert.AreEqual(1, wynik.Count);
            Assert.IsTrue(wynik.Contains("Konan Destylator"));

        }

        [TestMethod()]
        public void PodajCalkowiteWplywyZBiletowTest()
        {
            int total = dataProcessing.PodajCalkowiteWplywyZBiletow(SkladDanych.Bilety);
            Assert.AreEqual(400, total);
        }

        [TestMethod()]
        public void WybierzFilmyPokazywaneDanegoDniaTest()
        {
            DateTime Date = new DateTime(2019, 1, 20, 12, 00, 00);
            List<Film> filmyDnia = dataProcessing.WybierzFilmyPokazywaneDanegoDnia(SkladDanych.Seanse, Date);

            Assert.AreEqual(7, filmyDnia.Count);

        }

        [TestMethod()]
        public void NajpopularniejszyGatunekTest()
        {
            string gatunek = dataProcessing.NajpopularniejszyGatunek(SkladDanych.Filmy);
            Assert.AreEqual("Obyczajowy", gatunek);
        }
    }
}
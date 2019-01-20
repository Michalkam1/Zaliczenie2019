using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Dane;

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
    }
}
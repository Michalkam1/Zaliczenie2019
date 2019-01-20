using Microsoft.VisualStudio.TestTools.UnitTesting;
using WielkieKino.Dane;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WielkieKino.Dane.Tests
{
    [TestClass()]
    public class MetodyPomocniczeTests
    {
        MetodyPomocnicze metodyPomocnicze = new MetodyPomocnicze();
        [TestMethod()]
        public void CzyMoznaKupicBiletTest()
        {
            
            bool czyMoznaKupicBilet = metodyPomocnicze.CzyMoznaKupicBilet(SkladDanych.Bilety, SkladDanych.Seanse[0], 10, 10);
            Assert.AreEqual(true, czyMoznaKupicBilet);
        }

        [TestMethod()]
        public void CzyMoznaDodacSeansTest()
        {
            bool czyMoznaDodacSeans = metodyPomocnicze.CzyMoznaDodacSeans(SkladDanych.Seanse, SkladDanych.Sale[0], SkladDanych.Filmy[0], new DateTime(2019, 1, 20, 14, 00, 00));
            Assert.AreEqual(false, czyMoznaDodacSeans);
        }

        [TestMethod()]
        public void LiczbaWolnychMiejscWSaliTest()
        {
            int liczbaWolnychMiejsc = metodyPomocnicze.LiczbaWolnychMiejscWSali(SkladDanych.Bilety, SkladDanych.Seanse[0]);
            Assert.AreEqual(72, liczbaWolnychMiejsc);
        }

        [TestMethod()]
        public void CalkowitePrzychodyZBiletowTest()
        {
            double przychod = metodyPomocnicze.CalkowitePrzychodyZBiletow(SkladDanych.Bilety);
            Assert.AreEqual(400, przychod);
        }
    }
}
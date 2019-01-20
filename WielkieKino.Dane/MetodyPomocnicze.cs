using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;

namespace WielkieKino.Dane
{
    /// <summary>
    /// Metody do implementacji (raczej) bez wykorzystania LINQ
    /// </summary>
    public class MetodyPomocnicze
    {
        /// <summary>
        /// Sprawdzenie czy dane miejsce w konkretnym seansie nie jest zajęte
        /// </summary>
        /// <param name="sprzedaneBilety"></param>
        /// <param name="seans"></param>
        /// <param name="rzad"></param>
        /// <param name="miejsce"></param>
        /// <returns></returns>
        public bool CzyMoznaKupicBilet(List<Bilet> sprzedaneBilety, Seans seans, int rzad, int miejsce)
        {
            foreach (var bilet in sprzedaneBilety)
            {
                if (bilet.Seans.Date == seans.Date && 
                    bilet.Seans.Film.Tytul == seans.Film.Tytul && 
                    bilet.Seans.Sala.Nazwa == seans.Sala.Nazwa &&
                    bilet.Rzad == rzad &&
                    bilet.Miejsce == miejsce)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Sprawdzenie czy można projekcja filmu o zadanej godzinie nie nakłada się z już
        /// dodanymi seansami w tej sali.
        /// </summary>
        /// <param name="aktualneSeanse"></param>
        /// <param name="sala"></param>
        /// <param name="film"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool CzyMoznaDodacSeans(List<Seans> aktualneSeanse, Sala sala, Film film, DateTime data)
        {
            // np. nie można zagrać filmu "Egzamin" w sali Kameralnej 2019-01-20 o 17:00
            // można natomiast zagrać "Egzamin" w tej sali 2019-01-20 o 14:00
            foreach (var seans in aktualneSeanse)
            {
                if (seans.Sala.Nazwa == sala.Nazwa)
                {
                    if (data >= seans.Date && data <= seans.Date.AddHours(film.CzasTrwania))
                    {
                        return false;
                    }
                }
                
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprzedaneBilety">wszystkie sprzedane bilety</param>
        /// <param name="seansDoSprawdzenia"></param>
        /// <returns></returns>
        public int LiczbaWolnychMiejscWSali(List<Bilet> sprzedaneBilety, Seans seansDoSprawdzenia)
        {
            List<Bilet> wynik = new List<Bilet>();
           
            foreach (Bilet bilet in SkladDanych.Bilety)
            {
                if (bilet.Seans == seansDoSprawdzenia)
                    wynik.Add(bilet);
            }

            int LiczbaSprzedanychMiejsc = wynik.Count;
            int liczbaMiejscwSali = seansDoSprawdzenia.Sala.LiczbaMiejscWRzedzie * seansDoSprawdzenia.Sala.LiczbaRzedow;

            // Właściwa odpowiedź: np. na pierwszy seans z listy seansów w klasie SkladDanych są 72 miejsca
            return liczbaMiejscwSali - LiczbaSprzedanychMiejsc;
        }

        public double CalkowitePrzychodyZBiletow(List<Bilet> sprzedaneBilety)
        {
            double przychod = 0.0;
            foreach (var bilet in sprzedaneBilety)
            {
                przychod += bilet.Cena;
            }
            // Właściwa odpowiedź: 400.00
            return przychod;
        }
    }
}

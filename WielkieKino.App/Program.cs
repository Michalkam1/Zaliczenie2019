﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;
using WielkieKino.Dane;
using WielkieKino.Logic;

namespace WielkieKino.App
{
    public class Program
    {
        /// <summary>
        /// Na podstawie danych seansu i sprzedanych biletów należy wyświetlić "podgląd"
        /// sali w ten sposób, że: każdy rząd to jedna linia tekstu, znaków w linii
        /// ma być tyle ile miejsc w rzędzie, miejsca zajęte są inaczej oznaczone niż
        /// miejsca wolne.
        /// </summary>
        /// <param name="sprzedaneBilety"></param>
        /// <param name="seans"></param>
        private static void WyswietlPodgladSali(List<Bilet> sprzedaneBilety, Seans seans)
        {

        }

        /// <summary>
        /// Wyświetlony powinien być tytuł filmu, godzina rozpoczęcia, czas trwania
        /// i nazwa sali.
        /// </summary>
        /// <param name="seanse"></param>
        /// <param name="data"></param>
        private static void WyswietlFilmyOGodzinie(List<Seans> seanse, DateTime data)
        {
            //Wskazówka: Do obliczenia czy parametr data "wpada" w film można wykorzystać
            //metodę AddMinutes wykonanej na czasie rozpoczęcia seansu.
        }

        public static void Main(string[] args)
        {
            MetodyPomocnicze metodyPomocnicze = new MetodyPomocnicze();
            DataProcessing dataProcessing = new DataProcessing();


            List<Sala> sale = dataProcessing.ZwrocSalePosortowanePoCalkowitejLiczbieMiejsc(SkladDanych.Sale);
            //List<Film> filmyDnia = dataProcessing.WybierzFilmyPokazywaneDanegoDnia(SkladDanych.Seanse, Date);
            //Console.WriteLine(dataProcessing.NajpopularniejszyGatunek(SkladDanych.Filmy));
            //Console.WriteLine(dataProcessing.PodajCalkowiteWplywyZBiletow(SkladDanych.Bilety));
            //List<string> wynik = dataProcessing.WybierzFilmyZGatunku(SkladDanych.Filmy, "Fantasy");
            foreach (var item in sale)
            {
                Console.WriteLine(item.Nazwa);
            }

            //Console.WriteLine(metodyPomocnicze.CalkowitePrzychodyZBiletow(SkladDanych.Bilety));

            WyswietlPodgladSali(Dane.SkladDanych.Bilety, Dane.SkladDanych.Seanse[0]);
            Console.ReadKey();
            /* Przykładowo:
            ----------
            ----------
            ----------
            ----------
            ----ooo---
            ----ooo---
            -----oo---
            ----------
            */
        }
    }
}

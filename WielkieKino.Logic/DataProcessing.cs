using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WielkieKino.Lib;

namespace WielkieKino.Logic
{
    /// <summary>
    /// Metody do napisania z wykorzystaniem LINQ (w składni zapytania, wyrażeń
    /// lambda lub mieszanej)
    /// </summary>
    public class DataProcessing
    {
        public List<string> WybierzFilmyZGatunku(List<Film> filmy, string gatunek)
        {
            // Właściwa odpowiedź: np. "Konan Destylator" dla "Fantasy"
            List<string> wynik;
            wynik = (from Film film in filmy
                     where film.Gatunek == gatunek
                     select film.Tytul
                     ).ToList();
            return wynik;
        }

        /// <summary>
        /// Sumujemy wpływy bez względu na datę seansu
        /// </summary>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public int PodajCalkowiteWplywyZBiletow(List<Bilet> bilety)
        {
            double total = bilety.Sum(bilet => bilet.Cena);
            // Właściwa odpowiedź: 400
            return (int)total;
        }

        public List<Film> WybierzFilmyPokazywaneDanegoDnia(List<Seans> seanse, DateTime data)
        {
            List<Film> wynik;
            wynik = (from Seans seans in seanse
                     where seans.Date.Day == data.Day
                     select seans.Film
                     ).ToList();
            return wynik;
        }

        /// <summary>
        /// Zwraca gatunek, z którego jest najwięcej filmów. Jeśli jest kilka takich
        /// gatunków, to zwraca dowolny z nich.
        /// </summary>
        /// <param name="filmy"></param>
        /// <returns></returns>
        public string NajpopularniejszyGatunek(List<Film> filmy)
        {
            var wynik = (from Film film in filmy
                         group film by film.Gatunek into gr
                        orderby gr.Count() descending
                        select gr.Key).First();

            return wynik;

            // Właściwa odpowiedź: Obyczajowy

        }

        public List<Sala> ZwrocSalePosortowanePoCalkowitejLiczbieMiejsc(List<Sala> sale)
        {
            List<Sala> posortowaneSale = sale.OrderBy(x => x.LiczbaMiejscWRzedzie*x.LiczbaRzedow).ToList();
            // Właściwa odpowiedź: Kameralna, Bałtyk, Wisła (lub w odwrotnej kolejności)
            return posortowaneSale;
        }

        public Sala ZwrocSaleGdzieJestNajwiecejSeansow(List<Seans> seanse, DateTime data)
        {
            List<Seans> seanseDlaDaty;
            seanseDlaDaty = (from Seans seans in seanse
                     where seans.Date.Day == data.Day
                     select seans
                     ).ToList();

            var wynik = (from Seans seans in seanseDlaDaty
                         group seans by seans.Sala into gr
                         orderby gr.Count() descending
                         select gr.Key).First();

            return wynik;

           

            // Właściwa odpowiedź dla daty 2019-01-20: sala "Wisła" 
            
        }

        /// <summary>
        /// Uwaga: Nie wszystkie parametry przekazane do metody muszą być użyte przy
        /// implementacji. Jeśli jest kilka takich filmów, zwracamy dowolny.
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public Film ZwrocFilmNaKtorySprzedanoNajwiecejBiletow(List<Film> filmy, List<Bilet> bilety)
        {
            var wynik = (from Bilet bilet in bilety
                         group bilet by bilet.Seans into gr
                         orderby gr.Count() descending
                         select gr.Key).First();

            // Właściwa odpowiedź: "Konan Destylator"
            return wynik.Film;
        }

        /// <summary>
        /// Uwaga: Nie wszystkie parametry metody muszą być wykorzystane przy
        /// implementacji. Filmy z takim samym przychodem zwracamy w dowolnej kolejności
        /// </summary>
        /// <param name="filmy"></param>
        /// <param name="bilety"></param>
        /// <returns></returns>
        public Film PosortujFilmyPoDochodach(List<Film> filmy, List<Bilet> bilety)
        {

            return null;
        }


    }
}

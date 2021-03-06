﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Enums
    {
        public enum MealType :short
        {
            Sniadanie = 0,
            Obiad = 1,
            Kolacja = 2,
            Wszystkie = 9
        }

        public enum GenderType :short
        {
            Kobieta = 0,
            Mezczyzna = 1
        }

        public enum DaysToAnalize :short
        {
            Dzien = 1,
            Tydzien = 7,
            Miesiac = 30
        }

        public enum SubstancesType :short
        {
            Kalorie = 0,
            Bialka = 1,
            Tluszcze = 2,
            Weglowodany = 3
        }
    }
}

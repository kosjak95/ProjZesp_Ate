using System;
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
            Kolacja = 2
        }

        public enum GenderType :short
        {
            Kobieta = 0,
            Mezczyzna = 1
        }
    }
}

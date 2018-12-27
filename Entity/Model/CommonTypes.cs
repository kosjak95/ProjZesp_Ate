using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class DishData
    {
        public string UserLogin;
        public string Name;
        public string Mass;
        public List<Component> ComponentsList;
    }

    public class MealData
    {
        public string UserLogin;
        public long Weigth;
        public short MealType;
        public List<Dish> DishesList;
    }

    public class UserInfo
    {
        public string UserLogin;
        public int Age;
        public int Growth;
        public int Weight;
        public short Gender;
    }

    public class Statistics
    {
        public List<DayFood> DayFoods { get; set; }
        public MealNutritionalValues PropperDayValues { get; set; }
        public double BMI { get; set; }

        public Statistics()
        {
            DayFoods = new List<DayFood>();
            PropperDayValues = new MealNutritionalValues();
        }

    }

    public class DayFood
    {
        public DayFood()
        {
            MealNutritionalVal = new List<MealNutritionalValues>();
        }
        public List<MealNutritionalValues> MealNutritionalVal { get; set; }
    }

    public class MealNutritionalValues
    {
        public Enums.MealType MealType { get; set; }
        public double Fats { get; set; }
        public double Proteins { get; set; }
        public double Carbohydrates { get; set; }
        public double Calories { get; set; }
    }
}

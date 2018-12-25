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
}

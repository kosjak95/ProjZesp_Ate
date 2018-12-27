using Entity.Model;
using ProjZesp_Ate.Controllers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TechnikiInternetowe.Communication
{
    public class ExternalAdapterController : Controller
    {
        public ExternalAdapterController() { }

        [HttpPost]
        [Route("TryCreateUserAccount")]
        public async Task<bool> CreateNewUserAccount(User data)
        {
            return await Task.Run(() => HomeController.TryCreateUserAccount(data));
        }

        [HttpPost]
        [Route("LogIn")]
        public async Task<bool> Login(User data)
        {
            return await Task.Run(() => HomeController.TryLogIn(data));
        }

        [HttpPost]
        [Route("TryCreateComponent")]
        public async Task<bool> CreateComponent(Component component)
        {
            return await Task.Run(() => HomeController.TryCreateComponent(component));
        }

        [HttpPost]
        [Route("TryCreateDish")]
        public async Task<bool> CreateDish(string UserLogin, string Name, List<Component> ComponentsList)
        {
            return await Task.Run(() => HomeController.TryCreateDish(UserLogin, Name, ComponentsList));
        }

        [HttpPost]
        [Route("EatMeal")]
        //TODO: Weight is to remove, we have it at dish, now I will send one
        public async Task<bool> AddMeal(string UserLogin, long Weigth, short MealType, List<Dish> DishesList)
        {
            return await Task.Run(() => HomeController.AddMeal(UserLogin, Weigth, (Enums.MealType)MealType, DishesList));
        }

        [HttpPost]
        [Route("UpdateUserInfo")]
        public async Task<bool> UpdateUserInfo(string UserLogin, int Age, int Growth, int Weight, short Gender)
        {
            return await Task.Run(() => HomeController.UpdateUserInfo(UserLogin, Age, Growth, Weight, Gender));
        }

        [HttpGet]
        [Route("GetComponentsList")]
        public async Task<string> GetComponentsList()
        {
            return await Task.Run(() => HomeController.GetComponentsList());
        }

        //TODO: Function to get Dishes to add it to meal + create virtual dishes from existing components with connection to component....? 
        [HttpGet]
        [Route("GetDishesList/{UserLogin}")]
        public async Task<string> GetDishesList(string UserLogin)
        {
            return await Task.Run(() => HomeController.GetDishesList(UserLogin));
        }

        [HttpGet]
        [Route("GetStatistics/{UserLogin}/{DaysNum}/{KindOfMeal}")]
        public async Task<string> GetStatistics(string UserLogin, int DaysNum, Enums.MealType KindOfMeal)
        {
            return await Task.Run(() => HomeController.GetStatistics(UserLogin, DaysNum, KindOfMeal));
        }
    }
}
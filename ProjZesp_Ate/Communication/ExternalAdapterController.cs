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
        public async Task<bool> CreateDish(int UserId, string Name, List<Component> ComponentsList)
        {
            return await Task.Run(() => HomeController.TryCreateDish(UserId, Name, ComponentsList));
        }

        [HttpPost]
        [Route("EatMeal")]
        public async Task<bool> AddMeal(int FKUserId, long Weigth, short MealType, List<Dish> DishesList)
        {
            return await Task.Run(() => HomeController.AddMeal(FKUserId, Weigth, (Enums.MealType)MealType, DishesList));

        }

        [HttpGet]
        [Route("GetComponentsList")]
        public async Task<string> GetComponentsList()
        {
            return await Task.Run(() => HomeController.GetComponentsList());
        }
    }
}

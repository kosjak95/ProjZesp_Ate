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
        [Route("AddMyMeal")]
        public async Task<bool> AddMyMeal(List<NewMeal> list)
        {
            return await Task.Run(() => HomeController.InsertMeal(list));
        }

        [HttpPost]
        [Route("TryCreateComponent")]
        public async Task<bool> CreateComponent(Component component)
        {
            return await Task.Run(() => HomeController.TryCreateComponent(component));
        }

        [HttpPost]
        [Route("TryCreateDish")]
        public async Task<bool> CreateDish(DishData dishData)
        {
            return await Task.Run(() => HomeController.TryCreateDish(dishData));
        }

        [HttpGet]
        [Route("GetComponentsList")]
        public async Task<string> GetComponentsList()
        {
            return await Task.Run(() => HomeController.GetComponentsList());
        }
    }
}

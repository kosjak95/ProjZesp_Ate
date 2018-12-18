using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ProjZesp_Ate.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Server is running...";
        }

        internal static bool TryCreateUserAccount(User userAccountCreateData)
        {
            AteDatabase entity = new AteDatabase();
            //TODO: any validate
            try
            {
                entity.Users.Add(userAccountCreateData);
                entity.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        internal static bool TryLogIn(User data)
        {
            AteDatabase entity = new AteDatabase();
            User user = null;
            try
            {
                user = entity.Users.Where(w => (w.Login == data.Login || w.Email == data.Login) && w.Password == data.Password).Single();
            }
            catch(Exception e)
            {
                return false;
            }
            return true;
        }

        internal static bool InsertMeal(List<NewMeal> list)
        {
            throw new NotImplementedException();
        }
    }
}
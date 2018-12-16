using Entity.Model;
using System;
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
    }
}
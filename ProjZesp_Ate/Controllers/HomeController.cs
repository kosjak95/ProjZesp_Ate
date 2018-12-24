using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ProjZesp_Ate.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Server is running...";
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private static bool ValidateUserData(User userData)
        {
            if (userData.Password == null ||
               userData.Name == null ||
               userData.Surname == null ||
               userData.Login == null ||
               userData.Email == null ||
               userData.Adress == null)
            {
                return false;
            }

            if (userData.Password.Length < 8 ||
               userData.Name.Equals(string.Empty) ||
               userData.Surname.Equals(string.Empty) ||
               userData.Login.Length < 2 ||
               userData.Email.Equals(string.Empty) ||
               userData.Adress.Equals(string.Empty))
            {
                return false;
            }

            if (!IsValidEmail(userData.Email))
            {
                return false;
            }

            AteDatabase entity = new AteDatabase();
            try
            {
                long count = entity.Users.Where(w => w.Login == userData.Login ||
                                                     w.Email == userData.Email).LongCount();

                if (count > 0)
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        internal static bool TryCreateDish(int UserId, string Name, string Mass, List<Component> ComponentsList)
        {
            //DONE: insert to db
            if (Name.Equals("") || Mass.Equals("") || ComponentsList.Count == 0)
                return false;

            AteDatabase entity = new AteDatabase();
            try
            {
                Dish dish = new Dish()
                {
                    FKUserId = UserId,
                    Weigth = Convert.ToInt32(Mass),
                    Name = Name,
                };
                foreach(Component com in ComponentsList)
                {
                    dish.Connectors.Add(new Connector()
                    {
                        Component = com,
                        ComponentWeigth = com.TempWeigth.GetValueOrDefault(),
                    });
                }

                entity.Dishes.Add(dish);
                entity.SaveChanges();

                
            }
            catch(Exception e)
            {
                Console.Write("TryCreateDish Error");
                return false;
            }
            return true;
        }

        internal static string GetComponentsList()
        {
            List<Component> componentsNamesList = new List<Component>();

            AteDatabase entity = new AteDatabase();
            try
            {
                var dane = entity.Components.Select(s => new { s.Name, s.ComponentId, s.CaloriesIn100g, s.Manufacturer, s.Connectors });
                componentsNamesList = new JavaScriptSerializer().Deserialize<List<Component>>(
                                         new JavaScriptSerializer().Serialize(dane));
                return new JavaScriptSerializer().Serialize(componentsNamesList);

            }
            catch (Exception e)
            {
                return new JavaScriptSerializer().Serialize(componentsNamesList);
            }
        }

        internal static bool TryCreateUserAccount(User userAccountCreateData)
        {
            AteDatabase entity = new AteDatabase();
            if(!ValidateUserData(userAccountCreateData))
            {
                return false;
            }
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

        internal static bool TryCreateComponent(Component component)
        {
            AteDatabase entity = new AteDatabase();
            if(!ValidateComponentData(component))
            {
                return false;
            }
            try
            {
                entity.Components.Add(component);
                entity.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private static bool ValidateComponentData(Component component)
        {
            if (component.Manufacturer == null ||
                component.Name== null)
            {
                return false;
            }

            if (component.Manufacturer.Equals(string.Empty) ||
                component.Name.Equals(string.Empty)         ||
                component.CaloriesIn100g <= 0)
            {
                return false;
            }
            AteDatabase entity = new AteDatabase();
            try
            {
                long count = entity.Components.Where(w => w.Name == component.Name &&
                                                     w.Manufacturer == component.Manufacturer).LongCount();

                if (count > 0)
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

    }
}
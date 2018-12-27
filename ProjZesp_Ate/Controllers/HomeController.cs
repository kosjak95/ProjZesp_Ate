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
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        internal static bool UpdateUserInfo(string userLogin, int age, int growth, int weight, short gender)
        {
            if (userLogin == null || userLogin.Length.Equals(0))
            {
                return false;
            }
            if (age <= 0 || age > 120 || growth <= 0 || growth > 300 || weight <= 0)
            {
                return false;
            }

            AteDatabase entity = new AteDatabase();
            try
            {
                User user = entity.Users.Single(s => s.Login == userLogin);
                user.Age = age;
                user.Growth = growth;
                user.Weight = weight;
                user.Gender = gender;
                entity.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Fuction create statistics object of <see cref="MealNutritionalValues">MealNutritionalValues</see> eaten in given time peroid
        /// </summary>
        /// <param name="userLogin"></param>
        /// <param name="daysNum"></param>
        /// <param name="kindOfMeal"></param>
        /// <returns></returns>
        internal static string GetStatistics(string userLogin, int daysNum, Enums.MealType kindOfMeal)
        {
            if (daysNum == 0)
            {
                return String.Empty;
            }

            int userId;
            try
            {
                userId = GetUserByUserName(userLogin);
            }
            catch (ArgumentException e)
            {
                Console.Write("Missing user name" + e);
                return String.Empty;
            }
            catch (Exception e)
            {
                Console.Write("User not exist" + e);
                return String.Empty;
            }

            AteDatabase entity = new AteDatabase();
            Statistics statistics = new Statistics();
            User user = null;
            try
            {
                user = entity.Users.Single(s => s.UserId == userId);
                if (user.Weight.HasValue && user.Growth.HasValue)
                {
                    double userGrowth = user.Growth.Value / 100.0;
                    statistics.BMI = 1.0 * user.Weight.Value / (userGrowth * userGrowth);
                }
            }
            catch(Exception e)
            {
                Console.Write("Error in getting user" + e);
            }

            try
            {
                ///DONE: <see cref="Statistics.PropperDayValues"></see> have to bo read from db and set!!!
                StatisticData statData = entity.StatisticDatas.Where(w => w.WeightFrom < user.Weight && w.WeigthTo > user.Weight && w.Gender == user.Gender).Single();
                statistics.PropperDayValues = new MealNutritionalValues()
                {
                    Calories = statData.DayKcal,
                    Proteins = statData.DayProtein,
                    Carbohydrates = statData.DayCarnohydrates,
                    Fats = statData.DayFats,
                    MealType = Enums.MealType.Wszystkie
                };

            }
            catch(Exception e)
            {
                Console.Write("Statistics Propper Day Values not found" + e);
            }
            try
            {

                List<Meal> meals;

                DateTime statisticTime = DateTime.Now.AddDays(-1 * daysNum);
                if (kindOfMeal == Enums.MealType.Wszystkie)
                {
                    meals = entity.Meals.Where(w => w.FKUserId == userId && w.MealDate > statisticTime).ToList();
                }
                else
                {
                    meals = entity.Meals.Where(w => w.FKUserId == userId && w.MealDate > statisticTime && w.MealType == (short)kindOfMeal).ToList();
                }

                for (int i = daysNum; i >= 0; i--)
                {
                    DateTime statisticDate = DateTime.Now.AddDays(-1 * i).Date;
                    List<Meal> tempDayMeals = meals.Where(w => w.MealDate == statisticDate).ToList();
                    foreach (Meal m in tempDayMeals)
                    {
                        statistics.DayFoods.Add(new DayFood());
                        double fats = 0, kcal = 0, prot = 0, carb = 0;
                        foreach (Connector con in m.Connectors)
                        {
                            kcal += con.ComponentWeigth.GetValueOrDefault() / 100.0 * con.Component.CaloriesIn100g;
                            fats += con.ComponentWeigth.GetValueOrDefault() / 100.0 * con.Component.FatsIn100g;
                            prot += con.ComponentWeigth.GetValueOrDefault() / 100.0 * con.Component.ProteinIn100g;
                            carb += con.ComponentWeigth.GetValueOrDefault() / 100.0 * con.Component.CarbohydratesIn100g;
                        }

                        statistics.DayFoods.Last().MealNutritionalVal.Add(new MealNutritionalValues()
                        {
                            MealType = (Enums.MealType)m.MealType,
                            Calories = kcal,
                            Carbohydrates = carb,
                            Proteins = prot,
                            Fats = fats
                        });
                    }
                }
                return new JavaScriptSerializer().Serialize(statistics);
            }
            catch (Exception e)
            {

            }
            return String.Empty;
        }

        /// <summary>
        /// Function create meal from given dishes
        /// in case of eating single component it is needed to create virtual dish connected by Conncetor list in dish with component, but without adding it to Context
        /// Dishes should be given without connectors but when they are virtual it should ahve Connector list
        /// not tested cause UI not prepared YET
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="weigth"></param>
        /// <param name="mealType"></param>
        /// <param name="dishesList"></param>
        /// <returns></returns>
        internal static bool AddMeal(string userLogin, long weigth, Enums.MealType mealType, List<Dish> dishesList)
        {
            int userId;
            try
            {
                userId = GetUserByUserName(userLogin);
            }
            catch (ArgumentException e)
            {
                Console.Write("Missing user name" + e);
                return false;
            }
            catch (Exception e)
            {
                Console.Write("User not exist" + e);
                return false;
            }

            if (userId == 0 || weigth == 0 || dishesList.Count == 0)
            {
                return false;
            }

            AteDatabase entity = new AteDatabase();
            try
            {
                Meal meal = new Meal()
                {
                    FKUserId = userId,
                    Weigth = weigth,
                    MealType = (short)mealType,
                    MealDate = DateTime.Now
                };
                List<Dish> tempDish = new List<Dish>();
                foreach (Dish dish in dishesList)
                {
                    if (dish.Connectors.Count == 0)
                    {
                        tempDish.Add(entity.Dishes.Where(w => w.DishId == dish.DishId).Single());
                    }
                    else
                    {
                        tempDish.Add(dish);
                    }
                }
                foreach (var dish in tempDish)
                {
                    foreach (Connector con in dish.Connectors)
                    {
                        meal.Connectors.Add(new Connector()
                        {
                            FK_ComponentId = con.FK_ComponentId,
                            ComponentWeigth = con.ComponentWeigth
                        });
                    }
                }
                entity.Meals.Add(meal);
                entity.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write("AddMeal error" + e);
                return false;
            }

            return true;
        }

        internal static bool TryCreateDish(string userLogin, string Name, List<Component> ComponentsList)
        {
            int userId;
            try
            {
                userId = GetUserByUserName(userLogin);
            }
            catch (ArgumentException e)
            {
                Console.Write("Missing user name" + e);
                return false;
            }
            catch (Exception e)
            {
                Console.Write("User not exist" + e);
                return false;
            }

            if (userId == 0 || Name.Equals("") || ComponentsList.Count == 0)
            {
                return false;
            }

            int TotalDishMass = 0;
            foreach (Component compo in ComponentsList)
            {
                TotalDishMass += (int)compo.TempWeigth;
            }

            AteDatabase entity = new AteDatabase();
            try
            {
                Dish dish = new Dish()
                {
                    FKUserId = userId,
                    Weigth = TotalDishMass,
                    Name = Name
                };
                foreach (Component com in ComponentsList)
                {
                    dish.Connectors.Add(new Connector()
                    {
                        FK_ComponentId = com.ComponentId,
                        ComponentWeigth = com.TempWeigth.GetValueOrDefault(),
                    });
                }

                entity.Dishes.Add(dish);
                entity.SaveChanges();
            }
            catch (Exception)
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
            entity.Configuration.LazyLoadingEnabled = false;
            try
            {
                List<Component> dane = entity.Components.ToList();
                return new JavaScriptSerializer().Serialize(dane);

            }
            catch (Exception)
            {
                return new JavaScriptSerializer().Serialize(componentsNamesList);
            }
        }

        internal static bool TryCreateUserAccount(User userAccountCreateData)
        {
            AteDatabase entity = new AteDatabase();
            if (!ValidateUserData(userAccountCreateData))
            {
                return false;
            }
            try
            {
                entity.Users.Add(userAccountCreateData);
                entity.SaveChanges();
                return true;
            }
            catch (Exception)
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
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        internal static bool TryCreateComponent(Component component)
        {
            AteDatabase entity = new AteDatabase();
            if (!ValidateComponentData(component))
            {
                return false;
            }
            try
            {
                entity.Components.Add(component);
                entity.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Function gets all dishes for user
        /// To this dishes are added all components in DB converted to dish type
        /// Dishes dont have connectors
        /// Components ( virtual dishes ) have connector ( virtual ) pointing on real component in DB
        /// virtual mean not existing in db 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        internal static string GetDishesList(string userLogin)
        {
            int userId;

            try
            {
                userId = GetUserByUserName(userLogin);
            }
            catch (ArgumentException e)
            {
                Console.Write("Missing user name" + e);
                return String.Empty;
            }
            catch (Exception e)
            {
                Console.Write("User not exist" + e);
                return String.Empty;
            }
            //Get all User Dishes
            List<Dish> dishes = new List<Dish>();
            AteDatabase entity = new AteDatabase();
            entity.Configuration.LazyLoadingEnabled = false;
            try
            {
                dishes = entity.Dishes.Where(w => w.FKUserId == userId).ToList();
            }
            catch (Exception e)
            {
                Console.Write("User dont have any dishes" + e);
            }

            //convert components into dishes
            try
            {
                List<Component> components = entity.Components.ToList();
                foreach (Component com in components)
                {
                    dishes.Add(new Dish()
                    {
                        Name = com.Name,
                        Connectors = new HashSet<Connector>()

                    });
                    dishes.Last().Connectors.Add(new Connector()
                    {
                        FK_ComponentId = com.ComponentId
                    });
                }

                return new JavaScriptSerializer().Serialize(dishes);
            }
            catch (Exception e)
            {
                Console.Write("Convert component to dish FAILED" + e);
            }

            return String.Empty;
        }

        #region private_func

        private static int GetUserByUserName(string userLogin)
        {
            if (userLogin == null || userLogin.Length.Equals(0))
            {
                throw new ArgumentException();
            }
            int userId = 0;
            AteDatabase entity = new AteDatabase();
            try
            {
                userId = entity.Users.Single(s => s.Login == userLogin).UserId;
            }
            catch (Exception)
            {
                throw new Exception();
            }

            return userId;
        }

        private static bool ValidateComponentData(Component component)
        {
            if (component.Manufacturer == null ||
                component.Name == null)
            {
                return false;
            }

            if (component.Manufacturer.Equals(string.Empty) ||
                component.Name.Equals(string.Empty) ||
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
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TechnikiInterentoweClient;
using static Entity.Model.Enums;

namespace WpfProjZespClient.AppWindows
{
    /// <summary>
    /// Interaction logic for AddMealWindow.xaml
    /// </summary>
    public partial class AddMealWindow : Window
    {
        private List<Dish> addedDishes;
        private List<Dish> dishes;

        public AddMealWindow()
        {
            addedDishes = new List<Dish>();
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window mainWindow = new MainAppWindow();
            App.Current.MainWindow = mainWindow;
            mainWindow.Show();
            this.Close();
        }

        private void DishesComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            string result = RestClient.Instance.MakeGetRequest("GetDishesList/"+RestClient.Instance.LoggedUserLogin);
            dishes = new JavaScriptSerializer().Deserialize<List<Dish>>(result);
            List<string> dishesNames = new List<string>();
            foreach(Dish dish in dishes)
            {
                dishesNames.Add(dish.Name);
            }
            var combo = sender as ComboBox;
            combo.ItemsSource = dishesNames;
            combo.SelectedIndex = 0;
        }

        private void DishTypeComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = Enum.GetValues(typeof(MealType));
            combo.SelectedIndex = 0;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Button newButton = new Button();
            newButton.Content = dishesComboBox.SelectedItem as string;
            newButton.Width = 130;
            newButton.FontSize = 10;
            newButton.Margin = new Thickness(5, 3, 0, 0);
            newButton.MouseRightButtonUp  += RemoveButton_Click;
            SelectedDishesPanel.Children.Add(newButton);

            int selectedIndex = dishesComboBox.SelectedIndex;
            Dish dish = dishes.ElementAt(selectedIndex);
            if(dish.Connectors.Any())
                dish.Connectors.Last().ComponentWeigth = double.Parse(massTextBox.Text);
            addedDishes.Add(dish);
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int buttonIndex = SelectedDishesPanel.Children.IndexOf(button);
            addedDishes.RemoveAt(buttonIndex);
            SelectedDishesPanel.Children.RemoveAt(buttonIndex);
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            short type = (short)mealTypeComboBox.SelectedIndex;
            bool result = RestClient.Instance.MakePostRequest("EatMeal", new MealData()
            {
                UserLogin = RestClient.Instance.LoggedUserLogin,
                Weigth = 1,
                MealType = type,
                DishesList = addedDishes
            });
            string userResponse = result ? "Udało się dodać posiłek" : "Nie możemy dodać posiłku";

            if (result)
            {
                Window mainWindow = new MainAppWindow();
                App.Current.MainWindow = mainWindow;
                mainWindow.Show();
                this.Close();
            }

            MessageBox.Show(userResponse,
                            "Dodawanie posiłku",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        private void DishesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            Dish dish = dishes.Where(w => w.Name == cb.SelectedItem.ToString()).First();
            if(dish.Connectors.Count != 0)
            {
                massTextBox.Visibility = Visibility.Visible;
            }
            else
            {
                massTextBox.Visibility = Visibility.Hidden;
            }
        }
    }
}
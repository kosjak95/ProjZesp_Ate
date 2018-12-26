using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for MainAppWindow.xaml
    /// </summary>
    public partial class MainAppWindow : Window
    {
        public MainAppWindow()
        { 
            InitializeComponent();
        }

        private void changeMenuVisibility()
        {
            if (MenuPanel.Visibility.Equals(Visibility.Visible))
            {
                MenuPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                MenuPanel.Visibility = Visibility.Visible;
            }
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            changeMenuVisibility();
        }

        private void AddComponentButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AddComponentWindow();
            App.Current.MainWindow = window;
            window.Show();
            this.Close();
        }

        private void AddDishButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AddDishWindow();
            App.Current.MainWindow = window;
            window.Show();
            this.Close();
        }

        private void AddMealButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new AddMealWindow();
            App.Current.MainWindow = window;
            window.Show();
            this.Close();
        }

        private void UpdateUserInfoButton_Click(object sender, RoutedEventArgs e)
        {
            Window loginWindow = new UserInfoWindow();
            App.Current.MainWindow = loginWindow;
            loginWindow.Show();
            this.Close();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            RestClient.Instance.LoggedUserLogin = null;
            Window loginWindow = new LoginWindow();
            App.Current.MainWindow = loginWindow;
            loginWindow.Show();
            this.Close();
        }

        private void DaysComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = Enum.GetValues(typeof(DaysToAnalize));
            combo.SelectedIndex = 0;
        }

        private void MealTypeComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = Enum.GetValues(typeof(MealType));
            combo.SelectedIndex = 0;
        }
    }
}

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
    /// Interaction logic for MainAppWindow.xaml
    /// </summary>
    public partial class MainAppWindow : Window
    {
        private OxyPlotModel oxyPlotModel;

        public MainAppWindow()
        {
            oxyPlotModel = new OxyPlotModel();
            this.DataContext = oxyPlotModel;
            InitializeComponent();
        }

        public void LoadStatistic()
        {
            if (daysComboBox.SelectedItem == null ||
                mealTypeComboBox.SelectedItem == null ||
                SubstanceTypeComboBox.SelectedItem == null ||
                daysComboBox.SelectedItem.ToString().Equals("") || 
                mealTypeComboBox.SelectedItem.ToString().Equals("") ||
                SubstanceTypeComboBox.SelectedItem.ToString().Equals(""))
            {
                return;
            }
            string result = RestClient.Instance.MakeGetRequest("GetStatistics/" + RestClient.Instance.LoggedUserLogin + "/" +
                                                           (short)Enum.Parse(typeof(DaysToAnalize), daysComboBox.SelectedItem.ToString()) + "/" +
                                                           Enum.Parse(typeof(MealType), mealTypeComboBox.SelectedItem.ToString()));

            Statistics statistics = new JavaScriptSerializer().Deserialize<Statistics>(result);
            BMItextBox.SelectedText = statistics.BMI.ToString();
            oxyPlotModel.Draw(statistics, (SubstancesType)SubstanceTypeComboBox.SelectedIndex);
            plot1.Model = oxyPlotModel.PlotModel;
        }

        private void ChangeMenuVisibility()
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
            ChangeMenuVisibility();
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

        private void DaysComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadStatistic();
        }

        private void MealTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadStatistic();
        }

        private void SubstanceTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadStatistic();
        }

        private void SubstanceTypeComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = Enum.GetValues(typeof(SubstancesType));
            combo.SelectedIndex = 0;
        }
    }
}

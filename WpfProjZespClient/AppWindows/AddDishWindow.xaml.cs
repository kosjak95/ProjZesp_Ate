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

namespace WpfProjZespClient.AppWindows
{
    /// <summary>
    /// Interaction logic for AddDishWindow.xaml
    /// </summary>
    public partial class AddDishWindow : Window
    {
        private List<Component> componentsList;
        private List<Component> selectedComponentsList;

        public AddDishWindow()
        {
            selectedComponentsList = new List<Component>();
            LoadComponentsFromDb();
            InitializeComponent();
        }

        private void LoadComponentsFromDb()
        {
            RestClient.Instance.EndPoint = "http://localhost:4200/GetComponentsList";
            RestClient.Instance.HttpMethod = HttpVerb.GET;
            string codedComponentsList = RestClient.Instance.MakeRequest();
            componentsList = new JavaScriptSerializer().Deserialize<List<Component>>(codedComponentsList);
        }

        private void ComponentComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            List<string> listToComboFill = new List<string>();
            foreach(Component compo in componentsList)
            {
                listToComboFill.Add(compo.Name + "(" + compo.Manufacturer + ")[" + compo.CaloriesIn100g + "kcal/100g]");
            }
            combo.ItemsSource = listToComboFill;
            combo.SelectedIndex = 0;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Button newButton = new Button();
            newButton.Content = componentComboBox.SelectedItem as string;
            newButton.Width = 130;
            newButton.FontSize = 10;
            newButton.Margin = new Thickness(5, 3, 0, 0);
            newButton.MouseRightButtonUp += RemoveButton_Click;
            SelectedComponentsPanel.Children.Add(newButton);

            int selectedIndex = componentComboBox.SelectedIndex;
            selectedComponentsList.Add(componentsList.ElementAt(selectedIndex));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int buttonIndex = SelectedComponentsPanel.Children.IndexOf(button);
            selectedComponentsList.RemoveAt(buttonIndex);
            SelectedComponentsPanel.Children.RemoveAt(buttonIndex);
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = RestClient.Instance.MakePostRequest("TryCreateDish", new DishData()
            {
                Name = nameTextBox.Text,
                Mass = MassTextBox.Text,
                ComponentsList = selectedComponentsList
            });
            string userResponse = result ? "Udało się dodać danie" : "Nie możemy dodać wskazanego dania";

            if (result)
            {
                Window mainWindow = new MainAppWindow();
                App.Current.MainWindow = mainWindow;
                mainWindow.Show();
                this.Close();
            }

            MessageBox.Show(userResponse,
                            "Dodawanie potrawy",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }
    }
}
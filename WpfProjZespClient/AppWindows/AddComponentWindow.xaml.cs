using Entity.Model;
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

namespace WpfProjZespClient.AppWindows
{
    /// <summary>
    /// Interaction logic for AddComponentWindow.xaml
    /// </summary>
    public partial class AddComponentWindow : Window
    {
        public AddComponentWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool result = RestClient.Instance.MakePostRequest("TryCreateComponent", new Component()
            {
                Name = nameTextBox.Text,
                Manufacturer = manufacturerTextBox.Text,
                CaloriesIn100g = Int32.Parse(CaloriesTextBox.Text),
                ProteinIn100g = Int32.Parse(ProteinsTextBox.Text),
                FatsIn100g = Int32.Parse(FatsTextBox.Text),
                CarbohydratesIn100g = Int32.Parse(CarbohydratesTextBox.Text)
            });
            string userResponse = result ? "Udało się dodać składnik" : "Nie możemy dodać wskazanego składnika";

            if (addOneMoreCheckBox.IsChecked.Equals(false))
            {
                Window mainWindow = new MainAppWindow();
                App.Current.MainWindow = mainWindow;
                mainWindow.Show();
                this.Close();
            }
            else
            {
                nameTextBox.Clear();
                manufacturerTextBox.Clear();
                CaloriesTextBox.Clear();
            }

            MessageBox.Show(userResponse,
                            "Dodawanie składnika",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        private void Button_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window mainWindow = new MainAppWindow();
            App.Current.MainWindow = mainWindow;
            mainWindow.Show();
            this.Close();
        }
    }
}

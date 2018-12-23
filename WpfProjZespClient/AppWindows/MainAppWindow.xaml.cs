using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            //TODO: kosu add to connector table one more field, with mass of component at meal
        }

        private void AddMealButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: handle
        }
    }
}

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
        private string selectComponent;

        public AddDishWindow()
        {
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

        private void ComponentComboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            selectComponent = combo.SelectedItem as string;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: adding to list at background and at window next component
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO: send dish to db
        }
    }
}

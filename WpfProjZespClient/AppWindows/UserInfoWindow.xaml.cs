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
using static Entity.Model.Enums;

namespace WpfProjZespClient.AppWindows
{
    /// <summary>
    /// Interaction logic for UserInfoWindow.xaml
    /// </summary>
    public partial class UserInfoWindow : Window
    {
        public UserInfoWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            short type = (short)genderComboBox.SelectedIndex;

            bool result = RestClient.Instance.MakePostRequest("UpdateUserInfo", new UserInfo()
            {
                UserLogin = RestClient.Instance.LoggedUserLogin,
                Age = Int32.Parse(ageTextBox.Text),
                Weight = Int32.Parse(weightTextBox.Text),
                Growth = Int32.Parse(growthTextBox.Text),
                Gender = type
            });
            string userResponse = result ? "Zapisano dane" : "Nie możemy zapisać danych";
            
            if (result)
            {
                RestClient.Instance.LoggedUserLogin = null;
                Window loginWindow = new LoginWindow();
                ((LoginWindow)loginWindow).SetVisibilitySuccLoginLabel(Visibility.Visible);
                App.Current.MainWindow = loginWindow;
                loginWindow.Show();
                this.Close();
            }

            MessageBox.Show(userResponse,
                            "Uzepełnianie danych użytkownika",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = Enum.GetValues(typeof(GenderType));
            combo.SelectedIndex = 0;
        }
    }
}

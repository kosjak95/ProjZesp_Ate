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
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void AccountCreateButton_onClick(object sender, RoutedEventArgs e)
        {
            bool result = RestClient.Instance.MakePostRequest("TryCreateUserAccount", new User()
            {
                Name = nameTextBox.Text,
                Surname = surnameTextBox.Text,
                Email = emailTextBox.Text,
                Adress = adressTextBox.Text,
                Login = loginTextBox.Text,
                Password = passwordTextBox.Password
            });
            if(result)
            {
                RestClient.Instance.LoggedUserLogin = loginTextBox.Text;
                Window window = new UserInfoWindow();
                ((UserInfoWindow)window).UpdateAfterRegister = true;
                App.Current.MainWindow = window;
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Podane dane nie pozwalają na utworzenie nowego konta",
                                "Register error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }
    }
}

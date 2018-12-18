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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TechnikiInterentoweClient;
using WpfProjZespClient.AppWindows;

namespace WpfProjZespClient
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        public void SetVisibilitySuccLoginLabel(System.Windows.Visibility status)
        {
            this.SuccAccountCreated.Visibility = status;
        }
        
        private void LoginButton_onClick(object sender, RoutedEventArgs e)
        {
            bool result = RestClient.Instance.MakePostRequest("LogIn", new User()
            {
                Login = loginTextBox.Text,
                Password = pswdTextBox.Password
            });
            if(!result)
            {
                loginTextBox.Clear();
                pswdTextBox.Clear();
                FailLogIn.Visibility = Visibility.Visible;
            }
        }

        private void RegisterButton_onClick(object sender, RoutedEventArgs e)
        {
            Window registerWindow = new RegisterWindow();
            App.Current.MainWindow = registerWindow;
            registerWindow.Show();
            this.Close();
        }
    }
}
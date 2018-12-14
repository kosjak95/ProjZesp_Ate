using CommonTypes;
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
        private RestClient rClient;

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void ConfigureBeforeRequest(string routeAndArgs)
        {
            if (rClient == null)
            {
                rClient = new RestClient();
            }
            rClient.EndPoint = "http://localhost:4200/" + routeAndArgs;
        }

        private bool MakePostRequest(string route, object inObject)
        {
            ConfigureBeforeRequest(route);
            rClient.HttpMethod = HttpVerb.POST;
            return rClient.MakePostRequest(inObject);
        }

        private void AccountCreateButton_onClick(object sender, RoutedEventArgs e)
        {
            MakePostRequest("TryCreateUserAccount/", new UserAccountCreateData()
            {
                Name = nameTextBox.Text,
                Surname = surnameTextBox.Text,
                Email = emailTextBox.Text,
                Adress = adressTextBox.Text,
                Login = loginTextBox.Text,
                Password = passwordTextBox.Password
            });
        }
    }
}

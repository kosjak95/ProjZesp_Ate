using System;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace ProjZespClient
{
    public partial class Form1 : Form
    {
        public static ResourceManager Dict = new ResourceManager("ProjZespClient.PL_lang", Assembly.GetExecutingAssembly());

        public Form1()
        {
            FullInitializeComponent();
        }

        private void LoginTextBox_MouseHover(object sender, EventArgs e)
        {
            this.infoToolTip.SetToolTip((TextBox)sender, Dict.GetString("insertUserName"));
        }

        private void Handle_GotFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (tb.Name.Equals(pswdTextBox.Name) && !tb.Text.Equals(Dict.GetString("password")))
            {
                return;
            }
            if (tb.Name.Equals(loginTextBox.Name) && !tb.Text.Equals(Dict.GetString("login")))
            {
                return;
            }
            tb.Text = string.Empty;
        }

        private void Handle_LostFocus(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if(tb.Text.Equals(string.Empty))
            {
                if(tb.Name.Equals(pswdTextBox.Name))
                {
                    tb.Text = Dict.GetString("password");
                }
                else if (tb.Name.Equals(loginTextBox.Name))
                {
                    tb.Text = Dict.GetString("login");
                }
            }
        }

        private void PswdTextBox_MouseHover(object sender, EventArgs e)
        {
            this.infoToolTip.SetToolTip((TextBox)sender, Dict.GetString("insertPswd"));
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //TODO: LOGIN LOGIC
        }

        private void CreateAcountButton_Click(object sender, EventArgs e)
        {
            RegisterPanel.BringToFront();
        }
    }
}
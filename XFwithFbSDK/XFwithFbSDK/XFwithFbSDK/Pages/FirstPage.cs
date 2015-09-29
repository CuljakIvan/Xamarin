using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFwithFbSDK.Interfaces;

namespace XFwithFbSDK.Pages
{
    public class FirstPage:ContentPage
    {
        public FirstPage()
        {
            var loginButton = new Button()
            {
                Text = "Login"
            };
            loginButton.Clicked += LoginButton_Clicked;

            var logoutButton = new Button()
            {
                Text = "Logout"
            };
            logoutButton.Clicked += LogoutButton_Clicked;

            Content = new StackLayout()
            {
                Children = {loginButton, logoutButton}
            };
        }

        private void LogoutButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IFbService>().Login();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IFbService>().LogOut();
        }
    }
}

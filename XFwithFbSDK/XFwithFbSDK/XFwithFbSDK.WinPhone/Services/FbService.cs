using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook.Client;
using XFwithFbSDK.Interfaces;
using XFwithFbSDK.WinPhone.Services;

[assembly: Xamarin.Forms.Dependency(typeof(FbService))]
namespace XFwithFbSDK.WinPhone.Services
{
    public class FbService : IFbService
    {
        private readonly string _readPermissions = "public_profile, email";

        public void Login()
        {
            Session.ActiveSession.LoginWithBehavior(_readPermissions,
                FacebookLoginBehavior.LoginBehaviorApplicationOnly);
        }

        public void LogOut()
        {
            Session.ActiveSession.Logout();
        }
    }
}

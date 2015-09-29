using System;
using System.Collections.Generic;
using System.Text;
using Facebook.CoreKit;
using Facebook.LoginKit;
using Foundation;
using XFwithFbSDK.iOS.Services;
using XFwithFbSDK.Interfaces;
using XFwithFbSDK.Models;

[assembly: Xamarin.Forms.Dependency(typeof(FbService))]
namespace XFwithFbSDK.iOS.Services
{
    public class FbService : IFbService
    {
        private readonly string[] _readPermissions = new[]
        {
            "public_profile", "email"
        };

        public void Login()
        {
            try
            {
                var loginManager = new LoginManager();
                loginManager.LogOut();
                loginManager.LogInWithReadPermissions(_readPermissions, LoginManagerRequestTokenHandler);
            }
            catch (Exception ex)
            {
                //Handle exception
            }
        }

        private void LoginManagerRequestTokenHandler(LoginManagerLoginResult result, NSError error)
        {
            if (error != null)
            {
                //Handle error
            }

            var request = new GraphRequest("/me", null, AccessToken.CurrentAccessToken.TokenString, null, "GET");
            var requestConnection = new GraphRequestConnection();
            requestConnection.AddRequest(request, GraphRequestHandler);
            requestConnection.Start();
        }

        private void GraphRequestHandler(GraphRequestConnection connection, NSObject requestResult, NSError requestError)
        {
            NSDictionary userInfo = (requestResult as NSDictionary);

            // Handle if something went wrong
            if (requestError != null || userInfo == null)
            {
                //Handle error
            }

            //Handle graph request result
            //For example:
            var fad = new FacebookAccountData();

            if (userInfo["id"] != null)
            {
                fad.SocialNetworkId = userInfo["id"].ToString();
            }
            if (userInfo["name"] != null)
            {
                fad.Name = userInfo["name"].ToString();
            }
            if (userInfo["first_name"] != null)
            {
                fad.FirstName = userInfo["first_name"].ToString();
            }
            if (userInfo["middle_name"] != null)
            {
                fad.MiddleName = userInfo["middle_name"].ToString();
            }
            if (userInfo["last_name"] != null)
            {
                fad.LastName = userInfo["last_name"].ToString();
            }
            if (userInfo["age_range"] != null)
            {
                fad.AgeRange = userInfo["age_range"].ToString();
            }
            if (userInfo["link"] != null)
            {
                fad.Link = userInfo["link"].ToString();
            }
            if (userInfo["gender"] != null)
            {
                fad.Gender = userInfo["gender"].ToString();
            }
            if (userInfo["locale"] != null)
            {
                fad.Locale = userInfo["locale"].ToString();
            }
            if (userInfo["timezone"] != null)
            {
                fad.Timezone = userInfo["timezone"].ToString();
            }
            if (userInfo["updated_time"] != null)
            {
                fad.UpdatedTime = userInfo["updated_time"].ToString();
            }
            if (userInfo["verified"] != null)
            {
                fad.Verified = userInfo["verified"].ToString();
            }
            if (userInfo["email"] != null)
            {
                fad.Email = userInfo["email"].ToString();
            }
        }

        public void LogOut()
        {
            try
            {
                var loginManager = new LoginManager();
                loginManager.LogOut();
            }
            catch (Exception ex)
            {
                //Handle exception
            }
        }
    }
}

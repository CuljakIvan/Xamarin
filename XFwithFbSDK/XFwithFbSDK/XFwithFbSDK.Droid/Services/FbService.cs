using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Xamarin.Forms;
using XFwithFbSDK.Droid;
using XFwithFbSDK.Droid.Services;
using XFwithFbSDK.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(FbService))]
namespace XFwithFbSDK.Droid.Services
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
                LoginManager.Instance.LogInWithReadPermissions((Activity)Forms.Context, _readPermissions);

                LoginManager.Instance.RegisterCallback(MainActivity.CallbackManager, new FacebookCallback<LoginResult>()
                {
                    HandleSuccess = loginResult =>
                    {
                        //Handle success
                        GraphRequest request = GraphRequest.NewMeRequest(loginResult.AccessToken, new GraphRequestCallback());
                        request.ExecuteAsync();
                    },
                    HandleCancel = () =>
                    {
                        //Handle cancel
                    },
                    HandleError = loginError =>
                    {
                        //Handle error
                    }
                });

            }
            catch (Exception ex)
            {
                //Handle exception
            }
        }

        public void LogOut()
        {
            try
            {
                LoginManager.Instance.LogOut();
            }
            catch (Exception ex)
            {
                //Handle exception
            }
        }
    }
}
using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Newtonsoft.Json;
using Org.Json;
using Xamarin.Facebook;
using XFwithFbSDK.Models;

namespace XFwithFbSDK.Droid
{
    [Activity(Label = "XFwithFbSDK", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        public static ICallbackManager CallbackManager;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            FacebookSdk.SdkInitialize(this.ApplicationContext);

            CallbackManager = CallbackManagerFactory.Create();

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            CallbackManager.OnActivityResult(requestCode, (int)resultCode, data);
        }
    }

    internal class GraphRequestCallback : Java.Lang.Object, GraphRequest.IGraphJSONObjectCallback
    {
        public void OnCompleted(JSONObject p0, GraphResponse p1)
        {
            if (p1.Error != null)
            {
                //Handle error
            }
            else
            {
                try
                {
                    //Handle graph request result
                    //For example:
                    var fad = JsonConvert.DeserializeObject<FacebookAccountData>(p0.ToString());
                }
                catch (Exception ex)
                {
                    //Handle exception
                }
            }
        }
    }

    class FacebookCallback<TResult> : Java.Lang.Object, IFacebookCallback where TResult : Java.Lang.Object
    {
        public Action HandleCancel { get; set; }
        public Action<FacebookException> HandleError { get; set; }
        public Action<TResult> HandleSuccess { get; set; }

        public void OnCancel()
        {
            var c = HandleCancel;
            if (c != null)
                c();
        }

        public void OnError(FacebookException error)
        {
            var c = HandleError;
            if (c != null)
                c(error);
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            var c = HandleSuccess;
            if (c != null)
                c(result.JavaCast<TResult>());
        }
    }
}


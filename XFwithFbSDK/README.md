This is an early alpha release that I've created in one hour as an example.
It shows how to use consume Facebook SDK from Xamarin.Forms.
I've only implemented Logout and Login with GraphRequest for "me" object.

When I catch some time I'll add some new features (like additional graph requests) and pack this up in a plugin.


Official SDK is used for Android and iOS and Outercurve Facebook SDK is used for Windows Phone.

There's some additional setup that you need to do to make this work.

Android:
You need to enter Facebook App Name and ID into Resources/Values/strings.xml

iOS:
You need to enter Facebook App Name and ID into existing string in AppDeleate.cs
You also need to enter Facebook App ID in Info.plist (there's a placeholder already in) - the string should be formated as fb+appId -> example fb123456789

Windows Phone:
You also need to enter Facebook App ID in WMAppManifest.xml (there's a placeholder already in) - the string should be formated as fb+appId -> example fb123456789


For additional info please read Facebook SDK documentation and Outercourve Facebook SDK documentation.

As of iOS9 you need to tell iOS that it's safe to connect to Facebook server, so I added some stuff into Info.plist as stated here:
https://developers.facebook.com/docs/ios/ios9


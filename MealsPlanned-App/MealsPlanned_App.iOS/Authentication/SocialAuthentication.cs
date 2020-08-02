using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using MealsPlanned_App.iOS.Authentication;
using MealsPlanned_App.Interfaces;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using MealsPlanned_App.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(SocialAuthentication))]
namespace MealsPlanned_App.iOS.Authentication
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
          MobileServiceAuthenticationProvider provider,
          IDictionary<string, string> parameters = null)
        {
            try
            {
                var current = GetController();

                var user = await client.LoginAsync(provider, null);
                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private UIKit.UIViewController GetController()
        {
            var window = UIKit.UIApplication.SharedApplication.KeyWindow;
            var root = window.RootViewController;

            var current = root;
            while (current.PresentViewController != null)
            {
                current = current.PresentViewController;
            }

            return current;
        }
    }
}
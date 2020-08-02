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
using MealsPlanned_App.Droid;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using MealsPlanned_App.Interfaces;
using MealsPlanned_App.Helpers;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(SocialAuthentication))]
namespace MealsPlanned_App.Droid
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
           MobileServiceAuthenticationProvider provider,
           IDictionary<string, string> parameters = null)
        {
            try
            {

                Newtonsoft.Json.Linq.JObject obs = Newtonsoft.Json.Linq.JObject.Parse("{access_token : 'c6b1576ee65bd3f31fed8dd04044de7b' }");
                var user = await client.LoginAsync(provider, obs);
                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
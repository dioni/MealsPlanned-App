﻿using MealsPlanned_App.Helpers;
using MealsPlanned_App.Interfaces;
using MealsPlanned_App.Services;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AzureService))]
namespace MealsPlanned_App.Services
{
    public class AzureService
    {
        static readonly string AppUrl = "https://mealsplanned-app.azurewebsites.net";

        public MobileServiceClient Client { get; set; } = null;
        public static bool UseAuth { get; set; } = false;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);

            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();

            
            

            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user!=null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () => {
                    await App.Current.MainPage.DisplayAlert("Ops!", "Não conseguimos efetuar o seu login, tente novamente!", "OK");
                });

                return false;
            }
            else
            {
                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;
            }

            return true;
        }
    }
}

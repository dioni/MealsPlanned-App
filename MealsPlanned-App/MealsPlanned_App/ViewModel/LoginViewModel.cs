using MealsPlanned_App.Helpers;
using MealsPlanned_App.Services;
using MealsPlanned_App.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MealsPlanned_App.ViewModel
{
    public class LoginViewModel
    {
        AzureService azureService;
        INavigation navigation;

        ICommand loginCommand;

        public string Title;
        public bool IsBusy;

        public ICommand LoginCommand =>
            loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync()));

        public LoginViewModel(INavigation nav)
        {
            azureService = DependencyService.Get<AzureService>();
            navigation = nav;

            Title = "Login";
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if (IsBusy || !(await LoginAsync()))
                return;
            else
            {
                var mainPage = new MainPage();
                await navigation.PushAsync(mainPage);

                RemovePageFromStack();
            }
        }

        private void RemovePageFromStack()
        {
            var existingPages = navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if (page.GetType() == typeof(LoginPage))
                    navigation.RemovePage(page);
            }
        }

        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn)
                Task.FromResult(true);

            return azureService.LoginAsync();
        }
    }
}

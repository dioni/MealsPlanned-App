using MealsPlanned_App.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MealsPlanned_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            var viewModel = new LoginViewModel(this.Navigation);

            BindingContext = viewModel;

            LoginButton.Command = viewModel.LoginCommand;
        }
    }
}